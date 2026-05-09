namespace StreetChildrenCareSystem.Forms
{
    partial class frmAdminDashboard
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblChildCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOrpCount = new System.Windows.Forms.Label();
            this.lblFouCount = new System.Windows.Forms.Label();
            this.lblOverdueCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChildren = new System.Windows.Forms.Button();
            this.btnOrphanage = new System.Windows.Forms.Button();
            this.btnFoundation = new System.Windows.Forms.Button();
            this.btnVaccination = new System.Windows.Forms.Button();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(143, 88);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(362, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Street Children Care System [Admin]";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(143, 184);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(113, 25);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome: ";
            // 
            // lblChildCount
            // 
            this.lblChildCount.AutoSize = true;
            this.lblChildCount.Location = new System.Drawing.Point(182, 460);
            this.lblChildCount.Name = "lblChildCount";
            this.lblChildCount.Size = new System.Drawing.Size(36, 25);
            this.lblChildCount.TabIndex = 2;
            this.lblChildCount.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Children";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(547, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Orphanage";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(937, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Foundation";
            // 
            // lblOrpCount
            // 
            this.lblOrpCount.AutoSize = true;
            this.lblOrpCount.Location = new System.Drawing.Point(583, 460);
            this.lblOrpCount.Name = "lblOrpCount";
            this.lblOrpCount.Size = new System.Drawing.Size(36, 25);
            this.lblOrpCount.TabIndex = 6;
            this.lblOrpCount.Text = "00";
            // 
            // lblFouCount
            // 
            this.lblFouCount.AutoSize = true;
            this.lblFouCount.Location = new System.Drawing.Point(974, 460);
            this.lblFouCount.Name = "lblFouCount";
            this.lblFouCount.Size = new System.Drawing.Size(36, 25);
            this.lblFouCount.TabIndex = 7;
            this.lblFouCount.Text = "00";
            // 
            // lblOverdueCount
            // 
            this.lblOverdueCount.AutoSize = true;
            this.lblOverdueCount.Location = new System.Drawing.Point(583, 676);
            this.lblOverdueCount.Name = "lblOverdueCount";
            this.lblOverdueCount.Size = new System.Drawing.Size(36, 25);
            this.lblOverdueCount.TabIndex = 8;
            this.lblOverdueCount.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(496, 614);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Overdue Vaccinations";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnChildren
            // 
            this.btnChildren.Location = new System.Drawing.Point(148, 784);
            this.btnChildren.Name = "btnChildren";
            this.btnChildren.Size = new System.Drawing.Size(108, 46);
            this.btnChildren.TabIndex = 10;
            this.btnChildren.Text = "Children";
            this.btnChildren.UseVisualStyleBackColor = true;
            // 
            // btnOrphanage
            // 
            this.btnOrphanage.Location = new System.Drawing.Point(571, 784);
            this.btnOrphanage.Name = "btnOrphanage";
            this.btnOrphanage.Size = new System.Drawing.Size(112, 46);
            this.btnOrphanage.TabIndex = 12;
            this.btnOrphanage.Text = "Orphanage";
            this.btnOrphanage.UseVisualStyleBackColor = true;
            // 
            // btnFoundation
            // 
            this.btnFoundation.Location = new System.Drawing.Point(1037, 784);
            this.btnFoundation.Name = "btnFoundation";
            this.btnFoundation.Size = new System.Drawing.Size(116, 46);
            this.btnFoundation.TabIndex = 14;
            this.btnFoundation.Text = "Foundation";
            this.btnFoundation.UseVisualStyleBackColor = true;
            // 
            // btnVaccination
            // 
            this.btnVaccination.Location = new System.Drawing.Point(148, 904);
            this.btnVaccination.Name = "btnVaccination";
            this.btnVaccination.Size = new System.Drawing.Size(148, 44);
            this.btnVaccination.TabIndex = 16;
            this.btnVaccination.Text = "Vaccination";
            this.btnVaccination.UseVisualStyleBackColor = true;
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Location = new System.Drawing.Point(571, 904);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(112, 44);
            this.btnManageUsers.TabIndex = 18;
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1037, 904);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(102, 44);
            this.btnLogout.TabIndex = 20;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // frmAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 1018);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageUsers);
            this.Controls.Add(this.btnVaccination);
            this.Controls.Add(this.btnFoundation);
            this.Controls.Add(this.btnOrphanage);
            this.Controls.Add(this.btnChildren);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblOverdueCount);
            this.Controls.Add(this.lblFouCount);
            this.Controls.Add(this.lblOrpCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblChildCount);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmAdminDashboard";
            this.Text = "frmAdminDashboard";
            this.Load += new System.EventHandler(this.frmAdminDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblChildCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOrpCount;
        private System.Windows.Forms.Label lblFouCount;
        private System.Windows.Forms.Label lblOverdueCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnChildren;
        private System.Windows.Forms.Button btnOrphanage;
        private System.Windows.Forms.Button btnFoundation;
        private System.Windows.Forms.Button btnVaccination;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnLogout;
    }
}