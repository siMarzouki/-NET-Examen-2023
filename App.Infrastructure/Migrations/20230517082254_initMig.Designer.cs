﻿// <auto-generated />
using System;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230517082254_initMig")]
    partial class initMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("App.ApplicationCore.Domain.Beneficiary", b =>
                {
                    b.Property<string>("CIN")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CIN");

                    b.ToTable("Beneficiaries");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Donation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DonatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DonatorId");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Donator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profession")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Donators");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Kafala", b =>
                {
                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BeneficiaryCIN")
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("DonatorId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.HasKey("StartDate", "BeneficiaryCIN", "DonatorId");

                    b.HasIndex("BeneficiaryCIN");

                    b.HasIndex("DonatorId");

                    b.ToTable("Kafalas");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Beneficiary", b =>
                {
                    b.OwnsOne("App.ApplicationCore.Domain.Contact", "Contact", b1 =>
                        {
                            b1.Property<string>("BeneficiaryCIN")
                                .HasColumnType("nvarchar(8)");

                            b1.Property<string>("Address")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Email")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Phone")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("BeneficiaryCIN");

                            b1.ToTable("Beneficiaries");

                            b1.WithOwner()
                                .HasForeignKey("BeneficiaryCIN");
                        });

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Donation", b =>
                {
                    b.HasOne("App.ApplicationCore.Domain.Donator", "Donator")
                        .WithMany("Donations")
                        .HasForeignKey("DonatorId");

                    b.Navigation("Donator");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Donator", b =>
                {
                    b.OwnsOne("App.ApplicationCore.Domain.Contact", "Contact", b1 =>
                        {
                            b1.Property<int>("DonatorId")
                                .HasColumnType("int");

                            b1.Property<string>("Address")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Email")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Phone")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DonatorId");

                            b1.ToTable("Donators");

                            b1.WithOwner()
                                .HasForeignKey("DonatorId");
                        });

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Kafala", b =>
                {
                    b.HasOne("App.ApplicationCore.Domain.Beneficiary", "Beneficiary")
                        .WithMany("kafalas")
                        .HasForeignKey("BeneficiaryCIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.ApplicationCore.Domain.Donator", "Donator")
                        .WithMany("Kafalas")
                        .HasForeignKey("DonatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beneficiary");

                    b.Navigation("Donator");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Beneficiary", b =>
                {
                    b.Navigation("kafalas");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Donator", b =>
                {
                    b.Navigation("Donations");

                    b.Navigation("Kafalas");
                });
#pragma warning restore 612, 618
        }
    }
}
