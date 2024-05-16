using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Mandado_LockerSystem.Connection
{
    internal class Connection
    {
        public static OleDbConnection conn;
        private static string dbconnect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ Application.StartupPath + "\\LockersDB.accdb";
        public static void DB()
        {
            try
            {
                conn = new OleDbConnection(dbconnect);
                conn.Open();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
