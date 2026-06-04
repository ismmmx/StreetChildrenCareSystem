using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreetChildrenCareSystem.Forms
{
    public partial class frmManageUsers : Form
    {
        private string selectedUserID = "";

        // Constructor: only Admin can open this form
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            // Role options for new users
            cmbUserRole.Items.Add("Admin");
            cmbUserRole.Items.Add("Staff");
            cmbUserRole.SelectedIndex = 0;

            // Sort options
            cmbSort.Items.Add("Sort by Role");
            cmbSort.Items.Add("Sort by UserID");
            cmbSort.SelectedIndex = 0;

            LoadUsers();
            dgvUsers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Load all users from database
        private void LoadUsers()
        {
            DataTable dt = DBHelper.GetData(
                "SELECT UserID, Password, UserRole" +
                " FROM Users ORDER BY UserRole ASC");
            dgvUsers.DataSource = dt;
        }

        // Save new user
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                MessageBox.Show("User ID is required!");
                txtUserID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required!");
                txtPassword.Focus();
                return;
            }

            // Check if UserID already exists
            DataTable check = DBHelper.GetData(
                "SELECT UserID FROM Users WHERE UserID = @uid",
                new SqlParameter[] { new SqlParameter("@uid", txtUserID.Text.Trim()) });

            if (check.Rows.Count > 0)
            {
                MessageBox.Show("This User ID already exists! Choose a different one.");
                txtUserID.Focus();
                return;
            }

            string query =
                "INSERT INTO Users (UserID, Password, UserRole)" +
                " VALUES (@uid, @pass, @role)";

            SqlParameter[] p =
            {
                new SqlParameter("@uid",  txtUserID.Text.Trim()),
                new SqlParameter("@pass", txtPassword.Text.Trim()),
                new SqlParameter("@role", cmbUserRole.Text)
            };

            if (DBHelper.ExecuteQuery(query, p))
            {
                MessageBox.Show("User Added Successfully ✅");
                ClearForm();
                LoadUsers();
            }
        }

        // Clicking a row fills the fields
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                selectedUserID = row.Cells["UserID"].Value.ToString();
                txtUserID.Text = selectedUserID;
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                cmbUserRole.Text = row.Cells["UserRole"].Value.ToString();
            }
        }

        // Delete selected user
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedUserID))
            {
                MessageBox.Show("Please select a User first!");
                return;
            }

            // Protect the main admin account from being deleted
            if (selectedUserID.ToLower() == "admin01" ||
                selectedUserID.ToLower() == "admin")
            {
                MessageBox.Show(
                    "Cannot delete the main Admin account!",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Delete User: " + selectedUserID + "?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                if (DBHelper.ExecuteQuery(
                    "DELETE FROM Users WHERE UserID = @uid",
                    new SqlParameter[] { new SqlParameter("@uid", selectedUserID) }))
                {
                    MessageBox.Show("User Deleted ✅");
                    ClearForm();
                    LoadUsers();
                }
            }
        }

        // Search by UserID or Role
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();

            // If search box is empty, reload all users
            if (string.IsNullOrEmpty(kw))
            {
                LoadUsers();
                return;
            }

            DataTable dt = DBHelper.GetData(
                "SELECT UserID, Password, UserRole FROM Users" +
                " WHERE UserID LIKE @kw OR UserRole LIKE @kw",
                new SqlParameter[] { new SqlParameter("@kw", "%" + kw + "%") });

            dgvUsers.DataSource = dt;

            if (dt.Rows.Count == 0)
                MessageBox.Show("No users found matching: " + kw);
        }

        // Sort the list
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ignore if nothing is selected yet
            if (string.IsNullOrEmpty(cmbSort.Text)) return;

            string sortBy = "";

            if (cmbSort.Text == "Sort by Role")
                sortBy = "UserRole ASC";
            else if (cmbSort.Text == "Sort by UserID")
                sortBy = "UserID ASC";

            if (sortBy == "") return;

            DataTable dt = DBHelper.GetData(
                "SELECT UserID, Password, UserRole" +
                " FROM Users ORDER BY " + sortBy);

            dgvUsers.DataSource = dt;
        }

        // Clear all input fields
        private void ClearForm()
        {
            txtUserID.Clear();
            txtPassword.Clear();
            txtSearch.Clear();
            cmbUserRole.SelectedIndex = 0;
            selectedUserID = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadUsers();
        }

        // Home: show the hidden dashboard and close this form
        private void btnHome_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is frmAdminDashboard)
                {
                    openForm.Show();
                    break;
                }
            }
            this.Close();
        }

        // Back: same as Home for this form
        private void btnBack_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is frmAdminDashboard)
                {
                    openForm.Show();
                    break;
                }
            }
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form dashboardForm = null;
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is frmAdminDashboard || openForm is frmStaffDashboard)
                        dashboardForm = openForm;
                }
                if (dashboardForm != null) dashboardForm.Close();

                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }
    }
}

