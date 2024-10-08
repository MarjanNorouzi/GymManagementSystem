﻿using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Admins;
using GymManagement.Domain.Gyms;
using GymManagement.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GymManagement.Infrastructure.Common.Persistence;

public class GymManagementDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
{
    public DbSet<Subscription> Subscription { get; set; } = null!;
    public DbSet<Admin> Admin { get; set; } = null!;
    public DbSet<Gym> Gym { get; set; } = null!;

    public async Task CommitChangeAsync() => await base.SaveChangesAsync();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
