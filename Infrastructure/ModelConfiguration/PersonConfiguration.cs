using System.Data.Entity.ModelConfiguration;
using Infrastructure.Model;

namespace Infrastructure.ModelConfiguration
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public const string TableName = "Person";
        public const string SchemaName = "dbo";

        public PersonConfiguration()
        {
            ToTable(TableName, SchemaName);

            HasKey(x => x.Id);

            Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .IsRequired()
                .HasColumnType("varchar");
        
            Property(x => x.LastName)
                .HasColumnName("LastName")
                .IsRequired()
                .HasColumnType("varchar");

            Property(x => x.Age)
                .HasColumnName("Age")
                .IsRequired()
                .HasColumnType("int");

            Property(x => x.AgeGroupId)
                .HasColumnName("AgeGroupId")
                .IsRequired()
                .HasColumnType("int");


            // Foreign keys
            // ---------------------------------------------------------------------------------------------------------

            HasRequired(x => x.AgeGroup)
                .WithMany(x => x.Persons)
                .HasForeignKey(x => x.AgeGroupId)
                .WillCascadeOnDelete(false);
        }
    }
}
