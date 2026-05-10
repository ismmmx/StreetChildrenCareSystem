using System;
using System.Data;
using System.Windows.Forms;

namespace StreetChildrenCareSystem.Forms
{
    public partial class frmStaffDashboard : Form
    {
        private string loggedUserID;

        public frmStaffDashboard(string userID)
        {
            InitializeComponent();
            loggedUserID = userID;
            lblWelcome.Text = "Welcome: " + userID;
        }

        private void frmStaffDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardCounts();
        }

        private void LoadDashboardCounts()
        {
            try
            {
                DataTable dtC = DBHelper.GetData(
                    "SELECT COUNT(*) AS Total FROM Children");
                if (dtC.Rows.Count > 0)
                    lblChildCount.Text = dtC.Rows[0]["Total"].ToString();

                DataTable dtO = DBHelper.GetData(
                    "SELECT COUNT(*) AS Total FROM Orphanages");
                if (dtO.Rows.Count > 0)
                    lblOrpCount.Text = dtO.Rows[0]["Total"].ToString();

                DataTable dtF = DBHelper.GetData(
                    "SELECT COUNT(*) AS Total FROM Foundations");
                if (dtF.Rows.Count > 0)
                    lblFouCount.Text = dtF.Rows[0]["Total"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message);
            }
        }

        private void btnViewChildren_Click(object sender, EventArgs e)
        {
            frmChildren f = new frmChildren("Staff", loggedUserID);
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

       /* private void btnSwitchUser_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }*/
    }
}




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
    public partial class frmStaffDashboard : Form
    {
        private string loggedUserID;

        // Constructor to receive the User ID from Login form
        public frmStaffDashboard(string userID)
        {
            InitializeComponent();
            loggedUserID = userID;

            // Setting the welcome message
            lblWelcome.Text = "Welcome: " + userID;
        }

        // This event runs when the form opens
        private void frmStaffDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardCounts();
        }

        // Method to fetch and show total counts from database
        private void LoadDashboardCounts()
        {
            try
            {
                // Get total count of Children
                DataTable dtC = DBHelper.GetData("SELECT COUNT(*) AS Total FROM Children");
                if (dtC.Rows.Count > 0)
                    lblChildCount.Text = dtC.Rows[0]["Total"].ToString();

                // Get total count of Orphanages
                DataTable dtO = DBHelper.GetData("SELECT COUNT(*) AS Total FROM Orphanages");
                if (dtO.Rows.Count > 0)
                    lblOrpCount.Text = dtO.Rows[0]["Total"].ToString();

                // Get total count of Foundations
                DataTable dtF = DBHelper.GetData("SELECT COUNT(*) AS Total FROM Foundations");
                if (dtF.Rows.Count > 0)
                    lblFouCount.Text = dtF.Rows[0]["Total"].ToString();
            }
            catch (Exception ex)
            {
                // Show error if database connection fails
                MessageBox.Show("Error loading statistics: " + ex.Message);
            }
        }

        private void btnViewChildren_Click(object sender, EventArgs e)
        {
            // Opening the Children form with 'Staff' role (Read-Only access)
            frmChildren f = new frmChildren("Staff", loggedUserID);
            f.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Asking for logout confirmation
            DialogResult result = MessageBox.Show(
                "Are you sure to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Redirecting back to Login form
                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }
    }
} */

/*   public partial class frmStaffDashboard : Form
   {
       public frmStaffDashboard(string userID)
       {
           InitializeComponent();
       }

       private void frmStaffDashboard_Load(object sender, EventArgs e)
       {

       }
   }
}
*/