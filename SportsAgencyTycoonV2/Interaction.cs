﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAgencyTycoonV2
{
    public class Interaction
    {
        public string Category;
        public string Description;
        public Interaction(string category, string description)
        {
            Category = category;
            Description = description;
        }
    }
}
