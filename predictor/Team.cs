using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace predictor
{
    internal class Team : IComparable<Team>
    {
        public string Name;
        public int Wins;
        public int Losses;
        public int Ties;
        public int GoalsFor;
        public int GoalsAG;
        public Team(string name) 
        {
            Name = name;
        }
        public int CompareTo(Team other)
        {
            return string.Compare(this.Name, other.Name); ;
        }
    }
}
