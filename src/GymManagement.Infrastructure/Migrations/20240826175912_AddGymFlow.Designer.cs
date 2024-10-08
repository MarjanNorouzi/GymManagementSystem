﻿// <auto-generated />
using System;
using GymManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymManagement.Infrastructure.Migrations
{
    [DbContext(typeof(GymManagementDbContext))]
    [Migration("20240826175912_AddGymFlow")]
    partial class AddGymFlow
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("GymManagement.Domain.Admins.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SubscriptionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Admin");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3307892f-aa4a-425e-b807-84becae6d5cc"),
                            SubscriptionId = new Guid("92861a95-7cf6-432f-abbb-10b9500f92de"),
                            UserId = new Guid("d0bc2dcd-5a4b-479c-8dfa-0bfb7aea78dd")
                        });
                });

            modelBuilder.Entity("GymManagement.Domain.Gyms.Gym", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("TEXT");

                    b.Property<int>("_maxRooms")
                        .HasColumnType("INTEGER")
                        .HasColumnName("MaxRooms");

                    b.Property<string>("_roomIds")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("RoomIds");

                    b.Property<string>("_trainerIds")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("TrainerIds");

                    b.HasKey("Id");

                    b.ToTable("Gym");
                });

            modelBuilder.Entity("GymManagement.Domain.Subscriptions.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AdminId")
                        .HasColumnType("TEXT");

                    b.Property<int>("SubscriptionType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Subscription");
                });
#pragma warning restore 612, 618
        }
    }
}
