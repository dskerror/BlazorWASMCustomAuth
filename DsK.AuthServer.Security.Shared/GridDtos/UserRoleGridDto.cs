﻿namespace DsK.AuthServer.Security.Shared;
public partial class UserRoleGridDto
{
    public int Id { get; set; }
    public string ApplicationName { get; set; }
    public string RoleName { get; set; }
    public string RoleDescription { get; set; }
    public bool IsEnabled { get; set; }
}
