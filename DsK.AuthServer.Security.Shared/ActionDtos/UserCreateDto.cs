﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DsK.AuthServer.Security.Shared;
public class UserCreateDto
{
    [Required]
    [StringLength(256, MinimumLength = 3)]
    [DefaultValue("John Smith")]
    public string? Name { get; set; }

    [Required]
    [StringLength(256, MinimumLength = 6)]
    [EmailAddress]
    [DefaultValue("jsmith@gmail.com")]
    public string? Email { get; set; }

    [Required]
    [StringLength(256, MinimumLength = 6)]
    [PasswordPropertyText]
    public string? Password { get; set; }
}
