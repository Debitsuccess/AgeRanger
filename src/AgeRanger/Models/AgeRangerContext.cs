using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace AgeRanger.Models
{
    public partial class AgeRangerContext : DbContext
    {
        public DbSet<AgeGroup> AgeGroup { get; set; }
        public DbSet<Person> Person { get; set; }

        private readonly IConfigurationRoot _Configuration;

        public AgeRangerContext(IConfigurationRoot config)
        {
            _Configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var path = PlatformServices.Default.Application.ApplicationBasePath;
            //var connectionString = $"Filename={Path.Combine(path, "AgeRanger.db")}";

            var connectionString = _Configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlite(connectionString);            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                        
        }
    }

    public partial class AgeGroup
    {        
        public Int64 Id { get; set; }
        public Int64? MinAge { get; set; }
        public Int64? MaxAge { get; set; }             
        public String Description { get; set; }
    }

    public partial class Person
    {
        public Int64 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int64? Age { get; set; }
    }
}