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
           /* try
            {
                // Load all data when form opens
                SetPermissions();
                LoadProfile();
                LoadVaccinations();
            }
            catch (Exception ex)
            {
                // If any error happens, show the message so we can see what went wrong
                MessageBox.Show("Error loading profile: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Close this form if data could not load
            } */

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

            /* DataTable dt = DBHelper.GetData("SELECT OrpID, OrpName FROM Orphanages");
            cmbOrphanage.DisplayMember = "OrpName";
            cmbOrphanage.ValueMember = "OrpID";
            cmbOrphanage.DataSource = dt; */
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

            /* DataTable dt = DBHelper.GetData("SELECT FouID, FouName FROM Foundations");
            cmbFoundation.DisplayMember = "FouName";
            cmbFoundation.ValueMember = "FouID";
            cmbFoundation.DataSource = dt; */
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

            /* SqlParameter[] p =
             {
                 new SqlParameter("@name", txtChildName.Text.Trim()),
                 new SqlParameter("@age", (int)numAge.Value),
                 new SqlParameter("@gender", cmbGender.Text),
                 new SqlParameter("@loc", txtLocation.Text.Trim()),
                 new SqlParameter("@status", cmbStatus.Text),
                 new SqlParameter("@orp", cmbOrphanage.SelectedValue),
                 new SqlParameter("@fou", cmbFoundation.SelectedValue)
             }; */

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

            // নিশ্চিত হওয়া যে ব্যবহারকারী হেডার বাদ দিয়ে একটি সঠিক ডাটা রো-তে ক্লিক করেছেন
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChildren.Rows[e.RowIndex];

                // ১. ChildID চেক করা : ডাটাবেজে এটি DBNull হলে ডিফল্ট ০ বসবে
                if (row.Cells["ChildID"].Value != DBNull.Value && row.Cells["ChildID"].Value != null)
                {
                    selectedChildID = Convert.ToInt32(row.Cells["ChildID"].Value);
                }
                else
                {
                    selectedChildID = 0; // কোনো আইডি না থাকলে ০ সেট হবে
                }

                // ২. ChildName চেক করা: Convert.ToString ব্যবহার করলে null থাকলেও ক্র্যাশ করবে না
                txtChildName.Text = Convert.ToString(row.Cells["ChildName"].Value);

                // ৩. Age চেক করা: বয়স ফাকা থাকলে যেন ক্র্যাশ না করে
                if (row.Cells["Age"].Value != DBNull.Value && row.Cells["Age"].Value != null)
                {
                    numAge.Value = Convert.ToDecimal(row.Cells["Age"].Value);
                }
                else
                {
                    numAge.Value = 0; // বয়স ফাকা থাকলে ডিফল্ট ০
                }

                // ৪. Orphanage ComboBox প্রদর্শন হ্যান্ডেল করা
                string orpName = Convert.ToString(row.Cells["OrpName"].Value);
                cmbOrphanage.Text = string.IsNullOrEmpty(orpName) ? "-- None --" : orpName;

                // ৫. Foundation ComboBox প্রদর্শন হ্যান্ডেল করা
                string fouName = Convert.ToString(row.Cells["FouName"].Value);
                cmbFoundation.Text = string.IsNullOrEmpty(fouName) ? "-- None --" : fouName;
            }


            /* if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChildren.Rows[e.RowIndex];
                selectedChildID = Convert.ToInt32(row.Cells["ChildID"].Value);
                txtChildName.Text = row.Cells["ChildName"].Value.ToString();
                numAge.Value = Convert.ToDecimal(row.Cells["Age"].Value);

                // Handle Orphanage ComboBox display
                string orpName = row.Cells["OrpName"].Value.ToString();
                cmbOrphanage.Text = string.IsNullOrEmpty(orpName) ? "-- None --" : orpName;

                // Handle Foundation ComboBox display
                string fouName = row.Cells["FouName"].Value.ToString();
                cmbFoundation.Text = string.IsNullOrEmpty(fouName) ? "-- None --" : fouName;
            } */
            /*if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChildren.Rows[e.RowIndex];
                selectedChildID = Convert.ToInt32(row.Cells["ChildID"].Value);
                txtChildName.Text = row.Cells["ChildName"].Value.ToString();
                numAge.Value = Convert.ToDecimal(row.Cells["Age"].Value);
            } */
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

            /*SqlParameter[] p =
            {
                new SqlParameter("@name", txtChildName.Text.Trim()),
                new SqlParameter("@age", (int)numAge.Value),
                new SqlParameter("@gender", cmbGender.Text),
                new SqlParameter("@loc", txtLocation.Text.Trim()),
                new SqlParameter("@status", cmbStatus.Text),
                new SqlParameter("@orp", cmbOrphanage.SelectedValue),
                new SqlParameter("@fou", cmbFoundation.SelectedValue),
                new SqlParameter("@id", selectedChildID)
            }; */

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
            // This prevents the "everything vanishes" bug
            if (f.Visible)
            {
                this.Hide();
            }
            /*
            frmChildProfile f = new frmChildProfile(selectedChildID, userRole);
            f.Show(); */
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

        /* private void LoadOrphanageCombo()
         {
             DataTable dt = DBHelper.GetData("SELECT OrpID, OrpName FROM Orphanages");

             // Add a "None" option manually
             DataRow dr = dt.NewRow();
             dr["OrpID"] = 0; // Use 0 to represent 'No Selection'
             dr["OrpName"] = "-- None / Not Applicable --";
             dt.Rows.InsertAt(dr, 0);

             cmbOrphanage.DisplayMember = "OrpName";
             cmbOrphanage.ValueMember = "OrpID";
             cmbOrphanage.DataSource = dt;
         }

         private void LoadFoundationCombo()
         {
             DataTable dt = DBHelper.GetData("SELECT FouID, FouName FROM Foundations");

             // Add a "None" option manually
             DataRow dr = dt.NewRow();
             dr["FouID"] = 0;
             dr["FouName"] = "-- None / Not Applicable --";
             dt.Rows.InsertAt(dr, 0);

             cmbFoundation.DisplayMember = "FouName";
             cmbFoundation.ValueMember = "FouID";
             cmbFoundation.DataSource = dt;
         } */
    }
}








