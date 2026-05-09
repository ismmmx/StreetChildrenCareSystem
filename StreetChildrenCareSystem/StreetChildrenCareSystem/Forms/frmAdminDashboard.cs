using System;
using System.Data;
using System.Windows.Forms;

namespace StreetChildrenCareSystem.Forms
{
    public partial class frmAdminDashboard : Form
    {
        private string loggedUserID;

        public frmAdminDashboard(string userID)
        {
            InitializeComponent();
            loggedUserID = userID;
            lblWelcome.Text = "Welcome: " + userID;
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardCounts();
        }

        private void LoadDashboardCounts()
        {
            try
            {
                DataTable dtC = DBHelper.GetData("SELECT COUNT(*) AS Total FROM Children");
                lblChildCount.Text = dtC.Rows[0]["Total"].ToString();

                DataTable dtO = DBHelper.GetData("SELECT COUNT(*) AS Total FROM Orphanages");
                lblOrpCount.Text = dtO.Rows[0]["Total"].ToString();

                DataTable dtF = DBHelper.GetData("SELECT COUNT(*) AS Total FROM Foundations");
                lblFouCount.Text = dtF.Rows[0]["Total"].ToString();

                DataTable dtV = DBHelper.GetData(
                    "SELECT COUNT(*) AS Total FROM Vaccinations WHERE VacStatus = 'Overdue'");
                lblOverdueCount.Text = dtV.Rows[0]["Total"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnChildren_Click(object sender, EventArgs e)
        {
            frmChildren f = new frmChildren("Admin", loggedUserID);
            f.Show();
        }

        private void btnOrphanage_Click(object sender, EventArgs e)
        {
            // TODO: frmOrphanage তৈরি হলে এই comment সরাও
            MessageBox.Show("Coming Soon! (Being developed by team member)", "Info");
        }

        private void btnFoundation_Click(object sender, EventArgs e)
        {
            // TODO: frmFoundation তৈরি হলে এই comment সরাও
            MessageBox.Show("Coming Soon! (Being developed by team member)", "Info");
        }

        private void btnVaccination_Click(object sender, EventArgs e)
        {
            // TODO: frmVaccination তৈরি হলে এই comment সরাও
            MessageBox.Show("Coming Soon! (Being developed by team member)", "Info");
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            // TODO: frmManageUsers তৈরি হলে এই comment সরাও
            MessageBox.Show("Coming Soon! (Being developed by team member)", "Info");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}






/*using System;
using System.Data;
using System.Windows.Forms;
using StreetChildrenCareSystem.Forms; 

namespace StreetChildrenCareSystem.Forms
{
    public partial class frmAdminDashboard : Form
    {
        private string loggedUserID;

        public frmAdminDashboard(string userID)
        {
            InitializeComponent();
            loggedUserID = userID;
            lblWelcome.Text = "Welcome: " + userID;
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardCounts();
        }

        private void LoadDashboardCounts()
        {
            try
            {
                DataTable dtC = DBHelper.GetData("SELECT COUNT(*) AS Total FROM Children");
                lblChildCount.Text = dtC.Rows[0]["Total"].ToString();

                DataTable dtO = DBHelper.GetData("SELECT COUNT(*) AS Total FROM Orphanages");
                lblOrpCount.Text = dtO.Rows[0]["Total"].ToString();

                DataTable dtF = DBHelper.GetData("SELECT COUNT(*) AS Total FROM Foundations");
                lblFouCount.Text = dtF.Rows[0]["Total"].ToString();

                DataTable dtV = DBHelper.GetData(
                    "SELECT COUNT(*) AS Total FROM Vaccinations WHERE VacStatus = 'Overdue'");
                lblOverdueCount.Text = dtV.Rows[0]["Total"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnChildren_Click(object sender, EventArgs e)
        {
            frmChildren f = new frmChildren("Admin", loggedUserID);
            f.Show();
        }

        private void btnOrphanage_Click(object sender, EventArgs e)
        {
            frmOrphanage f = new frmOrphanage("Admin", loggedUserID);
            f.Show();
        }

        private void btnFoundation_Click(object sender, EventArgs e)
        {
            frmFoundation f = new frmFoundation("Admin", loggedUserID);
            f.Show();
        }

        private void btnVaccination_Click(object sender, EventArgs e)
        {
            frmVaccination f = new frmVaccination("Admin", loggedUserID);
            f.Show();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers f = new frmManageUsers();
            f.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}*/







/*using System;
using System.Data;
using System.Windows.Forms;

namespace StreetChildrenCareSystem.Forms
{
    public partial class frmAdminDashboard : Form
    {
        private string loggedUserID;

        public frmAdminDashboard(string userID)
        {
            InitializeComponent();
            loggedUserID = userID;
            lblWelcome.Text = "Welcome: " + userID;
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardCounts();
        }

        private void LoadDashboardCounts()
        {
            try
            {
                DataTable dtC = DBHelper.GetData("SELECT COUNT(*) AS Total FROM Children");
                lblChildCount.Text = dtC.Rows[0]["Total"].ToString();

                DataTable dtO = DBHelper.GetData("SELECT COUNT(*) AS Total FROM Orphanages");
                lblOrpCount.Text = dtO.Rows[0]["Total"].ToString();

                DataTable dtF = DBHelper.GetData("SELECT COUNT(*) AS Total FROM Foundations");
                lblFouCount.Text = dtF.Rows[0]["Total"].ToString();

                DataTable dtV = DBHelper.GetData(
                    "SELECT COUNT(*) AS Total FROM Vaccinations WHERE VacStatus = 'Overdue'");
                lblOverdueCount.Text = dtV.Rows[0]["Total"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnChildren_Click(object sender, EventArgs e)
        {
            frmChildren f = new frmChildren("Admin", loggedUserID);
            f.Show();
        }

        private void btnOrphanage_Click(object sender, EventArgs e)
        {
            frmOrphanage f = new frmOrphanage("Admin", loggedUserID);
            f.Show();
        }

        private void btnFoundation_Click(object sender, EventArgs e)
        {
            frmFoundation f = new frmFoundation("Admin", loggedUserID);
            f.Show();
        }

        private void btnVaccination_Click(object sender, EventArgs e)
        {
            frmVaccination f = new frmVaccination("Admin", loggedUserID);
            f.Show();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers f = new frmManageUsers();
            f.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }

   
        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}
*/





/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreetChildrenCareSystem.Forms
{
    public partial class frmAdminDashboard : Form
    {
        private string loggedUserID; 
        public frmAdminDashboard(string userID)
        {
            InitializeComponent();
            loggedUserID = userID;
            lblWelcome.Text = "Welcome: " + userID;
        }
       /* public frmAdminDashboard(string userID)
        {
            InitializeComponent();
        }
       */
/*       private void frmAdminDashboard_Load(object sender, EventArgs e)
       {
           LoadDashboardCounts();
       }

       private void LoadDashboardCounts()
       {
           try
           {
               // Children Count
               DataTable dtC =
                   DBHelper.GetData(
                   "SELECT COUNT(*) AS Total" +
                   " FROM Children");
               lblChildCount.Text =
                   dtC.Rows[0]["Total"]
                   .ToString();

               // Orphanage Count
               DataTable dtO =
                   DBHelper.GetData(
                   "SELECT COUNT(*) AS Total" +
                   " FROM Orphanages");
               lblOrpCount.Text =
                   dtO.Rows[0]["Total"]
                   .ToString();

               // Foundation Count
               DataTable dtF =
                   DBHelper.GetData(
                   "SELECT COUNT(*) AS Total" +
                   " FROM Foundations");
               lblFouCount.Text =
                   dtF.Rows[0]["Total"]
                   .ToString();

               // Overdue Vaccination Count
               DataTable dtV =
                   DBHelper.GetData(
                   "SELECT COUNT(*) AS Total" +
                   " FROM Vaccinations" +
                   " WHERE VacStatus=" +
                   "'Overdue'");
               lblOverdueCount.Text =
                   dtV.Rows[0]["Total"]
                   .ToString();
           }
           catch (Exception ex)
           {
               MessageBox.Show(
                   "Error: " + ex.Message);
           }
       }

       private void btnChildren_Click(
           object sender, EventArgs e)
       {
           frmChildren f =
               new frmChildren(
               "Admin", loggedUserID);
           f.Show();
       }

       private void btnOrphanage_Click(
           object sender, EventArgs e)
       {
           frmOrphanage f =
               new frmOrphanage(
               "Admin", loggedUserID);
           f.Show();
       }

       private void btnFoundation_Click(
           object sender, EventArgs e)
       {
           frmFoundation f =
               new frmFoundation(
               "Admin", loggedUserID);
           f.Show();
       }

       private void btnVaccination_Click(
           object sender, EventArgs e)
       {
           frmVaccination f =
               new frmVaccination(
               "Admin", loggedUserID);
           f.Show();
       }

       private void btnManageUsers_Click(
           object sender, EventArgs e)
       {
           frmManageUsers f =
               new frmManageUsers();
           f.Show();
       }

       private void btnLogout_Click(
           object sender, EventArgs e)
       {
           DialogResult result =
               MessageBox.Show(
               "Are you sure to logout?",
               "Logout",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

           if (result == DialogResult.Yes)
           {
               frmLogin login =
                   new frmLogin();
               login.Show();
               this.Close();
           }
       }
}

       private void label4_Click(object sender, EventArgs e)
       {

       }
   }
}
*/