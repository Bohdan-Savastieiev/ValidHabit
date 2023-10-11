using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidHabit.Domain.Entities;

namespace ValidHabit.Infrastructure.Data.EntityTypeConfiguration
{
    public class HabitAndCategoryEntityConfigurationpublic : IEntityTypeConfiguration<HabitAndCategory>
    {
        public void Configure(EntityTypeBuilder<HabitAndCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Habit)
                .WithMany(x => x.Categories)
                .HasForeignKey(x => x.HabitId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Habits)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}