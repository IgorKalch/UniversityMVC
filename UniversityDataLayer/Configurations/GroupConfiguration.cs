using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityDataLayer.Entities;

namespace UniversityDataLayer.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasOne(g => g.Course)
                   .WithMany(c => c.Groups)
                   .HasForeignKey(g => g.CourseId)
                   .IsRequired();

            builder.HasIndex(g => g.Name)
                   .IsUnique();

            builder.ToTable("Groups");
        }
    }
}
