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
        public int WeeksToComplete;
        public int PointsUntilCompletion;

        public FreelanceJob(string jobName, string jobDescription, JobType jobType, double baselineJobScore, int ipPayout, int moneyPayout, int weeksToComplete, int pointsUntilCompletion)
        {
            JobName = jobName;
            JobDescription = jobDescription;
            JobType = jobType;
            BaselineJobScore = baselineJobScore;
            IPPayout = ipPayout;
            MoneyPayout = moneyPayout;
            WeeksToComplete = weeksToComplete;
            PointsUntilCompletion = pointsUntilCompletion;
        }
    }
}
