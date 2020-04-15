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
    public partial class PlayerSearchForm : Form
    {
        Agency MyAgency;
        Agent Manager;
        Random rnd;
        List<Player> PlayersFound = new List<Player>();
        Timer time = new Timer();

        public PlayerSearchForm(Random r, Agency myAgency, Agent manager)
        {
            MyAgency = myAgency;
            Manager = manager;
            rnd = r;
            InitializeComponent();
            FillSportComboBox();
        }
        public void FillSportComboBox()
        {
            foreach (Sport s in MyAgency.Licenses)
                cbSelectSport.Items.Add(s.ToString());
        }

        private void cbSelectSport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelectSport.SelectedIndex == -1)
                cbSelectArchetype.Items.Clear();
            else
            {
                cbSelectArchetype.Items.Add(Archetype.Balanced.ToString());
                cbSelectArchetype.Items.Add(Archetype.RawAthlete.ToString());

                if (MyAgency.Licenses[cbSelectSport.SelectedIndex] == Sport.Baseball)
                {
                    cbSelectArchetype.Items.Add(Archetype.Flamethrower.ToString());
                    cbSelectArchetype.Items.Add(Archetype.ControlFreak.ToString());
                    cbSelectArchetype.Items.Add(Archetype.PowerBat.ToString());
                    cbSelectArchetype.Items.Add(Archetype.ContactHitter.ToString());
                    cbSelectArchetype.Items.Add(Archetype.GoldGlover.ToString());
                }
                else if (MyAgency.Licenses[cbSelectSport.SelectedIndex] == Sport.Soccer)
                {
                    cbSelectArchetype.Items.Add(Archetype.Finisher.ToString());
                    cbSelectArchetype.Items.Add(Archetype.TwoWayMidfielder.ToString());
                    cbSelectArchetype.Items.Add(Archetype.PlaymakingDefender.ToString());
                }
                else if (MyAgency.Licenses[cbSelectSport.SelectedIndex] == Sport.Basketball)
                {
                    cbSelectArchetype.Items.Add(Archetype.Defender.ToString());
                    cbSelectArchetype.Items.Add(Archetype.Scorer.ToString());
                    cbSelectArchetype.Items.Add(Archetype.Distributor.ToString());
                    cbSelectArchetype.Items.Add(Archetype.ThreeAndD.ToString());
                    cbSelectArchetype.Items.Add(Archetype.ShotBlocker.ToString());
                    cbSelectArchetype.Items.Add(Archetype.ThreePointSpecialist.ToString());
                }
                else if (MyAgency.Licenses[cbSelectSport.SelectedIndex] == Sport.Football)
                {
                    cbSelectArchetype.Items.Add(Archetype.MobileQB.ToString());
                    cbSelectArchetype.Items.Add(Archetype.PowerBack.ToString());
                    cbSelectArchetype.Items.Add(Archetype.SpeedRusher.ToString());
                    cbSelectArchetype.Items.Add(Archetype.CoverLinebacker.ToString());
                    cbSelectArchetype.Items.Add(Archetype.ManCorner.ToString());
                    cbSelectArchetype.Items.Add(Archetype.ZoneCorner.ToString());
                }
                else if (MyAgency.Licenses[cbSelectSport.SelectedIndex] == Sport.Hockey)
                {
                    cbSelectArchetype.Items.Add(Archetype.PowerForward.ToString());
                    cbSelectArchetype.Items.Add(Archetype.Sniper.ToString());
                    cbSelectArchetype.Items.Add(Archetype.Enforcer.ToString());
                    cbSelectArchetype.Items.Add(Archetype.OffensiveDefenseman.ToString());
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbSelectSport.SelectedIndex == -1)
                MessageBox.Show("Please select a sport.");
            else if (cbSelectArchetype.SelectedIndex == -1)
                MessageBox.Show("Please select an archetyep.");
            else if (radioQuick.Checked == false && radioDiligent.Checked == false && radioIntense.Checked == false)
                MessageBox.Show("Please select a search type.");
            else
            {
                searchTimer.Interval = DetermineTimerLength();
                searchProgressBar.Maximum = searchTimer.Interval;
                searchTimer.Start();
                InitializeMyTimer();
                lblSearching.Text = "Searching: Yes";
                Console.WriteLine(searchTimer.Interval);
            }            
        }
        private int DetermineTimerLength()
        {
            int seconds = 10 - MyAgency.Level;
            if (cbSelectArchetype.SelectedIndex == 0) seconds--;
            else if (cbSelectArchetype.SelectedIndex == 1) seconds += 2;
            else if (cbSelectArchetype.SelectedIndex > 1) seconds += 3;

            seconds *= 1000;

            if (radioDiligent.Checked)
                seconds *= 2;
            if (radioIntense.Checked)
                seconds *= 3;

            return seconds;
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Another player found!");
            FindPlayer();
            DisplayList();
        }

        private void btnStopSearch_Click(object sender, EventArgs e)
        {
            searchTimer.Stop();
            lblSearching.Text = "Searching: No";
        }

        private void FindPlayer()
        {
            Player player = new Player("First", "Last", MyAgency.Licenses[cbSelectSport.SelectedIndex]);
            Enum.TryParse(cbSelectArchetype.Text, out Archetype a);

            player.SetArchetype(a);
            player.SetStarRating(rnd, MyAgency.Level);
            player.SetSkillRating(rnd);
            player.SetWorkEthicRating(rnd);
            PlayersFound.Add(player);
            DisplayList();
            if (PlayersFound.Count > (MyAgency.Level + 1 * 2))
            {
                searchTimer.Stop();
                lblSearching.Text = "Searching: Completed!";
            }
        }
        private void DisplayList()
        {
            lblSearchResults.Text = "";
            foreach (Player p in PlayersFound)
            {
                lblSearchResults.Text += "Name: " + p.FullName + ", Archetype: " + p.Archetype.ToString() + ", Stars: " + p.Stars.ToString() + ", Skill: " + p.Skill.ToString() + ", Work Ethic: " + p.WorkEthic.ToString() + Environment.NewLine;
            }
        }

        

        // Call this method from the constructor of the form.
        private void InitializeMyTimer()
        {
            // Set the interval for the timer.
            time.Interval = searchProgressBar.Maximum / 10;
            // Connect the Tick event of the timer to its event handler.
            time.Tick += new EventHandler(IncreaseProgressBar);
            // Start the timer.
            time.Start();
        }

        private void IncreaseProgressBar(object sender, EventArgs e)
        {
            // Increment the value of the ProgressBar a value of one each time.
            searchProgressBar.Increment(searchProgressBar.Maximum / 10);
            // Determine if we have completed by comparing the value of the Value property to the Maximum value.
            if (searchProgressBar.Value == searchProgressBar.Maximum)
                // Stop the timer.
                time.Stop();
        }
    }
}
