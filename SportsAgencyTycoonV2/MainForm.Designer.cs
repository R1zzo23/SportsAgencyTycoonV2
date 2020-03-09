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
            this.lblAgencyName = new System.Windows.Forms.Label();
            this.lblManagerName = new System.Windows.Forms.Label();
            this.cbManagerActions = new System.Windows.Forms.ComboBox();
            this.btnManagerAction = new System.Windows.Forms.Button();
            this.lblAgencyMoney = new System.Windows.Forms.Label();
            this.lblInfluencePoints = new System.Windows.Forms.Label();
            this.gbCurrentOffice = new System.Windows.Forms.GroupBox();
            this.lblPurchaseCost = new System.Windows.Forms.Label();
            this.lblMonthlyCost = new System.Windows.Forms.Label();
            this.lblEmployeeCapacity = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblOfficeLevel = new System.Windows.Forms.Label();
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
            this.gbManager.Location = new System.Drawing.Point(20, 78);
            this.gbManager.Name = "gbManager";
            this.gbManager.Size = new System.Drawing.Size(469, 148);
            this.gbManager.TabIndex = 0;
            this.gbManager.TabStop = false;
            this.gbManager.Text = "Manager";
            // 
            // lblAgencyName
            // 
            this.lblAgencyName.AutoSize = true;
            this.lblAgencyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgencyName.Location = new System.Drawing.Point(12, 9);
            this.lblAgencyName.Name = "lblAgencyName";
            this.lblAgencyName.Size = new System.Drawing.Size(280, 44);
            this.lblAgencyName.TabIndex = 1;
            this.lblAgencyName.Text = "[Agency Name]";
            // 
            // lblManagerName
            // 
            this.lblManagerName.AutoSize = true;
            this.lblManagerName.Location = new System.Drawing.Point(7, 31);
            this.lblManagerName.Name = "lblManagerName";
            this.lblManagerName.Size = new System.Drawing.Size(80, 25);
            this.lblManagerName.TabIndex = 0;
            this.lblManagerName.Text = "Name: ";
            // 
            // cbManagerActions
            // 
            this.cbManagerActions.FormattingEnabled = true;
            this.cbManagerActions.Location = new System.Drawing.Point(12, 90);
            this.cbManagerActions.Name = "cbManagerActions";
            this.cbManagerActions.Size = new System.Drawing.Size(239, 33);
            this.cbManagerActions.TabIndex = 1;
            // 
            // btnManagerAction
            // 
            this.btnManagerAction.Location = new System.Drawing.Point(257, 90);
            this.btnManagerAction.Name = "btnManagerAction";
            this.btnManagerAction.Size = new System.Drawing.Size(202, 52);
            this.btnManagerAction.TabIndex = 2;
            this.btnManagerAction.Text = "Manager Action";
            this.btnManagerAction.UseVisualStyleBackColor = true;
            this.btnManagerAction.Click += new System.EventHandler(this.btnManagerAction_Click);
            // 
            // lblAgencyMoney
            // 
            this.lblAgencyMoney.AutoSize = true;
            this.lblAgencyMoney.Location = new System.Drawing.Point(722, 24);
            this.lblAgencyMoney.Name = "lblAgencyMoney";
            this.lblAgencyMoney.Size = new System.Drawing.Size(113, 25);
            this.lblAgencyMoney.TabIndex = 2;
            this.lblAgencyMoney.Text = "Money: $0";
            // 
            // lblInfluencePoints
            // 
            this.lblInfluencePoints.AutoSize = true;
            this.lblInfluencePoints.Location = new System.Drawing.Point(1010, 24);
            this.lblInfluencePoints.Name = "lblInfluencePoints";
            this.lblInfluencePoints.Size = new System.Drawing.Size(189, 25);
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
            this.gbCurrentOffice.Location = new System.Drawing.Point(20, 232);
            this.gbCurrentOffice.Name = "gbCurrentOffice";
            this.gbCurrentOffice.Size = new System.Drawing.Size(469, 256);
            this.gbCurrentOffice.TabIndex = 4;
            this.gbCurrentOffice.TabStop = false;
            this.gbCurrentOffice.Text = "Current Office";
            // 
            // lblPurchaseCost
            // 
            this.lblPurchaseCost.AutoSize = true;
            this.lblPurchaseCost.Location = new System.Drawing.Point(17, 76);
            this.lblPurchaseCost.Name = "lblPurchaseCost";
            this.lblPurchaseCost.Size = new System.Drawing.Size(189, 25);
            this.lblPurchaseCost.TabIndex = 0;
            this.lblPurchaseCost.Text = "Purchase Cost: $0";
            // 
            // lblMonthlyCost
            // 
            this.lblMonthlyCost.AutoSize = true;
            this.lblMonthlyCost.Location = new System.Drawing.Point(17, 111);
            this.lblMonthlyCost.Name = "lblMonthlyCost";
            this.lblMonthlyCost.Size = new System.Drawing.Size(174, 25);
            this.lblMonthlyCost.TabIndex = 1;
            this.lblMonthlyCost.Text = "Monthly Cost: $0";
            // 
            // lblEmployeeCapacity
            // 
            this.lblEmployeeCapacity.AutoSize = true;
            this.lblEmployeeCapacity.Location = new System.Drawing.Point(17, 146);
            this.lblEmployeeCapacity.Name = "lblEmployeeCapacity";
            this.lblEmployeeCapacity.Size = new System.Drawing.Size(251, 25);
            this.lblEmployeeCapacity.TabIndex = 2;
            this.lblEmployeeCapacity.Text = "Employee Capacity: 0/10";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 62);
            this.button1.TabIndex = 3;
            this.button1.Text = "Find New Office";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(212, 188);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(251, 62);
            this.button2.TabIndex = 4;
            this.button2.Text = "Upgrade Current Office";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblOfficeLevel
            // 
            this.lblOfficeLevel.AutoSize = true;
            this.lblOfficeLevel.Location = new System.Drawing.Point(22, 38);
            this.lblOfficeLevel.Name = "lblOfficeLevel";
            this.lblOfficeLevel.Size = new System.Drawing.Size(150, 25);
            this.lblOfficeLevel.TabIndex = 5;
            this.lblOfficeLevel.Text = "Office Level: 0";
            // 
            // lblLicenseList
            // 
            this.lblLicenseList.AutoSize = true;
            this.lblLicenseList.Location = new System.Drawing.Point(32, 495);
            this.lblLicenseList.Name = "lblLicenseList";
            this.lblLicenseList.Size = new System.Drawing.Size(139, 25);
            this.lblLicenseList.TabIndex = 5;
            this.lblLicenseList.Text = "License List: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 729);
            this.Controls.Add(this.lblLicenseList);
            this.Controls.Add(this.gbCurrentOffice);
            this.Controls.Add(this.lblInfluencePoints);
            this.Controls.Add(this.lblAgencyMoney);
            this.Controls.Add(this.lblAgencyName);
            this.Controls.Add(this.gbManager);
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

