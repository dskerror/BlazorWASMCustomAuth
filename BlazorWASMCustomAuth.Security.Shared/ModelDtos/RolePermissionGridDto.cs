﻿using System;
using System.Collections.Generic;

namespace BlazorWASMCustomAuth.Security.Shared;

public partial class RolePermissionGridDto
{   
    public int Id { get; set; }
    public string PermissionName { get; set; }
    public string PermissionDescription { get; set; }
    public bool Enable { get; set; }
}
