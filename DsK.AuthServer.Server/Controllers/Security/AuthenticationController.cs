﻿using DsK.AuthServer.Security.Infrastructure;
using DsK.AuthServer.Security.Shared;
using DsK.AuthServer.Security.Shared.ActionDtos;
using Microsoft.AspNetCore.Mvc;
namespace DsK.AuthServer.Server.Controllers.Security;

[Route("[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly SecurityService SecurityService;
    public AuthenticationController(SecurityService securityService)
    {
        SecurityService = securityService;
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginRequestDto model)
    {
        //todo : implement captcha
        var callbackUrl = await SecurityService.Login(model);

        if (callbackUrl == null)
            return NotFound();

        return Ok(callbackUrl);
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register(RegisterRequestDto model)
    {
        //todo : implement captcha
        var origin = Request.Headers["origin"];
        var registerSuccessfull = await SecurityService.Register(model, origin);
        return Ok(registerSuccessfull);
    }

    [HttpPost]
    [Route("PasswordChangeRequest")]
    public async Task<IActionResult> PasswordChangeRequest(PasswordChangeRequestDto model)
    {
        //todo : implement captcha
        var origin = Request.Headers["origin"];
        var status = await SecurityService.PasswordChangeRequest(model, origin);
        return Ok(status);
    }

    [HttpPost]
    [Route("PasswordChange")]
    public async Task<IActionResult> PasswordChange(PasswordChangeDto model)
    {
        //todo : implement captcha
        var status = await SecurityService.PasswordChange(model);
        return Ok(status);
    }

    [HttpPost]
    [Route("EmailConfirm")]
    public async Task<IActionResult> EmailConfirm(EmailConfirmCodeDto model)
    {
        //todo : implement captcha
        var status = await SecurityService.EmailConfirmCode(model);
        return Ok(status);
    }

    [HttpPost]
    [Route("ValidateLoginToken")]
    public async Task<IActionResult> ValidateLoginToken(ValidateLoginTokenDto model)
    {   
        var tokenModel = await SecurityService.ValidateLoginToken(model);

        if (tokenModel == null)
            return NotFound();

        return Ok(tokenModel);
    }

    [HttpPost]
    [Route("RefreshToken")]
    public async Task<IActionResult> RefreshToken(TokenModel refreshToken)
    {
        var resultTokenModel = await SecurityService.RefreshToken(refreshToken);
        if (resultTokenModel == null)
        {
            return NotFound();
        }
        return Ok(resultTokenModel);
    }
}

