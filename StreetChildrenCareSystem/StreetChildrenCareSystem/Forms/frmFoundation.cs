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
    public partial class frmFoundation : Form
    {
        private string userRole;
        private string userID;
        private int selectedFouID = 0;

        public frmFoundation(
               string role, string uid)
        {
            InitializeComponent();
            userRole = role;
            userID = uid;
        }

        private void frmFoundation_Load(
        object sender, EventArgs e)
        {
            SetPermissions();
            LoadFoundations();

            // make columns fill the full width of the DataGridView
            dgvFoundation.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // SupportType ComboBox
            cmbSupportType.Items.Add("Food");


            // SupportType ComboBox
            cmbSupportType.Items.Add("Food");
            cmbSupportType.Items.Add(
                "Clothing");
            cmbSupportType.Items.Add(
                "Education");
            cmbSupportType.Items.Add(
                "Medical");
            cmbSupportType.SelectedIndex = 0;

            // Sort ComboBox
            cmbSort.Items.Add("Sort by Name");
            cmbSort.Items.Add("Sort by Type");
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
                txtFouName.ReadOnly = true;
                txtFNumber.ReadOnly = true;
                cmbSupportType.Enabled = false;
            }
        }

        private void LoadFoundations()
        {
            DataTable dt = DBHelper.GetData(
                "SELECT FouID, FouName," +
                " SupportType, FouNumber" +
                " FROM Foundations" +
                " ORDER BY FouName ASC");
            dgvFoundation.DataSource = dt;
        }

        private void btnSave_Click(
            object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtFouName.Text))
            {
                MessageBox.Show(
                    "Foundation Name required!");
                txtFouName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(
                txtFNumber.Text))
            {
                MessageBox.Show(
                    "Contact Number required!");
                txtFNumber.Focus();
                return;
            }

            string query =
                "INSERT INTO Foundations" +
                " (FouName, SupportType," +
                " FouNumber)" +
                " VALUES (@name, @type, @num)";

            SqlParameter[] p =
            {
            new SqlParameter(
                "@name",
                txtFouName.Text.Trim()),
            new SqlParameter(
                "@type",
                cmbSupportType.Text),
            new SqlParameter(
                "@num",
                txtFNumber.Text.Trim())
        };

            if (DBHelper.ExecuteQuery(query, p))
            {
                MessageBox.Show(
                    "Foundation Saved ✅");
                ClearForm();
                LoadFoundations();
            }
        }

        private void dgvFoundation_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dgvFoundation.Rows[e.RowIndex];

                selectedFouID =
                    Convert.ToInt32(
                    row.Cells["FouID"].Value);
                txtFouName.Text =
                    row.Cells["FouName"]
                    .Value.ToString();
                cmbSupportType.Text =
                    row.Cells["SupportType"]
                    .Value.ToString();
                txtFNumber.Text =
                    row.Cells["FouNumber"]
                    .Value.ToString();
            }
        }

        private void btnUpdate_Click(
            object sender, EventArgs e)
        {
            if (selectedFouID == 0)
            {
                MessageBox.Show(
                    "Please select a Foundation!");
                return;
            }

            string query =
                "UPDATE Foundations SET" +
                " FouName = @name," +
                " SupportType = @type," +
                " FouNumber = @num" +
                " WHERE FouID = @id";

            SqlParameter[] p =
            {
            new SqlParameter(
                "@name",
                txtFouName.Text.Trim()),
            new SqlParameter(
                "@type",
                cmbSupportType.Text),
            new SqlParameter(
                "@num",
                txtFNumber.Text.Trim()),
            new SqlParameter(
                "@id", selectedFouID)
        };

            if (DBHelper.ExecuteQuery(query, p))
            {
                MessageBox.Show(
                    "Updated Successfully ✅");
                ClearForm();
                LoadFoundations();
            }
        }

        private void btnDelete_Click(
            object sender, EventArgs e)
        {
            if (selectedFouID == 0)
            {
                MessageBox.Show(
                    "Please select a Foundation!");
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Are you sure to delete?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                if (DBHelper.ExecuteQuery(
                    "DELETE FROM Foundations" +
                    " WHERE FouID = @id",
                    new SqlParameter[]
                    {
                    new SqlParameter(
                        "@id", selectedFouID)
                    }))
                {
                    MessageBox.Show(
                        "Deleted Successfully ✅");
                    ClearForm();
                    LoadFoundations();
                }
            }
        }

        private void btnSearch_Click(
            object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();
            SqlParameter[] p =
            {
            new SqlParameter(
                "@kw", "%" + kw + "%")
        };

            DataTable dt = DBHelper.GetData(
                "SELECT FouID, FouName," +
                " SupportType, FouNumber" +
                " FROM Foundations" +
                " WHERE FouName LIKE @kw" +
                " OR SupportType LIKE @kw",
                p);
            dgvFoundation.DataSource = dt;
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = cmbSort.Text ==
                "Sort by Name" ?
                "FouName ASC" :
                "SupportType ASC";

            DataTable dt = DBHelper.GetData(
                "SELECT FouID, FouName," +
                " SupportType, FouNumber" +
                " FROM Foundations ORDER BY "
                + s);
            dgvFoundation.DataSource = dt;
        }

        private void ClearForm()
        {
            txtFouName.Clear();
            txtFNumber.Clear();
            txtSearch.Clear();
            cmbSupportType.SelectedIndex = 0;
            selectedFouID = 0;
        }

        private void btnClear_Click(
            object sender, EventArgs e)
        {
            ClearForm();
            LoadFoundations();
        }

        private void btnBack_Click(
            object sender, EventArgs e)
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
            this.Close(); // Close
        }

        private void btnHome_Click(
            object sender, EventArgs e)
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
            this.Close(); // Close 
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
