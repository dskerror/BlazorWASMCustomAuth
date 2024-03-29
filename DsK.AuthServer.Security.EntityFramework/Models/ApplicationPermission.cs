﻿using System;
using System.Collections.Generic;

namespace DsK.AuthServer.Security.EntityFramework.Models;

public partial class ApplicationPermission
{
    public int Id { get; set; }

    public int ApplicationId { get; set; }

    public string PermissionName { get; set; } = null!;

    public string PermissionDescription { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public virtual Application Application { get; set; } = null!;

    public virtual ICollection<ApplicationRolePermission> ApplicationRolePermissions { get; set; } = new List<ApplicationRolePermission>();

    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
}
