﻿namespace DsK.AuthServer.Security.Shared;
public class ApplicationUserChangeDto
{
    public int UserId { get; set; }
    public int ApplicationId { get; set; }
    public bool IsEnabled { get; set; }
}
