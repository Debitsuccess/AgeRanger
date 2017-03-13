using System.Data.Entity.ModelConfiguration;
using Infrastructure.Model;

namespace Infrastructure.ModelConfiguration
{
    public class AgeGroupConfiguration : EntityTypeConfiguration<AgeGroup>
    {
        public const string TableName = "AgeGroup";
        public const string SchemaName = "dbo";

        public AgeGroupConfiguration()
        {
            ToTable(TableName, SchemaName);
            HasKey(x => x.Id);
       
            Property(x => x.MinAge)
                .HasColumnName("MinAge")
                .IsOptional()
                .HasColumnType("int");

            Property(x => x.MaxAge)
                .HasColumnName("MaxAge")
                .IsOptional()
                .HasColumnType("int");

            Property(x => x.Description)
                .HasColumnName("Description")
                .IsRequired()
                .HasColumnType("varchar");
        }
    }
}
