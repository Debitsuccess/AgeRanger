using System.Collections.Generic;
using Infrastructure.ModelConfiguration;

namespace Infrastructure.Model
{
    /// <seealso cref="AgeGroupConfiguration" />
    public class AgeGroup
    {
        public int Id { get; set; }

        public int? MinAge { get; set; }

        public int? MaxAge { get; set; }

        public string Description { get; set; }

      
        // Relationships
        // ---------------------------------
        public virtual ICollection<Person> Persons { get; set; }
    }
}
