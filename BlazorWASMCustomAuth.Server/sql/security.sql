USE [master]
GO
/****** Object:  Database [SecurityTablesTest]    Script Date: 1/9/2023 4:42:04 PM ******/
CREATE DATABASE [SecurityTablesTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SecurityTablesTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SecurityTablesTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SecurityTablesTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\SecurityTablesTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SecurityTablesTest] SET COMPATIBILITY_LEVEL = 160
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
ALTER DATABASE [SecurityTablesTest] SET AUTO_CLOSE OFF 
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
ALTER DATABASE [SecurityTablesTest] SET  DISABLE_BROKER 
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
ALTER DATABASE [SecurityTablesTest] SET READ_COMMITTED_SNAPSHOT OFF 
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
ALTER DATABASE [SecurityTablesTest] SET QUERY_STORE = ON
GO
ALTER DATABASE [SecurityTablesTest] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SecurityTablesTest]
GO
/****** Object:  Table [dbo].[AuthenticationProviders]    Script Date: 1/9/2023 4:42:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthenticationProviders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AuthenticationProvider] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AuthenticationProviders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 1/9/2023 4:42:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PermissionName] [nvarchar](255) NOT NULL,
	[PermissionDescription] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermissions]    Script Date: 1/9/2023 4:42:04 PM ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 1/9/2023 4:42:04 PM ******/
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
/****** Object:  Table [dbo].[UserAuthenticationProviderDefault]    Script Date: 1/9/2023 4:42:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAuthenticationProviderDefault](
	[UserId] [int] NOT NULL,
	[AuthenticationProviderId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAuthenticationProviders]    Script Date: 1/9/2023 4:42:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAuthenticationProviders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AuthenticationProviderId] [int] NOT NULL,
	[MappedUsername] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_UserAuthenticationProviders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAuthenticationProviderTokens]    Script Date: 1/9/2023 4:42:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAuthenticationProviderTokens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserAuthenticationProviderId] [int] NOT NULL,
	[Token] [nvarchar](max) NOT NULL,
	[RefreshToken] [nvarchar](max) NOT NULL,
	[TokenCreatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_UserAuthenticationProviderTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogs]    Script Date: 1/9/2023 4:42:04 PM ******/
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
/****** Object:  Table [dbo].[UserPasswords]    Script Date: 1/9/2023 4:42:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPasswords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[DateCreated] [date] NOT NULL,
 CONSTRAINT [PK_UserPasswords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPermissions]    Script Date: 1/9/2023 4:42:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPermissions](
	[UserId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
	[Allow] [bit] NOT NULL,
 CONSTRAINT [PK_UserPermissions_1] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 1/9/2023 4:42:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/9/2023 4:42:04 PM ******/
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
SET IDENTITY_INSERT [dbo].[AuthenticationProviders] ON 

INSERT [dbo].[AuthenticationProviders] ([Id], [AuthenticationProvider]) VALUES (1, N'Local')
INSERT [dbo].[AuthenticationProviders] ([Id], [AuthenticationProvider]) VALUES (2, N'Active Directory')
SET IDENTITY_INSERT [dbo].[AuthenticationProviders] OFF
GO
SET IDENTITY_INSERT [dbo].[Permissions] ON 

INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionDescription]) VALUES (1, N'Secured.Permiso1', N'')
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionDescription]) VALUES (2, N'Secured.Permiso2', N'')
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionDescription]) VALUES (3, N'Secured.Permiso3', N'')
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionDescription]) VALUES (4, N'Secured2.Permiso1', N'')
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionDescription]) VALUES (5, N'Secured2.Permiso2', N'')
INSERT [dbo].[Permissions] ([Id], [PermissionName], [PermissionDescription]) VALUES (6, N'Secured2.Permiso3', N'')
SET IDENTITY_INSERT [dbo].[Permissions] OFF
GO
INSERT [dbo].[RolePermissions] ([RoleId], [PermissionId]) VALUES (1, 1)
INSERT [dbo].[RolePermissions] ([RoleId], [PermissionId]) VALUES (1, 2)
INSERT [dbo].[RolePermissions] ([RoleId], [PermissionId]) VALUES (1, 3)
INSERT [dbo].[RolePermissions] ([RoleId], [PermissionId]) VALUES (1, 4)
INSERT [dbo].[RolePermissions] ([RoleId], [PermissionId]) VALUES (1, 5)
INSERT [dbo].[RolePermissions] ([RoleId], [PermissionId]) VALUES (1, 6)
INSERT [dbo].[RolePermissions] ([RoleId], [PermissionId]) VALUES (2, 1)
INSERT [dbo].[RolePermissions] ([RoleId], [PermissionId]) VALUES (2, 2)
INSERT [dbo].[RolePermissions] ([RoleId], [PermissionId]) VALUES (2, 3)
INSERT [dbo].[RolePermissions] ([RoleId], [PermissionId]) VALUES (3, 4)
INSERT [dbo].[RolePermissions] ([RoleId], [PermissionId]) VALUES (3, 5)
INSERT [dbo].[RolePermissions] ([RoleId], [PermissionId]) VALUES (3, 6)
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [RoleName], [RoleDescription]) VALUES (1, N'Admin', N'Admin Role')
INSERT [dbo].[Roles] ([Id], [RoleName], [RoleDescription]) VALUES (2, N'Secured', N'Secured Role')
INSERT [dbo].[Roles] ([Id], [RoleName], [RoleDescription]) VALUES (3, N'Secured2', N'Secured2 Role')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
INSERT [dbo].[UserAuthenticationProviderDefault] ([UserId], [AuthenticationProviderId]) VALUES (6, 2)
GO
SET IDENTITY_INSERT [dbo].[UserAuthenticationProviders] ON 

INSERT [dbo].[UserAuthenticationProviders] ([Id], [UserId], [AuthenticationProviderId], [MappedUsername]) VALUES (1, 6, 1, N'dskerror')
INSERT [dbo].[UserAuthenticationProviders] ([Id], [UserId], [AuthenticationProviderId], [MappedUsername]) VALUES (2, 6, 2, N'jmartinez')
SET IDENTITY_INSERT [dbo].[UserAuthenticationProviders] OFF
GO
SET IDENTITY_INSERT [dbo].[UserPasswords] ON 

