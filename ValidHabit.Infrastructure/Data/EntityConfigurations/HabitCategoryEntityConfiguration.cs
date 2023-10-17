using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ValidHabit.Domain.Entities;
using ValidHabit.Domain.ValueObjects;

namespace ValidHabit.Infrastructure.Data.EntityTypeConfiguration
{
    public class HabitCategoryEntityConfiguration : IEntityTypeConfiguration<HabitCategory>
    {
        public void Configure(EntityTypeBuilder<HabitCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name, fn =>
            {
                fn.Property(p => p.Value)
                  .HasColumnName("Name")
                  .HasMaxLength(Name.MaxLength)
                  .IsRequired();
            });

            builder.HasMany(x => x.Habits)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}