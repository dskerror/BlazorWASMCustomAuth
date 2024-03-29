﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DsK.AuthServer.Security.EntityFramework.Models;

public partial class DsKauthServerContext : DbContext
{
    public DsKauthServerContext()
    {
    }

    public DsKauthServerContext(DbContextOptions<DsKauthServerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationAuthenticationProvider> ApplicationAuthenticationProviders { get; set; }

    public virtual DbSet<ApplicationAuthenticationProviderUserMapping> ApplicationAuthenticationProviderUserMappings { get; set; }

    public virtual DbSet<ApplicationAuthenticationProviderUserToken> ApplicationAuthenticationProviderUserTokens { get; set; }

    public virtual DbSet<ApplicationPermission> ApplicationPermissions { get; set; }

    public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }

    public virtual DbSet<ApplicationRolePermission> ApplicationRolePermissions { get; set; }

    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserLog> UserLogs { get; set; }

    public virtual DbSet<UserPermission> UserPermissions { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.;Database=DsKAuthServer;Trusted_Connection=True;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasIndex(e => e.ApplicationName, "IX_Applications").IsUnique();

            entity.Property(e => e.ApplicationDesc).HasMaxLength(250);
            entity.Property(e => e.ApplicationGuid).HasColumnName("ApplicationGUID");
            entity.Property(e => e.ApplicationName).HasMaxLength(250);
            entity.Property(e => e.CallbackUrl)
                .HasMaxLength(500)
                .HasColumnName("CallbackURL");
        });

        modelBuilder.Entity<ApplicationAuthenticationProvider>(entity =>
        {
            entity.HasIndex(e => e.ApplicationId, "IX_ApplicationAuthenticationProviders_ApplicationId");

            entity.HasIndex(e => e.AuthenticationProviderType, "IX_ApplicationAuthenticationProviders_AuthenticationProviderId");

            entity.Property(e => e.ApplicationAuthenticationProviderGuid).HasColumnName("ApplicationAuthenticationProviderGUID");
            entity.Property(e => e.AuthenticationProviderType).HasMaxLength(50);
            entity.Property(e => e.Domain).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.Application).WithMany(p => p.ApplicationAuthenticationProviders)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationAuthenticationProviders_Applications");
        });

        modelBuilder.Entity<ApplicationAuthenticationProviderUserMapping>(entity =>
        {
            entity.HasIndex(e => new { e.ApplicationUserId, e.ApplicationAuthenticationProviderId }, "IX_AuthProv_UserId").IsUnique();

            entity.HasIndex(e => new { e.ApplicationAuthenticationProviderId, e.ApplicationUserId, e.Username }, "IX_AuthProv_UserId_Username");

            entity.Property(e => e.Username).HasMaxLength(256);

            entity.HasOne(d => d.ApplicationAuthenticationProvider).WithMany(p => p.ApplicationAuthenticationProviderUserMappings)
                .HasForeignKey(d => d.ApplicationAuthenticationProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationAuthenticationProviderUserMappings_ApplicationAuthenticationProviders");

            entity.HasOne(d => d.ApplicationUser).WithMany(p => p.ApplicationAuthenticationProviderUserMappings)
                .HasForeignKey(d => d.ApplicationUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationAuthenticationProviderUserMappings_Users");
        });

        modelBuilder.Entity<ApplicationAuthenticationProviderUserToken>(entity =>
        {
            entity.HasIndex(e => e.ApplicationId, "IX_ApplicationAuthenticationProviderUserTokens_ApplicationId");

            entity.HasIndex(e => e.UserId, "IX_ApplicationAuthenticationProviderUserTokens_UserId");

            entity.Property(e => e.TokenCreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.TokenRefreshedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Application).WithMany(p => p.ApplicationAuthenticationProviderUserTokens)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationAuthenticationProviderUserMappings_Applications");

            entity.HasOne(d => d.User).WithMany(p => p.ApplicationAuthenticationProviderUserTokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationAuthenticationProviderUserTokens_Users");
        });

        modelBuilder.Entity<ApplicationPermission>(entity =>
        {
            entity.HasIndex(e => new { e.PermissionName, e.ApplicationId }, "IX_ApplicationPermissions").IsUnique();

            entity.HasIndex(e => e.ApplicationId, "IX_ApplicationPermissions_ApplicationId");

            entity.Property(e => e.PermissionDescription).HasMaxLength(250);
            entity.Property(e => e.PermissionName).HasMaxLength(250);

            entity.HasOne(d => d.Application).WithMany(p => p.ApplicationPermissions)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationPermissions_Applications");
        });

        modelBuilder.Entity<ApplicationRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Roles");

            entity.HasIndex(e => e.ApplicationId, "IX_ApplicationRoles_ApplicationId");

            entity.HasIndex(e => new { e.RoleName, e.ApplicationId }, "IX_Roles").IsUnique();

            entity.Property(e => e.RoleDescription).HasMaxLength(250);
            entity.Property(e => e.RoleName).HasMaxLength(50);

            entity.HasOne(d => d.Application).WithMany(p => p.ApplicationRoles)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationRoles_Applications");
        });

        modelBuilder.Entity<ApplicationRolePermission>(entity =>
        {
            entity.HasKey(e => new { e.ApplicationRoleId, e.ApplicationPermissionId });

            entity.HasOne(d => d.ApplicationRole).WithMany(p => p.ApplicationRolePermissions)
                .HasForeignKey(d => d.ApplicationRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationRolePermissions_ApplicationPermissions");

            entity.HasOne(d => d.ApplicationRoleNavigation).WithMany(p => p.ApplicationRolePermissions)
                .HasForeignKey(d => d.ApplicationRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationRolePermissions_ApplicationRoles");
        });

        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.HasIndex(e => e.ApplicationId, "IX_ApplicationUsers_ApplicationId");

            entity.HasIndex(e => e.UserId, "IX_ApplicationUsers_UserId");

            entity.Property(e => e.LockoutEnd).HasColumnType("date");

            entity.HasOne(d => d.Application).WithMany(p => p.ApplicationUsers)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationUsers_Applications");

            entity.HasOne(d => d.User).WithMany(p => p.ApplicationUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationUsers_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Users_Email").IsUnique();

            entity.Property(e => e.AccountCreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LastPasswordChangeDateTime).HasColumnType("datetime");
            entity.Property(e => e.LockoutEnd).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.PasswordChangeDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserLog>(entity =>
        {
            entity.HasIndex(e => e.ApplicationId, "IX_UserLogs_ApplicationId");

            entity.HasIndex(e => e.UserId, "IX_UserLogs_UserId");

            entity.Property(e => e.Ip).HasColumnName("IP");
            entity.Property(e => e.LogDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Application).WithMany(p => p.UserLogs)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLogs_Users");
        });

        modelBuilder.Entity<UserPermission>(entity =>
        {
            entity.HasIndex(e => new { e.PermissionId, e.UserId }, "IX_UserPermissions").IsUnique();

            entity.HasIndex(e => e.UserId, "IX_UserPermissions_UserId");

            entity.HasOne(d => d.Permission).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPermissions_ApplicationPermissions");

            entity.HasOne(d => d.User).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPermissions_Users");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasIndex(e => new { e.UserId, e.RoleId }, "IX_UserRoles").IsUnique();

            entity.HasIndex(e => e.RoleId, "IX_UserRoles_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_ApplicationRoles");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
