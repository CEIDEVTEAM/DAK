﻿using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess.Context
{
    public partial class DAKContext : DbContext
    {

        public DAKContext() { 
        }

        public DAKContext(DbContextOptions<DAKContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Coordinate> Coordinate { get; set; }
        public virtual DbSet<DeliveryArea> DeliveryArea { get; set; }
        public virtual DbSet<Expedition> Expedition { get; set; }
        public virtual DbSet<FinalClient> FinalClient { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<PackageStatus> PackageStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source = devteamhost.ddns.net; initial catalog = DAK; user id = CEIDEVTEAM; password = CeiDev158$48 / Team; MultipleActiveResultSets = true; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BillingType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMail");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.IdClient);

                entity.ToTable("Company");

                entity.Property(e => e.IdClient).ValueGeneratedNever();

                entity.Property(e => e.BusinessName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Rut)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClientNavigation)
                    .WithOne(p => p.Company)
                    .HasForeignKey<Company>(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Client");
            });

            modelBuilder.Entity<Coordinate>(entity =>
            {
                entity.HasKey(e => new { e.Latitude, e.Longitude })
                    .HasName("PK_Table_1_1");

                entity.ToTable("Coordinate");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDeliveryAreaNavigation)
                    .WithMany(p => p.Coordinates)
                    .HasForeignKey(d => d.IdDeliveryArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Coordinate_DeliveryArea");
            });

            modelBuilder.Entity<DeliveryArea>(entity =>
            {
                entity.ToTable("DeliveryArea");

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Expedition>(entity =>
            {
                entity.ToTable("Expedition");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Truck)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Expedition)
                    .HasForeignKey<Expedition>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expedition_DeliveryArea");
            });

            modelBuilder.Entity<FinalClient>(entity =>
            {
                entity.HasKey(e => e.IdClient);

                entity.ToTable("FinalClient");

                entity.Property(e => e.IdClient).ValueGeneratedNever();

                entity.Property(e => e.DocumentNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClientNavigation)
                    .WithOne(p => p.FinalClient)
                    .HasForeignKey<FinalClient>(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FinalClient_FinalClient");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("Package");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TrackingNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.PackageIdClientNavigations)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Package_IdClient");

                entity.HasOne(d => d.IdExpeditionNavigation)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.IdExpedition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Package_Expedition");

                entity.HasOne(d => d.IdRecipientNavigation)
                    .WithMany(p => p.PackageIdRecipientNavigations)
                    .HasForeignKey(d => d.IdRecipient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Package_IdRecipient");

                entity.HasOne(d => d.StatusCodeNavigation)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.StatusCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Package_StatusCode");
            });

            modelBuilder.Entity<PackageStatus>(entity =>
            {
                entity.HasKey(e => e.StatusCode);

                entity.ToTable("PackageStatus");

                entity.Property(e => e.StatusCode).ValueGeneratedNever();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
