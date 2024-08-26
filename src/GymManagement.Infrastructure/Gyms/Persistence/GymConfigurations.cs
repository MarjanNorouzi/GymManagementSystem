using GymManagement.Domain.Gyms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagement.Infrastructure.Gyms.Persistence;

public class GymConfigurations : IEntityTypeConfiguration<Gym>
{
    public void Configure(EntityTypeBuilder<Gym> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(g => g.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name);

        builder.Property(x => x.SubscriptionId);

        builder.Property("_maxRooms")
            .HasColumnName("MaxRooms");

        builder.Property<List<Guid>>("_roomIds")
            .HasColumnName("RoomIds");

        builder.Property<List<Guid>>("_trainerIds")
            .HasColumnName("TrainerIds");
    }
}
