﻿using BlazorWASMCustomAuth.Security.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWASMCustomAuth.Security.Shared;
public class UserAuthenticationProviderMappingDto
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int AuthenticationProviderId { get; set; }

    public string Username { get; set; } = null!;

    public virtual ApplicationAuthenticationProviderDto AuthenticationProvider { get; set; } = null!;

    public virtual UserDto User { get; set; } = null!;
}