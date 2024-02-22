using CURO.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CURO.StudentConfiguration
{
    public class Configuration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(nameof(Student));
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Roll).HasMaxLength(10).IsRequired();
            builder.Property(t => t.Subject).HasMaxLength(25).IsRequired();
            builder.Property(t=>t.City).HasMaxLength(50).IsRequired();

        }
    }
}
