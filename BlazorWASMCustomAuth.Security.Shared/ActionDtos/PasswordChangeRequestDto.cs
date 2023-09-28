﻿using System.ComponentModel.DataAnnotations;

namespace BlazorWASMCustomAuth.Security.Shared;

public class PasswordChangeRequestDto
{
    [Required]
    [StringLength(256, MinimumLength = 5)]
    public string? Email { get; set; }
    public Guid ApplicationAuthenticationProviderGUID  { get; set; }
}
