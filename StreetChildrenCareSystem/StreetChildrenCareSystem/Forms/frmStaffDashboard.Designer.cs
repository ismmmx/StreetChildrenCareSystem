namespace StreetChildrenCareSystem.Forms
{
    partial class frmStaffDashboard
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblChildCount = new System.Windows.Forms.Label();
            this.lblOrpCount = new System.Windows.Forms.Label();
            this.lblFouCount = new System.Windows.Forms.Label();
            this.btnViewChildren = new System.Windows.Forms.Button();
            this.btnViewOrphanage = new System.Windows.Forms.Button();
            this.btnViewFoundation = new System.Windows.Forms.Button();
            this.btnViewVaccination = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Street Children Care System      [Staff]";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(161, 146);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(113, 25);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome: ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblChildCount);
            this.panel1.Location = new System.Drawing.Point(166, 334);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 204);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblOrpCount);
            this.panel2.Location = new System.Drawing.Point(605, 334);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 204);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.lblFouCount);
            this.panel3.Location = new System.Drawing.Point(1045, 334);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(246, 204);
            this.panel3.TabIndex = 4;
            // 
            // lblChildCount
            // 
            this.lblChildCount.AutoSize = true;
            this.lblChildCount.Location = new System.Drawing.Point(129, 128);
            this.lblChildCount.Name = "lblChildCount";
            this.lblChildCount.Size = new System.Drawing.Size(36, 25);
            this.lblChildCount.TabIndex = 0;
            this.lblChildCount.Text = "00";
            // 
            // lblOrpCount
            // 
            this.lblOrpCount.AutoSize = true;
            this.lblOrpCount.Location = new System.Drawing.Point(131, 128);
            this.lblOrpCount.Name = "lblOrpCount";
            this.lblOrpCount.Size = new System.Drawing.Size(36, 25);
            this.lblOrpCount.TabIndex = 1;
            this.lblOrpCount.Text = "00";
            // 
            // lblFouCount
            // 
            this.lblFouCount.AutoSize = true;
            this.lblFouCount.Location = new System.Drawing.Point(106, 128);
            this.lblFouCount.Name = "lblFouCount";
            this.lblFouCount.Size = new System.Drawing.Size(36, 25);
            this.lblFouCount.TabIndex = 1;
            this.lblFouCount.Text = "00";
            // 
            // btnViewChildren
            // 
            this.btnViewChildren.Location = new System.Drawing.Point(166, 658);
            this.btnViewChildren.Name = "btnViewChildren";
            this.btnViewChildren.Size = new System.Drawing.Size(159, 91);
            this.btnViewChildren.TabIndex = 5;
            this.btnViewChildren.Text = "View Children";
            this.btnViewChildren.UseVisualStyleBackColor = true;
            // 
            // btnViewOrphanage
            // 
            this.btnViewOrphanage.Location = new System.Drawing.Point(660, 658);
            this.btnViewOrphanage.Name = "btnViewOrphanage";
            this.btnViewOrphanage.Size = new System.Drawing.Size(137, 91);
            this.btnViewOrphanage.TabIndex = 6;
            this.btnViewOrphanage.Text = "View Orphanage";
            this.btnViewOrphanage.UseVisualStyleBackColor = true;
            // 
            // btnViewFoundation
            // 
            this.btnViewFoundation.Location = new System.Drawing.Point(1045, 668);
            this.btnViewFoundation.Name = "btnViewFoundation";
            this.btnViewFoundation.Size = new System.Drawing.Size(158, 81);
            this.btnViewFoundation.TabIndex = 7;
            this.btnViewFoundation.Text = "View Foundation";
            this.btnViewFoundation.UseVisualStyleBackColor = true;
            // 
            // btnViewVaccination
            // 
            this.btnViewVaccination.Location = new System.Drawing.Point(368, 823);
            this.btnViewVaccination.Name = "btnViewVaccination";
            this.btnViewVaccination.Size = new System.Drawing.Size(143, 81);
            this.btnViewVaccination.TabIndex = 8;
            this.btnViewVaccination.Text = "View Vaccination";
            this.btnViewVaccination.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(842, 843);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(125, 61);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 966);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "⚠️ Staff: View & Search Only";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Children";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Orphanage";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Foundation";
            // 
            // frmStaffDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 1024);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnViewVaccination);
            this.Controls.Add(this.btnViewFoundation);
            this.Controls.Add(this.btnViewOrphanage);
            this.Controls.Add(this.btnViewChildren);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.label1);
            this.Name = "frmStaffDashboard";
            this.Load += new System.EventHandler(this.frmStaffDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblChildCount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblOrpCount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblFouCount;
        private System.Windows.Forms.Button btnViewChildren;
        private System.Windows.Forms.Button btnViewOrphanage;
        private System.Windows.Forms.Button btnViewFoundation;
        private System.Windows.Forms.Button btnViewVaccination;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}