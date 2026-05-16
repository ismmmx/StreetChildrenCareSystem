using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StreetChildrenCareSystem.Forms;

namespace StreetChildrenCareSystem.Forms
{
    public partial class frmChildProfile : Form
    {
        // Store child ID, user role, and user ID for use throughout the form
        private int childID;
        private string userRole;
        private string userID;

        // Constructor now takes 3 values: child ID, role, and user ID
        public frmChildProfile(int cid, string role, string uid)
        {
            InitializeComponent();
            childID = cid;
            userRole = role;
            userID = uid;
        }

        // Runs automatically when the form opens
        private void frmChildProfile_Load(object sender, EventArgs e)
        {
            try
            {
                SetPermissions();
                LoadProfile();
                LoadVaccinations();
            }
            catch (Exception ex)
            {
                // Show error so we can identify the problem
                MessageBox.Show("Error loading profile: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // Hide buttons that Staff users should not see
        private void SetPermissions()
        {
            if (userRole == "Staff")
            {
                btnEdit.Visible = false;
                btnDeleteChild.Visible = false;
                btnAddVaccination.Visible = false;
            }
        }

        // Load and display the child's information from the database
        private void LoadProfile()
        {
            string query = @"SELECT C.*, O.OrpName, F.FouName 
                             FROM Children C 
                             LEFT JOIN Orphanages O ON C.OrpID = O.OrpID 
                             LEFT JOIN Foundations F ON C.FouID = F.FouID 
                             WHERE C.ChildID = @id";

            SqlParameter[] p = { new SqlParameter("@id", childID) };
            DataTable dt = DBHelper.GetData(query, p);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // FIXED: String literal prefixes removed to prevent duplicate text overlay on UI labels
                lblChildID.Text = row["ChildID"].ToString();
                lblName.Text = row["ChildName"].ToString();
                lblAge.Text = row["Age"].ToString();
                lblGender.Text = row["Gender"].ToString();
                lblLocation.Text = row["FoundLocation"].ToString();
                lblStatus.Text = row["ChildStatus"].ToString();
                lblOrphanage.Text = (row["OrpName"] == DBNull.Value ? "N/A" : row["OrpName"].ToString());
                lblFoundation.Text = (row["FouName"] == DBNull.Value ? "N/A" : row["FouName"].ToString());
            }
        }

        // Load vaccination records for this child
        private void LoadVaccinations()
        {
            string query =
                "SELECT VacID, VacName, GivenDate, NextDueDate, VacStatus" +
                " FROM Vaccinations" +
                " WHERE ChildID = @id" +
                " ORDER BY GivenDate DESC";

            SqlParameter[] p = { new SqlParameter("@id", childID) };
            DataTable dt = DBHelper.GetData(query, p);
            dgvVaccinations.DataSource = dt;
        }

        // Sort vaccination records when user changes the sort dropdown
        private void cmbSortVac_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortBy = "";

            if (cmbSortVac.Text == "Sort by Date")
                sortBy = "GivenDate DESC";
            else if (cmbSortVac.Text == "Sort by Status")
                sortBy = "VacStatus ASC";

            if (string.IsNullOrEmpty(sortBy)) return;

            string query =
                "SELECT VacID, VacName, GivenDate, NextDueDate, VacStatus" +
                " FROM Vaccinations" +
                " WHERE ChildID = @id" +
                " ORDER BY " + sortBy;

            SqlParameter[] p = { new SqlParameter("@id", childID) };
            DataTable dt = DBHelper.GetData(query, p);
            dgvVaccinations.DataSource = dt;
        }

        // Add vaccination button (coming soon)
        private void btnAddVaccination_Click(object sender, EventArgs e)
        {
            // Open Vaccination form so Admin can add vaccination for this child
            frmVaccination f = new frmVaccination(userRole);
            f.Show();
            this.Hide();
        }

        // Home button: close profile AND children form, go back to dashboard
        private void btnHome_Click(object sender, EventArgs e)
        {
            // Step 1: Find the hidden dashboard and show it
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is frmAdminDashboard || openForm is frmStaffDashboard)
                {
                    openForm.Show();
                    break;
                }
            }

