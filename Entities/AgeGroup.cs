using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class AgeGroup
    {
        public int? MinAge { get; set; }

        public int? MaxAge { get; set; }

        public string AgeGroupDescription { get; set; }
    }
}