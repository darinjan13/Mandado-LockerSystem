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
    public partial class LockerOwner : Form
    {
        PictureBox pictureBox;
        public LockerOwner(PictureBox pictureBox)
        {
            InitializeComponent();
            this.pictureBox = pictureBox;
            label1.Text = "Welcome! " + DBHelper.DBHelper.firstname;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Mao ni if ganahan ka buhi an ang locker nimo
        private void confirmBtn_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE lockers SET idnumber = 0, available = true WHERE idnumber = " + DBHelper.DBHelper.LockerOwner;
            if (DBHelper.DBHelper.ModifyRecord(sql))
            {
                sql = "UPDATE users SET ownsALocker = false";
                DBHelper.DBHelper.ModifyRecord(sql);
                MessageBox.Show("Locker is not yours now.");
                pictureBox.Image = Resources.AvailableLocker;
                this.Close();
            }
        }
    }
}