            // Step 2: Find frmChildren and close it
            frmChildren childrenForm = null;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is frmChildren)
                {
                    childrenForm = (frmChildren)openForm;
                    break;
                }
            }
            if (childrenForm != null)
                childrenForm.Close();

            // Step 3: Close this profile form
            this.Close();
        }

        // Edit Profile button: go back to frmChildren to edit the selected child
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Show the hidden frmChildren so user can edit
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is frmChildren)
                {
                    openForm.Show();
                    break;
                }
            }
            this.Close();
        }

        // Delete Child button: delete this child from the database
        private void btnDeleteChild_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Are you sure you want to delete this child profile?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                // First delete all vaccination records linked to this child
                DBHelper.ExecuteQuery(
                    "DELETE FROM Vaccinations WHERE ChildID = @id",
                    new SqlParameter[] { new SqlParameter("@id", childID) });

                // Then delete the child record itself
                bool result = DBHelper.ExecuteQuery(
                    "DELETE FROM Children WHERE ChildID = @id",
                    new SqlParameter[] { new SqlParameter("@id", childID) });

                if (result)
                {
                    MessageBox.Show("Child deleted successfully!", "Success");

                    // Go back to frmChildren and refresh the list
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm is frmChildren)
                        {
                            openForm.Show();
                            ((frmChildren)openForm).RefreshChildList();
                            break;
                        }
                    }
                    this.Close();
                }
            }
        }

        // Back button: return to frmChildren
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Show the hidden frmChildren
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is frmChildren)
                {
                    openForm.Show();
                    break;
                }
            }
            this.Close();
        }

        // Logout button: confirm and go back to login screen
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Close all other open forms before showing login
                frmChildren childrenForm = null;
                Form dashboardForm = null;

                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is frmChildren)
                        childrenForm = (frmChildren)openForm;
                    if (openForm is frmAdminDashboard || openForm is frmStaffDashboard)
                        dashboardForm = openForm;
                }

                if (childrenForm != null) childrenForm.Close();
                if (dashboardForm != null) dashboardForm.Close();

                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }

        private void lblAge_Click(object sender, EventArgs e)
        {

        }
    }
}




/*using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StreetChildrenCareSystem.Forms; 

namespace StreetChildrenCareSystem.Forms
{
    public partial class frmChildProfile : Form
    {
        private int childID;
        private string userRole;
        private string userID; // Added: needed to pass to frmChildren for Edit
        

        public frmChildProfile(int cid, string role, string uid)
        {
            InitializeComponent();
            childID = cid;
            userRole = role;
            userID = uid;
        }

        //nicher etar jonno error aste pare cause ei button tar name change korsilam ar etake fully comment e rakhsilam..
         private void frmChildProfile_Load(object sender, EventArgs e)
        {
           /* try
            {
                SetPermissions();
                LoadProfile();      // Load child info from database
                LoadVaccinations(); // Load vaccination records from database
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }*/
// } 
/*
        private void SetPermissions()
        {
            if (userRole == "Staff")
            {
                btnEdit.Visible = false;
                btnDeleteChild.Visible = false;
                btnAddVaccination.Visible = false;
            }
        }

        private void LoadProfile()
        {
            string query = @"SELECT C.*, O.OrpName, F.FouName 
                             FROM Children C 
                             LEFT JOIN Orphanages O ON C.OrpID = O.OrpID 
                             LEFT JOIN Foundations F ON C.FouID = F.FouID 
                             WHERE C.ChildID = @id";

            SqlParameter[] p = { new SqlParameter("@id", childID) };
            DataTable dt = DBHelper.GetData(query, p);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblChildID.Text = "ID: " + row["ChildID"].ToString();
                lblName.Text = "Name: " + row["ChildName"].ToString();
                lblAge.Text = "Age: " + row["Age"].ToString();
                lblGender.Text = "Gender: " + row["Gender"].ToString();
                lblLocation.Text = "Found At: " + row["FoundLocation"].ToString();
                lblStatus.Text = "Status: " + row["ChildStatus"].ToString();
                lblOrphanage.Text = "Orphanage: " + (row["OrpName"] == DBNull.Value ? "N/A" : row["OrpName"].ToString());
                lblFoundation.Text = "Foundation: " + (row["FouName"] == DBNull.Value ? "N/A" : row["FouName"].ToString());
            }
        }


        // Load vaccination records for this child
        private void LoadVaccinations()
        {
            string query =
                "SELECT VacID, VacName, GivenDate, NextDueDate, VacStatus" +
                " FROM Vaccinations" +
                " WHERE ChildID = @id" +
                " ORDER BY GivenDate DESC";

            SqlParameter[] p = { new SqlParameter("@id", childID) };
            DataTable dt = DBHelper.GetData(query, p);
            dgvVaccinations.DataSource = dt;
        }

        private void cmbSortVac_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortBy = "";

            if (cmbSortVac.Text == "Sort by Date")
                sortBy = "GivenDate DESC";
            else if (cmbSortVac.Text == "Sort by Status")
                sortBy = "VacStatus ASC";

            if (string.IsNullOrEmpty(sortBy)) return;

            string query =
                "SELECT VacID, VacName, GivenDate, NextDueDate, VacStatus" +
                " FROM Vaccinations" +
                " WHERE ChildID = @id" +
                " ORDER BY " + sortBy;

            SqlParameter[] p = { new SqlParameter("@id", childID) };
            DataTable dt = DBHelper.GetData(query, p);
            dgvVaccinations.DataSource = dt;
        }

        private void btnAddVaccination_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon!", "Info");
        }

        // Back button: go back to frmChildren
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Show the hidden frmChildren
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is frmChildren)
                {
                    openForm.Show();
                    break;
                }
            }
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Step 1: Find the hidden dashboard and show it
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is frmAdminDashboard || openForm is frmStaffDashboard)
                {
                    openForm.Show();
                    break;
                }
            }

            // Step 2: Find frmChildren and close it
            frmChildren childrenForm = null;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is frmChildren)
                {
                    childrenForm = (frmChildren)openForm;
                    break;
                }
            }
            if (childrenForm != null)
                childrenForm.Close();

            // Step 3: Close this profile form
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Close all other open forms before showing login
                frmChildren childrenForm = null;
                Form dashboardForm = null;

                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is frmChildren)
                        childrenForm = (frmChildren)openForm;
                    if (openForm is frmAdminDashboard || openForm is frmStaffDashboard)
                        dashboardForm = openForm;
                }

                if (childrenForm != null) childrenForm.Close();
                if (dashboardForm != null) dashboardForm.Close();

                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }

        private void btnDeleteChild_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Are you sure you want to delete this child profile?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                // First delete all vaccination records linked to this child
                DBHelper.ExecuteQuery(
                    "DELETE FROM Vaccinations WHERE ChildID = @id",
                    new SqlParameter[] { new SqlParameter("@id", childID) });

                // Then delete the child record itself
                bool result = DBHelper.ExecuteQuery(
                    "DELETE FROM Children WHERE ChildID = @id",
                    new SqlParameter[] { new SqlParameter("@id", childID) });

                if (result)
                {
                    MessageBox.Show("Child deleted successfully!", "Success");

                    // Go back to frmChildren and refresh the list
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm is frmChildren)
                        {
                            openForm.Show();
                            ((frmChildren)openForm).RefreshChildList();
                            break;
                        }
                    }
                    this.Close();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                SetPermissions();
                LoadProfile();      // Load child info from database
                LoadVaccinations(); // Load vaccination records from database
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }


}  */













