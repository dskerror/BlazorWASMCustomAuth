﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using BlazorWASMCustomAuth.Security.Shared;

namespace BlazorWASMCustomAuth.Client.Pages;
public partial class ApplicationRoleCreate
{
    [Parameter] public int ApplicationId { get; set; }
    [CascadingParameter] private Task<AuthenticationState> authenticationState { get; set; }
    private ApplicationRoleCreateDto model = new ApplicationRoleCreateDto();
    private bool _AccessApplicationRolesCreate;
    private List<BreadcrumbItem> _breadcrumbs;

    protected override async Task OnInitializedAsync()
    {
        var state = await authenticationState;
        SetPermissions(state);

        if (!_AccessApplicationRolesCreate)
            _navigationManager.NavigateTo("/noaccess");

        _breadcrumbs = new List<BreadcrumbItem>
        {
            new BreadcrumbItem("Applications", href: "Applications"),
            new BreadcrumbItem("Applications View/Edit", href: $"ApplicationViewEdit/{ ApplicationId }"),
            new BreadcrumbItem("Application Role Create", href: null, disabled: true)
        };
    }

    private void SetPermissions(AuthenticationState state)
    {
        _AccessApplicationRolesCreate = securityService.HasPermission(state.User, Access.ApplicationRoles.Create);
    }

    private async Task Create()
    {
        model.ApplicationId = ApplicationId;
        var result = await securityService.ApplicationRoleCreateAsync(model);

        if (result != null)
            if (result.HasError)
                Snackbar.Add(result.Message, Severity.Error);
            else
            {
                Snackbar.Add(result.Message, Severity.Success);
                _navigationManager.NavigateTo($"/ApplicationRoleViewEdit/{ApplicationId}/{result.Result.Id}");
            }
        else
            Snackbar.Add("An Unknown Error Has Occured", Severity.Error);

    }
}
