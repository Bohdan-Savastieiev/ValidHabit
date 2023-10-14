using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ValidHabit.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using ValidHabit.Domain.ValueObjects;

namespace ValidHabit.Infrastructure.Data.EntityTypeConfiguration
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.FirstName, fn =>
            {
                fn.Property(p => p.Value)
                  .HasColumnName("FirstName")
                  .HasMaxLength(Name.MaxLength)
                  .IsRequired();
            });

            builder.OwnsOne(x => x.LastName, ln =>
            {
                ln.Property(p => p.Value)
                  .HasColumnName("LastName")
                  .HasMaxLength(Name.MaxLength)
                  .IsRequired();
            });

            builder.Property(x => x.CreationDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);

            builder.HasMany(x => x.Habits)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.MotivationAnswers)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Summaries)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
