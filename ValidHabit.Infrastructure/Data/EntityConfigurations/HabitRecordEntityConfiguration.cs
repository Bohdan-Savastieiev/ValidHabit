using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidHabit.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ValidHabit.Infrastructure.Data.EntityTypeConfiguration
{
    public class HabitRecordEntityConfiguration : IEntityTypeConfiguration<HabitRecord>
    {
        public void Configure(EntityTypeBuilder<HabitRecord> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsCompleted)
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);
        }
    }
}