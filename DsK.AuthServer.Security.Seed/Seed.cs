﻿using DsK.AuthServer.Security.EntityFramework.Models;
using DsK.AuthServer.Security.Infrastructure;
using Microsoft.EntityFrameworkCore;
using DsK.AuthServer.Security.Shared;

namespace DsK.AuthServer.Security.Seed;
public class Seed
{
    private readonly DsKauthServerContext db;

    public Seed(DsKauthServerContext db)
    {
        this.db = db;
    }
    public void Run()
    {
        db.Database.Migrate(); //CREATES DATABASE IF IT DOESNT EXISTS
                               //var created = db.Database.EnsureCreated(); //CREATES TABLES IF IT DOESNT EXISTS

        //Security App
        if (db.Applications.Count() == 0)
        {
            var newApp = CreateApplication();

            var adminPermission = CreateAppPermission( newApp.Id, "Admin", "Admin Permission");
            var authAppPermissionList = CreateApplicationPermissions(newApp); //Create list of permissions based on Security.Shared Permissions

            var adminRole = CreateApplicationRole(newApp.Id, "Admin", "Admin Role");
            var userRole = CreateApplicationRole(newApp.Id, "User", "User Role");

            var applicationAuthenticationProvider = AddLocalAuthenticationProviderToApplication(newApp, userRole, "67A09D32-7664-49F8-8E8E-471A56A2858E");

            AddPermissionToRole(adminPermission.Id, adminRole.Id);
            var adminUser = CreateUser("admin@admin.com", "Admin", "admin123");
            var adminAppUser = AddUserToApplicationUser(adminUser, newApp);
            AddAuthenticationProviderMappingToUser(applicationAuthenticationProvider, adminUser, adminAppUser);
            AddRoleToUser(adminRole, adminUser);
            AddPermissionToRole(GetPermissionIdByName(Access.MyProfile.View, authAppPermissionList), userRole.Id);
            AddPermissionToRole(GetPermissionIdByName(Access.MyProfile.Edit, authAppPermissionList), userRole.Id);

            var regularUser = CreateUser("user@user.com", "User", "user123");
            var regularAppUser = AddUserToApplicationUser(regularUser, newApp);
            AddAuthenticationProviderMappingToUser(applicationAuthenticationProvider, regularUser, regularAppUser);
            AddRoleToUser(userRole, regularUser);
        }
    }

