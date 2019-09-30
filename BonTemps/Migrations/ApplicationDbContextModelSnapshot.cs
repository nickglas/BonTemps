﻿// <auto-generated />
using System;
using BonTemps.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BonTemps.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BonTemps.Areas.Manager.Models.ContactInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres");

                    b.Property<string>("DinsdagOpen");

                    b.Property<string>("DinsdagSluit");

                    b.Property<string>("DonderdagOpen");

                    b.Property<string>("DonderdagSluit");

                    b.Property<string>("Email");

                    b.Property<string>("MaandagOpen");

                    b.Property<string>("MaandagSluit");

                    b.Property<string>("Postcode");

                    b.Property<string>("Telefoonnummer");

                    b.Property<string>("VrijdagOpen");

                    b.Property<string>("VrijdagSluit");

                    b.Property<string>("WoensdagOpen");

                    b.Property<string>("WoensdagSluit");

                    b.Property<string>("ZaterdagOpen");

                    b.Property<string>("ZaterdagSluit");

                    b.Property<string>("ZondagOpen");

                    b.Property<string>("ZondagSluit");

                    b.HasKey("Id");

                    b.ToTable("ContactInfo");
                });

            modelBuilder.Entity("BonTemps.Areas.Systeem.Models.Bestelling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Afgerond");

                    b.Property<DateTime>("Bestellingsdatum_Tijd");

                    b.Property<DateTime>("Bestellingsdatum_afgerond");

                    b.Property<int>("ConsumptieId");

                    b.Property<int>("TafelsId");

                    b.HasKey("Id");

                    b.HasIndex("ConsumptieId");

                    b.HasIndex("TafelsId");

                    b.ToTable("Bestellingen");
                });

            modelBuilder.Entity("BonTemps.Areas.Systeem.Models.BestellingArchief", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Archiveerdatum");

                    b.Property<DateTime>("Bestellingsdatum_Tijd");

                    b.Property<DateTime>("Bestellingsdatum_afgerond");

                    b.Property<string>("Consumptie");

                    b.Property<int>("TafelsId");

                    b.HasKey("Id");

                    b.ToTable("BestellingArchief");
                });

            modelBuilder.Entity("BonTemps.Areas.Systeem.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beschrijving");

                    b.Property<string>("Naam");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BonTemps.Areas.Systeem.Models.Consumptie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beschrijving");

                    b.Property<int>("CategoryId");

                    b.Property<int?>("Consumptie");

                    b.Property<string>("Naam");

                    b.Property<double>("Prijs");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Consumptie");

                    b.ToTable("Consumpties");
                });

            modelBuilder.Entity("BonTemps.Areas.Systeem.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beschrijving");

                    b.Property<string>("Menu_naam");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("BonTemps.Areas.Systeem.Models.Reservering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AantalPersonen");

                    b.Property<string>("Email");

                    b.Property<bool>("Goedkeuring");

                    b.Property<string>("HuisTelefoonNummer");

                    b.Property<string>("MobielTelefoonNummer");

                    b.Property<string>("NaamReserveerder");

                    b.Property<string>("Opmerking");

                    b.Property<DateTime>("ReserveringAangemaakt");

                    b.Property<DateTime>("ReserveringsDatum");

                    b.HasKey("Id");

                    b.ToTable("Reserveringen");
                });

            modelBuilder.Entity("BonTemps.Areas.Systeem.Models.Tafels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Bezet");

                    b.Property<int>("Zitplaatsen");

                    b.HasKey("Id");

                    b.ToTable("Tafels");
                });

            modelBuilder.Entity("BonTemps.Models.Klantgegevens", b =>
                {
                    b.Property<int>("KlantGegevensId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Achternaam");

                    b.Property<DateTime>("GeboorteDatum");

                    b.Property<string>("Geslacht");

                    b.Property<string>("TelefoonNummer");

                    b.Property<string>("Voornaam");

                    b.HasKey("KlantGegevensId");

                    b.ToTable("Klantgegevens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BonTemps.Models.Rol", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.Property<DateTime>("Aanmaakdatum");

                    b.Property<string>("Beschrijving");

                    b.HasDiscriminator().HasValue("Rol");
                });

            modelBuilder.Entity("BonTemps.Models.Klant", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateTime>("Aanmaakdatum");

                    b.Property<int?>("KlantGegevensId");

                    b.Property<string>("RolId");

                    b.Property<string>("Rolnaam");

                    b.HasIndex("KlantGegevensId");

                    b.HasIndex("RolId");

                    b.HasDiscriminator().HasValue("Klant");
                });

            modelBuilder.Entity("BonTemps.Models.Personeel", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateTime>("Aanmaakdatum")
                        .HasColumnName("Personeel_Aanmaakdatum");

                    b.Property<string>("RolId")
                        .HasColumnName("Personeel_RolId");

                    b.HasIndex("RolId");

                    b.HasDiscriminator().HasValue("Personeel");
                });

            modelBuilder.Entity("BonTemps.Areas.Systeem.Models.Bestelling", b =>
                {
                    b.HasOne("BonTemps.Areas.Systeem.Models.Consumptie", "Consumptie")
                        .WithMany()
                        .HasForeignKey("ConsumptieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BonTemps.Areas.Systeem.Models.Tafels", "Tafels")
                        .WithMany()
                        .HasForeignKey("TafelsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BonTemps.Areas.Systeem.Models.Consumptie", b =>
                {
                    b.HasOne("BonTemps.Areas.Systeem.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BonTemps.Areas.Systeem.Models.Menu")
                        .WithMany("Consumpties")
                        .HasForeignKey("Consumptie");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BonTemps.Models.Klant", b =>
                {
                    b.HasOne("BonTemps.Models.Klantgegevens", "Klantgegevens")
                        .WithMany()
                        .HasForeignKey("KlantGegevensId");

                    b.HasOne("BonTemps.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId");
                });

            modelBuilder.Entity("BonTemps.Models.Personeel", b =>
                {
                    b.HasOne("BonTemps.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId");
                });
#pragma warning restore 612, 618
        }
    }
}
