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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnManagerAction = new System.Windows.Forms.Button();
            this.cbManagerActions = new System.Windows.Forms.ComboBox();
            this.lblManagerName = new System.Windows.Forms.Label();
            this.lblAgencyName = new System.Windows.Forms.Label();
            this.lblAgencyMoney = new System.Windows.Forms.Label();
            this.lblInfluencePoints = new System.Windows.Forms.Label();
            this.lblOfficeLevel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblEmployeeCapacity = new System.Windows.Forms.Label();
            this.lblMonthlyCost = new System.Windows.Forms.Label();
            this.lblPurchaseCost = new System.Windows.Forms.Label();
            this.lblLicenseList = new System.Windows.Forms.Label();
            this.universalAgencyPanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.panelButtonHighlight = new System.Windows.Forms.Panel();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnJobs = new System.Windows.Forms.Button();
            this.btnManager = new System.Windows.Forms.Button();
            this.btnOffice = new System.Windows.Forms.Button();
            this.toolTipMainForm = new System.Windows.Forms.ToolTip(this.components);
            this.lblManagerIQ = new System.Windows.Forms.Label();
            this.lblManagerNegotiate = new System.Windows.Forms.Label();
            this.lblManagerGreed = new System.Windows.Forms.Label();
            this.lblManagerPower = new System.Windows.Forms.Label();
            this.lblManagerScouting = new System.Windows.Forms.Label();
            this.agencyPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.agencyImageLarge = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.managerImageLarge = new System.Windows.Forms.PictureBox();
            this.freelancePanel = new System.Windows.Forms.Panel();
            this.jobProgressBar = new System.Windows.Forms.ProgressBar();
            this.gbJob3 = new System.Windows.Forms.GroupBox();
            this.job3WeeksToComplete = new System.Windows.Forms.Label();
            this.btnAcceptJob3 = new System.Windows.Forms.Button();
            this.job3PointsUntilCompletion = new System.Windows.Forms.Label();
            this.job3MoneyPayout = new System.Windows.Forms.Label();
            this.job3IPPayout = new System.Windows.Forms.Label();
            this.job3BaselineScore = new System.Windows.Forms.Label();
            this.job3Description = new System.Windows.Forms.Label();
            this.job3Title = new System.Windows.Forms.Label();
            this.gbJob2 = new System.Windows.Forms.GroupBox();
            this.job2WeeksToComplete = new System.Windows.Forms.Label();
            this.btnAcceptJob2 = new System.Windows.Forms.Button();
            this.job2PointsUntilCompletion = new System.Windows.Forms.Label();
            this.job2MoneyPayout = new System.Windows.Forms.Label();
            this.job2IPPayout = new System.Windows.Forms.Label();
            this.job2BaselineScore = new System.Windows.Forms.Label();
            this.job2Description = new System.Windows.Forms.Label();
            this.job2Title = new System.Windows.Forms.Label();
            this.gbJob1 = new System.Windows.Forms.GroupBox();
            this.job1WeeksToComplete = new System.Windows.Forms.Label();
            this.btnAcceptJob1 = new System.Windows.Forms.Button();
            this.job1PointsUntilCompletion = new System.Windows.Forms.Label();
            this.job1MoneyPayout = new System.Windows.Forms.Label();
            this.job1IPPayout = new System.Windows.Forms.Label();
            this.job1BaselineScore = new System.Windows.Forms.Label();
            this.job1Description = new System.Windows.Forms.Label();
            this.job1Title = new System.Windows.Forms.Label();
            this.universalAgencyPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.agencyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agencyImageLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.managerImageLarge)).BeginInit();
            this.freelancePanel.SuspendLayout();
            this.gbJob3.SuspendLayout();
            this.gbJob2.SuspendLayout();
            this.gbJob1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnManagerAction
            // 
            this.btnManagerAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagerAction.ForeColor = System.Drawing.Color.White;
            this.btnManagerAction.Location = new System.Drawing.Point(278, 157);
            this.btnManagerAction.Margin = new System.Windows.Forms.Padding(4);
            this.btnManagerAction.Name = "btnManagerAction";
            this.btnManagerAction.Size = new System.Drawing.Size(130, 25);
            this.btnManagerAction.TabIndex = 2;
            this.btnManagerAction.Text = "Perform Action";
            this.btnManagerAction.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnManagerAction.UseVisualStyleBackColor = true;
            this.btnManagerAction.Click += new System.EventHandler(this.btnManagerAction_Click);
            // 
            // cbManagerActions
            // 
            this.cbManagerActions.FormattingEnabled = true;
            this.cbManagerActions.Location = new System.Drawing.Point(7, 157);
            this.cbManagerActions.Margin = new System.Windows.Forms.Padding(4);
            this.cbManagerActions.Name = "cbManagerActions";
            this.cbManagerActions.Size = new System.Drawing.Size(263, 31);
            this.cbManagerActions.TabIndex = 1;
            // 
            // lblManagerName
            // 
            this.lblManagerName.AutoSize = true;
            this.lblManagerName.Location = new System.Drawing.Point(79, 6);
            this.lblManagerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblManagerName.Name = "lblManagerName";
            this.lblManagerName.Size = new System.Drawing.Size(290, 24);
            this.lblManagerName.TabIndex = 0;
            this.lblManagerName.Text = "Very Very Long Name Here";
            this.lblManagerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAgencyName
            // 
            this.lblAgencyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgencyName.Location = new System.Drawing.Point(412, 9);
            this.lblAgencyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAgencyName.Name = "lblAgencyName";
            this.lblAgencyName.Size = new System.Drawing.Size(379, 24);
            this.lblAgencyName.TabIndex = 1;
            this.lblAgencyName.Text = "[Agency Name]";
            this.lblAgencyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAgencyMoney
            // 
            this.lblAgencyMoney.AutoSize = true;
            this.lblAgencyMoney.Location = new System.Drawing.Point(476, 40);
            this.lblAgencyMoney.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAgencyMoney.Name = "lblAgencyMoney";
            this.lblAgencyMoney.Size = new System.Drawing.Size(116, 24);
            this.lblAgencyMoney.TabIndex = 2;
            this.lblAgencyMoney.Text = "Money: $0";
            // 
            // lblInfluencePoints
            // 
            this.lblInfluencePoints.AutoSize = true;
            this.lblInfluencePoints.Location = new System.Drawing.Point(622, 40);
            this.lblInfluencePoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfluencePoints.Name = "lblInfluencePoints";
            this.lblInfluencePoints.Size = new System.Drawing.Size(194, 24);
            this.lblInfluencePoints.TabIndex = 3;
            this.lblInfluencePoints.Text = "Influence Points: 0";
            // 
            // lblOfficeLevel
            // 
            this.lblOfficeLevel.AutoSize = true;
            this.lblOfficeLevel.Location = new System.Drawing.Point(394, 7);
            this.lblOfficeLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOfficeLevel.Name = "lblOfficeLevel";
            this.lblOfficeLevel.Size = new System.Drawing.Size(89, 24);
            this.lblOfficeLevel.TabIndex = 5;
            this.lblOfficeLevel.Text = "Level: 0";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(780, 7);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
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
            this.button1.Location = new System.Drawing.Point(588, 7);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 62);
            this.button1.TabIndex = 3;
            this.button1.Text = "Find New Office";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblEmployeeCapacity
            // 
            this.lblEmployeeCapacity.AutoSize = true;
            this.lblEmployeeCapacity.Location = new System.Drawing.Point(394, 67);
            this.lblEmployeeCapacity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployeeCapacity.Name = "lblEmployeeCapacity";
            this.lblEmployeeCapacity.Size = new System.Drawing.Size(270, 24);
            this.lblEmployeeCapacity.TabIndex = 2;
            this.lblEmployeeCapacity.Text = "Employee Capacity: 0/10";
            // 
            // lblMonthlyCost
            // 
            this.lblMonthlyCost.AutoSize = true;
            this.lblMonthlyCost.Location = new System.Drawing.Point(394, 47);
            this.lblMonthlyCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonthlyCost.Name = "lblMonthlyCost";
            this.lblMonthlyCost.Size = new System.Drawing.Size(179, 24);
            this.lblMonthlyCost.TabIndex = 1;
            this.lblMonthlyCost.Text = "Monthly Cost: $0";
            // 
            // lblPurchaseCost
            // 
            this.lblPurchaseCost.AutoSize = true;
            this.lblPurchaseCost.Location = new System.Drawing.Point(394, 27);
            this.lblPurchaseCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPurchaseCost.Name = "lblPurchaseCost";
            this.lblPurchaseCost.Size = new System.Drawing.Size(191, 24);
            this.lblPurchaseCost.TabIndex = 0;
            this.lblPurchaseCost.Text = "Purchase Cost: $0";
            // 
            // lblLicenseList
            // 
            this.lblLicenseList.AutoSize = true;
            this.lblLicenseList.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseList.Location = new System.Drawing.Point(433, 97);
            this.lblLicenseList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicenseList.Name = "lblLicenseList";
            this.lblLicenseList.Size = new System.Drawing.Size(221, 25);
            this.lblLicenseList.TabIndex = 5;
            this.lblLicenseList.Text = "Agency License List: ";
            // 
            // universalAgencyPanel
            // 
            this.universalAgencyPanel.Controls.Add(this.lblAgencyName);
            this.universalAgencyPanel.Controls.Add(this.lblAgencyMoney);
            this.universalAgencyPanel.Controls.Add(this.lblInfluencePoints);
            this.universalAgencyPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.universalAgencyPanel.Location = new System.Drawing.Point(0, 0);
            this.universalAgencyPanel.Name = "universalAgencyPanel";
            this.universalAgencyPanel.Size = new System.Drawing.Size(1200, 67);
            this.universalAgencyPanel.TabIndex = 6;
            // 
            // menuPanel
            // 
            this.menuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuPanel.Controls.Add(this.panelButtonHighlight);
            this.menuPanel.Controls.Add(this.btnClients);
            this.menuPanel.Controls.Add(this.btnJobs);
            this.menuPanel.Controls.Add(this.btnManager);
            this.menuPanel.Controls.Add(this.btnOffice);
            this.menuPanel.Location = new System.Drawing.Point(0, 73);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(89, 186);
            this.menuPanel.TabIndex = 7;
            // 
            // panelButtonHighlight
            // 
            this.panelButtonHighlight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(196)))), ((int)(((byte)(23)))));
            this.panelButtonHighlight.Location = new System.Drawing.Point(77, 6);
            this.panelButtonHighlight.Name = "panelButtonHighlight";
            this.panelButtonHighlight.Size = new System.Drawing.Size(7, 40);
            this.panelButtonHighlight.TabIndex = 8;
            // 
            // btnClients
            // 
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.ForeColor = System.Drawing.Color.White;
            this.btnClients.Image = ((System.Drawing.Image)(resources.GetObject("btnClients.Image")));
            this.btnClients.Location = new System.Drawing.Point(0, 141);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(71, 41);
            this.btnClients.TabIndex = 3;
            this.btnClients.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClients.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTipMainForm.SetToolTip(this.btnClients, "Clients");
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnJobs
            // 
            this.btnJobs.FlatAppearance.BorderSize = 0;
            this.btnJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJobs.ForeColor = System.Drawing.Color.White;
            this.btnJobs.Image = ((System.Drawing.Image)(resources.GetObject("btnJobs.Image")));
            this.btnJobs.Location = new System.Drawing.Point(3, 94);
            this.btnJobs.Name = "btnJobs";
            this.btnJobs.Size = new System.Drawing.Size(68, 41);
            this.btnJobs.TabIndex = 2;
            this.btnJobs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJobs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTipMainForm.SetToolTip(this.btnJobs, "Freelance Jobs");
            this.btnJobs.UseVisualStyleBackColor = true;
            this.btnJobs.Click += new System.EventHandler(this.btnJobs_Click);
            // 
            // btnManager
            // 
            this.btnManager.FlatAppearance.BorderSize = 0;
            this.btnManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManager.ForeColor = System.Drawing.Color.White;
            this.btnManager.Image = ((System.Drawing.Image)(resources.GetObject("btnManager.Image")));
            this.btnManager.Location = new System.Drawing.Point(3, 47);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(68, 41);
            this.btnManager.TabIndex = 1;
            this.btnManager.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTipMainForm.SetToolTip(this.btnManager, "Manager");
            this.btnManager.UseVisualStyleBackColor = true;
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // btnOffice
            // 
            this.btnOffice.FlatAppearance.BorderSize = 0;
            this.btnOffice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOffice.ForeColor = System.Drawing.Color.White;
            this.btnOffice.Image = ((System.Drawing.Image)(resources.GetObject("btnOffice.Image")));
            this.btnOffice.Location = new System.Drawing.Point(3, 0);
            this.btnOffice.Name = "btnOffice";
            this.btnOffice.Size = new System.Drawing.Size(68, 41);
            this.btnOffice.TabIndex = 0;
            this.btnOffice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOffice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTipMainForm.SetToolTip(this.btnOffice, "Agency");
            this.btnOffice.UseVisualStyleBackColor = true;
            this.btnOffice.Click += new System.EventHandler(this.btnOffice_Click);
            // 
            // lblManagerIQ
            // 
            this.lblManagerIQ.AutoSize = true;
            this.lblManagerIQ.Location = new System.Drawing.Point(82, 30);
            this.lblManagerIQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblManagerIQ.Name = "lblManagerIQ";
            this.lblManagerIQ.Size = new System.Drawing.Size(62, 24);
            this.lblManagerIQ.TabIndex = 13;
            this.lblManagerIQ.Text = "INT: 0";
            this.toolTipMainForm.SetToolTip(this.lblManagerIQ, "Intelligence");
            // 
            // lblManagerNegotiate
            // 
            this.lblManagerNegotiate.AutoSize = true;
            this.lblManagerNegotiate.Location = new System.Drawing.Point(82, 53);
            this.lblManagerNegotiate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblManagerNegotiate.Name = "lblManagerNegotiate";
            this.lblManagerNegotiate.Size = new System.Drawing.Size(78, 24);
            this.lblManagerNegotiate.TabIndex = 11;
            this.lblManagerNegotiate.Text = "NEG: 0";
            this.toolTipMainForm.SetToolTip(this.lblManagerNegotiate, "Negotiating");
            // 
            // lblManagerGreed
            // 
            this.lblManagerGreed.AutoSize = true;
            this.lblManagerGreed.Location = new System.Drawing.Point(82, 100);
            this.lblManagerGreed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblManagerGreed.Name = "lblManagerGreed";
            this.lblManagerGreed.Size = new System.Drawing.Size(80, 24);
            this.lblManagerGreed.TabIndex = 10;
            this.lblManagerGreed.Text = "GRD: 0";
            this.toolTipMainForm.SetToolTip(this.lblManagerGreed, "Greed");
            // 
            // lblManagerPower
            // 
            this.lblManagerPower.AutoSize = true;
            this.lblManagerPower.Location = new System.Drawing.Point(82, 78);
            this.lblManagerPower.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblManagerPower.Name = "lblManagerPower";
            this.lblManagerPower.Size = new System.Drawing.Size(82, 24);
            this.lblManagerPower.TabIndex = 12;
            this.lblManagerPower.Text = "POW: 0";
            this.toolTipMainForm.SetToolTip(this.lblManagerPower, "Power");
            // 
            // lblManagerScouting
            // 
            this.lblManagerScouting.AutoSize = true;
            this.lblManagerScouting.Location = new System.Drawing.Point(82, 122);
            this.lblManagerScouting.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblManagerScouting.Name = "lblManagerScouting";
            this.lblManagerScouting.Size = new System.Drawing.Size(68, 24);
            this.lblManagerScouting.TabIndex = 14;
            this.lblManagerScouting.Text = "SCT: 0";
            this.toolTipMainForm.SetToolTip(this.lblManagerScouting, "Greed");
            // 
            // agencyPanel
            // 
            this.agencyPanel.Controls.Add(this.lblManagerScouting);
            this.agencyPanel.Controls.Add(this.lblManagerIQ);
            this.agencyPanel.Controls.Add(this.lblManagerNegotiate);
            this.agencyPanel.Controls.Add(this.lblManagerGreed);
            this.agencyPanel.Controls.Add(this.lblManagerPower);
            this.agencyPanel.Controls.Add(this.label2);
            this.agencyPanel.Controls.Add(this.agencyImageLarge);
            this.agencyPanel.Controls.Add(this.label1);
            this.agencyPanel.Controls.Add(this.cbManagerActions);
            this.agencyPanel.Controls.Add(this.lblLicenseList);
            this.agencyPanel.Controls.Add(this.btnManagerAction);
            this.agencyPanel.Controls.Add(this.managerImageLarge);
            this.agencyPanel.Controls.Add(this.button1);
            this.agencyPanel.Controls.Add(this.lblManagerName);
            this.agencyPanel.Controls.Add(this.button2);
            this.agencyPanel.Controls.Add(this.lblOfficeLevel);
            this.agencyPanel.Controls.Add(this.lblMonthlyCost);
            this.agencyPanel.Controls.Add(this.lblPurchaseCost);
            this.agencyPanel.Controls.Add(this.lblEmployeeCapacity);
            this.agencyPanel.Location = new System.Drawing.Point(95, 74);
            this.agencyPanel.Name = "agencyPanel";
            this.agencyPanel.Size = new System.Drawing.Size(1061, 295);
            this.agencyPanel.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(326, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Office";
            // 
            // agencyImageLarge
            // 
            this.agencyImageLarge.Image = ((System.Drawing.Image)(resources.GetObject("agencyImageLarge.Image")));
            this.agencyImageLarge.InitialImage = null;
            this.agencyImageLarge.Location = new System.Drawing.Point(321, 28);
            this.agencyImageLarge.Name = "agencyImageLarge";
            this.agencyImageLarge.Size = new System.Drawing.Size(66, 63);
            this.agencyImageLarge.TabIndex = 8;
            this.agencyImageLarge.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Manager:";
            // 
            // managerImageLarge
            // 
            this.managerImageLarge.Image = ((System.Drawing.Image)(resources.GetObject("managerImageLarge.Image")));
            this.managerImageLarge.InitialImage = ((System.Drawing.Image)(resources.GetObject("managerImageLarge.InitialImage")));
            this.managerImageLarge.Location = new System.Drawing.Point(8, 28);
            this.managerImageLarge.Name = "managerImageLarge";
            this.managerImageLarge.Size = new System.Drawing.Size(66, 63);
            this.managerImageLarge.TabIndex = 6;
            this.managerImageLarge.TabStop = false;
            // 
            // freelancePanel
            // 
            this.freelancePanel.Controls.Add(this.jobProgressBar);
            this.freelancePanel.Controls.Add(this.gbJob3);
            this.freelancePanel.Controls.Add(this.gbJob2);
            this.freelancePanel.Controls.Add(this.gbJob1);
            this.freelancePanel.Location = new System.Drawing.Point(95, 74);
            this.freelancePanel.Name = "freelancePanel";
            this.freelancePanel.Size = new System.Drawing.Size(1061, 295);
            this.freelancePanel.TabIndex = 9;
            // 
            // jobProgressBar
            // 
            this.jobProgressBar.Location = new System.Drawing.Point(8, 270);
            this.jobProgressBar.Name = "jobProgressBar";
            this.jobProgressBar.Size = new System.Drawing.Size(919, 11);
            this.jobProgressBar.TabIndex = 10;
            // 
            // gbJob3
            // 
            this.gbJob3.Controls.Add(this.job3WeeksToComplete);
            this.gbJob3.Controls.Add(this.btnAcceptJob3);
            this.gbJob3.Controls.Add(this.job3PointsUntilCompletion);
            this.gbJob3.Controls.Add(this.job3MoneyPayout);
            this.gbJob3.Controls.Add(this.job3IPPayout);
            this.gbJob3.Controls.Add(this.job3BaselineScore);
            this.gbJob3.Controls.Add(this.job3Description);
            this.gbJob3.Controls.Add(this.job3Title);
            this.gbJob3.Location = new System.Drawing.Point(627, 7);
            this.gbJob3.Name = "gbJob3";
            this.gbJob3.Size = new System.Drawing.Size(300, 222);
            this.gbJob3.TabIndex = 10;
            this.gbJob3.TabStop = false;
            this.gbJob3.Text = "Job 1";
            this.gbJob3.Visible = false;
            // 
            // job3WeeksToComplete
            // 
            this.job3WeeksToComplete.AutoSize = true;
            this.job3WeeksToComplete.Location = new System.Drawing.Point(7, 151);
            this.job3WeeksToComplete.Name = "job3WeeksToComplete";
            this.job3WeeksToComplete.Size = new System.Drawing.Size(221, 24);
            this.job3WeeksToComplete.TabIndex = 9;
            this.job3WeeksToComplete.Text = "Weeks To Complete:";
            // 
            // btnAcceptJob3
            // 
            this.btnAcceptJob3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptJob3.ForeColor = System.Drawing.Color.White;
            this.btnAcceptJob3.Location = new System.Drawing.Point(64, 182);
            this.btnAcceptJob3.Name = "btnAcceptJob3";
            this.btnAcceptJob3.Size = new System.Drawing.Size(117, 31);
            this.btnAcceptJob3.TabIndex = 6;
            this.btnAcceptJob3.Text = "Accept Job";
            this.btnAcceptJob3.UseVisualStyleBackColor = true;
            this.btnAcceptJob3.Click += new System.EventHandler(this.btnAcceptJob3_Click);
            // 
            // job3PointsUntilCompletion
            // 
            this.job3PointsUntilCompletion.AutoSize = true;
            this.job3PointsUntilCompletion.Location = new System.Drawing.Point(7, 130);
            this.job3PointsUntilCompletion.Name = "job3PointsUntilCompletion";
            this.job3PointsUntilCompletion.Size = new System.Drawing.Size(253, 24);
            this.job3PointsUntilCompletion.TabIndex = 5;
            this.job3PointsUntilCompletion.Text = "Points Until Completion: ";
            // 
            // job3MoneyPayout
            // 
            this.job3MoneyPayout.AutoSize = true;
            this.job3MoneyPayout.Location = new System.Drawing.Point(7, 109);
            this.job3MoneyPayout.Name = "job3MoneyPayout";
            this.job3MoneyPayout.Size = new System.Drawing.Size(169, 24);
            this.job3MoneyPayout.TabIndex = 4;
            this.job3MoneyPayout.Text = "Money Payout: ";
            // 
            // job3IPPayout
            // 
            this.job3IPPayout.AutoSize = true;
            this.job3IPPayout.Location = new System.Drawing.Point(7, 88);
            this.job3IPPayout.Name = "job3IPPayout";
            this.job3IPPayout.Size = new System.Drawing.Size(115, 24);
            this.job3IPPayout.TabIndex = 3;
            this.job3IPPayout.Text = "IP Payout: ";
            // 
            // job3BaselineScore
            // 
            this.job3BaselineScore.AutoSize = true;
            this.job3BaselineScore.Location = new System.Drawing.Point(7, 67);
            this.job3BaselineScore.Name = "job3BaselineScore";
            this.job3BaselineScore.Size = new System.Drawing.Size(168, 24);
            this.job3BaselineScore.TabIndex = 2;
            this.job3BaselineScore.Text = "Baseline Score: ";
            // 
            // job3Description
            // 
            this.job3Description.AutoSize = true;
            this.job3Description.Location = new System.Drawing.Point(7, 46);
            this.job3Description.Name = "job3Description";
            this.job3Description.Size = new System.Drawing.Size(184, 24);
            this.job3Description.TabIndex = 1;
            this.job3Description.Text = "Job 1 Description";
            // 
            // job3Title
            // 
            this.job3Title.AutoSize = true;
            this.job3Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.job3Title.Location = new System.Drawing.Point(6, 16);
            this.job3Title.Name = "job3Title";
            this.job3Title.Size = new System.Drawing.Size(249, 37);
            this.job3Title.TabIndex = 0;
            this.job3Title.Text = "Job 1 Title Text";
            this.job3Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbJob2
            // 
            this.gbJob2.Controls.Add(this.job2WeeksToComplete);
            this.gbJob2.Controls.Add(this.btnAcceptJob2);
            this.gbJob2.Controls.Add(this.job2PointsUntilCompletion);
            this.gbJob2.Controls.Add(this.job2MoneyPayout);
            this.gbJob2.Controls.Add(this.job2IPPayout);
            this.gbJob2.Controls.Add(this.job2BaselineScore);
            this.gbJob2.Controls.Add(this.job2Description);
            this.gbJob2.Controls.Add(this.job2Title);
            this.gbJob2.Location = new System.Drawing.Point(321, 7);
            this.gbJob2.Name = "gbJob2";
            this.gbJob2.Size = new System.Drawing.Size(300, 222);
            this.gbJob2.TabIndex = 9;
            this.gbJob2.TabStop = false;
            this.gbJob2.Text = "Job 2";
            this.gbJob2.Visible = false;
            // 
            // job2WeeksToComplete
            // 
            this.job2WeeksToComplete.AutoSize = true;
            this.job2WeeksToComplete.Location = new System.Drawing.Point(4, 151);
            this.job2WeeksToComplete.Name = "job2WeeksToComplete";
            this.job2WeeksToComplete.Size = new System.Drawing.Size(221, 24);
            this.job2WeeksToComplete.TabIndex = 8;
            this.job2WeeksToComplete.Text = "Weeks To Complete:";
            // 
            // btnAcceptJob2
            // 
            this.btnAcceptJob2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptJob2.ForeColor = System.Drawing.Color.White;
            this.btnAcceptJob2.Location = new System.Drawing.Point(79, 182);
            this.btnAcceptJob2.Name = "btnAcceptJob2";
            this.btnAcceptJob2.Size = new System.Drawing.Size(117, 31);
            this.btnAcceptJob2.TabIndex = 6;
            this.btnAcceptJob2.Text = "Accept Job";
            this.btnAcceptJob2.UseVisualStyleBackColor = true;
            this.btnAcceptJob2.Click += new System.EventHandler(this.btnAcceptJob2_Click);
            // 
            // job2PointsUntilCompletion
            // 
            this.job2PointsUntilCompletion.AutoSize = true;
            this.job2PointsUntilCompletion.Location = new System.Drawing.Point(7, 130);
            this.job2PointsUntilCompletion.Name = "job2PointsUntilCompletion";
            this.job2PointsUntilCompletion.Size = new System.Drawing.Size(253, 24);
            this.job2PointsUntilCompletion.TabIndex = 5;
            this.job2PointsUntilCompletion.Text = "Points Until Completion: ";
            // 
            // job2MoneyPayout
            // 
            this.job2MoneyPayout.AutoSize = true;
            this.job2MoneyPayout.Location = new System.Drawing.Point(7, 109);
            this.job2MoneyPayout.Name = "job2MoneyPayout";
            this.job2MoneyPayout.Size = new System.Drawing.Size(169, 24);
            this.job2MoneyPayout.TabIndex = 4;
            this.job2MoneyPayout.Text = "Money Payout: ";
            // 
            // job2IPPayout
            // 
            this.job2IPPayout.AutoSize = true;
            this.job2IPPayout.Location = new System.Drawing.Point(7, 88);
            this.job2IPPayout.Name = "job2IPPayout";
            this.job2IPPayout.Size = new System.Drawing.Size(115, 24);
            this.job2IPPayout.TabIndex = 3;
            this.job2IPPayout.Text = "IP Payout: ";
            // 
            // job2BaselineScore
            // 
            this.job2BaselineScore.AutoSize = true;
            this.job2BaselineScore.Location = new System.Drawing.Point(7, 67);
            this.job2BaselineScore.Name = "job2BaselineScore";
            this.job2BaselineScore.Size = new System.Drawing.Size(168, 24);
            this.job2BaselineScore.TabIndex = 2;
            this.job2BaselineScore.Text = "Baseline Score: ";
            // 
            // job2Description
            // 
            this.job2Description.AutoSize = true;
            this.job2Description.Location = new System.Drawing.Point(7, 46);
            this.job2Description.Name = "job2Description";
            this.job2Description.Size = new System.Drawing.Size(184, 24);
            this.job2Description.TabIndex = 1;
            this.job2Description.Text = "Job 1 Description";
            // 
            // job2Title
            // 
            this.job2Title.AutoSize = true;
            this.job2Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.job2Title.Location = new System.Drawing.Point(6, 16);
            this.job2Title.Name = "job2Title";
            this.job2Title.Size = new System.Drawing.Size(249, 37);
            this.job2Title.TabIndex = 0;
            this.job2Title.Text = "Job 1 Title Text";
            this.job2Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbJob1
            // 
            this.gbJob1.Controls.Add(this.job1WeeksToComplete);
            this.gbJob1.Controls.Add(this.btnAcceptJob1);
            this.gbJob1.Controls.Add(this.job1PointsUntilCompletion);
            this.gbJob1.Controls.Add(this.job1MoneyPayout);
            this.gbJob1.Controls.Add(this.job1IPPayout);
            this.gbJob1.Controls.Add(this.job1BaselineScore);
            this.gbJob1.Controls.Add(this.job1Description);
            this.gbJob1.Controls.Add(this.job1Title);
            this.gbJob1.Location = new System.Drawing.Point(15, 7);
            this.gbJob1.Name = "gbJob1";
            this.gbJob1.Size = new System.Drawing.Size(300, 222);
            this.gbJob1.TabIndex = 8;
            this.gbJob1.TabStop = false;
            this.gbJob1.Text = "Job 1";
            this.gbJob1.Visible = false;
            // 
            // job1WeeksToComplete
            // 
            this.job1WeeksToComplete.AutoSize = true;
            this.job1WeeksToComplete.Location = new System.Drawing.Point(7, 156);
            this.job1WeeksToComplete.Name = "job1WeeksToComplete";
            this.job1WeeksToComplete.Size = new System.Drawing.Size(221, 24);
            this.job1WeeksToComplete.TabIndex = 7;
            this.job1WeeksToComplete.Text = "Weeks To Complete:";
            // 
            // btnAcceptJob1
            // 
            this.btnAcceptJob1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptJob1.ForeColor = System.Drawing.Color.White;
            this.btnAcceptJob1.Location = new System.Drawing.Point(85, 182);
            this.btnAcceptJob1.Name = "btnAcceptJob1";
            this.btnAcceptJob1.Size = new System.Drawing.Size(117, 31);
            this.btnAcceptJob1.TabIndex = 6;
            this.btnAcceptJob1.Text = "Accept Job";
            this.btnAcceptJob1.UseVisualStyleBackColor = true;
            this.btnAcceptJob1.Click += new System.EventHandler(this.btnAcceptJob1_Click);
            // 
            // job1PointsUntilCompletion
            // 
            this.job1PointsUntilCompletion.AutoSize = true;
            this.job1PointsUntilCompletion.Location = new System.Drawing.Point(7, 134);
            this.job1PointsUntilCompletion.Name = "job1PointsUntilCompletion";
            this.job1PointsUntilCompletion.Size = new System.Drawing.Size(253, 24);
            this.job1PointsUntilCompletion.TabIndex = 5;
            this.job1PointsUntilCompletion.Text = "Points Until Completion: ";
            // 
            // job1MoneyPayout
            // 
            this.job1MoneyPayout.AutoSize = true;
            this.job1MoneyPayout.Location = new System.Drawing.Point(7, 112);
            this.job1MoneyPayout.Name = "job1MoneyPayout";
            this.job1MoneyPayout.Size = new System.Drawing.Size(169, 24);
            this.job1MoneyPayout.TabIndex = 4;
            this.job1MoneyPayout.Text = "Money Payout: ";
            // 
            // job1IPPayout
            // 
            this.job1IPPayout.AutoSize = true;
            this.job1IPPayout.Location = new System.Drawing.Point(7, 90);
            this.job1IPPayout.Name = "job1IPPayout";
            this.job1IPPayout.Size = new System.Drawing.Size(115, 24);
            this.job1IPPayout.TabIndex = 3;
            this.job1IPPayout.Text = "IP Payout: ";
            // 
            // job1BaselineScore
            // 
            this.job1BaselineScore.AutoSize = true;
            this.job1BaselineScore.Location = new System.Drawing.Point(7, 68);
            this.job1BaselineScore.Name = "job1BaselineScore";
            this.job1BaselineScore.Size = new System.Drawing.Size(168, 24);
            this.job1BaselineScore.TabIndex = 2;
            this.job1BaselineScore.Text = "Baseline Score: ";
            // 
            // job1Description
            // 
            this.job1Description.AutoSize = true;
            this.job1Description.Location = new System.Drawing.Point(7, 46);
            this.job1Description.Name = "job1Description";
            this.job1Description.Size = new System.Drawing.Size(184, 24);
            this.job1Description.TabIndex = 1;
            this.job1Description.Text = "Job 1 Description";
            // 
            // job1Title
            // 
            this.job1Title.AutoSize = true;
            this.job1Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.job1Title.Location = new System.Drawing.Point(6, 16);
            this.job1Title.Name = "job1Title";
            this.job1Title.Size = new System.Drawing.Size(249, 37);
            this.job1Title.TabIndex = 0;
            this.job1Title.Text = "Job 1 Title Text";
            this.job1Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1200, 781);
            this.Controls.Add(this.freelancePanel);
            this.Controls.Add(this.agencyPanel);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.universalAgencyPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(196)))), ((int)(((byte)(23)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Sports Agency Tycoon";
            this.universalAgencyPanel.ResumeLayout(false);
            this.universalAgencyPanel.PerformLayout();
            this.menuPanel.ResumeLayout(false);
            this.agencyPanel.ResumeLayout(false);
            this.agencyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agencyImageLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.managerImageLarge)).EndInit();
            this.freelancePanel.ResumeLayout(false);
            this.gbJob3.ResumeLayout(false);
            this.gbJob3.PerformLayout();
            this.gbJob2.ResumeLayout(false);
            this.gbJob2.PerformLayout();
            this.gbJob1.ResumeLayout(false);
            this.gbJob1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblManagerName;
        private System.Windows.Forms.Label lblAgencyName;
        private System.Windows.Forms.Button btnManagerAction;
        private System.Windows.Forms.ComboBox cbManagerActions;
        private System.Windows.Forms.Label lblAgencyMoney;
        private System.Windows.Forms.Label lblInfluencePoints;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblEmployeeCapacity;
        private System.Windows.Forms.Label lblMonthlyCost;
        private System.Windows.Forms.Label lblPurchaseCost;
        private System.Windows.Forms.Label lblOfficeLevel;
        private System.Windows.Forms.Label lblLicenseList;
        private System.Windows.Forms.Panel universalAgencyPanel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel panelButtonHighlight;
        private System.Windows.Forms.ToolTip toolTipMainForm;
        private System.Windows.Forms.Panel agencyPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox managerImageLarge;
        private System.Windows.Forms.PictureBox agencyImageLarge;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel freelancePanel;
        public System.Windows.Forms.Label job1Title;
        public System.Windows.Forms.Button btnAcceptJob3;
        public System.Windows.Forms.Label job3PointsUntilCompletion;
        public System.Windows.Forms.Label job3MoneyPayout;
        public System.Windows.Forms.Label job3IPPayout;
        public System.Windows.Forms.Label job3BaselineScore;
        public System.Windows.Forms.Label job3Description;
        public System.Windows.Forms.Label job3Title;
        public System.Windows.Forms.Button btnAcceptJob2;
        public System.Windows.Forms.Label job2PointsUntilCompletion;
        public System.Windows.Forms.Label job2MoneyPayout;
        public System.Windows.Forms.Label job2IPPayout;
        public System.Windows.Forms.Label job2BaselineScore;
        public System.Windows.Forms.Label job2Description;
        public System.Windows.Forms.Label job2Title;
        public System.Windows.Forms.Button btnAcceptJob1;
        public System.Windows.Forms.Label job1PointsUntilCompletion;
        public System.Windows.Forms.Label job1MoneyPayout;
        public System.Windows.Forms.Label job1IPPayout;
        public System.Windows.Forms.Label job1BaselineScore;
        public System.Windows.Forms.Label job1Description;
        public System.Windows.Forms.GroupBox gbJob3;
        public System.Windows.Forms.GroupBox gbJob2;
        public System.Windows.Forms.GroupBox gbJob1;
        public System.Windows.Forms.Label lblManagerIQ;
        public System.Windows.Forms.Label lblManagerNegotiate;
        public System.Windows.Forms.Label lblManagerGreed;
        public System.Windows.Forms.Label lblManagerPower;
        public System.Windows.Forms.ProgressBar jobProgressBar;
        public System.Windows.Forms.Label lblManagerScouting;
        public System.Windows.Forms.Button btnClients;
        public System.Windows.Forms.Button btnJobs;
        public System.Windows.Forms.Button btnManager;
        public System.Windows.Forms.Button btnOffice;
        public System.Windows.Forms.Label job3WeeksToComplete;
        public System.Windows.Forms.Label job2WeeksToComplete;
        public System.Windows.Forms.Label job1WeeksToComplete;
    }
}

