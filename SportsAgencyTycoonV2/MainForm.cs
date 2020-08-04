using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsAgencyTycoonV2
{
    public partial class MainForm : Form
    {
        public Random rnd = new Random();
        public World world;
        public Freelance freelance;
        public Timer freelanceJobTimer = new Timer();
        public List<Control> dayMarkers = new List<Control>();
        public List<Control> agentNames = new List<Control>();
        public List<Control> agentGreeds = new List<Control>();
        public List<Control> agentNegotiations = new List<Control>();
        public List<Control> agentScoutings = new List<Control>();
        public List<Control> agentPowers = new List<Control>();
        public List<Control> agentEfficiencies = new List<Control>();
        public List<Control> agentIntelligences = new List<Control>();
        public List<Control> agentGroupBoxes = new List<Control>();
        public List<Control> agentStatusLabels = new List<Control>();
        public List<Control> agentRestButtons = new List<Control>();
        public List<Control> agentSalaries = new List<Control>();

        public WorldPanelFunctions worldPanelFunctions;
        public TeamRosterPanelFunctions teamRosterPanelFunctions;
        public ClientPanelFunctions clientPanelFunctions;
        public ManagerPanelFunctions managerPanelFunctions;
        public AgencyClientsPanelFunctions agencyClientsPanelFunctions;
        public MainForm()
        {
            world = new World(rnd);
            world.mainForm = this;
            InitializeComponent();
            panelButtonHighlight.Height = btnOffice.Height;
            panelButtonHighlight.Top = btnOffice.Top;
            PopUpStartGameForm();
            PopulateManagerAndAgencyInfo();
            PopulateManagerActions();
            freelance = new Freelance(this, rnd, world, world.MyAgency);
            world.calendar = new Calendar(this, world, 1, 1, 1);
            toolTipMainForm.SetToolTip(btnManager, "Manager - " + world.MyAgency.Manager.FullName);
            toolTipMainForm.SetToolTip(btnOffice, "Agency - " + world.MyAgency.Name);
            HideAllPanels();
            AddDayMarkersToList();
            AddAgentLabelsToList();
            UpdateOfficeInfo();
            world.InitializeWorld();
            worldPanelFunctions = new WorldPanelFunctions(this, world);
            teamRosterPanelFunctions = new TeamRosterPanelFunctions(this, world);
            clientPanelFunctions = new ClientPanelFunctions(this, world);
            managerPanelFunctions = new ManagerPanelFunctions(this, world);
            agencyClientsPanelFunctions = new AgencyClientsPanelFunctions(this, world);
        }
        private void AddAgentLabelsToList()
        {
            agentGroupBoxes.Add(gbAgent1);
            agentGroupBoxes.Add(gbAgent2);
            agentGroupBoxes.Add(gbAgent3);
            agentNames.Add(lblAgent1Name);
            agentNames.Add(lblAgent2Name);
            agentNames.Add(lblAgent3Name);
            agentNegotiations.Add(lblAgent1NEG);
            agentNegotiations.Add(lblAgent2NEG);
            agentNegotiations.Add(lblAgent3NEG);
            agentGreeds.Add(lblAgent1GRD);
            agentGreeds.Add(lblAgent2GRD);
            agentGreeds.Add(lblAgent3GRD);
            agentScoutings.Add(lblAgent1SCT);
            agentScoutings.Add(lblAgent2SCT);
            agentScoutings.Add(lblAgent3SCT);
            agentPowers.Add(lblAgent1POW);
            agentPowers.Add(lblAgent2POW);
            agentPowers.Add(lblAgent3POW);
            agentEfficiencies.Add(lblAgent1EFF);
            agentEfficiencies.Add(lblAgent2EFF);
            agentEfficiencies.Add(lblAgent3EFF);
            agentIntelligences.Add(lblAgent1INT);
            agentIntelligences.Add(lblAgent2INT);
            agentIntelligences.Add(lblAgent3INT);
            agentStatusLabels.Add(lblAgent1Status);
            agentStatusLabels.Add(lblAgent2Status);
            agentStatusLabels.Add(lblAgent3Status);
            agentRestButtons.Add(btnAgent1Rest);
            agentRestButtons.Add(btnAgent2Rest);
            agentRestButtons.Add(btnAgent3Rest);
            agentSalaries.Add(lblAgent1Salary);
            agentSalaries.Add(lblAgent2Salary);
            agentSalaries.Add(lblAgent3Salary);
        }
        private void AddDayMarkersToList()
        {
            dayMarkers.Add(pnlDay1);
            dayMarkers.Add(pnlDay2);
            dayMarkers.Add(pnlDay3);
            dayMarkers.Add(pnlDay4);
            dayMarkers.Add(pnlDay5);
            dayMarkers.Add(pnlDay6);
            dayMarkers.Add(pnlDay7);
        }
        public void PopUpStartGameForm()
        {
            CreateManagerAndAgency startGameForm = new CreateManagerAndAgency();
            startGameForm.BringToFront();
            startGameForm.ShowDialog();

            string agencyName = startGameForm.AgencyName;
            string firstName = startGameForm.FirstName;
            string lastName = startGameForm.LastName;

            Agent manager = new Agent(firstName, lastName, Role.Manager, 0, 0, 0, 0, 0, 0);
            world.SetMyAgency(new Agency(this, agencyName, 0));
            world.SetManager(manager);
            world.MyAgency.SetOffice();
            if (startGameForm.RandomLicenseOrder) world.SetLicenseOrder();
        }
        public void PopulateManagerAndAgencyInfo()
        {
            lblAgencyName.Text = world.MyAgency.Name;
            lblManagerName.Text = world.MyAgency.Manager.FullName;
            UpdateAgencyMoneyLabel();
            world.MyAgency.AddInfluencePoints(1000);
            UpdateAgencyInfluencePointsLabel();
            UpdateOfficeInfo();
            UpdateLicenseList();
            world.MyAgency.Manager.UpdateManagerUI(this);
        }
        public void UpdateAgencyMoneyLabel()
        {
            lblAgencyMoney.Text = "Money: " + world.MyAgency.Money.ToString("C0");
        }
        public void UpdateAgencyInfluencePointsLabel()
        {
            lblInfluencePoints.Text = "Influence Points: " + world.MyAgency.InfluencePoints.ToString();
        }
        public void PopulateManagerActions()
        {
            cbManagerActions.Items.Clear();
            if (world.MyAgency.Licenses.Count < 5)
                cbManagerActions.Items.Add("Obtain " + world.LicenseOrder[world.MyAgency.Licenses.Count].ToString() + " License (" + world.NextLicenseCost.ToString() + " IP)");
            cbManagerActions.Items.Add("Freelance");
            cbManagerActions.Items.Add("Search For Player");
            cbManagerActions.Items.Add("Hire Agent");
            //cbManagerActions.Items.Add("Call Teams");
        }
        public void UpdateOfficeInfo()
        {
            lblOfficeLevel.Text = "Office Level: " + world.MyAgency.Office.Level.ToString();
            lblPurchaseCost.Text = "Purchase Cost: " + world.MyAgency.Office.PurchaseCost.ToString("C0");
            lblMonthlyCost.Text = "Monthly Cost: " + world.MyAgency.Office.MonthlyCost.ToString("C0");
            lblEmployeeCapacity.Text = "Employee Capacity: " + (world.MyAgency.AgentCount + 1) + "/" + world.MyAgency.Office.EmployeeCapacity.ToString();
        }
        public void UpdateLicenseList()
        {
            lblLicenseList.Text = "Agency License List: ";
            if (world.MyAgency.Licenses.Count == 0)
                lblLicenseList.Text += "none";
            else
            {
                foreach (Sports s in world.MyAgency.Licenses)
                    lblLicenseList.Text += Environment.NewLine + s.ToString();
            }
        }

        private void btnManagerAction_Click(object sender, EventArgs e)
        {
            if (cbManagerActions.SelectedIndex > -1)
            {
                // obtain next license
                if (cbManagerActions.SelectedIndex == 0)
                {
                    if (world.MyAgency.InfluencePoints < world.NextLicenseCost)
                        MessageBox.Show("Not enough IP to purchase next license.");
                    else
                    {
                        world.ObtainNextLicense();
                        UpdateLicenseList();
                        UpdateAgencyInfluencePointsLabel();
                        PopulateManagerActions();
                        cbManagerActions.Text = "";
                        cbManagerActions.SelectedIndex = -1;
                    }
                }
                // freelance
                else if (cbManagerActions.SelectedIndex == 1)
                {
                    Freelance();
                }
                // search for player
                else if (cbManagerActions.SelectedIndex == 2)
                {
                    OpenClientPanel();
                }
                // hire new agent
                else if (cbManagerActions.SelectedIndex == 3)
                {
                    CheckToHireNewAgent();
                }
            }
        }
        private void CheckToHireNewAgent()
        {
            Console.WriteLine(world.MyAgency.AgentCount + " - - - - - " + world.MyAgency.Office.EmployeeCapacity);
            if (world.MyAgency.AgentCount + 1 < world.MyAgency.Office.EmployeeCapacity)
            {
                // begin agent hiring process
                panelButtonHighlight.Height = btnManager.Height;
                panelButtonHighlight.Top = btnManager.Top;
                HideAllPanels();
                managerPanel.Visible = true;
                managerPanelFunctions.ShowAgentHiringPanel();

            }
            else // show that there's no room in current office
            {
                MessageBox.Show("Office has reached its employee capacity. Upgrade your office or fire an agent to make room for a new one.");
            }
        }
        private void btnOffice_Click(object sender, EventArgs e)
        {
            panelButtonHighlight.Height = btnOffice.Height;
            panelButtonHighlight.Top = btnOffice.Top;
            HideAllPanels();
            agencyPanel.Visible = true;
            world.MyAgency.DisplayAllAgents();
            world.MyAgency.Manager.UpdateManagerUI(this);
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            panelButtonHighlight.Height = btnManager.Height;
            panelButtonHighlight.Top = btnManager.Top;
            HideAllPanels();
            managerPanel.Visible = true;
            managerPanelFunctions.DisplayInfo();
            managerPanelFunctions.HideManagerPanelFunctionPanels();
        }

        private void btnJobs_Click(object sender, EventArgs e)
        {
            Freelance();
        }
        private void Freelance()
        {
            panelButtonHighlight.Height = btnJobs.Height;
            panelButtonHighlight.Top = btnJobs.Top;
            HideAllPanels();
            freelancePanel.Visible = true;
            freelance.ShowFreelancePanel();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            panelButtonHighlight.Height = btnClients.Height;
            panelButtonHighlight.Top = btnClients.Top;
            HideAllPanels();
            agencyClientsPanel.Visible = true;
            agencyClientsPanelFunctions.DisplayClient(0);
        }
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            OpenClientPanel();
        }
        private void OpenClientPanel()
        {
            if (world.MyAgency.Licenses.Count == 0)
                MessageBox.Show("Must have a license to represent players before signing your own.");
            else
            {
                HideAllPanels();
                cbClientSport.SelectedIndex = -1;
                cbClientSport.Text = "";
                cbScoutedPlayers.SelectedIndex = -1;
                cbScoutedPlayers.Text = "";
                scoutClientPanel.Visible = true;
                clientPanelFunctions.FillSportComboBox();
                clientPanelFunctions.FillAgentComboBox();
            }
        }
        private void btnStandings_Click(object sender, EventArgs e)
        {
            panelButtonHighlight.Height = btnStandings.Height;
            panelButtonHighlight.Top = btnStandings.Top;
            HideAllPanels();
            worldPanel.Visible = true;
            worldPanelFunctions.PopulateLeagues();
        }
        private void btnViewRosters_Click(object sender, EventArgs e)
        {
            panelButtonHighlight.Height = btnViewRosters.Height;
            panelButtonHighlight.Top = btnViewRosters.Top;
            HideAllPanels();
            teamRosterPanel.Visible = true;
            worldPanelFunctions.PopulateLeagues();
        }

        private void HideAllPanels()
        {
            agencyPanel.Visible = false;
            freelancePanel.Visible = false;
            worldPanel.Visible = false;
            teamRosterPanel.Visible = false;
            scoutClientPanel.Visible = false;
            managerPanel.Visible = false;
            agencyClientsPanel.Visible = false;
        }
        #region Freelance Buttons
        private void btnAcceptJob1_Click(object sender, EventArgs e)
        {
            FreelanceJob job = world.MyAgency.FreelanceJobsAvailable[0];
            freelance.AttemptJob(job, freelanceJobTimer, jobProgressBar);
        }

        private void btnAcceptJob2_Click(object sender, EventArgs e)
        {
            FreelanceJob job = world.MyAgency.FreelanceJobsAvailable[1];
            freelance.AttemptJob(job, freelanceJobTimer, jobProgressBar);
        }

        private void btnAcceptJob3_Click(object sender, EventArgs e)
        {
            FreelanceJob job = world.MyAgency.FreelanceJobsAvailable[2];
            freelance.AttemptJob(job, freelanceJobTimer, jobProgressBar);
        }
        #endregion
        #region League, Team and Roster IndexChanged Methods
        private void cbLeagues_SelectedIndexChanged(object sender, EventArgs e)
        {
            worldPanelFunctions.LeagueSelected();
        }
        private void cbTeamRoster_SelectedIndexChanged(object sender, EventArgs e)
        {
            teamRosterPanelFunctions.DisplaySelectedPlayerInfo(world.Leagues[cbLeagueList.SelectedIndex].TeamList[cbTeamList.SelectedIndex].Roster[cbTeamRoster.SelectedIndex]);
        }

        private void cbLeagueList_SelectedIndexChanged(object sender, EventArgs e)
        {
            teamRosterPanelFunctions.FillTeamComboBox(world.Leagues[cbLeagueList.SelectedIndex]);
        }

        private void cbTeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLeagueList.SelectedIndex > -1)
            {
                teamRosterPanelFunctions.FillTeamRosterComboBox(world.Leagues[cbLeagueList.SelectedIndex].TeamList[cbTeamList.SelectedIndex]);
                teamRosterPanelFunctions.FillTeamInfo();
            }            
        }
        #endregion

        private void btnSearchForClient_Click(object sender, EventArgs e)
        {
            clientPanelFunctions.SearchForClient();
        }

        private void cbScoutedPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            clientPanelFunctions.DisplayScoutedPlayerInfo();
        }

        private void cbAgentToScout_SelectedIndexChanged(object sender, EventArgs e)
        {
            clientPanelFunctions.SelectAgentToScout();
        }

        private void cbClientSport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClientSport.SelectedIndex > -1)
            {
                clientPanelFunctions.selectedSport = world.MyAgency.Licenses[cbClientSport.SelectedIndex];
            }
            cbScoutedPlayers.SelectedIndex = -1;
            clientPanelFunctions.FillScoutedClientComboBox();
        }
        private void btnSignToAgency_Click(object sender, EventArgs e)
        {
            clientPanelFunctions.SignPlayerToAgency();
        }

        private void btnAgent1Rest_Click(object sender, EventArgs e)
        {
            RestAgent(0);
        }

        private void btnAgent2Rest_Click(object sender, EventArgs e)
        {
            RestAgent(1);
        }

        private void btnAgent3Rest_Click(object sender, EventArgs e)
        {
            RestAgent(2);
        }
        
        private void RestAgent(int i)
        {
            world.MyAgency.AgentRest(i);
        }

        private void btnCloseScoutingPanel_Click(object sender, EventArgs e)
        {
            scoutClientPanel.Visible = false;
        }

        private void btnScrollLeftThroughClients_Click(object sender, EventArgs e)
        {
            agencyClientsPanelFunctions.ScrollLeft();
        }

        private void btnScrollRightThroughClients_Click(object sender, EventArgs e)
        {
            agencyClientsPanelFunctions.ScrollRight();
        }

        private void btnCallForClient_Click(object sender, EventArgs e)
        {
            agencyClientsPanelFunctions.CallTeamOrTeams();
        }

        private void btnNegotiateForClient_Click(object sender, EventArgs e)
        {
            if (rbFocusMoney.Checked == false && rbFocusWinning.Checked == false && rbFocusLifestyle.Checked == false)
                MessageBox.Show("Select a focus for these negotiations.");
            else
            {
                string focus = "";
                if (rbFocusMoney.Checked) focus = "money";
                else if (rbFocusWinning.Checked) focus = "winning";
                else if (rbFocusLifestyle.Checked) focus = "lifestyle";
                agencyClientsPanelFunctions.getClientSignedFunctions.BeginNegotiations(focus);
            }
                
        }
        #region Agent Focus Radio Button CheckedChanged
        private void rbBalancedAgent_CheckedChanged(object sender, EventArgs e)
        {
            managerPanelFunctions.ChangeFocus("balanced");
        }

        private void rbNegotiatingAgent_CheckedChanged(object sender, EventArgs e)
        {
            managerPanelFunctions.ChangeFocus("negotiating");
        }

        private void rbGreedAgent_CheckedChanged(object sender, EventArgs e)
        {
            managerPanelFunctions.ChangeFocus("greed");
        }

        private void rbPowerAgent_CheckedChanged(object sender, EventArgs e)
        {
            managerPanelFunctions.ChangeFocus("power");
        }

        private void rbScoutingAgent_CheckedChanged(object sender, EventArgs e)
        {
            managerPanelFunctions.ChangeFocus("scouting");
        }
        #endregion
        #region Search Investment Radio Button CheckedChanged
        private void rb25kAgent_CheckedChanged(object sender, EventArgs e)
        {
            managerPanelFunctions.ChangeInvestmentAmount(25000);
        }
        private void rb50kAgent_CheckedChanged(object sender, EventArgs e)
        {
            managerPanelFunctions.ChangeInvestmentAmount(50000);
        }
        private void rb100kAgent_CheckedChanged(object sender, EventArgs e)
        {
            managerPanelFunctions.ChangeInvestmentAmount(100000);
        }
        private void rb250kAgent_CheckedChanged(object sender, EventArgs e)
        {
            managerPanelFunctions.ChangeInvestmentAmount(250000);
        }
        private void rb500kAgent_CheckedChanged(object sender, EventArgs e)
        {
            managerPanelFunctions.ChangeInvestmentAmount(500000);
        }
#endregion
        private void btnSearchForAgent_Click(object sender, EventArgs e)
        {
            managerPanelFunctions.SearchForAgent();
        }

        private void btnHireAgent1_Click(object sender, EventArgs e)
        {
            managerPanelFunctions.HireSelectedAgent(0);
        }

        private void btnHireAgent2_Click(object sender, EventArgs e)
        {
            managerPanelFunctions.HireSelectedAgent(1);
        }

        private void btnHireAgent3_Click(object sender, EventArgs e)
        {
            managerPanelFunctions.HireSelectedAgent(2);
        }

        private void btnManagerPanelAction_Click(object sender, EventArgs e)
        {
            if (cbManagerPanelActions.Text == "View Agency Finances")
            {
                managerPanelFunctions.ShowAgencyFinancesPanel();
            }
            else if (cbManagerPanelActions.Text == "Hire New Agent")
            {
                CheckToHireNewAgent();
            }
        }
    }
}
