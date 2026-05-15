using System;
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
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

    }
}




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