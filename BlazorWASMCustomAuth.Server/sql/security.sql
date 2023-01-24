USE [master]
GO
/****** Object:  Database [SecurityTablesTest]    Script Date: 1/23/2023 11:16:57 PM ******/
CREATE DATABASE [SecurityTablesTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SecurityTablesTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SecurityTablesTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SecurityTablesTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SecurityTablesTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SecurityTablesTest] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SecurityTablesTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SecurityTablesTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SecurityTablesTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SecurityTablesTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SecurityTablesTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SecurityTablesTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SecurityTablesTest] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SecurityTablesTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SecurityTablesTest] SET  MULTI_USER 
GO
ALTER DATABASE [SecurityTablesTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SecurityTablesTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SecurityTablesTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SecurityTablesTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SecurityTablesTest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SecurityTablesTest] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SecurityTablesTest] SET QUERY_STORE = OFF
GO
USE [SecurityTablesTest]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/23/2023 11:16:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthenticationProviders]    Script Date: 1/23/2023 11:16:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthenticationProviders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AuthenticationProviderName] [nvarchar](50) NOT NULL,
	[AuthenticationProviderType] [nvarchar](50) NULL,
	[Domain] [nvarchar](100) NULL,
	[Username] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
 CONSTRAINT [PK_AuthenticationProviders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 1/23/2023 11:16:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PermissionName] [nvarchar](50) NOT NULL,
	[PermissionDescription] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermissions]    Script Date: 1/23/2023 11:16:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermissions](
	[RoleId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
 CONSTRAINT [PK_RolePermissions_1] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 1/23/2023 11:16:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[RoleDescription] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogs]    Script Date: 1/23/2023 11:16:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[EventDateTime] [datetime] NOT NULL,
	[Event] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_UserLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPasswords]    Script Date: 1/23/2023 11:16:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPasswords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[HashedPassword] [nvarchar](max) NOT NULL,
	[Salt] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_UserPasswords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPermissions]    Script Date: 1/23/2023 11:16:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
	[Allow] [bit] NOT NULL,
 CONSTRAINT [PK_UserPermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 1/23/2023 11:16:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/23/2023 11:16:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](256) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnd] [date] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 1/23/2023 11:16:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Token] [nvarchar](max) NOT NULL,
	[RefreshToken] [nvarchar](max) NOT NULL,
	[TokenCreatedDateTime] [datetime] NOT NULL,
	[TokenRefreshedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_UserAuthenticationProviderTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230113201347_migration1', N'7.0.2')
GO
SET IDENTITY_INSERT [dbo].[AuthenticationProviders] ON 

INSERT [dbo].[AuthenticationProviders] ([Id], [AuthenticationProviderName], [AuthenticationProviderType], [Domain], [Username], [Password]) VALUES (1, N'Local', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[AuthenticationProviders] OFF
GO
SET IDENTITY_INSERT [dbo].[Permissions] ON 

INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionDescription]) VALUES (1, N'Admin', N'Admin Permission')
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionDescription]) VALUES (2, N'PermissionsGet', N'')
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionDescription]) VALUES (3, N'RefreshToken', N'')
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionDescription]) VALUES (4, N'RolePermissionsGet', N'')
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionDescription]) VALUES (5, N'RolesGet', N'')
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionDescription]) VALUES (6, N'UserChangeLocalPassword', N'')
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionDescription]) VALUES (7, N'UserCreate', N'')
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionDescription]) VALUES (8, N'UserCreateLocalPassword', N'')
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionDescription]) VALUES (9, N'UserLogin', N'')
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionDescription]) VALUES (12, N'newpermission', N'newpermission desc')
SET IDENTITY_INSERT [dbo].[Permissions] OFF
GO
INSERT [dbo].[RolePermissions] ([RoleId], [PermissionId]) VALUES (1, 1)
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [RoleName], [RoleDescription]) VALUES (1, N'Admin', N'Admin Role')
INSERT [dbo].[Roles] ([Id], [RoleName], [RoleDescription]) VALUES (2, N'User', N'Basic User Role')
INSERT [dbo].[Roles] ([Id], [RoleName], [RoleDescription]) VALUES (3, N'SuperUser', N'Super User Role')
INSERT [dbo].[Roles] ([Id], [RoleName], [RoleDescription]) VALUES (5, N'newrole', N'newrole desc')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[UserPasswords] ON 

