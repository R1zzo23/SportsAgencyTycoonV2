namespace SportsAgencyTycoonV2
{
    partial class MainForm
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
            this.gbManager = new System.Windows.Forms.GroupBox();
            this.btnManagerAction = new System.Windows.Forms.Button();
            this.cbManagerActions = new System.Windows.Forms.ComboBox();
            this.lblManagerName = new System.Windows.Forms.Label();
            this.lblAgencyName = new System.Windows.Forms.Label();
            this.lblAgencyMoney = new System.Windows.Forms.Label();
            this.lblInfluencePoints = new System.Windows.Forms.Label();
            this.gbCurrentOffice = new System.Windows.Forms.GroupBox();
            this.lblOfficeLevel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblEmployeeCapacity = new System.Windows.Forms.Label();
            this.lblMonthlyCost = new System.Windows.Forms.Label();
            this.lblPurchaseCost = new System.Windows.Forms.Label();
            this.lblLicenseList = new System.Windows.Forms.Label();
            this.gbManager.SuspendLayout();
            this.gbCurrentOffice.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbManager
            // 
            this.gbManager.Controls.Add(this.btnManagerAction);
            this.gbManager.Controls.Add(this.cbManagerActions);
            this.gbManager.Controls.Add(this.lblManagerName);
            this.gbManager.Location = new System.Drawing.Point(10, 41);
            this.gbManager.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbManager.Name = "gbManager";
            this.gbManager.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbManager.Size = new System.Drawing.Size(303, 77);
            this.gbManager.TabIndex = 0;
            this.gbManager.TabStop = false;
            this.gbManager.Text = "Manager";
            // 
            // btnManagerAction
            // 
            this.btnManagerAction.Location = new System.Drawing.Point(198, 47);
            this.btnManagerAction.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnManagerAction.Name = "btnManagerAction";
            this.btnManagerAction.Size = new System.Drawing.Size(101, 27);
            this.btnManagerAction.TabIndex = 2;
            this.btnManagerAction.Text = "Manager Action";
            this.btnManagerAction.UseVisualStyleBackColor = true;
            this.btnManagerAction.Click += new System.EventHandler(this.btnManagerAction_Click);
            // 
            // cbManagerActions
            // 
            this.cbManagerActions.FormattingEnabled = true;
            this.cbManagerActions.Location = new System.Drawing.Point(6, 47);
            this.cbManagerActions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbManagerActions.Name = "cbManagerActions";
            this.cbManagerActions.Size = new System.Drawing.Size(188, 21);
            this.cbManagerActions.TabIndex = 1;
            // 
            // lblManagerName
            // 
            this.lblManagerName.AutoSize = true;
            this.lblManagerName.Location = new System.Drawing.Point(4, 16);
            this.lblManagerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblManagerName.Name = "lblManagerName";
            this.lblManagerName.Size = new System.Drawing.Size(41, 13);
            this.lblManagerName.TabIndex = 0;
            this.lblManagerName.Text = "Name: ";
            // 
            // lblAgencyName
            // 
            this.lblAgencyName.AutoSize = true;
            this.lblAgencyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgencyName.Location = new System.Drawing.Point(6, 5);
            this.lblAgencyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAgencyName.Name = "lblAgencyName";
            this.lblAgencyName.Size = new System.Drawing.Size(141, 24);
            this.lblAgencyName.TabIndex = 1;
            this.lblAgencyName.Text = "[Agency Name]";
            // 
            // lblAgencyMoney
            // 
            this.lblAgencyMoney.AutoSize = true;
            this.lblAgencyMoney.Location = new System.Drawing.Point(361, 12);
            this.lblAgencyMoney.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAgencyMoney.Name = "lblAgencyMoney";
            this.lblAgencyMoney.Size = new System.Drawing.Size(57, 13);
            this.lblAgencyMoney.TabIndex = 2;
            this.lblAgencyMoney.Text = "Money: $0";
            // 
            // lblInfluencePoints
            // 
            this.lblInfluencePoints.AutoSize = true;
            this.lblInfluencePoints.Location = new System.Drawing.Point(505, 12);
            this.lblInfluencePoints.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfluencePoints.Name = "lblInfluencePoints";
            this.lblInfluencePoints.Size = new System.Drawing.Size(95, 13);
            this.lblInfluencePoints.TabIndex = 3;
            this.lblInfluencePoints.Text = "Influence Points: 0";
            // 
            // gbCurrentOffice
            // 
            this.gbCurrentOffice.Controls.Add(this.lblOfficeLevel);
            this.gbCurrentOffice.Controls.Add(this.button2);
            this.gbCurrentOffice.Controls.Add(this.button1);
            this.gbCurrentOffice.Controls.Add(this.lblEmployeeCapacity);
            this.gbCurrentOffice.Controls.Add(this.lblMonthlyCost);
            this.gbCurrentOffice.Controls.Add(this.lblPurchaseCost);
            this.gbCurrentOffice.Location = new System.Drawing.Point(10, 121);
            this.gbCurrentOffice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbCurrentOffice.Name = "gbCurrentOffice";
            this.gbCurrentOffice.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbCurrentOffice.Size = new System.Drawing.Size(299, 133);
            this.gbCurrentOffice.TabIndex = 4;
            this.gbCurrentOffice.TabStop = false;
            this.gbCurrentOffice.Text = "Current Office";
            // 
            // lblOfficeLevel
            // 
            this.lblOfficeLevel.AutoSize = true;
            this.lblOfficeLevel.Location = new System.Drawing.Point(8, 15);
            this.lblOfficeLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOfficeLevel.Name = "lblOfficeLevel";
            this.lblOfficeLevel.Size = new System.Drawing.Size(76, 13);
            this.lblOfficeLevel.TabIndex = 5;
            this.lblOfficeLevel.Text = "Office Level: 0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(106, 98);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 32);
            this.button2.TabIndex = 4;
            this.button2.Text = "Upgrade Current Office";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 98);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Find New Office";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblEmployeeCapacity
            // 
            this.lblEmployeeCapacity.AutoSize = true;
            this.lblEmployeeCapacity.Location = new System.Drawing.Point(8, 76);
            this.lblEmployeeCapacity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmployeeCapacity.Name = "lblEmployeeCapacity";
            this.lblEmployeeCapacity.Size = new System.Drawing.Size(126, 13);
            this.lblEmployeeCapacity.TabIndex = 2;
            this.lblEmployeeCapacity.Text = "Employee Capacity: 0/10";
            // 
            // lblMonthlyCost
            // 
            this.lblMonthlyCost.AutoSize = true;
            this.lblMonthlyCost.Location = new System.Drawing.Point(8, 58);
            this.lblMonthlyCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMonthlyCost.Name = "lblMonthlyCost";
            this.lblMonthlyCost.Size = new System.Drawing.Size(86, 13);
            this.lblMonthlyCost.TabIndex = 1;
            this.lblMonthlyCost.Text = "Monthly Cost: $0";
            // 
            // lblPurchaseCost
            // 
            this.lblPurchaseCost.AutoSize = true;
            this.lblPurchaseCost.Location = new System.Drawing.Point(8, 40);
            this.lblPurchaseCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPurchaseCost.Name = "lblPurchaseCost";
            this.lblPurchaseCost.Size = new System.Drawing.Size(94, 13);
            this.lblPurchaseCost.TabIndex = 0;
            this.lblPurchaseCost.Text = "Purchase Cost: $0";
            // 
            // lblLicenseList
            // 
            this.lblLicenseList.AutoSize = true;
            this.lblLicenseList.Location = new System.Drawing.Point(16, 257);
            this.lblLicenseList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLicenseList.Name = "lblLicenseList";
            this.lblLicenseList.Size = new System.Drawing.Size(69, 13);
            this.lblLicenseList.TabIndex = 5;
            this.lblLicenseList.Text = "License List: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 379);
            this.Controls.Add(this.lblLicenseList);
            this.Controls.Add(this.gbCurrentOffice);
            this.Controls.Add(this.lblInfluencePoints);
            this.Controls.Add(this.lblAgencyMoney);
            this.Controls.Add(this.lblAgencyName);
            this.Controls.Add(this.gbManager);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "Sports Agency Tycoon";
            this.gbManager.ResumeLayout(false);
            this.gbManager.PerformLayout();
            this.gbCurrentOffice.ResumeLayout(false);
            this.gbCurrentOffice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbManager;
        private System.Windows.Forms.Label lblManagerName;
        private System.Windows.Forms.Label lblAgencyName;
        private System.Windows.Forms.Button btnManagerAction;
        private System.Windows.Forms.ComboBox cbManagerActions;
        private System.Windows.Forms.Label lblAgencyMoney;
        private System.Windows.Forms.Label lblInfluencePoints;
        private System.Windows.Forms.GroupBox gbCurrentOffice;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblEmployeeCapacity;
        private System.Windows.Forms.Label lblMonthlyCost;
        private System.Windows.Forms.Label lblPurchaseCost;
        private System.Windows.Forms.Label lblOfficeLevel;
        private System.Windows.Forms.Label lblLicenseList;
    }
}

