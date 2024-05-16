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

        //Mao ni ang method para makuha nimo ang mga users gikan sa database
        private void FillDataGrid()
        {
            string sql = "SELECT * FROM users";
            DBHelper.DBHelper.fill(sql, dataGridView1);
        }

        private void Records_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Kani mao ni ang mo butang ug value sa textboxes everytime mo click kag users sa datagridview
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
                ownsALocker.Checked = (bool)dataGridView1[9, e.RowIndex].Value;
            }
        }

        //Button para maka create ug account
        private void createBtn_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO users (firstname, lastname, idnumber, gender, age, phonenumber, [password], role, ownsALocker) VALUES ('" + txtfirstname.Text + "', '" + txtlastname.Text + "', " + txtidnumber.Text + ", '" + txtgender.Text + "', " + txtage.Text + ", " + txtphonenumber.Text + ", '" + txtpassword.Text + "', '" + txtrole.Text + "', " + ownsALocker.Checked + ")"; ;
            if (DBHelper.DBHelper.ModifyRecord(sql))
            {
                MessageBox.Show("Registered Successfuly.");
                FillDataGrid();
            }
        }

        //Para update
        private void updateBtn_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE users SET firstname = '" + txtfirstname.Text + "', lastname = '" + txtlastname.Text + "', idnumber = " + txtidnumber.Text + ", gender = '" + txtgender.Text + "', age = " + txtage.Text + ", phonenumber = " + txtphonenumber.Text + ", [password] = '" + txtpassword.Text + "', role = '" + txtrole.Text + "', ownsALocker = " + ownsALocker.Checked + " WHERE ID = " + Convert.ToInt32(txtid.Text);
            if (DBHelper.DBHelper.ModifyRecord(sql))
            {
                if (!ownsALocker.Checked)
                {
                    sql = "UPDATE lockers SET idnumber = 0, available = true WHERE idnumber = " + txtidnumber.Text;
                    DBHelper.DBHelper.ModifyRecord(sql);
                }
                MessageBox.Show("Updated Successfuly.");
                FillDataGrid();
            }
        }

        //Para delete
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM users WHERE ID = " + txtid.Text;
            if (DBHelper.DBHelper.ModifyRecord(sql))
            {
                sql = "UPDATE lockers SET idnumber = 0, available = true WHERE idnumber = " + txtidnumber.Text;
                MessageBox.Show("Deleted Successfuly.");
                DBHelper.DBHelper.ModifyRecord(sql);
                FillDataGrid();
            }
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        //Search button ni
        private void searchBtn_Click(object sender, EventArgs e)
        {
            //Diri ma save ang sud sa textbox nga para gamiton sa pag search
            string searchText = searchBox.Text;
            //Kani mao ni ang searchby nga naa kilid sa search nga textbox
            string searchBy = searchByBox.Text;
            string sql;

            switch (searchBy) 
            {
                //Kani sila mao ni ilhanan if unsa imo e search like firstname ba or lastname
                case "firstname":
                    sql = "SELECT * FROM users WHERE firstname LIKE '" + searchText + "'";
                    DBHelper.DBHelper.fill(sql, dataGridView1);
                    break;
                case "lastname":
                    sql = "SELECT * FROM users WHERE lastname LIKE '" + searchText + "'";
                    DBHelper.DBHelper.fill(sql, dataGridView1);
                    break;
                case "idnumber":
                    sql = "SELECT * FROM users WHERE idnumber LIKE " + Convert.ToInt32(searchText);
                    DBHelper.DBHelper.fill(sql, dataGridView1);
                    break;
                case "gender":
                    sql = "SELECT * FROM users WHERE gender LIKE '" + searchText + "'";
                    DBHelper.DBHelper.fill(sql, dataGridView1);
                    break;
                case "age":
                    sql = "SELECT * FROM users WHERE age LIKE " + Convert.ToInt32(searchText);
                    DBHelper.DBHelper.fill(sql, dataGridView1);
                    break;
                case "phonenumber":
                    sql = "SELECT * FROM users WHERE phonenumber LIKE " + Convert.ToInt32(searchText);
                    DBHelper.DBHelper.fill(sql, dataGridView1);
                    break;

            }
        }
    }
}
