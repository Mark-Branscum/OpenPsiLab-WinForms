using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using OpenPsiLabWinForms.Controllers;
using OpenPsiLabWinForms.Interfaces;
using OpenPsiLabWinForms.Models;
using OpenPsiLabWinForms.Properties;
using OpenPsiLabWinForms.Views.Alerts;

namespace OpenPsiLabWinForms.DataSources
{
    public class SQLiteDatabase : ADatabase
    {
        public InsertUpdateType DBInsertUpdateType { get; set; }
        public enum InsertUpdateType
        {
            Insert,
            Update
        }
        public string DatabasePath
        {
            get
            {
                string slash = Path.DirectorySeparatorChar.ToString();
                if (string.IsNullOrWhiteSpace(oplConfig.SQLiteDatabasePath))
                {
                    return $"Database{slash}OpenPsiLabData.db";
                }
                else
                {
                    return oplConfig.SQLiteDatabasePath;
                }
            }
        }
        public OPLConfiguration oplConfig { get; set; }
        private ImageUtilities imageUtils;

        public SQLiteDatabase(OPLConfiguration oplConfiguration)
        {
            oplConfig = oplConfiguration;
            imageUtils = new ImageUtilities(oplConfig);
            Initialize();
        }

        public override void Initialize()
        {
            string slash = Path.DirectorySeparatorChar.ToString();
            if (!File.Exists(oplConfig.SQLiteDatabasePath))
            {
                if (!Directory.Exists(oplConfig.SQLiteDatabasePath))
                    Directory.CreateDirectory(Path.GetDirectoryName(oplConfig.SQLiteDatabasePath));
                File.Copy($"Resources{slash}OpenPsiLabDataTemplate.db",
                    oplConfig.SQLiteDatabasePath);
            }
        }

