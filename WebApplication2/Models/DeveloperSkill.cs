using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class DeveloperSkill
    {
        public int ID { get; set; }
        public Developer Developer { get; set; }
        public string Skill { get; set; }
    }
}
