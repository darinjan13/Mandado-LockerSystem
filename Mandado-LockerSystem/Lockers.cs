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
using System.Xml;

namespace Mandado_LockerSystem
{
    public partial class Lockers : Form
    {
        int idnumber;
        public Lockers(int idnumber)
        {
            InitializeComponent();
            this.idnumber = idnumber;
            //Kani imo ra ge call ang para makuha ang info sa ni logged in
            GetUserInfo();

            //Kani para rani e display iyang ngan
            if (DBHelper.DBHelper.firstname != null && DBHelper.DBHelper.lastname != null)
            {
                nameLabel.Text = DBHelper.DBHelper.firstname + " " + DBHelper.DBHelper.lastname;
            }
        }


        //Kani siya para rani makuha ang firsname, lastname and ownsALocker nga info gikan sa database aron makahibaw ta sa iya name ug naa ba siyay locker
        private void GetUserInfo()
        {
            string sql = "SELECT users.[firstname], users.[lastname], users.[ownsALocker] FROM users WHERE idnumber = " + idnumber;
            DBHelper.DBHelper.GetInfo(sql);
        }

        //Para close rani
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the user clicks Yes, close the application
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        //Kani if naka click naka ug locker mao ni mo check if ang locker is naay tag iya or ang tag iya is naa nay locker
        private void CheckLocker(int lockerNumber, PictureBox pictureBox)
        {
            //mao ni ang query para makuha ang info gikan sa lockers nga table sa database WHERE ang ID sa locker sa database kay the same sa number nga locker nga imo ge pili
            string sql = "SELECT * FROM lockers WHERE ID = " + lockerNumber;

            DBHelper.DBHelper.GetRecord(sql);

            //Kani mo check if ang user naka logged in is wala pay locker and e check niya ang locker if naay tag iya
            if (!DBHelper.DBHelper.LockerAvailability && DBHelper.DBHelper.LockerOwner != idnumber)
            {
                    MessageBox.Show($"This locker belongs to {DBHelper.DBHelper.LockerOwner}.");
                    pictureBox.Image = Resources.NotAvailableLocker;
            }
            //Diri if ang ge click nga locker sa naka logged in is iyaha
            else if (!DBHelper.DBHelper.LockerAvailability && DBHelper.DBHelper.LockerOwner == idnumber)
            {
                LockerOwner lockerOwner = new LockerOwner(pictureBox);
                lockerOwner.ShowDialog();
            }
            else
            {
                //Mao ni if dili iyaha and naa na siyay locker
                if (DBHelper.DBHelper.ownsALocker)
                {
                    MessageBox.Show("You already have a locker.");
                }
                //Kani if di iyaha and wala pa siyay locker
                else
                {
                    lockersClicked(lockerNumber, pictureBox);
                }
            }
            //Mao rani mo update sa database if naka tag iya na siyag locker aron di na siya pwede mo kuha ug laing locker
            GetUserInfo();
        }

        //Mao ni if di iyahang locker and if wala pa siyay locker
        private void lockersClicked(int locker, PictureBox pictureBox)
        {

            RentLockerForm rentLockerForm = new RentLockerForm(idnumber, locker, pictureBox);
            rentLockerForm.ShowDialog();
        }


        //Gikan diri hangtod sa last is mao ni ang method if mo click kag picture sa locker
        private void locker1_Click(object sender, EventArgs e)
        {
            //Meaning ani imo ge pasa sa CheckLocker ang kung unsa nga picturebox imo ge click aron ma usab iyang picture to red if naay mo gamit
            //same rani hangtod sa ubos
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

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
