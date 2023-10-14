using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidHabit.Domain.Entities;
using System.Reflection.Emit;

namespace ValidHabit.Infrastructure.Data.EntityTypeConfiguration
{
    public class HabitExecutionFrequencyEntityConfiguration : IEntityTypeConfiguration<HabitExecutionFrequency>
    {
        public void Configure(EntityTypeBuilder<HabitExecutionFrequency> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value)
                .IsRequired();

            builder.Property(e => e.FrequencyType)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(e => e.TimeInterval)
                .HasConversion<string>()
                .IsRequired();
        }
    }
}