        private DataTable ExecuteReader(string SQLStatement)
        {
            SqliteDataReader dbDataReader;
            DataTable dbDataTable = new DataTable();

            try
            {
                using (SqliteConnection connection = new SqliteConnection($"Data Source={DatabasePath}"))
                {
                    connection.Open();

                    using (var cmd = new SqliteCommand(SQLStatement, (SqliteConnection)connection))
                    {
                        dbDataReader = cmd.ExecuteReader();
                        dbDataTable.Load(dbDataReader);
                        return dbDataTable;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void ExecuteNonQuery(string SQLStatement)
        {
            try
            {
                using (SqliteConnection connection = new SqliteConnection($"Data Source={DatabasePath}"))
                {
                    connection.Open();

                    using (var cmd = new SqliteCommand(SQLStatement, (SqliteConnection)connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override void SetImageActive(Guid uuid, bool active)
        {
            string activeBool = active ? "true" : "false";
            string sql = $"UPDATE images SET active = '{activeBool}' " +
                         $"WHERE uuid = '{uuid}';";
            ExecuteNonQuery(sql);
        }

        public override Guid ImageUpsert(ImageAsset imageAsset)
        {
            ImageAsset ia = imageAsset;
            try
            {
                if (ia.UUID == null)
                    imageAsset.UUID = Guid.NewGuid();
                Guid uuid = ia.UUID;
                using (var connection = new SqliteConnection($"Data Source={DatabasePath}"))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.Parameters.AddWithValue("@name", ((object)ia.Name) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@notes", ((object)ia.Notes) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@uuid", ((object)ia.UUID.ToString()) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@image_file_format",
                            ((object)imageUtils.GetName(ia.ImageFileFormat)) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@file_name", ((object)ia.FileName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@image_url", ((object)ia.ImageURL) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@info_url", ((object)ia.InfoURL) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@download_time", 
                            DateTimeOffset.Now.ToUniversalTime());

                        List<ImageAsset> dbImages = ImagesGet(new List<Guid>() { imageAsset.UUID });
                        if (dbImages != null && dbImages.Count > 0)
                        {
                            //Update
                            command.CommandText =
                                "UPDATE images " +
                                "SET name = @name, " +
                                "notes = @notes, " +
                                "uuid = @uuid, " +
                                "image_file_format = @image_file_format, " +
                                "file_name = @file_name, " +
                                "image_url = @image_url, " +
                                "info_url = @info_url," +
                                "active = 'true' " +
                                "WHERE uuid = @uuid;";
                        }
                        else
                        {
                            //Insert
                            command.CommandText =
                                "INSERT INTO images(name, notes, uuid, image_file_format, file_name, " +
                                "image_url, info_url, active, download_time) " +
                                "VALUES (@name, @notes, @uuid, @image_file_format, @file_name," +
                                "@image_url, @info_url, 'true', @download_time);";
                        }
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return ia.UUID;
        }

        public override List<ImageAsset> ImagesGet(List<Guid> uuids = null)
        {
            List<ImageAsset> assetsReturn = new List<ImageAsset>();

            string uuidst = " ";
            if (uuids != null)
            { foreach (Guid uuid in uuids)
                {
                    //string uuid2 = string.Empty;
                    if (uuidst == " ")
                    {
                        uuidst = $" '{uuid}'";
                    }
                    else
                    {
                        uuidst += $", '{uuid}' ";
                    }
                }
            }

            using (var connection = new SqliteConnection($"Data Source={DatabasePath}"))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    string sql = string.Empty;
                    if (uuids == null)
                    {
                        sql = $"SELECT * from images;";
                    }
                    else
                    {
                        sql = $"SELECT * from images where uuid in({uuidst});";
                    }
                    
                    DataTable iaTable = ExecuteReader(sql);

                    List<ImageAsset> ias = new List<ImageAsset>();
                    foreach (DataRow row in iaTable.Rows)
                    {
                        ImageAsset ia = new ImageAsset();
                        ia.UUID = Guid.Parse(ConvertFromDBVal<string>(row["uuid"]));
                        ia.Name = ConvertFromDBVal<string>(row["name"]);
                        ia.InfoURL = ConvertFromDBVal<string>(row["info_url"]);
                        ia.ImageURL = ConvertFromDBVal<string>(row["image_url"]);
                        ia.FileName = ConvertFromDBVal<string>(row["file_name"]);
                        //ia.ImageFileFormat = ia.ParseImageFormat(ConvertFromDBVal<string>(row["image_file_format"]));
                        ia.Notes = ConvertFromDBVal<string>(row["notes"]);
                        ias.Add(ia);
                    }
                    return ias;
                }
            }
        }

        public override List<Guid> ImageUUIDsGetAll()
        {
            List<Guid> returnGuids = new List<Guid>();
            string sql = "SELECT uuid from images;";
            DataTable uuidTable = ExecuteReader(sql);
            foreach (DataRow row in uuidTable.Rows)
            {
                try
                {
                    Guid uuid = Guid.Parse((string)row["uuid"]);
                    returnGuids.Add(uuid);
                }
                catch (System.Exception)
                {
                    //continue;
                }
            }
            return returnGuids;
        }

        public override void SessionPracticeSave(RVSession rvSession, bool overwrite = false)
        {
            try
            {
                if (!overwrite == true)
                {
                    if (RVSessionExists(rvSession.UUID.ToString()))
                    {
                        SessionOverwriteAlertForm ovr = new SessionOverwriteAlertForm();
                        ovr.ShowDialog();

                        if (ovr.DialogResult == DialogResult.OK)
                        {
                            if (ovr.CustomDialogResult == "overwrite")
                            {
                                SessionPracticeDelete(rvSession.UUID.ToString());
                                internalSessionPracticeSave(rvSession);
                                return;
                            }
                            else if (ovr.CustomDialogResult == "create")
                            {
                                rvSession.UUID = Guid.NewGuid();
                                internalSessionPracticeSave(rvSession);
                                return;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                internalSessionPracticeSave(rvSession);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public override void internalSessionPracticeSave(RVSession rvSession)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabasePath}"))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        RVSession sp = rvSession;
                        command.Parameters.AddWithValue("@uuid",
                            ((object)sp.UUID.ToString()) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@name",
                            ((object)sp.Name) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@notes",
                            ((object)sp.Notes) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@target_id",
                            ((object)sp.TargetID) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@targeted",
                            ((object)sp.Targeted) ?? DBNull.Value);
                        if (sp.ImagesArray != null && sp.Image1 != null)
                        {
                            command.Parameters.AddWithValue("@image_1_uuid",
                                ((object)sp.Image1.UUID.ToString()) ?? DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@image_1_uuid",
                                ((object)"") ?? DBNull.Value);
                        }
                        if (sp.ImagesArray != null && sp.Image2 != null)
                        {
                            command.Parameters.AddWithValue("@image_2_uuid",
                                ((object)sp.Image2.UUID.ToString()) ?? DBNull.Value);
                        }else
                        {
                            command.Parameters.AddWithValue("@image_2_uuid",
                                ((object)"") ?? DBNull.Value);
                        }
                        
                        command.Parameters.AddWithValue("@longitude",
                            ((object)sp.Longitude) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@start_datetime_local",
                            ((object)sp.StartDateTimeLocal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@start_datetime_utc",
                            ((object)sp.StartDateTimeUTC) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@start_datetime_sidereal",
                            ((object)sp.StartDateTimeSidereal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@end_datetime_local",
                            ((object)sp.EndDateTimeLocal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@end_datetime_utc",
                            ((object)sp.EndDateTimeUTC) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@end_datetime_sidereal",
                            ((object)sp.EndDateTimeSidereal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@viewer_selected_image_uuid",
                            ((object)sp.ViewerSelectedImageUUID.ToString()) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@judge_selected_image_uuid",
                            ((object)sp.JudgeSelectedImageUUID.ToString()) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@target_image_uuid",
                            ((object)sp.TargetImageUUID.ToString()) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@viewer_selected_datetime_local",
                            ((object)sp.ViewerSelectedDateTimeLocal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@judge_selected_datetime_local",
                            ((object)sp.JudgeSelectedDateTimeLocal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@targeted_datetime_local",
                            ((object)sp.TargetedDateTimeLocal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@viewer_selected_datetime_utc",
                            ((object)sp.ViewerSelectedDateTimeUTC) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@judge_selected_datetime_utc",
                            ((object)sp.JudgeSelectedDateTimeUTC) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@targeted_datetime_utc",
                            ((object)sp.TargetedDateTimeUTC) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@viewer_selected_datetime_sidereal",
                            ((object)sp.ViewerSelectedDateTimeSidereal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@judge_selected_datetime_sidereal",
                            ((object)sp.JudgeSelectedDateTimeSidereal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@targeted_datetime_sidereal",
                            ((object)sp.TargetedDateTimeSidereal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@swx_overview_large_uuid",
                            ((object)sp.SWXOverviewLargeUUID) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@notifications_in_effect_timeline_uuid",
                            ((object)sp.NotificationsInEffectTimelineUUID) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@screenshot_uuid",
                            ((object)sp.ScreenshotUUID.ToString()) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@viewer_selected_target",
                            ((object)sp.ViewerSelectedTarget) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@judge_selected_target",
                            ((object)sp.JudgeSelectedTarget) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@viewer_name",
                            ((object)sp.ViewerName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@judge_name",
                            ((object)sp.JudgeName) ?? DBNull.Value);

                        command.Parameters.AddWithValue("@arv_question",
                            ((object)sp.ARVQuestion) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@arv_answer_1",
                            ((object)sp.ARVAnswer1) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@arv_answer_2",
                            ((object)sp.ARVAnswer2) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@session_type",
                            ((object)sp.SessionType.ToString()) ?? DBNull.Value);


                        command.CommandText =
                            "INSERT INTO rv_sessions " +
                            "(uuid, name, notes, target_id, targeted, image_1_uuid, image_2_uuid, " +
                            "longitude, start_datetime_local, " +
                            "start_datetime_utc, start_datetime_sidereal, end_datetime_local, " +
                            "end_datetime_utc, end_datetime_sidereal, viewer_selected_image_uuid, " +
                            "judge_selected_image_uuid, target_image_uuid, viewer_selected_datetime_local, " +
                            "judge_selected_datetime_local, targeted_datetime_local, viewer_selected_datetime_utc, " +
                            "judge_selected_datetime_utc, targeted_datetime_utc, viewer_selected_datetime_sidereal, " +
                            "judge_selected_datetime_sidereal, targeted_datetime_sidereal, " +
                            "swx_overview_large_uuid, notifications_in_effect_timeline_uuid, screenshot_uuid, " +
                            "viewer_selected_target, judge_selected_target, viewer_name, judge_name, " +
                            "arv_question, arv_answer_1, arv_answer_2, session_type" +
                            ") " +
                            "VALUES " +
                            "(@uuid, @name, @notes, @target_id, @targeted, @image_1_uuid, @image_2_uuid, " +
                            "@longitude, @start_datetime_local, " +
                            "@start_datetime_utc, @start_datetime_sidereal, @end_datetime_local, " +
                            "@end_datetime_utc, @end_datetime_sidereal, @viewer_selected_image_uuid, " +
                            "@judge_selected_image_uuid, @target_image_uuid, @viewer_selected_datetime_local, " +
                            "@judge_selected_datetime_local, @targeted_datetime_local, @viewer_selected_datetime_utc, " +
                            "@judge_selected_datetime_utc, @targeted_datetime_utc, @viewer_selected_datetime_sidereal, " +
                            "@judge_selected_datetime_sidereal, @targeted_datetime_sidereal, " +
                            "@swx_overview_large_uuid, @notifications_in_effect_timeline_uuid, @screenshot_uuid, " +
                            "@viewer_selected_target, @judge_selected_target, @viewer_name, @judge_name, " +
                            "@arv_question, @arv_answer_1, @arv_answer_2, @session_type " +
                            ");";
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public override void SessionPracticeDelete(string sessionUUID)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabasePath}"))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText =
                            "delete from rv_sessions \n" +
                            $"where uuid = '{sessionUUID}';";

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SessionPracticeUpdate(RVSession rvSession)
        {
            try
            {
                using (var connection = new SqliteConnection($"Data Source={DatabasePath}"))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        RVSession sp = rvSession;
                        command.Parameters.AddWithValue("@uuid",
                            ((object)sp.UUID.ToString()) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@name",
                            ((object)sp.Name) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@notes",
                            ((object)sp.Notes) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@image_1_uuid",
                            ((object)sp.Image1.UUID.ToString()) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@image_2_uuid",
                            ((object)sp.Image2.UUID.ToString()) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@longitude",
                            ((object)sp.Longitude) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@start_datetime_local",
                            ((object)sp.StartDateTimeLocal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@start_datetime_utc",
                            ((object)sp.StartDateTimeUTC) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@start_datetime_sidereal",
                            ((object)sp.StartDateTimeSidereal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@end_datetime_local",
                            ((object)sp.EndDateTimeLocal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@end_datetime_utc",
                            ((object)sp.EndDateTimeUTC) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@end_datetime_sidereal",
                            ((object)sp.EndDateTimeSidereal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@viewer_selected_image_uuid",
                            ((object)sp.ViewerSelectedImageUUID.ToString()) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@judge_selected_image_uuid",
                            ((object)sp.JudgeSelectedImageUUID.ToString()) ?? DBNull.Value);

                        command.Parameters.AddWithValue("@viewer_selected_datetime_local",
                            ((object)sp.ViewerSelectedDateTimeLocal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@judge_selected_datetime_local",
                            ((object)sp.JudgeSelectedDateTimeLocal) ?? DBNull.Value);

                        command.Parameters.AddWithValue("@viewer_selected_datetime_utc",
                            ((object)sp.ViewerSelectedDateTimeUTC) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@judge_selected_datetime_utc",
                            ((object)sp.JudgeSelectedDateTimeUTC) ?? DBNull.Value);

                        command.Parameters.AddWithValue("@viewer_selected_datetime_sidereal",
                            ((object)sp.ViewerSelectedDateTimeSidereal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@judge_selected_datetime_sidereal",
                            ((object)sp.JudgeSelectedDateTimeSidereal) ?? DBNull.Value);

                        command.Parameters.AddWithValue("@swx_overview_large_uuid",
                            ((object)sp.SWXOverviewLargeUUID) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@notifications_in_effect_timeline_uuid",
                            ((object)sp.NotificationsInEffectTimelineUUID) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@screenshot_uuid",
                            ((object)sp.ScreenshotUUID.ToString()) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@viewer_selected_target",
                            ((object)sp.ViewerSelectedTarget) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@judge_selected_target",
                            ((object)sp.JudgeSelectedTarget) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@viewer_name",
                            ((object)sp.ViewerName) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@judge_name",
                            ((object)sp.JudgeName) ?? DBNull.Value);

                        command.Parameters.AddWithValue("@targeted",
                            ((object)sp.Targeted) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@target_id",
                            ((object)sp.TargetID) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@target_image_uuid",
                            ((object)sp.TargetImageUUID.ToString()) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@targeted_datetime_local",
                            ((object)sp.TargetedDateTimeLocal) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@targeted_datetime_utc",
                            ((object)sp.TargetedDateTimeUTC) ?? DBNull.Value);
                        command.Parameters.AddWithValue("@targeted_datetime_sidereal",
                            ((object)sp.TargetedDateTimeSidereal) ?? DBNull.Value);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public override bool RVSessionExists(string sessionUUID)
        {
            string sql = $"SELECT uuid from rv_sessions where uuid = '{sessionUUID}';";
            DataTable uuidTable = ExecuteReader(sql);

            if (uuidTable.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public void SyncFileNames()
        {
            List<Guid> imageGuids = ImageUUIDsGetAll();
            
            //Get all of the files
            string path = oplConfig.ImageFolderPath;
            string[] filePaths = Directory.GetFiles(path);

            //Get the guids from DB
            foreach (string filePath in filePaths)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                string fileNameWithExtension = Path.GetFileName(filePath);
                using (var connection = new SqliteConnection($"Data Source={DatabasePath}"))
                {
                    List<ImageAsset> dbImages = null;
                    try
                    {
                         dbImages =
                            ImagesGet(new List<Guid>() { Guid.Parse(fileNameWithoutExtension) });
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"No image guid in db: {fileNameWithoutExtension}");
                        continue;
                    }
                    
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.Parameters.AddWithValue("@file_name", fileNameWithExtension);
                        command.Parameters.AddWithValue("@uuid", fileNameWithoutExtension);

                        if (dbImages != null && dbImages.Count > 0)
                        {
                            //Update
                            command.CommandText =
                                "UPDATE images " +
                                "SET file_name = @file_name " +
                                "WHERE uuid = @uuid;";
                        }

                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }

        }

        public override void ReconcileDBAndImageFiles()
        {
            //List<Guid> imageGuids = ImageUUIDsGetAll();

            //Get all of the files
            string path = oplConfig.ImageFolderPath;
            string[] filePaths = Directory.GetFiles(path);

            //Get the images from DB
            List < ImageAsset > imagesInDB = ImagesGet();

            //Find files not in DB
            List<string> filesNotInDB = new List<string>();
            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                var matchingDBRecords = from image in imagesInDB
                    where image.FileName == fileName
                    select image;

                if (matchingDBRecords.Count() < 1)
                    filesNotInDB.Add(filePath);
            }
            
            //Find db records with no files
            List<ImageAsset> dbRecordsWithNoFiles = new List<ImageAsset>();
            foreach (ImageAsset imageInDB in imagesInDB)
            {
                var matchingFiles = from filePath in filePaths
                    where Path.GetFileName(filePath) == imageInDB.FileName
                    select filePath;

                if (matchingFiles.Count() < 1)
                    dbRecordsWithNoFiles.Add(imageInDB);
            }

            //Foreach file not in DB, move file to import folder
            //and ask to import files into DB at end
            if (!Directory.Exists("Import"))
                Directory.CreateDirectory("Import");
            foreach (string filePath in filesNotInDB)
            {
                File.Move(filePath, 
                    Path.Combine("Import", $"{Path.GetFileName(filePath)}"));
            }

            //Foreach db record without file, mark inactive
            foreach (ImageAsset image in dbRecordsWithNoFiles)
            {
                SetImageActive(image.UUID, false);
            }
        }

        public override void ProgramVersionSave(string programVersion)
        {
            try
            {
                KeyValuePair<string, string>? dbKeyValue = AdminKeyValueGet("ProgramVersion");
                string insertType = string.Empty;
                if (dbKeyValue == null)
                    insertType = "insert";
                else
                    insertType = "update";

                using (var connection = new SqliteConnection($"Data Source={DatabasePath}"))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.Parameters.AddWithValue(
                            "@program_version", programVersion);

                        if (insertType == "insert")
                        {
                            command.CommandText =
                                "INSERT INTO admin (key, value) " +
                                "VALUES ('ProgramVersion', @program_version);";
                        }
                        else
                        {
                            command.CommandText =
                                "UPDATE admin SET value = @program_version " +
                                "WHERE key = 'ProgramVersion';";
                        }
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public override void DatabaseVersionSave(string databaseVersion)
        {
            try
            {
                KeyValuePair<string, string>? dbKeyValue = AdminKeyValueGet("DatabaseVersion");
                string insertType = string.Empty;
                if (dbKeyValue == null)
                    insertType = "insert";
                else
                    insertType = "update";

                using (var connection = new SqliteConnection($"Data Source={DatabasePath}"))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {

                        command.Parameters.AddWithValue(
                            "@database_version", databaseVersion);

                        if (insertType == "insert")
                        {
                            command.CommandText =
                                "INSERT INTO admin (key, value) " +
                                "VALUES ('DatabaseVersion', @database_version);";
                        }
                        else
                        {
                            command.CommandText = 
                                "UPDATE admin SET value = @database_version " +
                                "WHERE key = 'DatabaseVersion';";
                        }
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public KeyValuePair<string, string>? AdminKeyValueGet(string key)
        {
            KeyValuePair<string, string> returnKeyValue;

            using (var connection = new SqliteConnection($"Data Source={DatabasePath}"))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    string sql = $"SELECT * from admin where key = '{key}';";
                    
                    DataTable kvTable = ExecuteReader(sql);

                    string dbKey = string.Empty;
                    string dbValue = string.Empty;

                    if (kvTable.Rows.Count > 0)
                    {
                        DataRow row = kvTable.Rows[0];

                        ImageAsset ia = new ImageAsset();

                        dbKey = ConvertFromDBVal<string>(row["key"]);
                        dbValue = ConvertFromDBVal<string>(row["value"]);

                        returnKeyValue = new KeyValuePair<string, string>(dbKey, dbValue);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return returnKeyValue;
        }
    }
}
