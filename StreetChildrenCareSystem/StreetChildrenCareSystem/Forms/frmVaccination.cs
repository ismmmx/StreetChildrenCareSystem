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
    public partial class frmVaccination : Form
    {
        private string userRole;
        private int selectedVacID = 0;

        public frmVaccination(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void frmVaccination_Load(object sender, EventArgs e)
        {
            SetPermissions();
            LoadChildCombo();
            LoadAllVaccinations();
            dgvVaccination.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            cmbVacName.Items.Add("BCG");
            cmbVacName.Items.Add("Polio");
            cmbVacName.Items.Add("DPT");
            cmbVacName.Items.Add("Measles");
            cmbVacName.Items.Add("Hepatitis B");
            cmbVacName.SelectedIndex = 0;

            cmbVacStatus.Items.Add("Pending");
            cmbVacStatus.Items.Add("Completed");
            cmbVacStatus.Items.Add("Overdue");
            cmbVacStatus.SelectedIndex = 0;

            cmbSort.Items.Add("Sort by Date");
            cmbSort.Items.Add("Sort by Status");
            cmbSort.Items.Add("Sort by Child Name");
            cmbSort.SelectedIndex = 0;
        }

        private void SetPermissions()
        {
            if (userRole == "Staff")
            {
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnClear.Visible = false;
                cmbChild.Enabled = false;
                cmbVacName.Enabled = false;
                dtpGivenDate.Enabled = false;
                dtpNextDueDate.Enabled = false;
                cmbVacStatus.Enabled = false;
            }
        }

        private void LoadChildCombo()
        {
            DataTable dt = DBHelper.GetData(
                "SELECT ChildID, ChildName FROM Children ORDER BY ChildName ASC");
            cmbChild.DisplayMember = "ChildName";
            cmbChild.ValueMember = "ChildID";
            cmbChild.DataSource = dt;
        }

        private void LoadAllVaccinations()
        {
            string query =
                "SELECT V.VacID, C.ChildName, V.VacName," +
                " V.GivenDate, V.NextDueDate, V.VacStatus" +
                " FROM Vaccinations V" +
                " JOIN Children C ON V.ChildID = C.ChildID" +
                " ORDER BY V.GivenDate DESC";

            DataTable dt = DBHelper.GetData(query);
            dgvVaccination.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbChild.SelectedValue == null)
            {
                MessageBox.Show("Please select a Child!");
                return;
            }

            string query =
                "INSERT INTO Vaccinations" +
                " (ChildID, VacName, GivenDate, NextDueDate, VacStatus)" +
                " VALUES (@cid, @vname, @gdate, @ndate, @vstatus)";

            SqlParameter[] p =
            {
                new SqlParameter("@cid",     cmbChild.SelectedValue),
                new SqlParameter("@vname",   cmbVacName.Text),
                new SqlParameter("@gdate",   dtpGivenDate.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@ndate",   dtpNextDueDate.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@vstatus", cmbVacStatus.Text)
            };

            if (DBHelper.ExecuteQuery(query, p))
            {
                MessageBox.Show("Vaccination Record Saved ✅");
                ClearForm();
                LoadAllVaccinations();
            }
        }

        private void dgvVaccination_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVaccination.Rows[e.RowIndex];
                selectedVacID = Convert.ToInt32(row.Cells["VacID"].Value);
                cmbVacName.Text = row.Cells["VacName"].Value.ToString();
                cmbVacStatus.Text = row.Cells["VacStatus"].Value.ToString();

                if (row.Cells["GivenDate"].Value != DBNull.Value)
                    dtpGivenDate.Value = Convert.ToDateTime(row.Cells["GivenDate"].Value);

                if (row.Cells["NextDueDate"].Value != DBNull.Value)
                    dtpNextDueDate.Value = Convert.ToDateTime(row.Cells["NextDueDate"].Value);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedVacID == 0)
            {
                MessageBox.Show("Please select a record first!");
                return;
            }

            string query =
                "UPDATE Vaccinations SET" +
                " VacName = @vname," +
                " GivenDate = @gdate," +
                " NextDueDate = @ndate," +
                " VacStatus = @vstatus" +
                " WHERE VacID = @id";

            SqlParameter[] p =
            {
                new SqlParameter("@vname",   cmbVacName.Text),
                new SqlParameter("@gdate",   dtpGivenDate.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@ndate",   dtpNextDueDate.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@vstatus", cmbVacStatus.Text),
                new SqlParameter("@id",      selectedVacID)
            };

            if (DBHelper.ExecuteQuery(query, p))
            {
                MessageBox.Show("Updated Successfully ✅");
                ClearForm();
                LoadAllVaccinations();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedVacID == 0)
            {
                MessageBox.Show("Please select a record first!");
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Delete this vaccination record?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                if (DBHelper.ExecuteQuery(
                    "DELETE FROM Vaccinations WHERE VacID = @id",
                    new SqlParameter[] { new SqlParameter("@id", selectedVacID) }))
                {
                    MessageBox.Show("Deleted Successfully ✅");
                    ClearForm();
                    LoadAllVaccinations();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();

            string query =
                "SELECT V.VacID, C.ChildName, V.VacName," +
                " V.GivenDate, V.NextDueDate, V.VacStatus" +
                " FROM Vaccinations V" +
                " JOIN Children C ON V.ChildID = C.ChildID" +
                " WHERE C.ChildName LIKE @kw" +
                " OR V.VacName LIKE @kw OR V.VacStatus LIKE @kw";

            SqlParameter[] p = { new SqlParameter("@kw", "%" + kw + "%") };
            DataTable dt = DBHelper.GetData(query, p);
            dgvVaccination.DataSource = dt;
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortBy = "";

            if (cmbSort.Text == "Sort by Date")
                sortBy = "V.GivenDate DESC";
            else if (cmbSort.Text == "Sort by Status")
                sortBy = "V.VacStatus ASC";
            else if (cmbSort.Text == "Sort by Child Name")
                sortBy = "C.ChildName ASC";

            if (sortBy == "") return;

            DataTable dt = DBHelper.GetData(
                "SELECT V.VacID, C.ChildName, V.VacName," +
                " V.GivenDate, V.NextDueDate, V.VacStatus" +
                " FROM Vaccinations V" +
                " JOIN Children C ON V.ChildID = C.ChildID" +
                " ORDER BY " + sortBy);

            dgvVaccination.DataSource = dt;
        }

        private void ClearForm()
        {
            cmbVacName.SelectedIndex = 0;
            cmbVacStatus.SelectedIndex = 0;
            dtpGivenDate.Value = DateTime.Now;
            dtpNextDueDate.Value = DateTime.Now;
            selectedVacID = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadAllVaccinations();
        }

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



/*namespace StreetChildrenCareSystem.Forms
{
    public partial class frmVaccination : Form
    {
        public s()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void s_Load(object sender, EventArgs e)
        {

        }

        private void frmVaccination_Load(object sender, EventArgs e)
        {

        }
    }
} */


/*
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
    public partial class frmVaccination : Form
    {
        private string userRole;
        private int selectedVacID = 0;

        // Constructor: receives role from dashboard
        public frmVaccination(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void frmVaccination_Load(object sender, EventArgs e)
        {
            SetPermissions();
            LoadChildCombo();
            LoadAllVaccinations();
            dgvVaccination.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Vaccine name options
            cmbVacName.Items.Add("BCG");
            cmbVacName.Items.Add("Polio");
            cmbVacName.Items.Add("DPT");
            cmbVacName.Items.Add("Measles");
            cmbVacName.Items.Add("Hepatitis B");
            cmbVacName.SelectedIndex = 0;

            // Status options
            cmbVacStatus.Items.Add("Pending");
            cmbVacStatus.Items.Add("Completed");
            cmbVacStatus.Items.Add("Overdue");
            cmbVacStatus.SelectedIndex = 0;

            // Sort options
            cmbSort.Items.Add("Sort by Date");
            cmbSort.Items.Add("Sort by Status");
            cmbSort.Items.Add("Sort by Child Name");
            cmbSort.SelectedIndex = 0;
        }

        // Admin sees all buttons; Staff gets view-only
        private void SetPermissions()
        {
            if (userRole == "Staff")
            {
                btnSave.Visible    = false;
                btnUpdate.Visible  = false;
                btnDelete.Visible  = false;
                btnClear.Visible   = false;
                cmbChild.Enabled   = false;
                cmbVacName.Enabled = false;
                dtpGivenDate.Enabled   = false;
                dtpNextDueDate.Enabled = false;
                cmbVacStatus.Enabled   = false;
            }
        }

        // Load children into the dropdown
        private void LoadChildCombo()
        {
            DataTable dt = DBHelper.GetData(
                "SELECT ChildID, ChildName FROM Children ORDER BY ChildName ASC");
            cmbChild.DisplayMember = "ChildName";
            cmbChild.ValueMember   = "ChildID";
            cmbChild.DataSource    = dt;
        }

        // Load all vaccination records
        private void LoadAllVaccinations()
        {
            string query =
                "SELECT V.VacID, C.ChildName, V.VacName," +
                " V.GivenDate, V.NextDueDate, V.VacStatus" +
                " FROM Vaccinations V" +
                " JOIN Children C ON V.ChildID = C.ChildID" +
                " ORDER BY V.GivenDate DESC";

            DataTable dt = DBHelper.GetData(query);
            dgvVaccination.DataSource = dt;
        }

        // Save new vaccination record (Admin only)
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbChild.SelectedValue == null)
            {
                MessageBox.Show("Please select a Child!");
                return;
            }

            string query =
                "INSERT INTO Vaccinations" +
                " (ChildID, VacName, GivenDate, NextDueDate, VacStatus)" +
                " VALUES (@cid, @vname, @gdate, @ndate, @vstatus)";

            SqlParameter[] p =
            {
                new SqlParameter("@cid",     cmbChild.SelectedValue),
                new SqlParameter("@vname",   cmbVacName.Text),
                new SqlParameter("@gdate",   dtpGivenDate.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@ndate",   dtpNextDueDate.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@vstatus", cmbVacStatus.Text)
            };

            if (DBHelper.ExecuteQuery(query, p))
            {
                MessageBox.Show("Vaccination Record Saved ✅");
                ClearForm();
                LoadAllVaccinations();
            }
        }

        // Clicking a row fills the form fields
        private void dgvVaccination_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVaccination.Rows[e.RowIndex];
                selectedVacID       = Convert.ToInt32(row.Cells["VacID"].Value);
                cmbVacName.Text     = row.Cells["VacName"].Value.ToString();
                cmbVacStatus.Text   = row.Cells["VacStatus"].Value.ToString();

                // Load GivenDate into the date picker safely
                if (row.Cells["GivenDate"].Value != DBNull.Value)
                    dtpGivenDate.Value = Convert.ToDateTime(row.Cells["GivenDate"].Value);

                // Load NextDueDate into the date picker safely
                if (row.Cells["NextDueDate"].Value != DBNull.Value)
                    dtpNextDueDate.Value = Convert.ToDateTime(row.Cells["NextDueDate"].Value);
            }
        }

        // Update selected record (Admin only)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedVacID == 0)
            {
                MessageBox.Show("Please select a record first!");
                return;
            }

            string query =
                "UPDATE Vaccinations SET" +
                " VacName = @vname," +
                " GivenDate = @gdate," +
                " NextDueDate = @ndate," +
                " VacStatus = @vstatus" +
                " WHERE VacID = @id";

            SqlParameter[] p =
            {
                new SqlParameter("@vname",   cmbVacName.Text),
                new SqlParameter("@gdate",   dtpGivenDate.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@ndate",   dtpNextDueDate.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@vstatus", cmbVacStatus.Text),
                new SqlParameter("@id",      selectedVacID)
            };

            if (DBHelper.ExecuteQuery(query, p))
            {
                MessageBox.Show("Updated Successfully ✅");
                ClearForm();
                LoadAllVaccinations();
            }
        }

        // Delete selected record (Admin only)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedVacID == 0)
            {
                MessageBox.Show("Please select a record first!");
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Delete this vaccination record?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                if (DBHelper.ExecuteQuery(
                    "DELETE FROM Vaccinations WHERE VacID = @id",
                    new SqlParameter[] { new SqlParameter("@id", selectedVacID) }))
                {
                    MessageBox.Show("Deleted Successfully ✅");
                    ClearForm();
                    LoadAllVaccinations();
                }
            }
        }

        // Search by child name, vaccine name or status
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();

            string query =
                "SELECT V.VacID, C.ChildName, V.VacName," +
                " V.GivenDate, V.NextDueDate, V.VacStatus" +
                " FROM Vaccinations V" +
                " JOIN Children C ON V.ChildID = C.ChildID" +
                " WHERE C.ChildName LIKE @kw" +
                " OR V.VacName LIKE @kw OR V.VacStatus LIKE @kw";

            SqlParameter[] p = { new SqlParameter("@kw", "%" + kw + "%") };
            DataTable dt = DBHelper.GetData(query, p);
            dgvVaccination.DataSource = dt;
        }

        // Sort the list
        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortBy = "";

            if (cmbSort.Text == "Sort by Date")
                sortBy = "V.GivenDate DESC";
            else if (cmbSort.Text == "Sort by Status")
                sortBy = "V.VacStatus ASC";
            else if (cmbSort.Text == "Sort by Child Name")
                sortBy = "C.ChildName ASC";

            if (sortBy == "") return;

            DataTable dt = DBHelper.GetData(
                "SELECT V.VacID, C.ChildName, V.VacName," +
                " V.GivenDate, V.NextDueDate, V.VacStatus" +
                " FROM Vaccinations V" +
                " JOIN Children C ON V.ChildID = C.ChildID" +
                " ORDER BY " + sortBy);

            dgvVaccination.DataSource = dt;
        }

        // Clear all input fields
        private void ClearForm()
        {
            cmbVacName.SelectedIndex   = 0;
            cmbVacStatus.SelectedIndex = 0;
            dtpGivenDate.Value   = DateTime.Now;
            dtpNextDueDate.Value = DateTime.Now;
            selectedVacID = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadAllVaccinations();
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

 */