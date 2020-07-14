namespace SportsAgencyTycoonV2
{
    partial class CreateManagerAndAgency
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
            this.lblManagerFirstName = new System.Windows.Forms.Label();
            this.lblAgencyName = new System.Windows.Forms.Label();
            this.lblManagerLastName = new System.Windows.Forms.Label();
            this.txtManagerFirstName = new System.Windows.Forms.TextBox();
            this.txtManagerLastName = new System.Windows.Forms.TextBox();
            this.txtAgencyName = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cbRandomLicenseOrder = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblManagerFirstName
            // 
            this.lblManagerFirstName.AutoSize = true;
            this.lblManagerFirstName.Location = new System.Drawing.Point(8, 9);
            this.lblManagerFirstName.Name = "lblManagerFirstName";
            this.lblManagerFirstName.Size = new System.Drawing.Size(148, 17);
            this.lblManagerFirstName.TabIndex = 0;
            this.lblManagerFirstName.Text = "Manager First Name:";
            // 
            // lblAgencyName
            // 
            this.lblAgencyName.AutoSize = true;
            this.lblAgencyName.Location = new System.Drawing.Point(48, 89);
            this.lblAgencyName.Name = "lblAgencyName";
            this.lblAgencyName.Size = new System.Drawing.Size(110, 17);
            this.lblAgencyName.TabIndex = 1;
            this.lblAgencyName.Text = "Agency Name:";
            // 
            // lblManagerLastName
            // 
            this.lblManagerLastName.AutoSize = true;
            this.lblManagerLastName.Location = new System.Drawing.Point(8, 49);
            this.lblManagerLastName.Name = "lblManagerLastName";
            this.lblManagerLastName.Size = new System.Drawing.Size(148, 17);
            this.lblManagerLastName.TabIndex = 2;
            this.lblManagerLastName.Text = "Manager Last Name:";
            // 
            // txtManagerFirstName
            // 
            this.txtManagerFirstName.Location = new System.Drawing.Point(155, 9);
            this.txtManagerFirstName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtManagerFirstName.MaxLength = 10;
            this.txtManagerFirstName.Name = "txtManagerFirstName";
            this.txtManagerFirstName.Size = new System.Drawing.Size(245, 23);
            this.txtManagerFirstName.TabIndex = 3;
            // 
            // txtManagerLastName
            // 
            this.txtManagerLastName.Location = new System.Drawing.Point(155, 46);
            this.txtManagerLastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtManagerLastName.MaxLength = 10;
            this.txtManagerLastName.Name = "txtManagerLastName";
            this.txtManagerLastName.Size = new System.Drawing.Size(245, 23);
            this.txtManagerLastName.TabIndex = 4;
            // 
            // txtAgencyName
            // 
            this.txtAgencyName.Location = new System.Drawing.Point(155, 85);
            this.txtAgencyName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAgencyName.MaxLength = 30;
            this.txtAgencyName.Name = "txtAgencyName";
            this.txtAgencyName.Size = new System.Drawing.Size(245, 23);
            this.txtAgencyName.TabIndex = 5;
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(275, 126);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(80, 28);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cbRandomLicenseOrder
            // 
            this.cbRandomLicenseOrder.AutoSize = true;
            this.cbRandomLicenseOrder.Location = new System.Drawing.Point(52, 133);
            this.cbRandomLicenseOrder.Margin = new System.Windows.Forms.Padding(4);
            this.cbRandomLicenseOrder.Name = "cbRandomLicenseOrder";
            this.cbRandomLicenseOrder.Size = new System.Drawing.Size(192, 21);
            this.cbRandomLicenseOrder.TabIndex = 6;
            this.cbRandomLicenseOrder.Text = "Random License Order?";
            this.cbRandomLicenseOrder.UseVisualStyleBackColor = true;
            // 
            // CreateManagerAndAgency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(416, 169);
            this.ControlBox = false;
            this.Controls.Add(this.cbRandomLicenseOrder);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtAgencyName);
            this.Controls.Add(this.txtManagerLastName);
            this.Controls.Add(this.txtManagerFirstName);
            this.Controls.Add(this.lblManagerLastName);
            this.Controls.Add(this.lblAgencyName);
            this.Controls.Add(this.lblManagerFirstName);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(196)))), ((int)(((byte)(23)))));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateManagerAndAgency";
            this.Text = "Create Manager And Agency";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblManagerFirstName;
        private System.Windows.Forms.Label lblAgencyName;
        private System.Windows.Forms.Label lblManagerLastName;
        private System.Windows.Forms.TextBox txtManagerFirstName;
        private System.Windows.Forms.TextBox txtManagerLastName;
        private System.Windows.Forms.TextBox txtAgencyName;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.CheckBox cbRandomLicenseOrder;
    }
}