    private int GetPermissionIdByName(string permissionName, Dictionary<string, ApplicationPermission> permissionList)
    {
        permissionList.TryGetValue(permissionName, out var value);
        return value.Id;
    }
    private Dictionary<string, ApplicationPermission> CreateApplicationPermissions(Application application)
    {
        var permissionList = Access.GetRegisteredPermissions();
        Dictionary<string, ApplicationPermission> outputList = new Dictionary<string, ApplicationPermission>();

        foreach (var permission in permissionList)
        {
            var newPermission = new ApplicationPermission() { ApplicationId = application.Id, PermissionName = permission, PermissionDescription = "" };
            outputList.Add(permission, newPermission);
            db.ApplicationPermissions.Add(newPermission);
        }
        db.SaveChanges();

        return outputList;
    }
    private Application CreateApplication()
    {
        Application newApplication = new Application()
        {
            IsEnabled = true,
            ApplicationName = "DsK.AuthServer",
            ApplicationDesc = "Manages authentication and authorization for other applications",
            ApplicationGuid = Guid.Parse("870F0BC1-DF58-447E-99BB-DA38D1D56D86"),
            AppApiKey = Guid.Parse("CAB41EEC-6002-4738-BE23-128B0A7276C1"),
            CallbackUrl = "/Callback/"
        };

        db.Applications.Add(newApplication);
        db.SaveChanges();
        return newApplication;
    }
    private ApplicationAuthenticationProvider AddLocalAuthenticationProviderToApplication(Application newApplication, ApplicationRole role, string guid)
    {
        ApplicationAuthenticationProvider applicationAuthenticationProvider =
                new ApplicationAuthenticationProvider()
                {
                    IsEnabled = true,
                    ApplicationAuthenticationProviderGuid = Guid.Parse(guid),
                    ApplicationId = newApplication.Id,
                    DefaultApplicationRoleId = role.Id,
                    Name = "Local",
                    AuthenticationProviderType = "Local",
                    Domain = "",
                    Username = "",
                    Password = "",
                    RegistrationEnabled = true,
                    RegistrationAutoEmailConfirm = true
                };

        db.ApplicationAuthenticationProviders.Add(applicationAuthenticationProvider);
        db.SaveChanges();

        return applicationAuthenticationProvider;
    }
    private void AddRoleToUser(ApplicationRole adminRole, User adminUser)
    {
        var adminUserRole = new UserRole() { Role = adminRole, User = adminUser };
        db.UserRoles.Add(adminUserRole);
        db.SaveChanges();
    }
    private void AddAuthenticationProviderMappingToUser(ApplicationAuthenticationProvider authProvider, User user, ApplicationUser appUser)
    {
        var applicationAuthenticationProviderUserMapping = new ApplicationAuthenticationProviderUserMapping()
        {
            ApplicationUser = appUser,
            Username = user.Email,
            ApplicationAuthenticationProvider = authProvider,
            IsEnabled = true
        };
        db.ApplicationAuthenticationProviderUserMappings.Add(applicationAuthenticationProviderUserMapping);
        db.SaveChanges();
    }
    private User CreateUser(string email, string name, string password)
    {
        var ramdomSalt = SecurityHelpers.RandomizeSalt;

        var adminUser = new User()
        {
            Email = email,
            Name = name,
            EmailConfirmed = true,
            AccessFailedCount = 0,
            LockoutEnabled = false,
            HashedPassword = SecurityHelpers.HashPasword(password, ramdomSalt),
            Salt = Convert.ToHexString(ramdomSalt),
            AccountCreatedDateTime = DateTime.Now,
            LastPasswordChangeDateTime = DateTime.Now,
            IsEnabled = true
        };

        db.Users.Add(adminUser);
        db.SaveChanges();
        return adminUser;
    }
    private ApplicationUser AddUserToApplicationUser(User user, Application application)
    {
        var adminApplicationUser = new ApplicationUser()
        {
            UserId = user.Id,
            ApplicationId = application.Id,
            AccessFailedCount = 0,
            TwoFactorEnabled = false,
            LockoutEnabled = false,
            IsEnabled = true
        };

        db.ApplicationUsers.Add(adminApplicationUser);
        db.SaveChanges();
        return adminApplicationUser;
    }
    private void AddPermissionToRole(int permissionId, int roleId)
    {
        var rolePermission = new ApplicationRolePermission()
        {
            ApplicationRoleId = roleId,
            ApplicationPermissionId = permissionId
        };
        db.ApplicationRolePermissions.Add(rolePermission);
        db.SaveChanges();
    }
    private ApplicationRole CreateApplicationRole(int applicationId, string RoleName, string RoleDescription)
    {
        var adminRole = new ApplicationRole()
        {
            IsEnabled = true,
            ApplicationId = applicationId,
            RoleName = RoleName,
            RoleDescription = RoleDescription
        };
        db.ApplicationRoles.Add(adminRole);
        db.SaveChanges();
        return adminRole;
    }
    private Application CreateTestApp()
    {
        Application newApplication = new Application()
        {
            ApplicationName = "TestApp.Client",
            ApplicationDesc = "Application to test DsK.AuthorizationServer",
            ApplicationGuid = Guid.Parse("004998CC-6A12-46AD-A7D3-D032B4194358"),
            AppApiKey = Guid.Parse("B4F1712E-25E9-4E35-A54A-68A8BA6CEB2C"),
            CallbackUrl = "https://localhost:7298/Callback/"
        };

        db.Applications.Add(newApplication);
        db.SaveChanges();
        return newApplication;
    }
    private ApplicationPermission CreateAppPermission(int applicationId, string permissionName, string permissionDescription)
    {
        var permission = new ApplicationPermission()
        {
            ApplicationId = applicationId,
            PermissionName = permissionName,
            PermissionDescription = permissionDescription
        };
        db.ApplicationPermissions.Add(permission);
        db.SaveChanges();

        return permission;
    }
}