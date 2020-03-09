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
            this.lblManagerFirstName.Location = new System.Drawing.Point(6, 7);
            this.lblManagerFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblManagerFirstName.Name = "lblManagerFirstName";
            this.lblManagerFirstName.Size = new System.Drawing.Size(105, 13);
            this.lblManagerFirstName.TabIndex = 0;
            this.lblManagerFirstName.Text = "Manager First Name:";
            // 
            // lblAgencyName
            // 
            this.lblAgencyName.AutoSize = true;
            this.lblAgencyName.Location = new System.Drawing.Point(36, 72);
            this.lblAgencyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAgencyName.Name = "lblAgencyName";
            this.lblAgencyName.Size = new System.Drawing.Size(77, 13);
            this.lblAgencyName.TabIndex = 1;
            this.lblAgencyName.Text = "Agency Name:";
            // 
            // lblManagerLastName
            // 
            this.lblManagerLastName.AutoSize = true;
            this.lblManagerLastName.Location = new System.Drawing.Point(6, 40);
            this.lblManagerLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblManagerLastName.Name = "lblManagerLastName";
            this.lblManagerLastName.Size = new System.Drawing.Size(106, 13);
            this.lblManagerLastName.TabIndex = 2;
            this.lblManagerLastName.Text = "Manager Last Name:";
            // 
            // txtManagerFirstName
            // 
            this.txtManagerFirstName.Location = new System.Drawing.Point(116, 7);
            this.txtManagerFirstName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtManagerFirstName.Name = "txtManagerFirstName";
            this.txtManagerFirstName.Size = new System.Drawing.Size(185, 20);
            this.txtManagerFirstName.TabIndex = 3;
            // 
            // txtManagerLastName
            // 
            this.txtManagerLastName.Location = new System.Drawing.Point(116, 37);
            this.txtManagerLastName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtManagerLastName.Name = "txtManagerLastName";
            this.txtManagerLastName.Size = new System.Drawing.Size(185, 20);
            this.txtManagerLastName.TabIndex = 4;
            // 
            // txtAgencyName
            // 
            this.txtAgencyName.Location = new System.Drawing.Point(116, 69);
            this.txtAgencyName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAgencyName.Name = "txtAgencyName";
            this.txtAgencyName.Size = new System.Drawing.Size(185, 20);
            this.txtAgencyName.TabIndex = 5;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(206, 102);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(60, 23);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cbRandomLicenseOrder
            // 
            this.cbRandomLicenseOrder.AutoSize = true;
            this.cbRandomLicenseOrder.Location = new System.Drawing.Point(39, 108);
            this.cbRandomLicenseOrder.Name = "cbRandomLicenseOrder";
            this.cbRandomLicenseOrder.Size = new System.Drawing.Size(141, 17);
            this.cbRandomLicenseOrder.TabIndex = 7;
            this.cbRandomLicenseOrder.Text = "Random License Order?";
            this.cbRandomLicenseOrder.UseVisualStyleBackColor = true;
            // 
            // CreateManagerAndAgency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 137);
            this.Controls.Add(this.cbRandomLicenseOrder);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtAgencyName);
            this.Controls.Add(this.txtManagerLastName);
            this.Controls.Add(this.txtManagerFirstName);
            this.Controls.Add(this.lblManagerLastName);
            this.Controls.Add(this.lblAgencyName);
            this.Controls.Add(this.lblManagerFirstName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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