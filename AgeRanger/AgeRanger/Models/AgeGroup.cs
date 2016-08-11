using System;
using System.Collections.Generic;

namespace AgeRanger.Models
{
    public class AgeGroup
    {
        public int Id { get; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public string Description { get; set; }
        public AgeGroup(int minAge, int maxAge)
        {
            MinAge = minAge;
            MaxAge = maxAge;
        }
    }

}