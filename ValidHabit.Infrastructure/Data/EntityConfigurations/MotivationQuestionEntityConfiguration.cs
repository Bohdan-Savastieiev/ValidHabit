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
    public class MotivationQuestionEntityConfiguration : IEntityTypeConfiguration<MotivationQuestion>
    {
        public void Configure(EntityTypeBuilder<MotivationQuestion> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Question)
                .IsRequired();

            builder.HasMany(x => x.Answers)
                .WithOne(x => x.Question)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}