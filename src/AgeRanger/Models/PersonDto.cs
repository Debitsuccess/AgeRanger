using System;

namespace AgeRanger.Models
{
    public class PersonDto
    {
        public Int64 Id { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public Int64? Age { get; set; }

        public string AgeGroup { get; set; }
    }
}
