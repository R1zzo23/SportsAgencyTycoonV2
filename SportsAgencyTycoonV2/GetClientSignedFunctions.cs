using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class GetClientSignedFunctions
    {
        MainForm mainForm;
        World world;
        Agency agency;
        Player client;
        League league;
        List<Team> interestedTeams = new List<Team>();
        List<Contract> contractOffers = new List<Contract>();
        List<int> yearlySalary = new List<int>();
        List<int> totalSalary = new List<int>();
        List<Team> finalTeams = new List<Team>();
        List<Contract> finalOffers = new List<Contract>();

        public GetClientSignedFunctions(MainForm mf, World w)
        {
            mainForm = mf;
            world = w;
        }

        public void AttemptToGetPlayerSigned(Player c, League l, Agency a)
        {
            agency = a;
            client = c;
            league = l;
            mainForm.clientTeamNegotiationPanel.Visible = true;
            interestedTeams.Clear();
            contractOffers.Clear();
            yearlySalary.Clear();
            totalSalary.Clear();
            finalTeams.Clear();
            finalOffers.Clear();
            GatherInterestedTeams(client, league);
        }
        private void GatherInterestedTeams(Player client, League l)
        {
            interestedTeams.Clear();
            contractOffers.Clear();

            Console.WriteLine("Client's Skill: " + client.CurrentSkill + "/" + client.PotentialSkill);

            foreach (Team t in l.TeamList)
            {
                bool interested = false;
                InterestLevel interestLevel = InterestLevel.None;

                List<Player> playersAtPosition = new List<Player>();
                foreach (Player p in t.Roster)
                    if (p.Position == client.Position)
                        playersAtPosition.Add(p);

                playersAtPosition = playersAtPosition.OrderByDescending(o => o.CurrentSkill).ToList();

                // check if player is better than anyone on the roster at same position
                if (client.CurrentSkill > playersAtPosition[0].CurrentSkill)
                {
                    interested = true;
                    if (client.Age <= 30)
                        interestLevel = InterestLevel.VeryHigh;
                    else if (playersAtPosition[0].PotentialSkill > client.PotentialSkill && playersAtPosition[0].Age <= client.Age)
                        interestLevel = InterestLevel.Medium;
                    else interestLevel = InterestLevel.High;
                    Console.WriteLine("Starter's Current Skill: " + playersAtPosition[0].CurrentSkill);
                }                   
                // check if player has more potential than last guy on roster at same position
                else if (client.PotentialSkill > playersAtPosition[playersAtPosition.Count - 1].PotentialSkill)
                {
                    interested = true;
                    if (client.Age <= 30)
                        interestLevel = InterestLevel.Low;
                    else interestLevel = InterestLevel.VeryLow;
                    Console.WriteLine("Worst Players's Potential Skill: " + playersAtPosition[playersAtPosition.Count - 1].PotentialSkill);
                }
                // young player with comparable upside to end of bench player
                else if (client.Age <= playersAtPosition[playersAtPosition.Count - 1].Age - 3 && client.PotentialSkill >= playersAtPosition[playersAtPosition.Count - 1].PotentialSkill - 10)
                {
                    interested = true;
                    interestLevel = InterestLevel.Medium;
                    Console.WriteLine("Worst Players's Potential Skill: " + playersAtPosition[playersAtPosition.Count - 1].PotentialSkill);
                }

                if (interested) interestedTeams.Add(t);
                if (interestLevel != InterestLevel.None)
                    GenerateContract(interestLevel);
            }

            Console.WriteLine("Teams Interested:");
            foreach (Team t in interestedTeams)
                Console.WriteLine("- " + t.City + " " + t.Mascot);

            mainForm.lblNumberOfTeamsInterested.Text = "# of Teams Interested: " + interestedTeams.Count.ToString();
            if (interestedTeams.Count > 0)
                mainForm.gbNegotiationFocus.Visible = true;
            else mainForm.gbNegotiationFocus.Visible = false;

            foreach (Contract c in contractOffers)
                Console.WriteLine(c.Years + "yr @ " + c.YearlySalary.ToString("C0"));
        }
        public void BeginNegotiations(string focus)
        {
            GatherFinalOffers();

            List<Contract> trimmedList = new List<Contract>();
            List<Team> trimmedTeams = new List<Team>();

            if (focus == "money")
            {
                List<int> contractIndexes = new List<int>();
                List<int> teamIndexes = new List<int>();

                for (int i = 0; i < 3; i++)
                {
                    if (finalOffers.Count > 0)
                    {
                        int mostMoney = finalOffers.Max(o => o.YearlySalary);
                        for (int j = 0; j < finalOffers.Count; j++)
                        {
                            if (finalOffers[j].YearlySalary == mostMoney)
                            {
                                contractIndexes.Add(j);
                                //teamIndexes.Add(j);
                            }
                        }
                        if (trimmedList.Count < 3)
                        {
                            int spotsLeft = 3 - trimmedList.Count;
                            if (contractIndexes.Count <= spotsLeft)
                            {
                                //foreach (int index in contractIndexes)
                                for (int x = contractIndexes.Count - 1; x >= 0; x--)
                                {
                                    trimmedList.Add(finalOffers[contractIndexes[x]]);
                                    trimmedTeams.Add(finalTeams[contractIndexes[x]]);
                                    finalOffers.RemoveAt(contractIndexes[x]);
                                    finalTeams.RemoveAt(contractIndexes[x]);
                                }
                                contractIndexes.Clear();
                            }
                            else
                            {
                                while (trimmedList.Count < 3)
                                {
                                    int randomContract = world.rnd.Next(0, contractIndexes.Count);
                                    trimmedList.Add(finalOffers[randomContract]);
                                    trimmedTeams.Add(finalTeams[randomContract]);
                                    contractIndexes.RemoveAt(randomContract);
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Trimemed List: Final 3");
            for (int i = 0; i < trimmedList.Count; i++)
                Console.WriteLine(trimmedTeams[i].Abbreviation + " offers " + trimmedList[i].YearlySalary.ToString("C0") + " per year for " + trimmedList[i].Years + " years.");
        }

        public void GatherFinalOffers()
        {
            foreach (Contract c in contractOffers)
            {
                yearlySalary.Add(c.YearlySalary);
                totalSalary.Add(c.YearlySalary * c.Years);
            }
            for (int i = 0; i < 3; i++)
            {
                if (finalOffers.Count < 3)
                {
                    if (contractOffers.Count > 0)
                    {
                        for (int j = contractOffers.Count - 1; j >= 0; j--)
                        {
                            int largestSalary = contractOffers.Max(o => o.YearlySalary);

                            if (contractOffers[j].YearlySalary == largestSalary)
                            {
                                finalOffers.Add(contractOffers[j]);
                                finalTeams.Add(interestedTeams[j]);

                                contractOffers.RemoveAt(j);
                                interestedTeams.RemoveAt(j);
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < finalTeams.Count; i++)
                Console.WriteLine(finalTeams[i].Abbreviation + " offers " + finalOffers[i].YearlySalary.ToString("C0") + " per year for " + finalOffers[i].Years + " years.");
        }

        public void GenerateContract(InterestLevel interestLevel)
        {
            int randomNumber = world.rnd.Next(1, 101);
            int years = 0;
            int maxYears = 0;
            int yearlySalary = 0;
            int maxSalaryWillingToOffer = 0;
            bool willingToNegotiate = false;

            if (interestLevel == InterestLevel.None)
            {
                years = 0;
                yearlySalary = 0;
                willingToNegotiate = false;
            }
            else if (interestLevel == InterestLevel.VeryLow)
            {
                if (randomNumber > 50)
                {
                    years = 1;
                    yearlySalary = client.League.MinSalary;
                    maxSalaryWillingToOffer = client.League.MinSalary;
                }
                else
                {
                    years = 1;
                    yearlySalary = client.League.MinSalary;
                    maxSalaryWillingToOffer = client.League.MinSalary;
                }
                willingToNegotiate = false;
            }
            else if (interestLevel == InterestLevel.Low)
            {
                years = 1;
                yearlySalary = client.League.MinSalary;
                maxSalaryWillingToOffer = world.rnd.Next(client.League.MinSalary, client.League.MinSalary + 750000);
                maxYears = world.rnd.Next(1, 3);
                /*if (relationship.Relationship >= 75)
                    willingToNegotiate = true;
                else
                    willingToNegotiate = false;*/
            }
            else if (interestLevel == InterestLevel.Medium)
            {
                years = world.rnd.Next(1, 3);
                maxYears = world.rnd.Next(1, 3);
                if (maxYears < years) maxYears = years;
                yearlySalary = client.DetermineYearlySalary(world.rnd);
                double percent = world.rnd.Next(1, 21);
                double maxPercent = world.rnd.Next(5, 101);
                yearlySalary = Convert.ToInt32((double)yearlySalary * (1 - (percent / 100)));
                maxSalaryWillingToOffer = Convert.ToInt32((double)yearlySalary * (1 + ((maxPercent + 25) / 100)));

                if (yearlySalary > maxSalaryWillingToOffer)
                {
                    int temp = yearlySalary;
                    yearlySalary = maxSalaryWillingToOffer;
                    maxSalaryWillingToOffer = temp;
                }

                willingToNegotiate = true;
            }
            else if (interestLevel == InterestLevel.High)
            {
                years = world.rnd.Next(2, 4);
                maxYears = world.rnd.Next(2, 5);
                if (maxYears < years) maxYears = years + 1;
                yearlySalary = client.DetermineYearlySalary(world.rnd);
                maxSalaryWillingToOffer = Convert.ToInt32((double)yearlySalary * (1 + (world.rnd.Next(20, 101) / 100)));
                willingToNegotiate = true;
            }
            else // interestLevel == "VERY HIGH"
            {
                years = world.rnd.Next(3, 5);
                maxYears = world.rnd.Next(3, 5);
                if (maxYears < years) maxYears = years;
                yearlySalary = client.DetermineYearlySalary(world.rnd);
                double percent = world.rnd.Next(10, 26);
                yearlySalary = Convert.ToInt32((double)yearlySalary * (1 + (percent / 100)));
                if (yearlySalary > client.League.MaxSalary) yearlySalary = client.League.MaxSalary;
                maxSalaryWillingToOffer = Convert.ToInt32((double)yearlySalary * (1 + (world.rnd.Next(50, 151) / 100)));
                if (yearlySalary > maxSalaryWillingToOffer) maxSalaryWillingToOffer = yearlySalary;
                willingToNegotiate = true;
            }

            if (yearlySalary > client.League.MaxSalary) yearlySalary = client.League.MaxSalary;
            if (maxSalaryWillingToOffer > client.League.MaxSalary) maxSalaryWillingToOffer = client.League.MaxSalary;

            contractOffers.Add(new Contract(years, yearlySalary, Convert.ToInt32((double)yearlySalary / (double)league.MonthsInSeason), league.SeasonStart, league.SeasonEnd, 0, 0, PaySchedule.Monthly));
        }
    }
}
