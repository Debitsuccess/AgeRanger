using System.Data.Entity;
using Infrastructure.Model;
using Infrastructure.ModelConfiguration;

namespace Infrastructure.Service
{
    public class AgeRangerContext : DbContext
    {
        public AgeRangerContext(): base("name=AgeRangerContext")
        {
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<AgeGroup> AgeGroups { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new PersonConfiguration());

            modelBuilder.Configurations.Add(new AgeGroupConfiguration());
        }
    }
}
