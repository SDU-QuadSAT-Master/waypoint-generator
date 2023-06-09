﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace waypoint_generator.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BaseCalibrationPlan", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("CalibrationPlanType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<int?>("MissionID")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("CalibrationPlans", (string)null);

                    b.HasDiscriminator<string>("CalibrationPlanType").HasValue("BaseCalibrationPlan");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BaseScanPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<int>("MissionID")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ScanPlanType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ScanPlans", (string)null);

                    b.HasDiscriminator<string>("ScanPlanType").HasValue("BaseScanPlan");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("BeamFindingPlan", b =>
                {
                    b.HasBaseType("BaseCalibrationPlan");

                    b.Property<double>("Buffer")
                        .HasColumnType("double precision");

                    b.Property<double>("Radius")
                        .HasColumnType("double precision");

                    b.Property<double>("Speed")
                        .HasColumnType("double precision");

                    b.Property<double>("StartAzimuth")
                        .HasColumnType("double precision");

                    b.Property<double>("StartElevation")
                        .HasColumnType("double precision");

                    b.Property<double>("StepAzimuth")
                        .HasColumnType("double precision");

                    b.Property<double>("StepElevation")
                        .HasColumnType("double precision");

                    b.Property<double>("StopAzimuth")
                        .HasColumnType("double precision");

                    b.Property<double>("StopElevation")
                        .HasColumnType("double precision");

                    b.HasDiscriminator().HasValue("BeamFinding");
                });

            modelBuilder.Entity("RollAlignmentPlan", b =>
                {
                    b.HasBaseType("BaseCalibrationPlan");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<float>("OffsetAzimuth")
                        .HasColumnType("real");

                    b.Property<float>("OffsetElevation")
                        .HasColumnType("real");

                    b.Property<float>("Radius")
                        .HasColumnType("real");

                    b.Property<bool>("Zenith")
                        .HasColumnType("boolean");

                    b.ToTable("CalibrationPlans", t =>
                        {
                            t.Property("Radius")
                                .HasColumnName("RollAlignmentPlan_Radius");
                        });

                    b.HasDiscriminator().HasValue("RollAlignment");
                });

            modelBuilder.Entity("PrincipalPlan", b =>
                {
                    b.HasBaseType("BaseScanPlan");

                    b.Property<int>("Direction")
                        .HasColumnType("integer");

                    b.Property<int>("Plane")
                        .HasColumnType("integer");

                    b.Property<int>("Polarization")
                        .HasColumnType("integer");

                    b.Property<double>("Radius")
                        .HasColumnType("double precision");

                    b.Property<double>("Roll")
                        .HasColumnType("double precision");

                    b.Property<double>("Speed")
                        .HasColumnType("double precision");

                    b.Property<double>("Start")
                        .HasColumnType("double precision");

                    b.Property<double>("Step")
                        .HasColumnType("double precision");

                    b.Property<double>("Stop")
                        .HasColumnType("double precision");

                    b.HasDiscriminator().HasValue("Principal");
                });

            modelBuilder.Entity("RasterPlan", b =>
                {
                    b.HasBaseType("BaseScanPlan");

                    b.Property<double>("AzimuthStart")
                        .HasColumnType("double precision");

                    b.Property<double>("AzimuthStep")
                        .HasColumnType("double precision");

                    b.Property<double>("AzimuthStop")
                        .HasColumnType("double precision");

                    b.Property<int>("Direction")
                        .HasColumnType("integer");

                    b.Property<double>("ElevationStart")
                        .HasColumnType("double precision");

                    b.Property<double>("ElevationStep")
                        .HasColumnType("double precision");

                    b.Property<double>("ElevationStop")
                        .HasColumnType("double precision");

                    b.Property<int>("Plane")
                        .HasColumnType("integer");

                    b.Property<int>("Polarization")
                        .HasColumnType("integer");

                    b.Property<double>("Radius")
                        .HasColumnType("double precision");

                    b.Property<double>("Speed")
                        .HasColumnType("double precision");

                    b.ToTable("ScanPlans", t =>
                        {
                            t.Property("Direction")
                                .HasColumnName("RasterPlan_Direction");

                            t.Property("Plane")
                                .HasColumnName("RasterPlan_Plane");

                            t.Property("Polarization")
                                .HasColumnName("RasterPlan_Polarization");

                            t.Property("Radius")
                                .HasColumnName("RasterPlan_Radius");

                            t.Property("Speed")
                                .HasColumnName("RasterPlan_Speed");
                        });

                    b.HasDiscriminator().HasValue("Raster");
                });

            modelBuilder.Entity("SinglePointPlan", b =>
                {
                    b.HasBaseType("BaseScanPlan");

                    b.Property<double>("Duration")
                        .HasColumnType("double precision");

                    b.Property<double>("OffsetAzimuth")
                        .HasColumnType("double precision");

                    b.Property<double>("OffsetElevation")
                        .HasColumnType("double precision");

                    b.Property<int>("Polarization")
                        .HasColumnType("integer");

                    b.Property<double>("Radius")
                        .HasColumnType("double precision");

                    b.ToTable("ScanPlans", t =>
                        {
                            t.Property("Polarization")
                                .HasColumnName("SinglePointPlan_Polarization");

                            t.Property("Radius")
                                .HasColumnName("SinglePointPlan_Radius");
                        });

                    b.HasDiscriminator().HasValue("SinglePoint");
                });
#pragma warning restore 612, 618
        }
    }
}
