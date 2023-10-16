﻿// <auto-generated />
using System;
using DsK.AuthServer.Security.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DsK.AuthServer.Security.EntityFramework.Migrations
{
    [DbContext(typeof(DsKAuthServerDbContext))]
    partial class SecurityTablesTestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AppApiKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApplicationDesc")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("ApplicationGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ApplicationGUID");

                    b.Property<string>("ApplicationName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CallbackUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("CallbackURL");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ApplicationName" }, "IX_Applications")
                        .IsUnique();

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationAuthenticationProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ActiveDirectoryFirstLoginAutoRegister")
                        .HasColumnType("bit");

                    b.Property<Guid>("ApplicationAuthenticationProviderGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ApplicationAuthenticationProviderGUID");

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("AuthenticationProviderType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("DefaultApplicationRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Domain")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("RegistrationAutoEmailConfirm")
                        .HasColumnType("bit");

                    b.Property<bool>("RegistrationEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ApplicationId" }, "IX_ApplicationAuthenticationProviders_ApplicationId");

                    b.HasIndex(new[] { "AuthenticationProviderType" }, "IX_ApplicationAuthenticationProviders_AuthenticationProviderId");

                    b.ToTable("ApplicationAuthenticationProviders");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationAuthenticationProviderUserMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationAuthenticationProviderId")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ApplicationAuthenticationProviderId" }, "IX_ApplicationAuthenticationProviderUserMappings_ApplicationAuthenticationProviderId");

                    b.HasIndex(new[] { "UserId" }, "IX_ApplicationAuthenticationProviderUserMappings_UserId");

                    b.ToTable("ApplicationAuthenticationProviderUserMappings");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationAuthenticationProviderUserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<Guid>("LoginToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TokenCreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("TokenRefreshedDateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ApplicationId" }, "IX_ApplicationAuthenticationProviderUserTokens_ApplicationId");

                    b.HasIndex(new[] { "UserId" }, "IX_ApplicationAuthenticationProviderUserTokens_UserId");

                    b.ToTable("ApplicationAuthenticationProviderUserTokens");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("PermissionDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "PermissionName", "ApplicationId" }, "IX_ApplicationPermissions")
                        .IsUnique();

                    b.HasIndex(new[] { "ApplicationId" }, "IX_ApplicationPermissions_ApplicationId");

                    b.ToTable("ApplicationPermissions");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("RoleDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_Roles");

                    b.HasIndex(new[] { "ApplicationId" }, "IX_ApplicationRoles_ApplicationId");

                    b.HasIndex(new[] { "RoleName", "ApplicationId" }, "IX_Roles")
                        .IsUnique();

                    b.ToTable("ApplicationRoles");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationRolePermission", b =>
                {
                    b.Property<int>("ApplicationRoleId")
                        .HasColumnType("int");

                    b.Property<int>("ApplicationPermissionId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationRoleId", "ApplicationPermissionId");

                    b.ToTable("ApplicationRolePermissions");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("date");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ApplicationId" }, "IX_ApplicationUsers_ApplicationId");

                    b.HasIndex(new[] { "UserId" }, "IX_ApplicationUsers_UserId");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("AccountCreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastPasswordChangeDateTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("PasswordChangeDateTime")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("PasswordChangeGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IX_Users_Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.UserLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IP");

                    b.Property<DateTime>("LogDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QueryString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ApplicationId" }, "IX_UserLogs_ApplicationId");

                    b.HasIndex(new[] { "UserId" }, "IX_UserLogs_UserId");

                    b.ToTable("UserLogs");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.UserPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Overwrite")
                        .HasColumnType("bit");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "PermissionId", "UserId" }, "IX_UserPermissions")
                        .IsUnique();

                    b.HasIndex(new[] { "UserId" }, "IX_UserPermissions_UserId");

                    b.ToTable("UserPermissions");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId", "RoleId" }, "IX_UserRoles")
                        .IsUnique();

                    b.HasIndex(new[] { "RoleId" }, "IX_UserRoles_RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationAuthenticationProvider", b =>
                {
                    b.HasOne("DsK.AuthServer.Security.EntityFramework.Models.Application", "Application")
                        .WithMany("ApplicationAuthenticationProviders")
                        .HasForeignKey("ApplicationId")
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationAuthenticationProviders_Applications");

                    b.Navigation("Application");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationAuthenticationProviderUserMapping", b =>
                {
                    b.HasOne("DsK.AuthServer.Security.EntityFramework.Models.ApplicationAuthenticationProvider", "ApplicationAuthenticationProvider")
                        .WithMany("ApplicationAuthenticationProviderUserMappings")
                        .HasForeignKey("ApplicationAuthenticationProviderId")
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationAuthenticationProviderUserMappings_ApplicationAuthenticationProviders");

                    b.HasOne("DsK.AuthServer.Security.EntityFramework.Models.User", "User")
                        .WithMany("ApplicationAuthenticationProviderUserMappings")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationAuthenticationProviderUserMappings_Users");

                    b.Navigation("ApplicationAuthenticationProvider");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationAuthenticationProviderUserToken", b =>
                {
                    b.HasOne("DsK.AuthServer.Security.EntityFramework.Models.Application", "Application")
                        .WithMany("ApplicationAuthenticationProviderUserTokens")
                        .HasForeignKey("ApplicationId")
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationAuthenticationProviderUserMappings_Applications");

                    b.HasOne("DsK.AuthServer.Security.EntityFramework.Models.User", "User")
                        .WithMany("ApplicationAuthenticationProviderUserTokens")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationAuthenticationProviderUserTokens_Users");

                    b.Navigation("Application");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationPermission", b =>
                {
                    b.HasOne("DsK.AuthServer.Security.EntityFramework.Models.Application", "Application")
                        .WithMany("ApplicationPermissions")
                        .HasForeignKey("ApplicationId")
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationPermissions_Applications");

                    b.Navigation("Application");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationRole", b =>
                {
                    b.HasOne("DsK.AuthServer.Security.EntityFramework.Models.Application", "Application")
                        .WithMany("ApplicationRoles")
                        .HasForeignKey("ApplicationId")
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationRoles_Applications");

                    b.Navigation("Application");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationRolePermission", b =>
                {
                    b.HasOne("DsK.AuthServer.Security.EntityFramework.Models.ApplicationPermission", "ApplicationRole")
                        .WithMany("ApplicationRolePermissions")
                        .HasForeignKey("ApplicationRoleId")
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationRolePermissions_ApplicationPermissions");

                    b.HasOne("DsK.AuthServer.Security.EntityFramework.Models.ApplicationRole", "ApplicationRoleNavigation")
                        .WithMany("ApplicationRolePermissions")
                        .HasForeignKey("ApplicationRoleId")
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationRolePermissions_ApplicationRoles");

                    b.Navigation("ApplicationRole");

                    b.Navigation("ApplicationRoleNavigation");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationUser", b =>
                {
                    b.HasOne("DsK.AuthServer.Security.EntityFramework.Models.Application", "Application")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("ApplicationId")
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationUsers_Applications");

                    b.HasOne("DsK.AuthServer.Security.EntityFramework.Models.User", "User")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_ApplicationUsers_Users");

                    b.Navigation("Application");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.UserLog", b =>
                {
                    b.HasOne("DsK.AuthServer.Security.EntityFramework.Models.Application", "Application")
                        .WithMany("UserLogs")
                        .HasForeignKey("ApplicationId")
                        .IsRequired()
                        .HasConstraintName("FK_UserLogs_Users");

                    b.Navigation("Application");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.UserPermission", b =>
                {
                    b.HasOne("DsK.AuthServer.Security.EntityFramework.Models.ApplicationPermission", "Permission")
                        .WithMany("UserPermissions")
                        .HasForeignKey("PermissionId")
                        .IsRequired()
                        .HasConstraintName("FK_UserPermissions_ApplicationPermissions");

                    b.HasOne("DsK.AuthServer.Security.EntityFramework.Models.User", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserPermissions_Users");

                    b.Navigation("Permission");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.UserRole", b =>
                {
                    b.HasOne("DsK.AuthServer.Security.EntityFramework.Models.ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_UserRoles_ApplicationRoles");

                    b.HasOne("DsK.AuthServer.Security.EntityFramework.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserRoles_Users");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.Application", b =>
                {
                    b.Navigation("ApplicationAuthenticationProviderUserTokens");

                    b.Navigation("ApplicationAuthenticationProviders");

                    b.Navigation("ApplicationPermissions");

                    b.Navigation("ApplicationRoles");

                    b.Navigation("ApplicationUsers");

                    b.Navigation("UserLogs");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationAuthenticationProvider", b =>
                {
                    b.Navigation("ApplicationAuthenticationProviderUserMappings");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationPermission", b =>
                {
                    b.Navigation("ApplicationRolePermissions");

                    b.Navigation("UserPermissions");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.ApplicationRole", b =>
                {
                    b.Navigation("ApplicationRolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("DsK.AuthServer.Security.EntityFramework.Models.User", b =>
                {
                    b.Navigation("ApplicationAuthenticationProviderUserMappings");

                    b.Navigation("ApplicationAuthenticationProviderUserTokens");

                    b.Navigation("ApplicationUsers");

                    b.Navigation("UserPermissions");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
