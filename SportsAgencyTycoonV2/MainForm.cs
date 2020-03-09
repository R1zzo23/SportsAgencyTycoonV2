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
        World world = new World();
        public MainForm()
        {
            InitializeComponent();
            PopUpStartGameForm();
            PopulateManagerAndAgencyInfo();
            PopulateManagerActions();
        }
        public void PopUpStartGameForm()
        {
            CreateManagerAndAgency startGameForm = new CreateManagerAndAgency();
            startGameForm.BringToFront();
            startGameForm.ShowDialog();

            string agencyName = startGameForm.AgencyName;
            string firstName = startGameForm.FirstName;
            string lastName = startGameForm.LastName;

            Agent manager = new Agent(firstName, lastName, Role.Manager);
            world.SetMyAgency(new Agency(agencyName, 0));
            world.SetManager(manager);
            world.MyAgency.SetOffice();
        }
        public void PopulateManagerAndAgencyInfo()
        {
            lblAgencyName.Text = world.MyAgency.Name;
            lblManagerName.Text = world.MyAgency.Manager.FullName;
            UpdateAgencyMoneyLabel();
            UpdateAgencyInfluencePointsLabel();
            UpdateOfficeInfo();
            UpdateLicenseList();
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
            cbManagerActions.Items.Add("Obtain License (" + world.NextLicenseCost.ToString() + " IP)");
            cbManagerActions.Items.Add("Search For Player");
            cbManagerActions.Items.Add("Call Teams");
        }
        public void UpdateOfficeInfo()
        {
            lblOfficeLevel.Text = "Office Level: " + world.MyAgency.Office.Level.ToString();
            lblPurchaseCost.Text = "Purchase Cost: " + world.MyAgency.Office.PurchaseCost.ToString("C0");
            lblMonthlyCost.Text = "Monthly Cost: " + world.MyAgency.Office.MonthlyCost.ToString("C0");
            lblEmployeeCapacity.Text = "Employee Capacity: " + (world.MyAgency.ClientCount + 1) + "/" + world.MyAgency.Office.EmployeeCapacity.ToString();
        }
        public void UpdateLicenseList()
        {
            lblLicenseList.Text = "License List: ";
            if (world.MyAgency.Licenses.Count == 0)
                lblLicenseList.Text += "none";
            else
            {
                foreach (Sport s in world.MyAgency.Licenses)
                    lblLicenseList.Text += Environment.NewLine + s.ToString();
            }
        }

        private void btnManagerAction_Click(object sender, EventArgs e)
        {
            if (cbManagerActions.SelectedIndex > -1)
            {
                if (cbManagerActions.SelectedIndex == 0)
                {
                    if (world.MyAgency.InfluencePoints < world.NextLicenseCost)
                        MessageBox.Show("Not enough IP to purchase next license.");
                    else
                    {
                        world.ObtainNextLicense();
                        UpdateLicenseList();
                        UpdateAgencyInfluencePointsLabel();
                    }
                }
            }
        }
    }
}
