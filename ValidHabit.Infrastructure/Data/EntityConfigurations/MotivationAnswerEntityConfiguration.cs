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
    public class MotivationAnswerEntityConfiguration : IEntityTypeConfiguration<MotivationAnswer>
    {
        public void Configure(EntityTypeBuilder<MotivationAnswer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Answer)
                .IsRequired();
        }
    }
}