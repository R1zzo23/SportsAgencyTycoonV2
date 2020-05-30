﻿using System;
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
        List<Control> DaysForCompletion = new List<Control>();
        List<Control> AcceptJobButtons = new List<Control>();
        List<Control> GroupBoxes = new List<Control>();
        Timer jobTimer;
        ProgressBar jobProgressBar;
        FreelanceJob AttemptedJob;
        int interval;

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
            DaysForCompletion.Add(MainForm.job1DaysToComplete);
            DaysForCompletion.Add(MainForm.job2DaysToComplete);
            DaysForCompletion.Add(MainForm.job3DaysToComplete);
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
                agency.AddFreelanceJob(new FreelanceJob("Back To School", "Complete a Sports Management Course", JobType.education, 1, 5, 0, 28, 1500));
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
                DaysForCompletion[i].Text = "Days For Completion: " + agency.FreelanceJobsAvailable[i].DaysToComplete.ToString();
                AcceptJobButtons[i].Enabled = true;
                GroupBoxes[i].Visible = true;
            }
        }
        public void AttemptJob(FreelanceJob job, Timer timer, ProgressBar progressBar)
        {
            //setup Agency to record days attempting new job
            world.MyAgency.AttemptingJob = true;
            world.MyAgency.DaysAttemptingJob = 0;

            AttemptedJob = job;
            jobTimer = timer;
            jobProgressBar = progressBar;
            jobProgressBar.Maximum = AttemptedJob.PointsUntilCompletion;
            InitializeMyTimer(jobTimer, jobProgressBar);

            // disable buttons so agency cannot do anything other than this job
            DisableButtons();
        }
        private void InitializeMyTimer(Timer timer, ProgressBar progressBar)
        {
            // Set the interval for the timer.
            if (AttemptedJob.JobType == JobType.education)
                interval = (jobProgressBar.Maximum / world.MyAgency.Manager.Intelligence) * 10;
            else if (AttemptedJob.JobType == JobType.negotiating)
                interval = (jobProgressBar.Maximum / ((world.MyAgency.Manager.Negotiating + world.MyAgency.Manager.Intelligence) / 2)) * 10;
            else if (AttemptedJob.JobType == JobType.scouting)
                interval = (jobProgressBar.Maximum / world.MyAgency.Manager.Scouting) * 10;

            jobTimer.Interval = interval;

            Console.WriteLine("jobTimer.Interval = " + jobTimer.Interval);

            // Connect the Tick event of the timer to its event handler.
            AddEvent(IncreaseProgressBar);
            //jobTimer.Tick += IncreaseProgressBar;

            // Start the timer.
            jobTimer.Start();
        }
        private void IncreaseProgressBar(object sender, EventArgs e)
        {
            // Increment the value of the ProgressBar a value of one each time.
            jobProgressBar.Increment(interval / 10);
            // Determine if we have completed by comparing the value of the Value property to the Maximum value.
            if (jobProgressBar.Value >= jobProgressBar.Maximum)
            {
                // Stop the timer.
                jobTimer.Stop();
                jobProgressBar.Value = 0;
                RemoveEvent(IncreaseProgressBar);

                // need to remove EventHandler or reset it somehow

                // Get agency score for job
                ScoreJob(AttemptedJob);
                EnableButtons();
            }
        }
        private void ScoreJob(FreelanceJob job)
        {
            double baselineScore = job.BaselineJobScore;
            double jobScore = 10;
            bool jobDoneInTime;
            string results;

            Console.WriteLine("Agency Days To Complete Job: " + world.MyAgency.DaysAttemptingJob.ToString());

            if (world.MyAgency.DaysAttemptingJob <= job.DaysToComplete)
                jobDoneInTime = true;
            else jobDoneInTime = false;

            if (job.JobType == JobType.education)
            {
                if (jobDoneInTime) jobScore = rnd.Next(7, 11);
                else jobScore = rnd.Next(1, 7);
            }
            else if (job.JobType == JobType.negotiating)
            {
                if (jobDoneInTime) jobScore = rnd.Next(6, 11);
                else jobScore = rnd.Next(1, 6);
            }
            else if (job.JobType == JobType.scouting)
            {
                // do something
            }

            if (!jobDoneInTime)
            {
                double penaltyPercentage = (Convert.ToDouble(world.MyAgency.DaysAttemptingJob) - Convert.ToDouble(job.DaysToComplete)) / Convert.ToDouble(job.DaysToComplete);
                jobScore = jobScore * (1 - penaltyPercentage);

                Console.WriteLine("penaltyPercentage = " + penaltyPercentage);
            }

            results = "Baseline Score Needed: " + baselineScore.ToString() + Environment.NewLine
                + "Agency's Job Score: " + jobScore.ToString() + Environment.NewLine;

            if (jobScore >= baselineScore)
            {
                results = results + "SUCCESS!";
                AwardCompanyPayouts(job);
            }
            else
            {
                results = results + "JOB FAILED!";
                // knock agency reputation?

            }
            MessageBox.Show(results);
            world.MyAgency.FreelanceJobsAvailable.Remove(job);
            DisplayAvailableJobs();
                
        }
        private void AwardCompanyPayouts(FreelanceJob job)
        {
            world.MyAgency.AddInfluencePoints(job.IPPayout);
            world.MyAgency.AddMoney(job.MoneyPayout);
        }
        private void DisableButtons()
        {
            MainForm.btnOffice.Enabled = false;
            MainForm.btnManager.Enabled = false;
            MainForm.btnJobs.Enabled = false;
            MainForm.btnClients.Enabled = false;
            MainForm.btnAcceptJob1.Enabled = false;
            MainForm.btnAcceptJob2.Enabled = false;
            MainForm.btnAcceptJob3.Enabled = false;
        }
        private void EnableButtons()
        {
            MainForm.btnOffice.Enabled = true;
            MainForm.btnManager.Enabled = true;
            MainForm.btnJobs.Enabled = true;
            MainForm.btnClients.Enabled = true;
            MainForm.btnAcceptJob1.Enabled = true;
            MainForm.btnAcceptJob2.Enabled = true;
            MainForm.btnAcceptJob3.Enabled = true;
        }
        private void AddEvent(EventHandler ev)
        {
            jobTimer.Tick += ev;
        }

        public void RemoveEvent(EventHandler ev)
        {
            jobTimer.Tick -= ev;
        }
    }
}