/*using System;
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
    public partial class frmChildren : Form
    {
        private string userRole;
        private string userID;
        private int selectedChildID = 0;

        public frmChildren(
            string role, string uid)
        {
            InitializeComponent();
            userRole = role;
            userID = uid;
        }

        private void frmChildren_Load(
            object sender, EventArgs e)
        {
            SetPermissions();
            LoadOrphanageCombo();
            LoadFoundationCombo();
            LoadChildren();
        }

        // Admin হলে সব button দেখাবে
        // Staff হলে শুধু View ও Search
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
            DataTable dt = DBHelper.GetData(
                "SELECT OrpID, OrpName" +
                " FROM Orphanages");
            cmbOrphanage.DisplayMember =
                "OrpName";
            cmbOrphanage.ValueMember =
                "OrpID";
            cmbOrphanage.DataSource = dt;
        }

        private void LoadFoundationCombo()
        {
            DataTable dt = DBHelper.GetData(
                "SELECT FouID, FouName" +
                " FROM Foundations");
            cmbFoundation.DisplayMember =
                "FouName";
            cmbFoundation.ValueMember =
                "FouID";
            cmbFoundation.DataSource = dt;
        }

        private void LoadChildren()
        {
            string query =
                "SELECT C.ChildID," +
                " C.ChildName, C.Age," +
                " C.Gender, C.FoundLocation," +
                " C.ChildStatus," +
                " O.OrpName, F.FouName" +
                " FROM Children C" +
                " LEFT JOIN Orphanages O" +
                " ON C.OrpID = O.OrpID" +
                " LEFT JOIN Foundations F" +
                " ON C.FouID = F.FouID";

            DataTable dt =
                DBHelper.GetData(query);
            dgvChildren.DataSource = dt;
        }

        // Search Feature
        private void btnSearch_Click(
            object sender, EventArgs e)
        {
            string keyword =
                txtSearch.Text.Trim();

            string query =
                "SELECT C.ChildID," +
                " C.ChildName, C.Age," +
                " C.Gender, C.ChildStatus," +
                " O.OrpName, F.FouName" +
                " FROM Children C" +
                " LEFT JOIN Orphanages O" +
                " ON C.OrpID = O.OrpID" +
                " LEFT JOIN Foundations F" +
                " ON C.FouID = F.FouID" +
                " WHERE C.ChildName" +
                " LIKE @keyword" +
                " OR C.ChildStatus" +
                " LIKE @keyword";

            SqlParameter[] p =
            {
            new SqlParameter(
                "@keyword",
                "%" + keyword + "%")
        };

            DataTable dt =
                DBHelper.GetData(query, p);
            dgvChildren.DataSource = dt;
        }

        // Sort Feature
        private void cmbSort_SelectedIndex
            Changed(object sender,
        EventArgs e)
        {
            string sortBy = "";

            if (cmbSort.Text ==
                "Sort by Name")
                sortBy = "C.ChildName ASC";
            else if (cmbSort.Text ==
                "Sort by Status")
                sortBy = "C.ChildStatus ASC";
            else if (cmbSort.Text ==
                "Sort by Age")
                sortBy = "C.Age ASC";

            if (sortBy != "")
            {
                string query =
                    "SELECT C.ChildID," +
                    " C.ChildName, C.Age," +
                    " C.Gender," +
                    " C.ChildStatus," +
                    " O.OrpName, F.FouName" +
                    " FROM Children C" +
                    " LEFT JOIN Orphanages O" +
                    " ON C.OrpID = O.OrpID" +
                    " LEFT JOIN Foundations F" +
                    " ON C.FouID = F.FouID" +
                    " ORDER BY " + sortBy;

                DataTable dt =
                    DBHelper.GetData(query);
                dgvChildren.DataSource = dt;
            }
        }

        // Save — Admin Only
        private void btnSave_Click(
            object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtChildName.Text))
            {
                MessageBox.Show(
                    "Child Name required!");
                return;
            }

            string query =
                "INSERT INTO Children" +
                " (ChildName, Age, Gender," +
                " FoundLocation, ChildStatus," +
                " OrpID, FouID)" +
                " VALUES" +
                " (@name, @age, @gender," +
                " @loc, @status," +
                " @orp, @fou)";

            SqlParameter[] p =
            {
            new SqlParameter(
                "@name",
                txtChildName.Text.Trim()),
            new SqlParameter(
                "@age",
                (int)numAge.Value),
            new SqlParameter(
                "@gender",
                cmbGender.Text),
            new SqlParameter(
                "@loc",
                txtLocation.Text.Trim()),
            new SqlParameter(
                "@status",
                cmbStatus.Text),
            new SqlParameter(
                "@orp",
                cmbOrphanage.SelectedValue),
            new SqlParameter(
                "@fou",
                cmbFoundation.SelectedValue)
        };

            bool result =
                DBHelper.ExecuteQuery(
                query, p);

            if (result)
            {
                MessageBox.Show(
                    "Child Saved ✅");
                ClearForm();
                LoadChildren();
            }
        }

        // DataGridView row click করলে
        // Form এ data আসবে
        private void dgvChildren_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dgvChildren.Rows[e.RowIndex];

                selectedChildID = Convert.ToInt32(
                    row.Cells["ChildID"].Value);
                txtChildName.Text =
                    row.Cells["ChildName"]
                    .Value.ToString();
                numAge.Value = Convert.ToDecimal(
                    row.Cells["Age"].Value);
            }
        }

        // Update — Admin Only
        private void btnUpdate_Click(
            object sender, EventArgs e)
        {
            if (selectedChildID == 0)
            {
                MessageBox.Show(
                    "Please select a child!");
                return;
            }

            string query =
                "UPDATE Children SET" +
                " ChildName = @name," +
                " Age = @age," +
                " Gender = @gender," +
                " FoundLocation = @loc," +
                " ChildStatus = @status," +
                " OrpID = @orp," +
                " FouID = @fou" +
                " WHERE ChildID = @id";

            SqlParameter[] p =
            {
            new SqlParameter(
                "@name",
                txtChildName.Text.Trim()),
            new SqlParameter(
                "@age",
                (int)numAge.Value),
            new SqlParameter(
                "@gender",
                cmbGender.Text),
            new SqlParameter(
                "@loc",
                txtLocation.Text.Trim()),
            new SqlParameter(
                "@status",
                cmbStatus.Text),
            new SqlParameter(
                "@orp",
                cmbOrphanage.SelectedValue),
            new SqlParameter(
                "@fou",
                cmbFoundation.SelectedValue),
            new SqlParameter(
                "@id",
                selectedChildID)
        };

            bool result =
                DBHelper.ExecuteQuery(
                query, p);
            if (result)
            {
                MessageBox.Show(
                    "Updated Successfully ✅");
                ClearForm();
                LoadChildren();
            }
        }

        // Delete — Admin Only
        private void btnDelete_Click(
            object sender, EventArgs e)
        {
            if (selectedChildID == 0)
            {
                MessageBox.Show(
                    "Please select a child!");
                return;
            }

            DialogResult dr =
                MessageBox.Show(
                "Are you sure to delete?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                // আগে Vaccinations মুছো
                DBHelper.ExecuteQuery(
                    "DELETE FROM Vaccinations" +
                    " WHERE ChildID = @id",
                    new SqlParameter[]
                    {
                    new SqlParameter(
                        "@id",
                        selectedChildID)
                    });

                // তারপর Child মুছো
                bool result =
                    DBHelper.ExecuteQuery(
                    "DELETE FROM Children" +
                    " WHERE ChildID = @id",
                    new SqlParameter[]
                    {
                    new SqlParameter(
                        "@id",
                        selectedChildID)
                    });

                if (result)
                {
                    MessageBox.Show(
                        "Deleted Successfully ✅");
                    ClearForm();
                    LoadChildren();
                }
            }
        }

        // View Profile
        private void btnViewProfile_Click(
            object sender, EventArgs e)
        {
            if (selectedChildID == 0)
            {
                MessageBox.Show(
                    "Please select a child!");
                return;
            }

            frmChildProfile f =
                new frmChildProfile(
                selectedChildID,
                userRole);
            f.Show();
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

        // Home Button
        private void btnHome_Click(
            object sender, EventArgs e)
        {
            this.Close();
        }

        // Back Button
        private void btnBack_Click(
            object sender, EventArgs e)
        {
            this.Close();
        }
    }*/

/* public partial class frmChildren : Form
{
    public frmChildren()
    {
        InitializeComponent();
    }

    private void frmChildren_Load(object sender, EventArgs e)
    {

    }
}
}
*/