INSERT [dbo].[UserPasswords] ([Id], [UserId], [Password], [DateCreated]) VALUES (1, 6, N'CCA18432B0527BE688B68D25C9B82F2A930AFDA1A7824A84EE3CFCDC091680E0E9DD4D199CA2E6308844E6319A97AE26EA0196C17B13914772A6F6473C66C921', CAST(N'2023-01-04' AS Date))
INSERT [dbo].[UserPasswords] ([Id], [UserId], [Password], [DateCreated]) VALUES (2, 8, N'B2DCE8129A0EA27A7F8221F603F5FA34A946BC27D9A99B5401366E29F7E82E48C43A41EB00B66614A87281FF9E7174BD5D86804918FB61E87B0F931B1A941AB6', CAST(N'2023-01-06' AS Date))
SET IDENTITY_INSERT [dbo].[UserPasswords] OFF
GO
INSERT [dbo].[UserPermissions] ([UserId], [PermissionId], [Allow]) VALUES (6, 2, 0)
INSERT [dbo].[UserPermissions] ([UserId], [PermissionId], [Allow]) VALUES (6, 5, 1)
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (6, 2)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Name], [Email], [EmailConfirmed], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [TwoFactorEnabled]) VALUES (6, N'dskerror', N'dsk', N'dskerror@gmail.com', 0, NULL, 0, 0, 0)
INSERT [dbo].[Users] ([Id], [Username], [Name], [Email], [EmailConfirmed], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [TwoFactorEnabled]) VALUES (7, N'user1', N'user1 name', N'user@1.com', 0, NULL, 0, 0, 0)
INSERT [dbo].[Users] ([Id], [Username], [Name], [Email], [EmailConfirmed], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [TwoFactorEnabled]) VALUES (8, N'admin', N'Administrator', N'admin123', 0, NULL, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Email]    Script Date: 1/9/2023 4:42:04 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Username]    Script Date: 1/9/2023 4:42:04 PM ******/
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
ALTER TABLE [dbo].[UserAuthenticationProviders]  WITH CHECK ADD  CONSTRAINT [FK_UserAuthenticationProviders_AuthenticationProviders] FOREIGN KEY([AuthenticationProviderId])
REFERENCES [dbo].[AuthenticationProviders] ([Id])
GO
ALTER TABLE [dbo].[UserAuthenticationProviders] CHECK CONSTRAINT [FK_UserAuthenticationProviders_AuthenticationProviders]
GO
ALTER TABLE [dbo].[UserAuthenticationProviders]  WITH CHECK ADD  CONSTRAINT [FK_UserAuthenticationProviders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserAuthenticationProviders] CHECK CONSTRAINT [FK_UserAuthenticationProviders_Users]
GO
ALTER TABLE [dbo].[UserAuthenticationProviderTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserAuthenticationProviderTokens_UserAuthenticationProviders] FOREIGN KEY([UserAuthenticationProviderId])
REFERENCES [dbo].[UserAuthenticationProviders] ([Id])
GO
ALTER TABLE [dbo].[UserAuthenticationProviderTokens] CHECK CONSTRAINT [FK_UserAuthenticationProviderTokens_UserAuthenticationProviders]
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
/****** Object:  StoredProcedure [dbo].[sp_PermissionList]    Script Date: 1/9/2023 4:42:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_PermissionList]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id],[PermissionName],[PermissionDescription]
	FROM [SecurityTablesTest].[dbo].[Permissions]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RoleList]    Script Date: 1/9/2023 4:42:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_RoleList]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id],[RoleName],[RoleDescription]
	FROM [SecurityTablesTest].[dbo].[ROles]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RolePermissionList]    Script Date: 1/9/2023 4:42:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_RolePermissionList]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		RoleId, RoleName, RoleDescription,
		PermissionId,	PermissionName, PermissionDescription
	FROM [SecurityTablesTest].[dbo].[Roles] a
	INNER JOIN [SecurityTablesTest].[dbo].[RolePermissions] b on a.Id = b.RoleId
	INNER JOIN [SecurityTablesTest].[dbo].[Permissions] c on b.RoleId = c.Id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UserCreate]    Script Date: 1/9/2023 4:42:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UserCreate] 
	@Username nvarchar(max),
	@Name nvarchar(max),
	@Email nvarchar(max)	
AS
BEGIN

	SET NOCOUNT ON;    

	INSERT INTO Users ([Username],[Name],[Email],[EmailConfirmed],[LockoutEnabled],[AccessFailedCount],[TwoFactorEnabled])
	OUTPUT Inserted.Id 
	VALUES (@Username, @Name, @Email, 0, 0, 0, 0)
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UserCreate_VerifyIfExists]    Script Date: 1/9/2023 4:42:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UserCreate_VerifyIfExists] 
	@Username nvarchar(max),
	@Email nvarchar(max)	
AS
BEGIN

	SET NOCOUNT ON;    
	SELECT * FROM Users WHERE Username = @Username OR Email = @Email
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UserPasswordCreate]    Script Date: 1/9/2023 4:42:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UserPasswordCreate] 
	@UserId int,
	@Password nvarchar(max)	
AS
BEGIN

	SET NOCOUNT ON;    

	INSERT INTO UserPasswords ([UserId],[Password],[DateCreated])
	OUTPUT Inserted.Id VALUES (@UserId, @Password, getdate())
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UsersCountGet]    Script Date: 1/9/2023 4:42:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UsersCountGet]
	@Id int = null
AS
BEGIN
	SET NOCOUNT ON;

	SELECT COUNT(*) as [COUNT]
	FROM [SecurityTablesTest].[dbo].[Users]	
	WHERE 1=1
	AND (@Id IS NULL OR Id = @Id)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UsersGet]    Script Date: 1/9/2023 4:42:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UsersGet] --1,2
	@Offset int,
	@PageSize int ,
	@Id int = null
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *		
	FROM [SecurityTablesTest].[dbo].[Users]	
	WHERE 1=1
	AND (@Id IS NULL OR Id = @Id)
	ORDER BY ID, NAME
	OFFSET @Offset ROWS
	FETCH NEXT @PageSize ROWS ONLY
END
GO
USE [master]
GO
ALTER DATABASE [SecurityTablesTest] SET  READ_WRITE 
GO
