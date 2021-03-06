﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rivader.Infra.Storage;

namespace Rivader.Infra.Migrations
{
    [DbContext(typeof(RivaderDbContext))]
    [Migration("20200420161604_CreateDefaultValueForCity")]
    partial class CreateDefaultValueForCity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rivader.Domain.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Code")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3)
                        .HasDefaultValue("PA");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3)
                        .HasDefaultValue("FRA");

                    b.Property<int>("TranslationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("CountryCode");

                    b.HasIndex("TranslationId");

                    b.ToTable("Cities","dbo");
                });

            modelBuilder.Entity("Rivader.Domain.Models.Country", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnName("Code")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<int>("TranslationId")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.HasIndex("TranslationId");

                    b.ToTable("Countries","dbo");
                });

            modelBuilder.Entity("Rivader.Domain.Models.CulturedLabel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Lcid")
                        .HasColumnName("Lcid")
                        .HasColumnType("int");

                    b.Property<int>("TranslationId")
                        .HasColumnName("TranslationId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("Value")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.HasIndex("TranslationId", "Lcid")
                        .IsUnique();

                    b.ToTable("CulturedLabels","dbo");
                });

            modelBuilder.Entity("Rivader.Domain.Models.SpaceInvader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3)
                        .HasDefaultValue("FRA");

                    b.Property<decimal?>("Latitude")
                        .HasColumnName("Latitude")
                        .HasColumnType("decimal(8,5)");

                    b.Property<decimal?>("Longitude")
                        .HasColumnName("Longitude")
                        .HasColumnType("decimal(8,5)");

                    b.Property<int>("Number")
                        .HasColumnName("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryCode");

                    b.ToTable("SpaceInvaders","dbo");
                });

            modelBuilder.Entity("Rivader.Domain.Models.Translation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Translations","dbo");
                });

            modelBuilder.Entity("Rivader.Domain.Models.City", b =>
                {
                    b.HasOne("Rivader.Domain.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Rivader.Domain.Models.Translation", "Translation")
                        .WithMany()
                        .HasForeignKey("TranslationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Rivader.Domain.Models.Country", b =>
                {
                    b.HasOne("Rivader.Domain.Models.Translation", "Translation")
                        .WithMany()
                        .HasForeignKey("TranslationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Rivader.Domain.Models.CulturedLabel", b =>
                {
                    b.HasOne("Rivader.Domain.Models.Translation", "Translation")
                        .WithMany("CulturedLabels")
                        .HasForeignKey("TranslationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Rivader.Domain.Models.SpaceInvader", b =>
                {
                    b.HasOne("Rivader.Domain.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
