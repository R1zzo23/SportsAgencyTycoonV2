using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsAgencyTycoonV2
{
    public class Freelance
    {
        MainForm MainForm;
        Random rnd;
        World world;
        Agency agency;
        List<Control> JobTitles = new List<Control>();
        List<Control> JobDescriptions = new List<Control>();
        List<Control> BaselineScores = new List<Control>();
        List<Control> IPPayouts = new List<Control>();
        List<Control> MoneyPayouts = new List<Control>();
        List<Control> PointsUntilCompletion = new List<Control>();
        List<Control> AcceptJobButtons = new List<Control>();
        List<Control> GroupBoxes = new List<Control>();
        Timer jobTimer;
        ProgressBar jobProgressBar;

        public Freelance(MainForm main, Random r, World w, Agency a)
        {
            MainForm = main;
            rnd = r;
            world = w;
            agency = a;
        }
        public void ShowFreelancePanel()
        {
            FillLists();
            CheckForFirstTimeFreelancing();
            DisplayAvailableJobs();
        }
        public void FillLists()
        {
            GroupBoxes.Add(MainForm.gbJob1);
            GroupBoxes.Add(MainForm.gbJob2);
            GroupBoxes.Add(MainForm.gbJob3);
            JobTitles.Add(MainForm.job1Title);
            JobTitles.Add(MainForm.job2Title);
            JobTitles.Add(MainForm.job3Title);
            JobDescriptions.Add(MainForm.job1Description);
            JobDescriptions.Add(MainForm.job2Description);
            JobDescriptions.Add(MainForm.job3Description);
            BaselineScores.Add(MainForm.job1BaselineScore);
            BaselineScores.Add(MainForm.job2BaselineScore);
            BaselineScores.Add(MainForm.job3BaselineScore);
            IPPayouts.Add(MainForm.job1IPPayout);
            IPPayouts.Add(MainForm.job2IPPayout);
            IPPayouts.Add(MainForm.job3IPPayout);
            MoneyPayouts.Add(MainForm.job1MoneyPayout);
            MoneyPayouts.Add(MainForm.job2MoneyPayout);
            MoneyPayouts.Add(MainForm.job3MoneyPayout);
            PointsUntilCompletion.Add(MainForm.job1PointsUntilCompletion);
            PointsUntilCompletion.Add(MainForm.job2PointsUntilCompletion);
            PointsUntilCompletion.Add(MainForm.job3PointsUntilCompletion);
            AcceptJobButtons.Add(MainForm.btnAcceptJob1);
            AcceptJobButtons.Add(MainForm.btnAcceptJob2);
            AcceptJobButtons.Add(MainForm.btnAcceptJob3);
        }
        public void CheckForFirstTimeFreelancing()
        {
            if (!agency.FreelanceBefore)
            {
                MessageBox.Show("Welcome to the freelance business. This is where you can hone your craft as an agency and find ways to improve your " +
                    "influence in the sports world as well as earn some cash. Do a great job and you will earn bigger and better recommendations. " +
                    "Do a poor job or bite off more than you can chew and your reputation will spoil. Good luck!");

                agency.FreelanceBefore = true;
                agency.AddFreelanceJob(new FreelanceJob("Back To School", "Complete a Sports Management Course", JobType.education, 1, 5, 0, 1500));
            }
        }
        public void DisplayAvailableJobs()
        {
            int emptySpots = 3 - agency.FreelanceJobsAvailable.Count;

            if (emptySpots > 0)
            {
                for (int i = 0; i < emptySpots; i++)
                {
                    GroupBoxes[GroupBoxes.Count - 1 - i].Visible = false;
                }
            }

            for (int i = 0; i < agency.FreelanceJobsAvailable.Count; i++)
            {
                JobTitles[i].Text = agency.FreelanceJobsAvailable[i].JobName;
                JobDescriptions[i].Text = agency.FreelanceJobsAvailable[i].JobDescription;
                BaselineScores[i].Text = "Baseline Score: " + agency.FreelanceJobsAvailable[i].BaselineJobScore.ToString();
                IPPayouts[i].Text = "IP Payout: " + agency.FreelanceJobsAvailable[i].IPPayout.ToString();
                MoneyPayouts[i].Text = "Money Payout: " + agency.FreelanceJobsAvailable[i].MoneyPayout.ToString();
                PointsUntilCompletion[i].Text = "Points Until Completion: " + agency.FreelanceJobsAvailable[i].PointsUntilCompletion.ToString();
                AcceptJobButtons[i].Enabled = true;
                GroupBoxes[i].Visible = true;
            }
        }
        public void AttemptJob(FreelanceJob job, Timer timer, ProgressBar progressBar)
        {
            jobTimer = timer;
            jobProgressBar = progressBar;
            jobProgressBar.Maximum = job.PointsUntilCompletion;
            InitializeMyTimer(jobTimer, jobProgressBar);
            Console.WriteLine("Attempting " + job.JobName);
            if (job.JobType == JobType.education)
            {
                
            }
        }
        private void InitializeMyTimer(Timer timer, ProgressBar progressBar)
        {
            // Set the interval for the timer.
            jobTimer.Interval = (jobProgressBar.Maximum / world.MyAgency.Manager.Intelligence) * 100;
            // Connect the Tick event of the timer to its event handler.
            jobTimer.Tick += new EventHandler(IncreaseProgressBar);
            // Start the timer.
            jobTimer.Start();
        }
        private void IncreaseProgressBar(object sender, EventArgs e)
        {
            // Increment the value of the ProgressBar a value of one each time.
            jobProgressBar.Increment(world.MyAgency.Manager.Intelligence);
            // Determine if we have completed by comparing the value of the Value property to the Maximum value.
            if (jobProgressBar.Value == jobProgressBar.Maximum)
                // Stop the timer.
                jobTimer.Stop();
        }
    }
}
