using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPsiLabWinForms.DataSources;
using OpenPsiLabWinForms.Interfaces;
using OpenPsiLabWinForms.Models;

namespace OpenPsiLabWinForms.Views
{
    public partial class ReconcileImagesForm : Form
    {
        public OPLConfiguration oplConfig { get; set; }
        public ReconcileImagesForm(OPLConfiguration oplConfiguration)
        {
            InitializeComponent();
            oplConfig = oplConfiguration;

            instructionsTextBox.Text =
                "This utility will compare the images in the images folder with the image records " +
                "in the database.  It will correct two possible discrepancies to prevent program errors, " +
                "however you may also wish to take additional manual actions to return the system to " +
                "its original state.\r\n\r\n" +
                "1.  Files in the image folder which no longer have a matching record in the database:  " +
                "In this instance the reconciliation utility will move the file to the Import folder.  " +
                "You may wish to manually import these images back into the database.\r\n\r\n" +
                "2.  Records in database that have no matching file:  In this instance, since these " +
                "records may be associated with existing RV sessions, instead of deleting the records " +
                "they are marked as inactive.  Whenever you save an RV session, copies of the " +
                "associated images are also saved in the folder for that saved session (located in " +
                "the \"Data\" folder.) If you can find the associated image file you can copy it to " +
                "the \"Images\" folder and give it a name that matches the \"file_name\" field for that record in " +
                "the database. To view the file name you will need to open the \"images\" table in the SQLite " +
                "database file named \"OpenPsiLabData.db\" in the \"Resources\" folder.  You can open " +
                "the database file in DB Browser for SQLite    http://sqlitebrowser.org ";
        }

        private void reconcileButton_Click(object sender, EventArgs e)
        {
            ADatabase db = new SQLiteDatabase(oplConfig);
            db.ReconcileDBAndImageFiles();
            MessageBox.Show("Reconciliation is complete.", "Finished", MessageBoxButtons.OK);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
