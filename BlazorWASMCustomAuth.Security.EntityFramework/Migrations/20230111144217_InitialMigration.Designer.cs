﻿// <auto-generated />
using System;
using BlazorWASMCustomAuth.Security.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorWASMCustomAuth.Security.EntityFramework.Migrations
{
    [DbContext(typeof(SecurityTablesTestContext))]
    [Migration("20230111144217_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.AuthenticationProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthenticationProviderName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("AuthenticationProviderName");

                    b.HasKey("Id");

                    b.ToTable("AuthenticationProviders");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.AuthenticationProviderAdconfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("AuthenticationProviderADConfig", (string)null);
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PermissionDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.RolePermission", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "PermissionId")
                        .HasName("PK_RolePermissions_1");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IX_Users_Email")
                        .IsUnique();

                    b.HasIndex(new[] { "Username" }, "IX_Users_Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserAuthenticationProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthenticationProviderId")
                        .HasColumnType("int");

                    b.Property<string>("MappedUsername")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthenticationProviderId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAuthenticationProviders");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserAuthenticationProviderDefault", b =>
                {
                    b.Property<int>("AuthenticationProviderId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.ToTable("UserAuthenticationProviderDefault", (string)null);
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserAuthenticationProviderToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TokenCreatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("UserAuthenticationProviderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserAuthenticationProviderId");

                    b.ToTable("UserAuthenticationProviderTokens");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Event")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventDateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogs");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("date");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserPasswords");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserPermission", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<bool>("Allow")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "PermissionId")
                        .HasName("PK_UserPermissions_1");

                    b.HasIndex("PermissionId");

                    b.ToTable("UserPermissions");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.RolePermission", b =>
                {
                    b.HasOne("BlazorWASMCustomAuth.Security.EntityFramework.Models.Permission", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_RolePermissions_Permissions");

                    b.HasOne("BlazorWASMCustomAuth.Security.EntityFramework.Models.Role", "RoleNavigation")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_RolePermissions_Roles");

                    b.Navigation("Role");

                    b.Navigation("RoleNavigation");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserAuthenticationProvider", b =>
                {
                    b.HasOne("BlazorWASMCustomAuth.Security.EntityFramework.Models.AuthenticationProvider", "AuthenticationProvider")
                        .WithMany("UserAuthenticationProviders")
                        .HasForeignKey("AuthenticationProviderId")
                        .IsRequired()
                        .HasConstraintName("FK_UserAuthenticationProviders_AuthenticationProviders");

                    b.HasOne("BlazorWASMCustomAuth.Security.EntityFramework.Models.User", "User")
                        .WithMany("UserAuthenticationProviders")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserAuthenticationProviders_Users");

                    b.Navigation("AuthenticationProvider");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserAuthenticationProviderToken", b =>
                {
                    b.HasOne("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserAuthenticationProvider", "UserAuthenticationProvider")
                        .WithMany("UserAuthenticationProviderTokens")
                        .HasForeignKey("UserAuthenticationProviderId")
                        .IsRequired()
                        .HasConstraintName("FK_UserAuthenticationProviderTokens_UserAuthenticationProviders");

                    b.Navigation("UserAuthenticationProvider");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserLog", b =>
                {
                    b.HasOne("BlazorWASMCustomAuth.Security.EntityFramework.Models.User", "User")
                        .WithMany("UserLogs")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserLogs_Users");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserPassword", b =>
                {
                    b.HasOne("BlazorWASMCustomAuth.Security.EntityFramework.Models.User", "User")
                        .WithMany("UserPasswords")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserPasswords_Users");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserPermission", b =>
                {
                    b.HasOne("BlazorWASMCustomAuth.Security.EntityFramework.Models.Permission", "Permission")
                        .WithMany("UserPermissions")
                        .HasForeignKey("PermissionId")
                        .IsRequired()
                        .HasConstraintName("FK_UserPermissions_Permissions");

                    b.HasOne("BlazorWASMCustomAuth.Security.EntityFramework.Models.User", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserPermissions_Users");

                    b.Navigation("Permission");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.HasOne("BlazorWASMCustomAuth.Security.EntityFramework.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_UserRoles_Roles");

                    b.HasOne("BlazorWASMCustomAuth.Security.EntityFramework.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserRoles_Users");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.AuthenticationProvider", b =>
                {
                    b.Navigation("UserAuthenticationProviders");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.Permission", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserPermissions");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.Role", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.User", b =>
                {
                    b.Navigation("UserAuthenticationProviders");

                    b.Navigation("UserLogs");

                    b.Navigation("UserPasswords");

                    b.Navigation("UserPermissions");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserAuthenticationProvider", b =>
                {
                    b.Navigation("UserAuthenticationProviderTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
