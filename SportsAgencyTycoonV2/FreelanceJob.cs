using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class FreelanceJob
    {
        MainForm mf;
        public string JobName;
        public string JobDescription;
        public JobType JobType;
        public double BaselineJobScore;
        public int IPPayout;
        public int MoneyPayout;
        public int DaysToComplete;
        public int PointsUntilCompletion;
        public Sports Sport;

        public FreelanceJob(MainForm m, string jobName, string jobDescription, JobType jobType, double baselineJobScore, int ipPayout, int moneyPayout, int daysToComplete, int pointsUntilCompletion)
        {
            mf = m;
            JobName = jobName;
            JobDescription = jobDescription;
            JobType = jobType;
            BaselineJobScore = baselineJobScore;
            IPPayout = ipPayout;
            MoneyPayout = moneyPayout;
            DaysToComplete = daysToComplete;
            PointsUntilCompletion = pointsUntilCompletion;

            if (JobType == JobType.scouting)
                Sport = mf.world.LicenseOrder[mf.rnd.Next(0, 5)];
        }
    }
}
