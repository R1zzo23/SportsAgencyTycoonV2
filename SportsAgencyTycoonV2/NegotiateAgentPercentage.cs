using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class NegotiateAgentPercentage
    {
        //public int max = 0;
        //public int min = 200;
        public double playersCurrentPercent;
        public void NegotiatePercentage(Player p, Agent a, Random r)
        {
            Random rnd = r;
            int max = DetermineMaxPercentage(p) * 100;
            int min = 200;
            double playersCurrentPercent = p.Contract.AgentPercentage;
            int daysToNegotiate = DetermineLengthOfNegotiation(p, a);
            a.WorkTime = daysToNegotiate;
            a.Status = AgentStatus.Negotiating;
            p.Contract.AgentPercentage = DetermineAgentPercentage(p, a, daysToNegotiate, rnd, max, min);
        }
        private int DetermineMaxPercentage(Player p)
        {
            if (p.Sport == Sports.Basketball || p.Sport == Sports.Football) return 3;
            else if (p.Sport == Sports.Baseball || p.Sport == Sports.Hockey || p.Sport == Sports.Soccer)  return 5;
            else return 10;
        }
        private int DetermineLengthOfNegotiation(Player p, Agent a)
        {
            int days = 0;
            int playerGreed = p.Greed;
            int agentScore = ((a.Negotiating * 4) + (a.Greed * 4) + (a.Intelligence *3)) / 15;

            if (p.Greed >= 75)
            {
                if (agentScore >= 75)
                    days = 12;
                else if (agentScore >= 50)
                    days = 10;
                else if (agentScore >= 25)
                    days = 4;
            }
            else if (p.Greed >= 50)
            {
                if (agentScore >= 75)
                    days = 8;
                else if (agentScore >= 50)
                    days = 6;
                else if (agentScore >= 25)
                    days = 5;
            }
            else if (p.Greed >= 25)
            {
                if (agentScore >= 75)
                    days = 5;
                else if (agentScore >= 50)
                    days = 4;
                else if (agentScore >= 25)
                    days = 3;
            }
            else
            {
                if (agentScore >= 75)
                    days = 3;
                else if (agentScore >= 50)
                    days = 2;
                else if (agentScore >= 25)
                    days = 1;
            }

            return days;
        }

        private double DetermineAgentPercentage(Player p, Agent a, int days, Random rnd, int max, int min)
        {
            int percentage = Convert.ToInt32(p.Contract.AgentPercentage * 100);
            int playerGreed = p.Greed;
            int agentScore = ((a.Negotiating * 4) + (a.Greed * 4) + (a.Intelligence * 3)) / 15;
            int playerDaysWon = 0;
            int agentDaysWon = 0;

            for (int i = 0; i < days; i++)
            {
                int percent = 0;
                int randomNumber = rnd.Next(0, playerGreed + agentScore);
                if (randomNumber <= playerGreed)
                {
                    // player's favor
                    playerDaysWon++;

                    percent = rnd.Next(min, percentage);
                    percentage -= percent;

                    Console.WriteLine("% dropped by" + percent);
                }
                else
                {
                    // agent's favor
                    agentDaysWon++;
                    percent = rnd.Next(percentage, max);
                    percentage += percent;

                    Console.WriteLine("% increased by" + percent);
                }
            }

            if (agentDaysWon == days)
            {
                // give achievement for winning every day of a negotiation
            }
            if (playerDaysWon == days)
            {
                // give unlucky achievement for losing every day of a negotiation
            }

            Console.WriteLine("Player's Old Agent %: " + playersCurrentPercent.ToString());
            Console.WriteLine("Players New Agent %: " + percentage.ToString());

            return percentage;
        }
    }
}
