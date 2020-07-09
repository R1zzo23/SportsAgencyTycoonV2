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
    public partial class FreelanceForm : Form
    {
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

        public FreelanceForm(Random r, World w, Agency a)
        {
            rnd = r;
            world = w;
            agency = a;
            InitializeComponent();
            FillLists();
            CheckForFirstTimeFreelancing();
            DisplayAvailableJobs();
        }
        void FillLists()
        {
            JobTitles.Add(job1Title);
            JobTitles.Add(job2Title);
            JobTitles.Add(job3Title);
            JobDescriptions.Add(job1Description);
            JobDescriptions.Add(job2Description);
            JobDescriptions.Add(job3Description);
            BaselineScores.Add(job1BaselineScore);
            BaselineScores.Add(job2BaselineScore);
            BaselineScores.Add(job3BaselineScore);
            IPPayouts.Add(job1IPPayout);
            IPPayouts.Add(job2IPPayout);
            IPPayouts.Add(job3IPPayout);
            MoneyPayouts.Add(job1MoneyPayout);
            MoneyPayouts.Add(job2MoneyPayout);
            MoneyPayouts.Add(job3MoneyPayout);
            PointsUntilCompletion.Add(job1PointsUntilCompletion);
            PointsUntilCompletion.Add(job2PointsUntilCompletion);
            PointsUntilCompletion.Add(job3PointsUntilCompletion);
            AcceptJobButtons.Add(btnAcceptJob1);
            AcceptJobButtons.Add(btnAcceptJob2);
            AcceptJobButtons.Add(btnAcceptJob3);
        }
        void CheckForFirstTimeFreelancing()
        {
            if (!agency.FreelanceBefore)
            {
                MessageBox.Show("Welcome to the freelance business. This is where you can hone your craft as an agency and find ways to improve your " +
                    "influence in the sports world as well as earn some cash. Do a great job and you will earn bigger and better recommendations. " +
                    "Do a poor job or bite off more than you can chew and your reputation will spoil. Good luck!");

                agency.FreelanceBefore = true;
                //agency.AddFreelanceJob(new FreelanceJob("Back To School", "Complete a Sports Management Course", JobType.education, 1, 5, 0, 28, 1500));
            }
        }
        void DisplayAvailableJobs()
        {
            for (int i = 0; i < agency.FreelanceJobsAvailable.Count; i++)
            {
                if (i == 0)
                {
                    job1Title.Text = agency.FreelanceJobsAvailable[i].JobName;
                    job1Description.Text = agency.FreelanceJobsAvailable[i].JobDescription;
                    job1BaselineScore.Text = "Baseline Score: " + agency.FreelanceJobsAvailable[i].BaselineJobScore.ToString();
                    job1IPPayout.Text = "IP Payout: " + agency.FreelanceJobsAvailable[i].IPPayout.ToString();
                    job1MoneyPayout.Text = "Money Payout: " + agency.FreelanceJobsAvailable[i].MoneyPayout.ToString();
                    job1PointsUntilCompletion.Text = "Points Until Completion: " + agency.FreelanceJobsAvailable[i].PointsUntilCompletion.ToString();
                    btnAcceptJob1.Enabled = true;
                }
            }
        }
    }
}
