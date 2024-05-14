using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandado_LockerSystem.DBHelper
{
    internal class DBHelper
    {
        //used for database transaction
        public static string gen = "";
        public static OleDbConnection conn;
        public static OleDbCommand command;
        public static OleDbDataReader reader;
        public static int LockerOwner;
        public static bool LockerAvailability;
        public static void fill(string q, DataGridView dgv)
        {
            try
            {
                Connection.Connection.DB();
                DataTable dt = new DataTable();
                OleDbDataAdapter data = null;
                OleDbCommand command = new OleDbCommand(q, Connection.Connection.conn);
                data = new OleDbDataAdapter(command);
                data.Fill(dt);
                dgv.DataSource = dt;
                Connection.Connection.conn.Close();
            }
            catch (Exception ex)
            {
                Connection.Connection.conn.Close();
                MessageBox.Show(ex.Message, "Error FillDataGridView", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static bool ModifyRecord(string updates)
        {
            bool result = false;
            try
            {
                Connection.Connection.DB();
                command = new OleDbCommand(updates, Connection.Connection.conn);
                command.ExecuteNonQuery();
                result = true;
                Connection.Connection.conn.Close();
            }
            catch (Exception ex)
            {
                Connection.Connection.conn.Close();
                MessageBox.Show("Error ---->" + updates + ex.Message);
            }
            return result;
        }

        public static void GetRecord(string updates) 
        {
            try
            {
                Connection.Connection.DB();
                command = new OleDbCommand(updates, Connection.Connection.conn);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    LockerOwner = Convert.ToInt32(reader["idnumber"]);
                    LockerAvailability = (bool)reader["available"];
                }
                reader.Close();
                Connection.Connection.conn.Close();
            } catch (Exception ex)
            {
                Connection.Connection.conn.Close();
                MessageBox.Show("Error ---->" + updates + ex.Message);
            }
        }

    }
}
