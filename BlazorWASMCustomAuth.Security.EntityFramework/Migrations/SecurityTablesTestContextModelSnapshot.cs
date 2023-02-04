﻿// <auto-generated />
using System;
using BlazorWASMCustomAuth.Security.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorWASMCustomAuth.Security.EntityFramework.Migrations
{
    [DbContext(typeof(SecurityTablesTestContext))]
    partial class SecurityTablesTestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AuthenticationProviderType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Domain")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("AuthenticationProviders");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PermissionDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "PermissionName" }, "IX_Permissions")
                        .IsUnique();

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

                    b.HasIndex(new[] { "RoleName" }, "IX_Roles")
                        .IsUnique();

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

                    b.HasIndex(new[] { "UserId" }, "IX_UserLogs_UserId");

                    b.ToTable("UserLogs");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_UserPasswords_UserId");

                    b.ToTable("UserPasswords");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Allow")
                        .HasColumnType("bit");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex(new[] { "PermissionId", "UserId" }, "IX_UserPermissions")
                        .IsUnique();

                    b.ToTable("UserPermissions");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserRole", b =>
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

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "UserId", "RoleId" }, "IX_UserRoles")
                        .IsUnique();

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserToken", b =>
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

                    b.Property<DateTime>("TokenRefreshedDateTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK_UserAuthenticationProviderTokens");

                    b.ToTable("UserTokens");
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

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.UserRole", b =>
                {
                    b.HasOne("BlazorWASMCustomAuth.Security.EntityFramework.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_UserRoles_Roles");

                    b.HasOne("BlazorWASMCustomAuth.Security.EntityFramework.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_UserRoles_Users");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.Permission", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserPermissions");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("BlazorWASMCustomAuth.Security.EntityFramework.Models.User", b =>
                {
                    b.Navigation("UserLogs");

                    b.Navigation("UserPasswords");

                    b.Navigation("UserPermissions");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
