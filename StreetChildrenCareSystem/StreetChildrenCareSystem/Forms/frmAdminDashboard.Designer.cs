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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(143, 88);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(374, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Street Children Care System   [Admin]";
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
            this.lblChildCount.Location = new System.Drawing.Point(95, 88);
            this.lblChildCount.Name = "lblChildCount";
            this.lblChildCount.Size = new System.Drawing.Size(36, 25);
            this.lblChildCount.TabIndex = 2;
            this.lblChildCount.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Children";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Orphanage";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Foundation";
            // 
            // lblOrpCount
            // 
            this.lblOrpCount.AutoSize = true;
            this.lblOrpCount.Location = new System.Drawing.Point(100, 79);
            this.lblOrpCount.Name = "lblOrpCount";
            this.lblOrpCount.Size = new System.Drawing.Size(36, 25);
            this.lblOrpCount.TabIndex = 6;
            this.lblOrpCount.Text = "00";
            // 
            // lblFouCount
            // 
            this.lblFouCount.AutoSize = true;
            this.lblFouCount.Location = new System.Drawing.Point(99, 76);
            this.lblFouCount.Name = "lblFouCount";
            this.lblFouCount.Size = new System.Drawing.Size(36, 25);
            this.lblFouCount.TabIndex = 7;
            this.lblFouCount.Text = "00";
            // 
            // lblOverdueCount
            // 
            this.lblOverdueCount.AutoSize = true;
            this.lblOverdueCount.Location = new System.Drawing.Point(112, 90);
            this.lblOverdueCount.Name = "lblOverdueCount";
            this.lblOverdueCount.Size = new System.Drawing.Size(36, 25);
            this.lblOverdueCount.TabIndex = 8;
            this.lblOverdueCount.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Overdue Vaccinations";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnChildren
            // 
            this.btnChildren.Location = new System.Drawing.Point(206, 810);
            this.btnChildren.Name = "btnChildren";
            this.btnChildren.Size = new System.Drawing.Size(108, 46);
            this.btnChildren.TabIndex = 10;
            this.btnChildren.Text = "Children";
            this.btnChildren.UseVisualStyleBackColor = true;
            this.btnChildren.Click += new System.EventHandler(this.btnChildren_Click);
            // 
            // btnOrphanage
            // 
            this.btnOrphanage.Location = new System.Drawing.Point(619, 810);
            this.btnOrphanage.Name = "btnOrphanage";
            this.btnOrphanage.Size = new System.Drawing.Size(156, 46);
            this.btnOrphanage.TabIndex = 12;
            this.btnOrphanage.Text = "Orphanage";
            this.btnOrphanage.UseVisualStyleBackColor = true;
            this.btnOrphanage.Click += new System.EventHandler(this.btnOrphanage_Click);
            // 
            // btnFoundation
            // 
            this.btnFoundation.Location = new System.Drawing.Point(1073, 810);
            this.btnFoundation.Name = "btnFoundation";
            this.btnFoundation.Size = new System.Drawing.Size(164, 66);
            this.btnFoundation.TabIndex = 14;
            this.btnFoundation.Text = "Foundation";
            this.btnFoundation.UseVisualStyleBackColor = true;
            this.btnFoundation.Click += new System.EventHandler(this.btnFoundation_Click);
            // 
            // btnVaccination
            // 
            this.btnVaccination.Location = new System.Drawing.Point(187, 966);
            this.btnVaccination.Name = "btnVaccination";
            this.btnVaccination.Size = new System.Drawing.Size(148, 44);
            this.btnVaccination.TabIndex = 16;
            this.btnVaccination.Text = "Vaccination";
            this.btnVaccination.UseVisualStyleBackColor = true;
            this.btnVaccination.Click += new System.EventHandler(this.btnVaccination_Click);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Location = new System.Drawing.Point(663, 966);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(112, 44);
            this.btnManageUsers.TabIndex = 18;
            this.btnManageUsers.Text = "Manage Users";
            this.btnManageUsers.UseVisualStyleBackColor = true;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1105, 954);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(102, 44);
            this.btnLogout.TabIndex = 20;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblChildCount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(169, 340);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 145);
            this.panel1.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblOrpCount);
            this.panel2.Location = new System.Drawing.Point(567, 340);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 146);
            this.panel2.TabIndex = 22;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lblFouCount);
            this.panel3.Location = new System.Drawing.Point(969, 340);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(252, 145);
            this.panel3.TabIndex = 23;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.lblOverdueCount);
            this.panel4.Location = new System.Drawing.Point(553, 552);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(250, 148);
            this.panel4.TabIndex = 24;
            // 
            // frmAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1374, 929);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageUsers);
            this.Controls.Add(this.btnVaccination);
            this.Controls.Add(this.btnFoundation);
            this.Controls.Add(this.btnOrphanage);
            this.Controls.Add(this.btnChildren);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmAdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdminDashboard";
            this.Load += new System.EventHandler(this.frmAdminDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}