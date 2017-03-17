using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgeRanger.Models
{
    public class AgeGroupModel
    {
        public int Id { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public string Description { get; set; }
    }
}