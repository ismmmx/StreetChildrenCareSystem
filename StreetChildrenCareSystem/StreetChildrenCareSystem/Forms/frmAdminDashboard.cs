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
                DataTable dtC = DBHelper.GetData(
                    "SELECT COUNT(*) AS Total FROM Children");
                lblChildCount.Text = dtC.Rows[0]["Total"].ToString();

                DataTable dtO = DBHelper.GetData(
                    "SELECT COUNT(*) AS Total FROM Orphanages");
                lblOrpCount.Text = dtO.Rows[0]["Total"].ToString();

                DataTable dtF = DBHelper.GetData(
                    "SELECT COUNT(*) AS Total FROM Foundations");
                lblFouCount.Text = dtF.Rows[0]["Total"].ToString();

                DataTable dtV = DBHelper.GetData(
                    "SELECT COUNT(*) AS Total FROM Vaccinations" +
                    " WHERE VacStatus = 'Overdue'");
                lblOverdueCount.Text = dtV.Rows[0]["Total"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnChildren_Click(object sender, EventArgs e)
        {
            // Open Children form and hide the dashboard (don't close it)
            frmChildren f = new frmChildren("Admin", loggedUserID);
            f.Show();
            this.Hide(); // Hide dashboard so it can be shown again when Home is clicked
        }

        private void btnOrphanage_Click(object sender, EventArgs e)
        {
            // Open Orphanage form and hide dashboard
            frmOrphanage f = new frmOrphanage("Admin", loggedUserID);
            f.Show();
            this.Hide();
        }

        private void btnFoundation_Click(object sender, EventArgs e)
        {
            // Open Foundation form and hide dashboard
            frmFoundation f = new frmFoundation("Admin", loggedUserID);
            f.Show();
            this.Hide();
        }

        private void btnVaccination_Click(object sender, EventArgs e)
        {
            // Open Vaccination form and hide dashboard
            frmVaccination f = new frmVaccination("Admin");
            f.Show();
            this.Hide();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            // Open Manage Users form and hide dashboard (Admin only)
            frmManageUsers f = new frmManageUsers();
            f.Show();
            this.Hide();
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
         } */

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}



