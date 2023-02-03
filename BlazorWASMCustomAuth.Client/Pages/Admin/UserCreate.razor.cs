﻿using BlazorWASMCustomAuth.Security.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorWASMCustomAuth.Client.Pages.Admin
{
    public partial class UserCreate
    {
        [CascadingParameter] private Task<AuthenticationState> authenticationState { get; set; }

        private UserCreateDto model = new UserCreateDto();

        private async Task Create()
        {
            var result = await securityService.UserCreateAsync(model);

            if (result != null)
                if (result.HasError)
                    Snackbar.Add(result.Message, Severity.Error);
                else
                {
                    Snackbar.Add(result.Message, Severity.Success);
                    _navigationManager.NavigateTo($"/admin/userviewedit/{result.Result.Id}");
                }
            else
                Snackbar.Add("An Unknown Error Has Occured", Severity.Error);

        }
    }
}
