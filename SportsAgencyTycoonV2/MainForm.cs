﻿using System;
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
        Random rnd = new Random();
        World world;
        Freelance freelance;
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

        public WorldPanelFunctions worldPanelFunctions;
        public TeamRosterPanelFunctions teamRosterPanelFunctions;
        public ClientPanelFunctions clientPanelFunctions;
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
            cbManagerActions.Items.Add("Call Teams");
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
            }
        }

        private void btnOffice_Click(object sender, EventArgs e)
        {
            panelButtonHighlight.Height = btnOffice.Height;
            panelButtonHighlight.Top = btnOffice.Top;
            HideAllPanels();
            agencyPanel.Visible = true;
            world.MyAgency.DisplayAllAgents();
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            panelButtonHighlight.Height = btnManager.Height;
            panelButtonHighlight.Top = btnManager.Top;
            HideAllPanels();
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
            OpenClientPanel();
        }
        private void OpenClientPanel()
        {
            if (world.MyAgency.Licenses.Count == 0)
                MessageBox.Show("Must have a license to represent players before signing your own.");
            else
            {
                panelButtonHighlight.Height = btnClients.Height;
                panelButtonHighlight.Top = btnClients.Top;
                HideAllPanels();
                clientPanel.Visible = true;
                clientPanelFunctions.FillSportComboBox();
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
            clientPanel.Visible = false;
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
            teamRosterPanelFunctions.FillTeamRosterComboBox(world.Leagues[cbLeagueList.SelectedIndex].TeamList[cbTeamList.SelectedIndex]);
            teamRosterPanelFunctions.FillTeamInfo();
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
    }
}
