using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StreetChildrenCareSystem.Forms
{
    public partial class frmChildren : Form
    {
        private string userRole;
        private string userID;
        private int selectedChildID = 0;

        public frmChildren(string role, string uid)
        {
            InitializeComponent();
            userRole = role;
            userID = uid;
        }

        private void frmChildren_Load(object sender, EventArgs e)
        {

            SetPermissions();
            LoadOrphanageCombo();
            LoadFoundationCombo();
            LoadChildren();

            dgvChildren.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetPermissions()
        {
            if (userRole == "Staff")
            {
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnClear.Visible = false;
                txtChildName.ReadOnly = true;
                numAge.Enabled = false;
                cmbGender.Enabled = false;
                txtLocation.ReadOnly = true;
                cmbStatus.Enabled = false;
                cmbOrphanage.Enabled = false;
                cmbFoundation.Enabled = false;
            }
        }

        private void LoadOrphanageCombo()
        {
            // 1. Fetch the data from the database
            DataTable dt = DBHelper.GetData("SELECT OrpID, OrpName FROM Orphanages");

            // 2. Create a new dummy row with the same structure as the table
            DataRow dr = dt.NewRow();
            dr["OrpID"] = 0;              // Use 0 as the ID for 'None'
            dr["OrpName"] = "-- None --"; // The text the user will see

            // 3. Insert this row at the very top (index 0)
            dt.Rows.InsertAt(dr, 0);

            // 4. Bind to the ComboBox
            cmbOrphanage.DisplayMember = "OrpName";
            cmbOrphanage.ValueMember = "OrpID";
            cmbOrphanage.DataSource = dt;


        }

        private void LoadFoundationCombo()
        {
            DataTable dt = DBHelper.GetData("SELECT FouID, FouName FROM Foundations");

            DataRow dr = dt.NewRow();
            dr["FouID"] = 0;
            dr["FouName"] = "-- None --";
            dt.Rows.InsertAt(dr, 0);

            cmbFoundation.DisplayMember = "FouName";
            cmbFoundation.ValueMember = "FouID";
            cmbFoundation.DataSource = dt;


        }

        private void LoadChildren()
        {
            string query =
                "SELECT C.ChildID, C.ChildName, C.Age, C.Gender," +
                " C.FoundLocation, C.ChildStatus, O.OrpName, F.FouName" +
                " FROM Children C" +
                " LEFT JOIN Orphanages O ON C.OrpID = O.OrpID" +
                " LEFT JOIN Foundations F ON C.FouID = F.FouID";

            DataTable dt = DBHelper.GetData(query);
            dgvChildren.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            string query =
                "SELECT C.ChildID, C.ChildName, C.Age, C.Gender," +
                " C.ChildStatus, O.OrpName, F.FouName" +
                " FROM Children C" +
                " LEFT JOIN Orphanages O ON C.OrpID = O.OrpID" +
                " LEFT JOIN Foundations F ON C.FouID = F.FouID" +
                " WHERE C.ChildName LIKE @keyword OR C.ChildStatus LIKE @keyword";

            SqlParameter[] p = { new SqlParameter("@keyword", "%" + keyword + "%") };

            DataTable dt = DBHelper.GetData(query, p);
            dgvChildren.DataSource = dt;
        }


        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortBy = "";

            if (cmbSort.Text == "Sort by Name")
                sortBy = "C.ChildName ASC";
            else if (cmbSort.Text == "Sort by Status")
                sortBy = "C.ChildStatus ASC";
            else if (cmbSort.Text == "Sort by Age")
                sortBy = "C.Age ASC";

            if (sortBy == "") return;

            string query =
                "SELECT C.ChildID, C.ChildName, C.Age, C.Gender," +
                " C.ChildStatus, O.OrpName, F.FouName" +
                " FROM Children C" +
                " LEFT JOIN Orphanages O ON C.OrpID = O.OrpID" +
                " LEFT JOIN Foundations F ON C.FouID = F.FouID" +
                " ORDER BY " + sortBy;

            DataTable dt = DBHelper.GetData(query);
            dgvChildren.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtChildName.Text))
            {
                MessageBox.Show("Child Name required!");
                return;
            }

            string query =
                "INSERT INTO Children (ChildName, Age, Gender," +
                " FoundLocation, ChildStatus, OrpID, FouID)" +
                " VALUES (@name, @age, @gender, @loc, @status, @orp, @fou)";

            object orpIdParam = (int)cmbOrphanage.SelectedValue == 0 ? DBNull.Value : cmbOrphanage.SelectedValue;
            object fouIdParam = (int)cmbFoundation.SelectedValue == 0 ? DBNull.Value : cmbFoundation.SelectedValue;

            SqlParameter[] p =
            {
                new SqlParameter("@name", txtChildName.Text.Trim()),
                new SqlParameter("@age", (int)numAge.Value),
                new SqlParameter("@gender", cmbGender.Text),
                new SqlParameter("@loc", txtLocation.Text.Trim()),
                new SqlParameter("@status", cmbStatus.Text),
                new SqlParameter("@orp", orpIdParam), // Correctly handles NULL
                new SqlParameter("@fou", fouIdParam)  // Correctly handles NULL
};



            bool result = DBHelper.ExecuteQuery(query, p);
            if (result)
            {
                MessageBox.Show("Child Saved ✅");
                ClearForm();
                LoadChildren();
            }
        }

        private void dgvChildren_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChildren.Rows[e.RowIndex];


                if (row.Cells["ChildID"].Value != DBNull.Value && row.Cells["ChildID"].Value != null)
                {
                    selectedChildID = Convert.ToInt32(row.Cells["ChildID"].Value);
                }
                else
                {
                    selectedChildID = 0;
                }


                txtChildName.Text = Convert.ToString(row.Cells["ChildName"].Value);


                if (row.Cells["Age"].Value != DBNull.Value && row.Cells["Age"].Value != null)
                {
                    numAge.Value = Convert.ToDecimal(row.Cells["Age"].Value);
                }
                else
                {
                    numAge.Value = 0;
                }

                // ৪. Orphanage ComboBox 
                string orpName = Convert.ToString(row.Cells["OrpName"].Value);
                cmbOrphanage.Text = string.IsNullOrEmpty(orpName) ? "-- None --" : orpName;

                // ৫. Foundation ComboBox 
                string fouName = Convert.ToString(row.Cells["FouName"].Value);
                cmbFoundation.Text = string.IsNullOrEmpty(fouName) ? "-- None --" : fouName;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedChildID == 0)
            {
                MessageBox.Show("Please select a child!");
                return;
            }

            string query =
                "UPDATE Children SET ChildName = @name, Age = @age," +
                " Gender = @gender, FoundLocation = @loc," +
                " ChildStatus = @status, OrpID = @orp, FouID = @fou" +
                " WHERE ChildID = @id";

            // Logic to handle Nulls for Orphanage and Foundation
            object orpIdValue = (int)cmbOrphanage.SelectedValue == 0 ? DBNull.Value : cmbOrphanage.SelectedValue;
            object fouIdValue = (int)cmbFoundation.SelectedValue == 0 ? DBNull.Value : cmbFoundation.SelectedValue;

            SqlParameter[] p =
            {
                new SqlParameter("@name", txtChildName.Text.Trim()),
                new SqlParameter("@age", (int)numAge.Value),
                new SqlParameter("@gender", cmbGender.Text),
                new SqlParameter("@loc", txtLocation.Text.Trim()),
                new SqlParameter("@status", cmbStatus.Text),
                new SqlParameter("@orp", orpIdValue), // Uses DBNull if 0
                new SqlParameter("@fou", fouIdValue), // Uses DBNull if 0
                // If it's the update button, don't forget the ID:
                 new SqlParameter("@id", selectedChildID)
            };



            bool result = DBHelper.ExecuteQuery(query, p);
            if (result)
            {
                MessageBox.Show("Updated Successfully ✅");
                ClearForm();
                LoadChildren();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedChildID == 0)
            {
                MessageBox.Show("Please select a child!");
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Are you sure to delete?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                DBHelper.ExecuteQuery(
                    "DELETE FROM Vaccinations WHERE ChildID = @id",
                    new SqlParameter[] { new SqlParameter("@id", selectedChildID) });

                bool result = DBHelper.ExecuteQuery(
                    "DELETE FROM Children WHERE ChildID = @id",
                    new SqlParameter[] { new SqlParameter("@id", selectedChildID) });

                if (result)
                {
                    MessageBox.Show("Deleted Successfully ✅");
                    ClearForm();
                    LoadChildren();
                }
            }
        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            if (selectedChildID == 0)
            {
                MessageBox.Show("Please select a child!");
                return;
            }

            // Create the profile form with all 3 required values
            frmChildProfile f = new frmChildProfile(selectedChildID, userRole, userID);
            f.Show();

            // Only hide this form if profile form is actually visible and open
            if (f.Visible)
            {
                this.Hide();
            }

        }

        private void ClearForm()
        {
            txtChildName.Clear();
            numAge.Value = 1;
            txtLocation.Clear();
            cmbGender.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            selectedChildID = 0;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Find the hidden dashboard form and show it
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is frmAdminDashboard || openForm is frmStaffDashboard)
                {
                    openForm.Show(); // Show the dashboard that was hidden
                    break;
                }
            }
            this.Close(); // Close frmChildren
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Back button does the same as Home in this form (goes to Dashboard)
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is frmAdminDashboard || openForm is frmStaffDashboard)
                {
                    openForm.Show(); // Show the dashboard that was hidden
                    break;
                }
            }
            this.Close(); // Close frmChildren
        }

        // Public method so frmChildProfile can call it to refresh the list after delete
        public void RefreshChildList()
        {
            LoadChildren();
            ClearForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all input fields and reload the full list
            ClearForm();
            LoadChildren();
        }

        private void dgvChildren_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}