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
    public partial class frmOrphanage : Form
    {
        private string userRole;
        private string userID;
        private int selectedOrpID = 0;

        // Constructor: receives role and userID from dashboard
        public frmOrphanage(string role, string uid)
        {
            InitializeComponent();
            userRole = role;
            userID = uid;
        }

        private void frmOrphanage_Load(object sender, EventArgs e)
        {
            SetPermissions();
            LoadOrphanages();
            dgvOrphanage.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Add sort options to combo box
            cmbSort.Items.Add("Sort by Name");
            cmbSort.Items.Add("Sort by Location");
            cmbSort.SelectedIndex = 0;
        }

        // Admin sees all buttons; Staff gets view-only
        private void SetPermissions()
        {
            if (userRole == "Staff")
            {
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnClear.Visible = false;
                txtOrpName.ReadOnly = true;
                txtLocation.ReadOnly = true;
                txtONumber.ReadOnly = true;
            }
        }

        // Load all orphanages from database
        private void LoadOrphanages()
        {
            string query =
                "SELECT OrpID, OrpName, OrpLocation, OrpNumber" +
                " FROM Orphanages ORDER BY OrpName ASC";

            DataTable dt = DBHelper.GetData(query);
            dgvOrphanage.DataSource = dt;
        }

        // Save new orphanage (Admin only)
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrpName.Text))
            {
                MessageBox.Show("Orphanage Name is required!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOrpName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Location is required!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtONumber.Text))
            {
                MessageBox.Show("Contact Number is required!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtONumber.Focus();
                return;
            }

            string query =
                "INSERT INTO Orphanages (OrpName, OrpLocation, OrpNumber)" +
                " VALUES (@name, @loc, @num)";

            SqlParameter[] p =
            {
                new SqlParameter("@name", txtOrpName.Text.Trim()),
                new SqlParameter("@loc",  txtLocation.Text.Trim()),
                new SqlParameter("@num",  txtONumber.Text.Trim())
            };

            if (DBHelper.ExecuteQuery(query, p))
            {
                MessageBox.Show("Orphanage Saved ✅", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadOrphanages();
            }
        }

        // Clicking a row fills the form fields
        private void dgvOrphanage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOrphanage.Rows[e.RowIndex];
                selectedOrpID = Convert.ToInt32(row.Cells["OrpID"].Value);
                txtOrpName.Text = row.Cells["OrpName"].Value.ToString();
                txtLocation.Text = row.Cells["OrpLocation"].Value.ToString();
                txtONumber.Text = row.Cells["OrpNumber"].Value.ToString();
            }
        }

        // Update selected orphanage (Admin only)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedOrpID == 0)
            {
                MessageBox.Show("Please select an Orphanage first!");
                return;
            }

            string query =
                "UPDATE Orphanages SET OrpName = @name," +
                " OrpLocation = @loc, OrpNumber = @num" +
                " WHERE OrpID = @id";

            SqlParameter[] p =
            {
                new SqlParameter("@name", txtOrpName.Text.Trim()),
                new SqlParameter("@loc",  txtLocation.Text.Trim()),
                new SqlParameter("@num",  txtONumber.Text.Trim()),
                new SqlParameter("@id",   selectedOrpID)
            };

            if (DBHelper.ExecuteQuery(query, p))
            {
                MessageBox.Show("Updated Successfully ✅");
                ClearForm();
                LoadOrphanages();
            }
        }

        // Delete selected orphanage (Admin only)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedOrpID == 0)
            {
                MessageBox.Show("Please select an Orphanage first!");
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Are you sure to delete this Orphanage?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                if (DBHelper.ExecuteQuery(
                    "DELETE FROM Orphanages WHERE OrpID = @id",
                    new SqlParameter[] { new SqlParameter("@id", selectedOrpID) }))
                {
                    MessageBox.Show("Deleted Successfully ✅");
                    ClearForm();
                    LoadOrphanages();
                }
            }
        }

        // Search by name or location
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            string query =
                "SELECT OrpID, OrpName, OrpLocation, OrpNumber" +
                " FROM Orphanages" +
                " WHERE OrpName LIKE @kw OR OrpLocation LIKE @kw";

            SqlParameter[] p =
            {
                new SqlParameter("@kw", "%" + keyword + "%")
            };

            DataTable dt = DBHelper.GetData(query, p);
            dgvOrphanage.DataSource = dt;
        }

        // Sort the list
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortBy = "";

            if (cmbSort.Text == "Sort by Name")
                sortBy = "OrpName ASC";
            else if (cmbSort.Text == "Sort by Location")
                sortBy = "OrpLocation ASC";

            if (sortBy == "") return;

            DataTable dt = DBHelper.GetData(
                "SELECT OrpID, OrpName, OrpLocation, OrpNumber" +
                " FROM Orphanages ORDER BY " + sortBy);

            dgvOrphanage.DataSource = dt;
        }

        // Clear all input fields
        private void ClearForm()
        {
            txtOrpName.Clear();
            txtLocation.Clear();
            txtONumber.Clear();
            txtSearch.Clear();
            selectedOrpID = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadOrphanages();
        }

        // Home: show the hidden dashboard and close this form
        private void btnHome_Click(object sender, EventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is frmAdminDashboard || openForm is frmStaffDashboard)
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
                if (openForm is frmAdminDashboard || openForm is frmStaffDashboard)
                {
                    openForm.Show();
                    break;
                }
            }
            this.Close();
        }

        // Logout: confirm and go to login screen
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

