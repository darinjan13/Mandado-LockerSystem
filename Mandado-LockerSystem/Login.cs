using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandado_LockerSystem
{
    public partial class Login : Form
    {
        public static string sendtext = "";
        string role;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Connection.DB();
                DBHelper.DBHelper.gen = "Select * from users where [idnumber] = " + txtidnumber.Text + " and [password] = '" + txtpassword.Text + "'";
                DBHelper.DBHelper.command = new OleDbCommand(DBHelper.DBHelper.gen, Connection.Connection.conn);
                DBHelper.DBHelper.reader = DBHelper.DBHelper.command.ExecuteReader();

                if (DBHelper.DBHelper.reader.HasRows)
                {
                    DBHelper.DBHelper.reader.Read();
                    //database  
                    role = DBHelper.DBHelper.reader["role"].ToString();
                    timer1.Enabled = true;
                    timer1.Start();
                    timer1.Interval = 1;
                    progressBar1.Maximum = 200;
                    timer1.Tick += new EventHandler(timer1_Tick);
                    
                }
                else
                {
                    MessageBox.Show("Invalid Username and Password");

                }

                
                Connection.Connection.conn.Close();
            }
            catch (Exception ex)
            {
                Connection.Connection.conn.Close();
                MessageBox.Show(ex.Message);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != 200)
            {
                progressBar1.Value++;
            }
            else
            {
                timer1.Stop();
                this.Hide();
                if (role != "student")
                {
                    Records rec = new Records();
                    rec.Show();
                }
                else
                {
                    Lockers lockers = new Lockers(Convert.ToInt32(txtidnumber.Text));
                    lockers.Show();
                }

                progressBar1.Value = 0;
                

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            CreateAccount create = new CreateAccount();
            create.Show(); Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the user clicks Yes, close the application
            if (result == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