INSERT [dbo].[UserPasswords] ([Id], [UserId], [HashedPassword], [Salt], [DateCreated]) VALUES (1, 1, N'7090E76ACA8C3EB45D37FF21C11015B03B4CC119CC83BD597CD04488889D474A1F1F9E60F96D0C3947D51D6F1AB1B111B3B5AD446D2271F9E5E2B8FD09954B9D', N'58AD2CBBC6FD1E5402491CC4653BEE579C9512D34DE0A8279B316A490E5502B3CE007AF1764D9FE8F56FF70D01FE82DB020AD3110E6EA57DA893B2D1678B7193', CAST(N'2023-01-13T00:00:00.000' AS DateTime))
INSERT [dbo].[UserPasswords] ([Id], [UserId], [HashedPassword], [Salt], [DateCreated]) VALUES (2, 4, N'6294F09ECC6397895E76C831D0F1127B53ABD5EB5306FBC18569263C6FE359A77723B5A8EA6CC90DD7A00E8CC5E22CB4A8B89671973EC33F3C6D58A1A579581C', N'90F72DF72F8646061FBA41D4FA4BC88650B2F3E080417CE79E2CA994844819422542D35E54E8FDA7E9E90159786AF26D8E16B1A5DF3B6D2669E8DBCB2183C513', CAST(N'2023-01-19T00:00:00.000' AS DateTime))
INSERT [dbo].[UserPasswords] ([Id], [UserId], [HashedPassword], [Salt], [DateCreated]) VALUES (3, 4, N'2612FB5820C191EF53BFCBA73527C85F0BC2B74D53C4214835891173D59BB23F847BE18B370EE449BE1835EACE4D787DB0D1971F75D8D980B01A159C082DCD47', N'7AEF6BD9DFF99A30BF6FF25E7398E845BFE6241DC0B11192E2404D34444729F2C3AAA8F8B7EA5445721142D094D486F35D84FD400230596BE93D1549318539C4', CAST(N'2023-01-19T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserPasswords] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (1, 1, 1)
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Name], [Email], [EmailConfirmed], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [TwoFactorEnabled]) VALUES (1, N'admin', N'admin', N'admin@admin.com', 1, NULL, 0, 0, 0)
INSERT [dbo].[Users] ([Id], [Username], [Name], [Email], [EmailConfirmed], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [TwoFactorEnabled]) VALUES (2, N'user1', N'el user 1', N'user1@user.com', 0, NULL, 0, 0, 0)
INSERT [dbo].[Users] ([Id], [Username], [Name], [Email], [EmailConfirmed], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [TwoFactorEnabled]) VALUES (3, N'user2', N'el user 2', N'user2@user.com', 0, NULL, 0, 0, 0)
INSERT [dbo].[Users] ([Id], [Username], [Name], [Email], [EmailConfirmed], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [TwoFactorEnabled]) VALUES (4, N'user4', N'el user 4', N'user4@user.com', 0, NULL, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[UserTokens] ON 

INSERT [dbo].[UserTokens] ([Id], [Token], [RefreshToken], [TokenCreatedDateTime], [TokenRefreshedDateTime]) VALUES (1, N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhZG1pbkBhZG1pbi5jb20iLCJVc2VySWQiOiIxIiwiVXNlck5hbWUiOiJhZG1pbiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6ImFkbWluIiwiZXhwIjoxNjc0MjQ1MDg1LCJpc3MiOiJCbGF6b3JXQVNNQ3VzdG9tQXV0aC5TZXJ2ZXIiLCJhdWQiOiJBUEkifQ.yM-jDKIQAGF4S_FGwdpMVMR3z9DncEDrQOfF2IoKmjE', N'Z1f/X2SC2fcLHxDMW/yfCDidVjdRegH2futm26+HNwI=', CAST(N'2023-01-19T15:57:48.007' AS DateTime), CAST(N'2023-01-19T16:05:04.207' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserTokens] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Permissions]    Script Date: 1/23/2023 11:16:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Permissions] ON [dbo].[Permissions]
(
	[PermissionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Roles]    Script Date: 1/23/2023 11:16:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Roles] ON [dbo].[Roles]
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserLogs_UserId]    Script Date: 1/23/2023 11:16:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserLogs_UserId] ON [dbo].[UserLogs]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserPasswords_UserId]    Script Date: 1/23/2023 11:16:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserPasswords_UserId] ON [dbo].[UserPasswords]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserPermissions]    Script Date: 1/23/2023 11:16:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserPermissions] ON [dbo].[UserPermissions]
(
	[PermissionId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles]    Script Date: 1/23/2023 11:16:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserRoles] ON [dbo].[UserRoles]
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Email]    Script Date: 1/23/2023 11:16:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Username]    Script Date: 1/23/2023 11:16:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Username] ON [dbo].[Users]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_Permissions] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Permissions] ([Id])
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_Permissions]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_Roles]
GO
ALTER TABLE [dbo].[UserLogs]  WITH CHECK ADD  CONSTRAINT [FK_UserLogs_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserLogs] CHECK CONSTRAINT [FK_UserLogs_Users]
GO
ALTER TABLE [dbo].[UserPasswords]  WITH CHECK ADD  CONSTRAINT [FK_UserPasswords_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserPasswords] CHECK CONSTRAINT [FK_UserPasswords_Users]
GO
ALTER TABLE [dbo].[UserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_UserPermissions_Permissions] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permissions] ([Id])
GO
ALTER TABLE [dbo].[UserPermissions] CHECK CONSTRAINT [FK_UserPermissions_Permissions]
GO
ALTER TABLE [dbo].[UserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_UserPermissions_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserPermissions] CHECK CONSTRAINT [FK_UserPermissions_Users]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users]
GO
/****** Object:  StoredProcedure [dbo].[sp_UserPermissions]    Script Date: 1/23/2023 11:16:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UserPermissions] @Username nvarchar(max)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    
	SELECT rtrim(ltrim(lower(a.PermissionName))) as PermissionName
	FROM
	(
		SELECT distinct e.PermissionName
		FROM Users a 
		INNER JOIN UserRoles b ON a.Id = b.UserId
		INNER JOIN Roles c ON b.RoleId = c.Id
		INNER JOIN RolePermissions d ON c.Id = d.RoleId
		INNER JOIN Permissions e ON d.PermissionId = e.Id
		WHERE a.Username = @Username
	
		UNION ALL
	
		SELECT distinct c.PermissionName
		FROM Users a 
		INNER JOIN UserPermissions b ON a.Id = b.UserId
		INNER JOIN Permissions c ON b.PermissionId = c.Id
		WHERE a.Username = @Username and b.Allow = 1
	) a
	LEFT JOIN
	(
		SELECT distinct c.PermissionName
		FROM Users a 
		INNER JOIN UserPermissions b ON a.Id = b.UserId
		INNER JOIN Permissions c ON b.PermissionId = c.Id
		WHERE a.Username = @Username and b.Allow = 0	
	) b ON a.PermissionName = b.PermissionName
	WHERE b.PermissionName is null
	
END
GO
USE [master]
GO
ALTER DATABASE [SecurityTablesTest] SET  READ_WRITE 
GO
