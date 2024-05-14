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
    public partial class Lockers : Form
    {
        int idnumber;
        public Lockers(int idnumber)
        {
            InitializeComponent();
            this.idnumber = idnumber;
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

        private void lockersClicked(int locker, PictureBox pictureBox)
        {
            RentLockerForm rentLockerForm = new RentLockerForm(idnumber, locker, pictureBox);
            rentLockerForm.ShowDialog();
        }

        private void CheckLocker(int lockerNumber, PictureBox pictureBox)
        {
            string sql = "SELECT * FROM lockers WHERE ID = " + lockerNumber;
            DBHelper.DBHelper.GetRecord(sql);
            if (!DBHelper.DBHelper.LockerAvailability && DBHelper.DBHelper.LockerOwner != idnumber)
            {
                MessageBox.Show("This locker is not available.");
                pictureBox.Image = Resources.NotAvailableLocker;
            } else if (!DBHelper.DBHelper.LockerAvailability && DBHelper.DBHelper.LockerOwner == idnumber)
            {
                LockerOwner lockerOwner = new LockerOwner(pictureBox);
                lockerOwner.ShowDialog();
            }
            else
            {
                lockersClicked(lockerNumber, pictureBox);
            }
        }

        private void locker1_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(1, clickedLocker);
            }
        }

        private void locker2_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(2, clickedLocker);
            }
        }

        private void locker3_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(3, clickedLocker);
            }
        }

        private void locker4_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(4, clickedLocker);
            }
        }

        private void locker5_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(5, clickedLocker);
            }
        }

        private void locker6_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(6, clickedLocker);
            }
        }

        private void locker7_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(7, clickedLocker);
            }
        }

        private void locker8_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(8, clickedLocker);
            }
        }

        private void locker9_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(9, clickedLocker);
            }
        }

        private void locker10_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(10, clickedLocker);
            }
        }

        private void locker11_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(11, clickedLocker);
            }
        }

        private void locker12_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(12, clickedLocker);
            }
        }

        private void locker13_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(13, clickedLocker);
            }
        }

        private void locker14_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(14, clickedLocker);
            }
        }

        private void locker15_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(15, clickedLocker);
            }
        }

        private void locker16_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(16, clickedLocker);
            }
        }

        private void locker17_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(17, clickedLocker);
            }
        }

        private void locker18_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(18, clickedLocker);
            }
        }

        private void locker19_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(19, clickedLocker);
            }
        }

        private void locker20_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedLocker)
            {
                CheckLocker(20, clickedLocker);
            }
        }
    }
}
