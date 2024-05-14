using Mandado_LockerSystem.Connection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandado_LockerSystem
{
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void register()
        {
                string sql = "INSERT INTO users (firstname, lastname, idnumber, gender, age, phonenumber, [password], role) VALUES ('" + txtfirstname.Text + "', '" + txtlastname.Text + "', " + txtidnumber.Text + ", '" + txtgender.Text + "', " + txtage.Text + ", " + txtphonenumber.Text + ", '" + txtpassword.Text + "', 'student')";
                if(DBHelper.DBHelper.ModifyRecord(sql))
                {
                    ClearForm();
                    MessageBox.Show("Registered Successfuly.");
                }
        }


        public void ClearForm()
        {
            txtfirstname.Clear();
            txtlastname.Clear();
            txtidnumber.Clear();
            txtage.Clear();
            txtphonenumber.Clear();
            txtpassword.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();Hide();
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

        private void CreateAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            register();
        }
    }
}
