namespace StreetChildrenCareSystem.Forms
{
    partial class frmChildProfile
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
            this.btnHome = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDeleteChild = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbSortVac = new System.Windows.Forms.ComboBox();
            this.dgvVaccinations = new System.Windows.Forms.DataGridView();
            this.btnAddVaccination = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblChildID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblOrphanage = new System.Windows.Forms.Label();
            this.lblFoundation = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccinations)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Child Profile";
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(795, 38);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(133, 69);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1131, 40);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(133, 67);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFoundation);
            this.panel1.Controls.Add(this.lblOrphanage);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblLocation);
            this.panel1.Controls.Add(this.lblGender);
            this.panel1.Controls.Add(this.lblAge);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblChildID);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(91, 184);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1160, 576);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "ChildID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Age :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(625, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Gender :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Found At :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 341);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Status :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 415);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 25);
            this.label8.TabIndex = 6;
            this.label8.Text = "Orphanage :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 495);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 25);
            this.label9.TabIndex = 7;
            this.label9.Text = "Foundation :";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(201, 816);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(233, 87);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit Profile";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDeleteChild
            // 
            this.btnDeleteChild.Location = new System.Drawing.Point(708, 816);
            this.btnDeleteChild.Name = "btnDeleteChild";
            this.btnDeleteChild.Size = new System.Drawing.Size(243, 87);
            this.btnDeleteChild.TabIndex = 5;
            this.btnDeleteChild.Text = "Delete Child";
            this.btnDeleteChild.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(86, 972);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(282, 25);
            this.label10.TabIndex = 6;
            this.label10.Text = "── Vaccination Records ──";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(100, 1056);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 25);
            this.label11.TabIndex = 7;
            this.label11.Text = "Sort :";
            // 
            // cmbSortVac
            // 
            this.cmbSortVac.FormattingEnabled = true;
            this.cmbSortVac.Items.AddRange(new object[] {
            "Sort by Date",
            "Sort by Status"});
            this.cmbSortVac.Location = new System.Drawing.Point(201, 1053);
            this.cmbSortVac.Name = "cmbSortVac";
            this.cmbSortVac.Size = new System.Drawing.Size(383, 33);
            this.cmbSortVac.TabIndex = 8;
            // 
            // dgvVaccinations
            // 
            this.dgvVaccinations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVaccinations.Location = new System.Drawing.Point(91, 1202);
            this.dgvVaccinations.Name = "dgvVaccinations";
            this.dgvVaccinations.RowHeadersWidth = 82;
            this.dgvVaccinations.RowTemplate.Height = 33;
            this.dgvVaccinations.Size = new System.Drawing.Size(1173, 480);
            this.dgvVaccinations.TabIndex = 9;
            // 
            // btnAddVaccination
            // 
            this.btnAddVaccination.Location = new System.Drawing.Point(169, 1735);
            this.btnAddVaccination.Name = "btnAddVaccination";
            this.btnAddVaccination.Size = new System.Drawing.Size(199, 96);
            this.btnAddVaccination.TabIndex = 10;
            this.btnAddVaccination.Text = "Add Vaccination";
            this.btnAddVaccination.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(1065, 1735);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(199, 96);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // lblChildID
            // 
            this.lblChildID.AutoSize = true;
            this.lblChildID.Location = new System.Drawing.Point(210, 54);
            this.lblChildID.Name = "lblChildID";
            this.lblChildID.Size = new System.Drawing.Size(36, 25);
            this.lblChildID.TabIndex = 8;
            this.lblChildID.Text = "00";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(214, 127);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(36, 25);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "00";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(214, 195);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(36, 25);
            this.lblAge.TabIndex = 11;
            this.lblAge.Text = "00";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(743, 195);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(36, 25);
            this.lblGender.TabIndex = 13;
            this.lblGender.Text = "00";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(214, 269);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(36, 25);
            this.lblLocation.TabIndex = 15;
            this.lblLocation.Text = "00";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(214, 341);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(36, 25);
            this.lblStatus.TabIndex = 17;
            this.lblStatus.Text = "00";
            // 
            // lblOrphanage
            // 
            this.lblOrphanage.AutoSize = true;
            this.lblOrphanage.Location = new System.Drawing.Point(214, 415);
            this.lblOrphanage.Name = "lblOrphanage";
            this.lblOrphanage.Size = new System.Drawing.Size(36, 25);
            this.lblOrphanage.TabIndex = 19;
            this.lblOrphanage.Text = "00";
            // 
            // lblFoundation
            // 
            this.lblFoundation.AutoSize = true;
            this.lblFoundation.Location = new System.Drawing.Point(214, 495);
            this.lblFoundation.Name = "lblFoundation";
            this.lblFoundation.Size = new System.Drawing.Size(36, 25);
            this.lblFoundation.TabIndex = 21;
            this.lblFoundation.Text = "00";
            // 
            // frmChildProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1374, 929);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAddVaccination);
            this.Controls.Add(this.dgvVaccinations);
            this.Controls.Add(this.cmbSortVac);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnDeleteChild);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.label1);
            this.Name = "frmChildProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChildProfile";
            this.Load += new System.EventHandler(this.frmChildProfile_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccinations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDeleteChild;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbSortVac;
        private System.Windows.Forms.DataGridView dgvVaccinations;
        private System.Windows.Forms.Button btnAddVaccination;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblFoundation;
        private System.Windows.Forms.Label lblOrphanage;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblChildID;
    }
}