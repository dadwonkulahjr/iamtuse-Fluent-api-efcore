using iamtuseFluentApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iamtuseFluentApi.Infrastructure.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeId)
                    .HasName("PK_employeeId");

            builder.ToTable("tblEmployee");
            builder.Property(e => e.FirstName)
                   .HasComment("The firstname field is required.")
                   .HasColumnName("First_name")
                   .HasColumnType("varchar(50)")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(e => e.LastName)
                .HasComment("The lastname field is required.")
                   .HasColumnName("Last_name")
                  .HasColumnType("varchar(50)")
                  .HasMaxLength(50)
                  .IsRequired();

            builder.Property(e => e.Email)
                  .HasColumnType("varchar(50)")
                  .HasMaxLength(50);

            builder.Property(e => e.Salary)
                .HasComment("The salary field is required.")
                  .HasColumnType("decimal(18,2)")
                  .HasMaxLength(50)
                  .IsRequired();

            builder.Ignore(e => e.FullName);

            builder.HasOne(e => e.Gender)
                   .WithMany()
                   .HasForeignKey(e => e.GenderId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired()
                   .HasConstraintName("FK_genderId");
                   
        }
    }
}
