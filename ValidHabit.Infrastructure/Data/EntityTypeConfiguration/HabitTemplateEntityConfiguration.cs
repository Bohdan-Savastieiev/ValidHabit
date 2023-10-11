using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidHabit.Domain.Entities;
using ValidHabit.Domain.ValueObjects;

namespace ValidHabit.Infrastructure.Data.EntityTypeConfiguration
{
    public class HabitTemplateEntityConfiguration : IEntityTypeConfiguration<HabitTemplate>
    {
        public void Configure(EntityTypeBuilder<HabitTemplate> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name, fn =>
            {
                fn.Property(p => p.Value)
                  .HasColumnName("Name")
                  .HasMaxLength(Name.MaxLength)
                  .IsRequired();
            });

            builder.Property(x => x.Template)
                .IsRequired();

        }
    }
}