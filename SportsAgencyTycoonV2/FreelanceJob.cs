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
        public double BaselineJobScore;
        public int IPPayout;
        public int MoneyPayout;
        public int PointsUntilCompletion;

        public FreelanceJob(string jobName, string jobDescription, double baselineJobScore, int ipPayout, int moneyPayout, int pointsUntilCompletion)
        {
            JobName = jobName;
            JobDescription = jobDescription;
            BaselineJobScore = baselineJobScore;
            IPPayout = ipPayout;
            MoneyPayout = moneyPayout;
            PointsUntilCompletion = pointsUntilCompletion;
        }
    }
}
