﻿using System;
using System.Collections.Generic;

namespace DsK.AuthServer.Security.EntityFramework.Models;

public partial class ApplicationAuthenticationProvider
{
    public int Id { get; set; }

    public Guid ApplicationAuthenticationProviderGuid { get; set; }

    public int ApplicationId { get; set; }

    public int? DefaultApplicationRoleId { get; set; }

    public string? AuthenticationProviderType { get; set; }

    public string? Name { get; set; }

    public string? Domain { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public bool IsEnabled { get; set; }

    public bool RegistrationEnabled { get; set; }

    public bool RegistrationAutoEmailConfirm { get; set; }

    public bool ActiveDirectoryFirstLoginAutoRegister { get; set; }

    public virtual Application Application { get; set; } = null!;

    public virtual ICollection<ApplicationAuthenticationProviderUserMapping> ApplicationAuthenticationProviderUserMappings { get; set; } = new List<ApplicationAuthenticationProviderUserMapping>();
}
