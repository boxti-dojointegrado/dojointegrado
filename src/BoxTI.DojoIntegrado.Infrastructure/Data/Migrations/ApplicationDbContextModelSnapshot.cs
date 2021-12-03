﻿// <auto-generated />
using BoxTI.DojoIntegrado.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoxTI.DojoIntegrado.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BoxTI.DojoIntegrado.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("BoxTI.DojoIntegrado.Domain.Entities.Company", b =>
                {
                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.HasKey("OrganizationId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("BoxTI.DojoIntegrado.Domain.Entities.Ngo", b =>
                {
                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.HasKey("OrganizationId");

                    b.ToTable("Ngos");
                });

            modelBuilder.Entity("BoxTI.DojoIntegrado.Domain.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CorporateName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FantasyName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("BoxTI.DojoIntegrado.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BoxTI.DojoIntegrado.Domain.Entities.Company", b =>
                {
                    b.HasOne("BoxTI.DojoIntegrado.Domain.Entities.Organization", "Organization")
                        .WithOne("Company")
                        .HasForeignKey("BoxTI.DojoIntegrado.Domain.Entities.Company", "OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("BoxTI.DojoIntegrado.Domain.Entities.Ngo", b =>
                {
                    b.HasOne("BoxTI.DojoIntegrado.Domain.Entities.Organization", "Organization")
                        .WithOne("Ngo")
                        .HasForeignKey("BoxTI.DojoIntegrado.Domain.Entities.Ngo", "OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("BoxTI.DojoIntegrado.Domain.Entities.Organization", b =>
                {
                    b.HasOne("BoxTI.DojoIntegrado.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("BoxTI.DojoIntegrado.Domain.Entities.Organization", b =>
                {
                    b.Navigation("Company")
                        .IsRequired();

                    b.Navigation("Ngo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
