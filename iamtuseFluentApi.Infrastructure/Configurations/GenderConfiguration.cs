using iamtuseFluentApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iamtuseFluentApi.Infrastructure.Configurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(g => g.GenderId)
                    .HasName("PK_genderId");

            builder.Property(g => g.Name)
                    .HasMaxLength(20)
                    .HasColumnName("Sex")
                    .HasColumnType("varchar(20)")
                    .HasComment("This field is for gender")
                    .IsRequired();    
                   
        }
    }
}
