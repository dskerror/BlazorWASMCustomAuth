﻿using DsK.AuthServer.Security.Infrastructure;
using DsK.AuthServer.Security.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DsK.AuthServer.Server.Controllers.Security;
[Route("[controller]")]
[ApiController]
public class ApplicationAuthenticationProviderUserMappingsController : ControllerBase
{
    private readonly SecurityService SecurityService;
    public ApplicationAuthenticationProviderUserMappingsController(SecurityService securityService)
    {
        SecurityService = securityService;
    }

    [HttpPost]
    [Route("IsEnabledToggle")]
    [Authorize(Roles = $"{Access.Admin}, {Access.ApplicationAuthenticationProviderUserMappings.Create}")]
    public async Task<IActionResult> IsEnabledToggle(ApplicationAuthenticationProviderUserMappingIsEnabledToggleDto model)
    {
        var result = await SecurityService.ApplicationAuthenticationProviderUserMappingIsEnabledToggleDto(model);
        return Ok(result);
    }

    [HttpGet]
    [Authorize(Roles = $"{Access.Admin}, {Access.ApplicationAuthenticationProviderUserMappings.View}")]
    public async Task<IActionResult> Get(int applicationId, int userId)
    {
        var result = await SecurityService.ApplicationAuthenticationProviderUserMappingsGet(applicationId, userId);
        return Ok(result);
    }

    [HttpPut]
    [Authorize(Roles = $"{Access.Admin}, {Access.ApplicationAuthenticationProviderUserMappings.Edit}")]
    public async Task<IActionResult> Update(ApplicationAuthenticationProviderUserMappingUpdateDto model)
    {
        var result = await SecurityService.ApplicationAuthenticationProviderUserMappingUpdate(model);
        return Ok(result);
    }

    //[HttpDelete]
    //[Authorize(Roles = $"{Access.Admin}, {Access.ApplicationAuthenticationProviderUserMappings.Delete}")]
    //public async Task<IActionResult> Delete(int id)
    //{
    //    var result = await SecurityService.ApplicationAuthenticationProviderUserMappingDelete(id);
    //    return Ok(result);
    //}
}

