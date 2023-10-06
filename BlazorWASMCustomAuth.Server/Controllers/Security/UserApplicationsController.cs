﻿using BlazorWASMCustomAuth.Security.Infrastructure;
using BlazorWASMCustomAuth.Security.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWASMCustomAuth.Server.Controllers.Security;

[Route("api/[controller]")]
[ApiController]
public class UserApplicationsController : ControllerBase
{
    private readonly SecurityService SecurityService;
    public UserApplicationsController(SecurityService securityService)
    {
        SecurityService = securityService;
    }

    [HttpGet]
    [Authorize(Roles = $"{Access.Admin}, {Access.UserApplications.View}")]
    public async Task<IActionResult> Get(int userId = 0)
    {
        var result = await SecurityService.UserApplicationsGet(userId);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = $"{Access.Admin}, {Access.UserApplications.Edit}, {Access.ApplicationUsers.Edit}")]
    public async Task<IActionResult> UserApplicationChange(ApplicationUserChangeDto model)
    {
        var result = await SecurityService.UserApplicationChange(model);
        return Ok(result);
    }
}