//-----------------------------------------------------------------------------

/*using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StreetChildrenCareSystem.Forms
{
    public partial class frmChildProfile : Form
    {
        private int childID;
        private string userRole;

        public frmChildProfile(int cid, string role)
        {
            InitializeComponent();
            childID = cid;
            userRole = role;
        }

        private void frmChildProfile_Load(object sender, EventArgs e)
        {
            SetPermissions();
            LoadProfile();
            LoadVaccinations();
        }

        private void SetPermissions()
        {
            if (userRole == "Staff")
            {
                btnEdit.Visible = false;
                btnDeleteChild.Visible = false;
                btnAddVaccination.Visible = false;
            }
        }

        private void LoadProfile()
        {
            string query =
                "SELECT C.*, O.OrpName, F.FouName" +
                " FROM Children C" +
                " LEFT JOIN Orphanages O ON C.OrpID = O.OrpID" +
                " LEFT JOIN Foundations F ON C.FouID = F.FouID" +
                " WHERE C.ChildID = @id";

            SqlParameter[] p = { new SqlParameter("@id", childID) };

            DataTable dt = DBHelper.GetData(query, p);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblChildID.Text = row["ChildID"].ToString();
                lblName.Text = row["ChildName"].ToString();
                lblAge.Text = row["Age"].ToString();
                lblGender.Text = row["Gender"].ToString();
                lblLocation.Text = row["FoundLocation"].ToString();
                lblStatus.Text = row["ChildStatus"].ToString();
                lblOrphanage.Text = row["OrpName"].ToString();
                lblFoundation.Text = row["FouName"].ToString();
            }
        }

        private void LoadVaccinations()
        {
            string query =
                "SELECT VacID, VacName, GivenDate, NextDueDate, VacStatus" +
                " FROM Vaccinations" +
                " WHERE ChildID = @id" +
                " ORDER BY GivenDate DESC";

            SqlParameter[] p = { new SqlParameter("@id", childID) };

            DataTable dt = DBHelper.GetData(query, p);
            dgvVaccinations.DataSource = dt;
        }

        
        private void cmbSortVac_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortBy = "";
            if (cmbSortVac.Text == "Sort by Date")
                sortBy = "GivenDate DESC";
            else if (cmbSortVac.Text == "Sort by Status")
                sortBy = "VacStatus ASC";

            if (string.IsNullOrEmpty(sortBy)) return;

            string query =
                "SELECT VacID, VacName, GivenDate, NextDueDate, VacStatus" +
                " FROM Vaccinations" +
                " WHERE ChildID = @id" +
                " ORDER BY " + sortBy;

            SqlParameter[] p = { new SqlParameter("@id", childID) };

            DataTable dt = DBHelper.GetData(query, p);
            dgvVaccinations.DataSource = dt;
        }

        private void btnAddVaccination_Click(object sender, EventArgs e)
        {
            frmVaccination f = new frmVaccination("Admin", childID);
            f.ShowDialog();
            LoadVaccinations();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
*/






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
    public partial class frmChildProfile : Form
    {
            private int childID;
            private string userRole;

            public frmChildProfile(
                int cid, string role)
            {
                InitializeComponent();
                childID = cid;
                userRole = role;
            }

            private void frmChildProfile_Load(
                object sender, EventArgs e)
            {
                SetPermissions();
                LoadProfile();
                LoadVaccinations();
            }

            private void SetPermissions()
            {
                if (userRole == "Staff")
                {
                    btnEdit.Visible = false;
                    btnDeleteChild.Visible = false;
                    btnAddVaccination.Visible
                        = false;
                }
            }

            private void LoadProfile()
            {
                string query =
                    "SELECT C.*," +
                    " O.OrpName, F.FouName" +
                    " FROM Children C" +
                    " LEFT JOIN Orphanages O" +
                    " ON C.OrpID = O.OrpID" +
                    " LEFT JOIN Foundations F" +
                    " ON C.FouID = F.FouID" +
                    " WHERE C.ChildID = @id";

                SqlParameter[] p =
                {
            new SqlParameter(
                "@id", childID)
        };

                DataTable dt =
                    DBHelper.GetData(query, p);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblChildID.Text =
                        row["ChildID"].ToString();
                    lblName.Text =
                        row["ChildName"].ToString();
                    lblAge.Text =
                        row["Age"].ToString();
                    lblGender.Text =
                        row["Gender"].ToString();
                    lblLocation.Text =
                        row["FoundLocation"]
                        .ToString();
                    lblStatus.Text =
                        row["ChildStatus"].ToString();
                    lblOrphanage.Text =
                        row["OrpName"].ToString();
                    lblFoundation.Text =
                        row["FouName"].ToString();
                }
            }

            private void LoadVaccinations()
            {
                string query =
                    "SELECT VacID, VacName," +
                    " GivenDate, NextDueDate," +
                    " VacStatus" +
                    " FROM Vaccinations" +
                    " WHERE ChildID = @id" +
                    " ORDER BY GivenDate DESC";

                SqlParameter[] p =
                {
            new SqlParameter(
                "@id", childID)
        };

                DataTable dt =
                    DBHelper.GetData(query, p);
                dgvVaccinations.DataSource = dt;
            }

            // Sort Vaccination
            private void cmbSortVac
        
        _SelectedIndexChanged(
        object sender, EventArgs e)
            {
                string sortBy = "";
                if (cmbSortVac.Text ==
                    "Sort by Date")
                    sortBy = "GivenDate DESC";
                else if (cmbSortVac.Text ==
                    "Sort by Status")
                    sortBy = "VacStatus ASC";

                string query =
                    "SELECT VacID, VacName," +
                    " GivenDate, NextDueDate," +
                    " VacStatus" +
                    " FROM Vaccinations" +
                    " WHERE ChildID = @id" +
                    " ORDER BY " + sortBy;

                SqlParameter[] p =
                {
            new SqlParameter(
                "@id", childID)
        };

                DataTable dt =
                    DBHelper.GetData(query, p);
                dgvVaccinations.DataSource = dt;
            }

            private void btnAddVaccination_Click(
                object sender, EventArgs e)
            {
                frmVaccination f =
                    new frmVaccination(
                    "Admin", childID);
                f.ShowDialog();
                LoadVaccinations();
            }

            private void btnBack_Click(
                object sender, EventArgs e)
            {
                this.Close();
            }
        
*/

/*public frmChildProfile()
{
    InitializeComponent();
}

private void frmChildProfile_Load(object sender, EventArgs e)
{

}
}
}
*/