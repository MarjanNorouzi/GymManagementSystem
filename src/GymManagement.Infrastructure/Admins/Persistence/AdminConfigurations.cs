using GymManagement.Domain.Admins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagement.Infrastructure.Admins.Persistence;

public class AdminConfigurations : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId);

        builder.Property(x => x.SubscriptionId);

        // admin seed data
        builder.HasData(new Admin(Guid.NewGuid(), Guid.Parse("92861a95-7cf6-432f-abbb-10b9500f92de")),
            new Admin(Guid.NewGuid(), Guid.Parse("EF5E7641-AEF3-44F1-A115-39CC0DA63F70")));
    }
}
