using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class Sport
    {
        public SportName sportName;
        public List<Player> freeAgents = new List<Player>();
        public List<League> leagues = new List<League>();
    }
    
    public enum SportName
    {
        Baseball,
        Basketball,
        Football,
        Hockey,
        Soccer,
        Tennis,
        Golf
    }
}
