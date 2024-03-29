﻿using System.ComponentModel.DataAnnotations;

namespace DsK.AuthServer.Security.Shared;

public class LoginRequestDto
{
    [Required]
    [StringLength(256, MinimumLength = 5)]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    public Guid ApplicationAuthenticationProviderGUID  { get; set; }
}
