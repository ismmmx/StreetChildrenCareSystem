using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using StreetChildrenCareSystem.Forms;

namespace StreetChildrenCareSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnLogin_Click(sender, e); // forward to real handler
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                MessageBox.Show("Please enter User ID.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter Password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                string query = "SELECT UserID, UserRole FROM Users WHERE UserID = @uid AND Password = @pass";
                SqlParameter[] parameters = {
                    new SqlParameter("@uid", txtUserID.Text.Trim()),
                    new SqlParameter("@pass", txtPassword.Text.Trim())
                };

                DataTable dt = DBHelper.GetData(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    string role = dt.Rows[0]["UserRole"].ToString();
                    if (role == "Admin")
                    {
                        frmAdminDashboard adminForm = new frmAdminDashboard(txtUserID.Text);
                        adminForm.Show();
                        this.Hide();
                    }
                    else if (role == "Staff")
                    {
                        frmStaffDashboard staffForm = new frmStaffDashboard(txtUserID.Text);
                        staffForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid User ID or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
