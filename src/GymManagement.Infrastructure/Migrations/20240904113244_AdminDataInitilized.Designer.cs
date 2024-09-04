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
    [Migration("20240904113244_AdminDataInitilized")]
    partial class AdminDataInitilized
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
                            Id = new Guid("d27db9b6-1353-48f3-8e32-759e9a73f45c"),
                            SubscriptionId = new Guid("92861a95-7cf6-432f-abbb-10b9500f92de"),
                            UserId = new Guid("e9df994f-275e-4755-bd19-6b3cbe826373")
                        },
                        new
                        {
                            Id = new Guid("47a63386-a292-4199-9058-deb4c0657c42"),
                            SubscriptionId = new Guid("ef5e7641-aef3-44f1-a115-39cc0da63f70"),
                            UserId = new Guid("77a5b1f6-46ad-478e-907a-5382b78121e7")
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
