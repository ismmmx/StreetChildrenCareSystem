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
            this.Text = "frmStaffDashboard"; // set the title bar text
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
            // Open Children form and hide the dashboard (don't close it)
            frmChildren f = new frmChildren("Staff", loggedUserID);
            f.Show();
            this.Hide(); // Hide dashboard so it can be shown again when Home is clicked
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
        private void btnViewOrphanage_Click(object sender, EventArgs e)
        {
            // Staff can view Orphanage in read-only mode
            frmOrphanage f = new frmOrphanage("Staff", loggedUserID);
            f.Show();
            this.Hide();
        }

        private void btnViewVaccination_Click(object sender, EventArgs e)
        {
            // Staff can view Vaccination records in read-only mode
            frmVaccination f = new frmVaccination("Staff");
            f.Show();
            this.Hide();
        }
        private void btnViewFoundation_Click(object sender, EventArgs e)
        {
            // Staff can view Foundation in read-only mode
            frmFoundation f = new frmFoundation("Staff", loggedUserID);
            f.Show();
            this.Hide();
        }


    }
}



