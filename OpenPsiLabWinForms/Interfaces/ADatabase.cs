using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenPsiLabWinForms.Models;

namespace OpenPsiLabWinForms.Interfaces
{
    public abstract class ADatabase : IDatabase
    {
        public T ConvertFromDBVal<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(T); // returns the default value for the type
            }
            else
            {
                return (T)obj;
            }
        }

        public abstract Guid ImageUpsert(ImageAsset imageAsset);

        public abstract List<ImageAsset> ImagesGet(List<Guid> uuids);

        public abstract List<Guid> ImageUUIDsGetAll();

        public abstract void SessionPracticeSave(RVSession rvSession, bool overwrite);
        
        public abstract void Initialize();
        
        public abstract void SetImageActive(Guid uuid, bool active);

        public abstract void ReconcileDBAndImageFiles();

        public abstract void ProgramVersionSave(string programVersion);

        public abstract void DatabaseVersionSave(string databaseVersion);

        public abstract bool RVSessionExists(string sessionUUID);

        public abstract void SessionPracticeDelete(string sessionUUID);

        public abstract void internalSessionPracticeSave(RVSession rvSession);

    }
}
