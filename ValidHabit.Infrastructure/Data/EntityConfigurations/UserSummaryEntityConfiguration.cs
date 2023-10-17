using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ValidHabit.Domain.Entities;

namespace ValidHabit.Infrastructure.Data.EntityTypeConfiguration
{
    public class UserSummaryEntityConfiguration : IEntityTypeConfiguration<UserSummary>
    {
        public void Configure(EntityTypeBuilder<UserSummary> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CompletedHabitGoals)
                .IsRequired();

            builder.Property(x => x.TotalHabitGoals)
                .IsRequired();

            builder.Property(x => x.Rating)
                .IsRequired();

            builder.Property(x => x.StartDate)
                .IsRequired();

            builder.Property(x => x.EndDate)
                .IsRequired();
        }
    }
}