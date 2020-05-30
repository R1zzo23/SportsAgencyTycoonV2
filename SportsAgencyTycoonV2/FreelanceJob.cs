using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class FreelanceJob
    {
        public string JobName;
        public string JobDescription;
        public JobType JobType;
        public double BaselineJobScore;
        public int IPPayout;
        public int MoneyPayout;
        public int DaysToComplete;
        public int PointsUntilCompletion;

        public FreelanceJob(string jobName, string jobDescription, JobType jobType, double baselineJobScore, int ipPayout, int moneyPayout, int daysToComplete, int pointsUntilCompletion)
        {
            JobName = jobName;
            JobDescription = jobDescription;
            JobType = jobType;
            BaselineJobScore = baselineJobScore;
            IPPayout = ipPayout;
            MoneyPayout = moneyPayout;
            DaysToComplete = daysToComplete;
            PointsUntilCompletion = pointsUntilCompletion;
        }
    }
}
