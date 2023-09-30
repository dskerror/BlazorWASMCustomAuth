﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using BlazorWASMCustomAuth.Security.Shared;
using BlazorWASMCustomAuth.Security.Shared.ActionDtos;

namespace BlazorWASMCustomAuth.Client.Pages;
public partial class EmailConfirm
{
    [CascadingParameter] private Task<AuthenticationState> authenticationState { get; set; }
    [Parameter] public string emailConfirmCode { get; set; }
    private EmailConfirmCodeDto model { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        model = new EmailConfirmCodeDto() { EmailConfirmCode = emailConfirmCode };
        var result = await securityService.EmailConfirmAsync(model);

        if (result)
        {
            Snackbar.Add("Email confirmed", Severity.Success);
            _navigationManager.NavigateTo("/login");
        }
        else
            Snackbar.Add("Error.", Severity.Error);
    }
}