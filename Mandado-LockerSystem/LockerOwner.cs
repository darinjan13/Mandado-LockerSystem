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
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE lockers SET available = true WHERE idnumber = " + DBHelper.DBHelper.LockerOwner;
            if (DBHelper.DBHelper.ModifyRecord(sql))
            {
                MessageBox.Show("Locker is not yours now.");
                pictureBox.Image = Resources.AvailableLocker;
                this.Close();
            }
        }
    }
}
