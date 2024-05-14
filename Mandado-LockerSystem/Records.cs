using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandado_LockerSystem
{
    public partial class Records : Form
    {
        public Records()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            string sql = "SELECT * FROM users";
            DBHelper.DBHelper.fill(sql, dataGridView1);
        }

        private void Records_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtid.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                txtfirstname.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                txtlastname.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                txtidnumber.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                txtgender.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                txtage.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                txtphonenumber.Text = dataGridView1[6, e.RowIndex].Value.ToString();
                txtpassword.Text = dataGridView1[7, e.RowIndex].Value.ToString();
                txtrole.Text = dataGridView1[8, e.RowIndex].Value.ToString();
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO users (firstname, lastname, idnumber, gender, age, phonenumber, [password], role) VALUES ('" + txtfirstname.Text + "', '" + txtlastname.Text + "', " + txtidnumber.Text + ", '" + txtgender.Text + "', " + txtage.Text + ", " + txtphonenumber.Text + ", '" + txtpassword.Text + "', '" + txtrole.Text + "')"; ;
            if (DBHelper.DBHelper.ModifyRecord(sql))
            {
                MessageBox.Show("Registered Successfuly.");
                FillDataGrid();
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE users SET firstname = '" + txtfirstname.Text + "', lastname = '" + txtlastname.Text + "', idnumber = " + txtidnumber.Text + ", gender = '" + txtgender.Text + "', age = " + txtage.Text + ", phonenumber = " + txtphonenumber.Text + ", [password] = '" + txtpassword.Text + "', role = '" + txtrole.Text + "' WHERE ID = " + Convert.ToInt32(txtid.Text);
            if (DBHelper.DBHelper.ModifyRecord(sql))
            {
                MessageBox.Show("Updated Successfuly.");
                FillDataGrid();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM users WHERE ID = " + txtid.Text;
            if (DBHelper.DBHelper.ModifyRecord(sql))
            {
                MessageBox.Show("Deleted Successfuly.");
                FillDataGrid();
            }
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
