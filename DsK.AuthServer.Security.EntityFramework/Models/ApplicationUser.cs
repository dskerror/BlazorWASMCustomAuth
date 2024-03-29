﻿using System;
using System.Collections.Generic;

namespace DsK.AuthServer.Security.EntityFramework.Models;

public partial class ApplicationUser
{
    public int Id { get; set; }

    public int ApplicationId { get; set; }

    public int UserId { get; set; }

    public DateTime? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public bool IsEnabled { get; set; }

    public virtual Application Application { get; set; } = null!;

    public virtual ICollection<ApplicationAuthenticationProviderUserMapping> ApplicationAuthenticationProviderUserMappings { get; set; } = new List<ApplicationAuthenticationProviderUserMapping>();

    public virtual User User { get; set; } = null!;
}
