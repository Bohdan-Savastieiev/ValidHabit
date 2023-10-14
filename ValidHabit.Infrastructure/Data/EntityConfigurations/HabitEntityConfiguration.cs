using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValidHabit.Domain.Entities;
using ValidHabit.Domain.ValueObjects;

namespace ValidHabit.Infrastructure.Data.EntityTypeConfiguration
{
    public class HabitEntityConfiguration : IEntityTypeConfiguration<Habit>
    {
        public void Configure(EntityTypeBuilder<Habit> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name, fn =>
            {
                fn.Property(p => p.Value)
                  .HasColumnName("Name")
                  .HasMaxLength(Name.MaxLength)
                  .IsRequired();
            });

            builder.Property(x => x.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);

            builder.HasMany(x => x.ExecutionFrequencies)
                .WithOne(x => x.Habit)
                .HasForeignKey(x => x.HabitId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Categories)
                .WithOne(x => x.Habit)
                .HasForeignKey(x => x.HabitId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Records)
                .WithOne(x => x.Habit)
                .HasForeignKey(x => x.HabitId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}