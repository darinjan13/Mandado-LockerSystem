using Mandado_LockerSystem.Properties;
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
    public partial class RentLockerForm : Form
    {
        int idnumber, locker;
        PictureBox pictureBox;
        public RentLockerForm(int idnumber, int locker, PictureBox pictureBox)
        {
            InitializeComponent();
            lockerNumber.Text = "Locker number: " + locker;
            this.idnumber = idnumber;
            this.locker = locker;
            this.pictureBox = pictureBox;
        }

        //Mao ni if ganahan siya kuhaon ang locker
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE lockers SET idnumber = " + idnumber + ", available = " + false + " where ID = " + locker;
            if (DBHelper.DBHelper.ModifyRecord(sql))
            {
                MessageBox.Show("Taken Successfuly");
                sql = "UPDATE users SET ownsALocker = true WHERE idnumber = " + idnumber;
                DBHelper.DBHelper.ModifyRecord(sql);
            }
            this.Close();
            pictureBox.Image = Resources.NotAvailableLocker;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
