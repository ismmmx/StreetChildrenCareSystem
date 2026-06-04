namespace StreetChildrenCareSystem.Forms
{
    partial class frmOrphanage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrpName = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtONumber = new System.Windows.Forms.TextBox();
            this.dgvOrphanage = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrphanage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(123, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(455, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orphanage Management";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(163)))));
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(1116, 74);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(156, 73);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(163)))));
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Location = new System.Drawing.Point(870, 74);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(177, 73);
            this.btnHome.TabIndex = 6;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(163)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(764, 646);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(152, 115);
            this.btnSearch.TabIndex = 47;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbSort
            // 
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Location = new System.Drawing.Point(214, 716);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(502, 45);
            this.cmbSort.TabIndex = 46;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(214, 646);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(502, 43);
            this.txtSearch.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(80, 719);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 37);
            this.label9.TabIndex = 44;
            this.label9.Text = "Sort :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(80, 649);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 37);
            this.label8.TabIndex = 43;
            this.label8.Text = "Search :";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(163)))));
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(875, 513);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(139, 61);
            this.btnClear.TabIndex = 41;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(163)))));
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Location = new System.Drawing.Point(530, 513);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(132, 61);
            this.btnUpdate.TabIndex = 40;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(163)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(191, 513);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 61);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 37);
            this.label2.TabIndex = 48;
            this.label2.Text = "Orphanage Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 37);
            this.label3.TabIndex = 50;
            this.label3.Text = "Location :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(80, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(332, 37);
            this.label4.TabIndex = 51;
            this.label4.Text = "Orphanage Contact No. :";
            // 
            // txtOrpName
            // 
            this.txtOrpName.Location = new System.Drawing.Point(418, 219);
            this.txtOrpName.Name = "txtOrpName";
            this.txtOrpName.Size = new System.Drawing.Size(840, 43);
            this.txtOrpName.TabIndex = 52;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(418, 311);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(840, 43);
            this.txtLocation.TabIndex = 53;
            // 
            // txtONumber
            // 
            this.txtONumber.Location = new System.Drawing.Point(418, 399);
            this.txtONumber.Name = "txtONumber";
            this.txtONumber.Size = new System.Drawing.Size(840, 43);
            this.txtONumber.TabIndex = 54;
            // 
            // dgvOrphanage
            // 
            this.dgvOrphanage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrphanage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrphanage.Location = new System.Drawing.Point(87, 830);
            this.dgvOrphanage.Name = "dgvOrphanage";
            this.dgvOrphanage.ReadOnly = true;
            this.dgvOrphanage.RowHeadersWidth = 82;
            this.dgvOrphanage.RowTemplate.Height = 33;
            this.dgvOrphanage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrphanage.Size = new System.Drawing.Size(1185, 418);
            this.dgvOrphanage.TabIndex = 55;
            this.dgvOrphanage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrphanage_CellClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(578, 1383);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(226, 37);
            this.label10.TabIndex = 58;
            this.label10.Text = "-------------------";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(201)))), ((int)(((byte)(163)))));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(530, 1290);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(134, 72);
            this.btnBack.TabIndex = 57;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(298, 1290);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(134, 72);
            this.btnDelete.TabIndex = 56;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmOrphanage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(247)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1374, 929);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvOrphanage);
            this.Controls.Add(this.txtONumber);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtOrpName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmOrphanage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOrphanage";
            this.Load += new System.EventHandler(this.frmOrphanage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrphanage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrpName;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtONumber;
        private System.Windows.Forms.DataGridView dgvOrphanage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDelete;
    }
}