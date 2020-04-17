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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOffice = new System.Windows.Forms.Button();
            this.btnManager = new System.Windows.Forms.Button();
            this.btnJobs = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.panelButtonHighlight = new System.Windows.Forms.Panel();
            this.gbManager.SuspendLayout();
            this.gbCurrentOffice.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbManager
            // 
            this.gbManager.Controls.Add(this.btnManagerAction);
            this.gbManager.Controls.Add(this.cbManagerActions);
            this.gbManager.Controls.Add(this.lblManagerName);
            this.gbManager.Location = new System.Drawing.Point(552, 455);
            this.gbManager.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbManager.Name = "gbManager";
            this.gbManager.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbManager.Size = new System.Drawing.Size(606, 148);
            this.gbManager.TabIndex = 0;
            this.gbManager.TabStop = false;
            this.gbManager.Text = "Manager";
            // 
            // btnManagerAction
            // 
            this.btnManagerAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagerAction.ForeColor = System.Drawing.Color.White;
            this.btnManagerAction.Location = new System.Drawing.Point(379, 64);
            this.btnManagerAction.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnManagerAction.Name = "btnManagerAction";
            this.btnManagerAction.Size = new System.Drawing.Size(219, 78);
            this.btnManagerAction.TabIndex = 2;
            this.btnManagerAction.Text = "Manager Action";
            this.btnManagerAction.UseVisualStyleBackColor = true;
            this.btnManagerAction.Click += new System.EventHandler(this.btnManagerAction_Click);
            // 
            // cbManagerActions
            // 
            this.cbManagerActions.FormattingEnabled = true;
            this.cbManagerActions.Location = new System.Drawing.Point(12, 90);
            this.cbManagerActions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbManagerActions.Name = "cbManagerActions";
            this.cbManagerActions.Size = new System.Drawing.Size(372, 41);
            this.cbManagerActions.TabIndex = 1;
            // 
            // lblManagerName
            // 
            this.lblManagerName.AutoSize = true;
            this.lblManagerName.Location = new System.Drawing.Point(8, 31);
            this.lblManagerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblManagerName.Name = "lblManagerName";
            this.lblManagerName.Size = new System.Drawing.Size(111, 33);
            this.lblManagerName.TabIndex = 0;
            this.lblManagerName.Text = "Name: ";
            // 
            // lblAgencyName
            // 
            this.lblAgencyName.AutoSize = true;
            this.lblAgencyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgencyName.Location = new System.Drawing.Point(17, 29);
            this.lblAgencyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAgencyName.Name = "lblAgencyName";
            this.lblAgencyName.Size = new System.Drawing.Size(280, 44);
            this.lblAgencyName.TabIndex = 1;
            this.lblAgencyName.Text = "[Agency Name]";
            // 
            // lblAgencyMoney
            // 
            this.lblAgencyMoney.AutoSize = true;
            this.lblAgencyMoney.Location = new System.Drawing.Point(577, 40);
            this.lblAgencyMoney.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAgencyMoney.Name = "lblAgencyMoney";
            this.lblAgencyMoney.Size = new System.Drawing.Size(151, 33);
            this.lblAgencyMoney.TabIndex = 2;
            this.lblAgencyMoney.Text = "Money: $0";
            // 
            // lblInfluencePoints
            // 
            this.lblInfluencePoints.AutoSize = true;
            this.lblInfluencePoints.Location = new System.Drawing.Point(816, 40);
            this.lblInfluencePoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfluencePoints.Name = "lblInfluencePoints";
            this.lblInfluencePoints.Size = new System.Drawing.Size(248, 33);
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
            this.gbCurrentOffice.Location = new System.Drawing.Point(552, 147);
            this.gbCurrentOffice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbCurrentOffice.Name = "gbCurrentOffice";
            this.gbCurrentOffice.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbCurrentOffice.Size = new System.Drawing.Size(598, 256);
            this.gbCurrentOffice.TabIndex = 4;
            this.gbCurrentOffice.TabStop = false;
            this.gbCurrentOffice.Text = "Current Office";
            // 
            // lblOfficeLevel
            // 
            this.lblOfficeLevel.AutoSize = true;
            this.lblOfficeLevel.Location = new System.Drawing.Point(16, 29);
            this.lblOfficeLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOfficeLevel.Name = "lblOfficeLevel";
            this.lblOfficeLevel.Size = new System.Drawing.Size(202, 33);
            this.lblOfficeLevel.TabIndex = 5;
            this.lblOfficeLevel.Text = "Office Level: 0";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(212, 188);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(252, 62);
            this.button2.TabIndex = 4;
            this.button2.Text = "Upgrade Current Office";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 188);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 62);
            this.button1.TabIndex = 3;
            this.button1.Text = "Find New Office";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblEmployeeCapacity
            // 
            this.lblEmployeeCapacity.AutoSize = true;
            this.lblEmployeeCapacity.Location = new System.Drawing.Point(16, 146);
            this.lblEmployeeCapacity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeeCapacity.Name = "lblEmployeeCapacity";
            this.lblEmployeeCapacity.Size = new System.Drawing.Size(350, 33);
            this.lblEmployeeCapacity.TabIndex = 2;
            this.lblEmployeeCapacity.Text = "Employee Capacity: 0/10";
            // 
            // lblMonthlyCost
            // 
            this.lblMonthlyCost.AutoSize = true;
            this.lblMonthlyCost.Location = new System.Drawing.Point(16, 112);
            this.lblMonthlyCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonthlyCost.Name = "lblMonthlyCost";
            this.lblMonthlyCost.Size = new System.Drawing.Size(232, 33);
            this.lblMonthlyCost.TabIndex = 1;
            this.lblMonthlyCost.Text = "Monthly Cost: $0";
            // 
            // lblPurchaseCost
            // 
            this.lblPurchaseCost.AutoSize = true;
            this.lblPurchaseCost.Location = new System.Drawing.Point(16, 77);
            this.lblPurchaseCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPurchaseCost.Name = "lblPurchaseCost";
            this.lblPurchaseCost.Size = new System.Drawing.Size(245, 33);
            this.lblPurchaseCost.TabIndex = 0;
            this.lblPurchaseCost.Text = "Purchase Cost: $0";
            // 
            // lblLicenseList
            // 
            this.lblLicenseList.AutoSize = true;
            this.lblLicenseList.Location = new System.Drawing.Point(546, 656);
            this.lblLicenseList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicenseList.Name = "lblLicenseList";
            this.lblLicenseList.Size = new System.Drawing.Size(171, 33);
            this.lblLicenseList.TabIndex = 5;
            this.lblLicenseList.Text = "License List: ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAgencyName);
            this.panel1.Controls.Add(this.lblAgencyMoney);
            this.panel1.Controls.Add(this.lblInfluencePoints);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1174, 100);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelButtonHighlight);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.btnClients);
            this.panel2.Controls.Add(this.btnJobs);
            this.panel2.Controls.Add(this.btnManager);
            this.panel2.Controls.Add(this.btnOffice);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(166, 629);
            this.panel2.TabIndex = 7;
            // 
            // btnOffice
            // 
            this.btnOffice.FlatAppearance.BorderSize = 0;
            this.btnOffice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOffice.ForeColor = System.Drawing.Color.White;
            this.btnOffice.Image = ((System.Drawing.Image)(resources.GetObject("btnOffice.Image")));
            this.btnOffice.Location = new System.Drawing.Point(3, 3);
            this.btnOffice.Name = "btnOffice";
            this.btnOffice.Size = new System.Drawing.Size(149, 92);
            this.btnOffice.TabIndex = 0;
            this.btnOffice.Text = "Office";
            this.btnOffice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOffice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOffice.UseVisualStyleBackColor = true;
            this.btnOffice.Click += new System.EventHandler(this.btnOffice_Click);
            // 
            // btnManager
            // 
            this.btnManager.FlatAppearance.BorderSize = 0;
            this.btnManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManager.ForeColor = System.Drawing.Color.White;
            this.btnManager.Image = ((System.Drawing.Image)(resources.GetObject("btnManager.Image")));
            this.btnManager.Location = new System.Drawing.Point(3, 107);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(149, 92);
            this.btnManager.TabIndex = 1;
            this.btnManager.Text = "Manager";
            this.btnManager.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnManager.UseVisualStyleBackColor = true;
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // btnJobs
            // 
            this.btnJobs.FlatAppearance.BorderSize = 0;
            this.btnJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobs.ForeColor = System.Drawing.Color.White;
            this.btnJobs.Image = ((System.Drawing.Image)(resources.GetObject("btnJobs.Image")));
            this.btnJobs.Location = new System.Drawing.Point(3, 211);
            this.btnJobs.Name = "btnJobs";
            this.btnJobs.Size = new System.Drawing.Size(149, 92);
            this.btnJobs.TabIndex = 2;
            this.btnJobs.Text = "Jobs";
            this.btnJobs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJobs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnJobs.UseVisualStyleBackColor = true;
            this.btnJobs.Click += new System.EventHandler(this.btnJobs_Click);
            // 
            // btnClients
            // 
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.ForeColor = System.Drawing.Color.White;
            this.btnClients.Image = ((System.Drawing.Image)(resources.GetObject("btnClients.Image")));
            this.btnClients.Location = new System.Drawing.Point(0, 315);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(152, 92);
            this.btnClients.TabIndex = 3;
            this.btnClients.Text = "Clients";
            this.btnClients.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClients.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // button7
            // 
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(3, 419);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(149, 92);
            this.button7.TabIndex = 4;
            this.button7.Text = "Menu 5";
            this.button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(3, 523);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(149, 92);
            this.button8.TabIndex = 5;
            this.button8.Text = "Menu 6";
            this.button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // panelButtonHighlight
            // 
            this.panelButtonHighlight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(196)))), ((int)(((byte)(23)))));
            this.panelButtonHighlight.Location = new System.Drawing.Point(159, 6);
            this.panelButtonHighlight.Name = "panelButtonHighlight";
            this.panelButtonHighlight.Size = new System.Drawing.Size(7, 100);
            this.panelButtonHighlight.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1174, 729);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblLicenseList);
            this.Controls.Add(this.gbCurrentOffice);
            this.Controls.Add(this.gbManager);
            this.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(196)))), ((int)(((byte)(23)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Sports Agency Tycoon";
            this.gbManager.ResumeLayout(false);
            this.gbManager.PerformLayout();
            this.gbCurrentOffice.ResumeLayout(false);
            this.gbCurrentOffice.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnJobs;
        private System.Windows.Forms.Button btnManager;
        private System.Windows.Forms.Button btnOffice;
        private System.Windows.Forms.Panel panelButtonHighlight;
    }
}

