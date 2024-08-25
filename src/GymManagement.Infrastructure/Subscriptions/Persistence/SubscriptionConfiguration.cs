using GymManagement.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(s => s.AdminId);

        builder
            .Property(x => x.SubscriptionType)
            .HasConversion(
                s => s.Value,
                v => SubscriptionType.FromValue(v));
    }
}
