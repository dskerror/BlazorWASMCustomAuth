﻿using BlazorWASMCustomAuth.Security.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Microsoft.EntityFrameworkCore.Scaffolding;
using System.Drawing.Printing;
using static MudBlazor.CategoryTypes;
using Microsoft.AspNetCore.Components.Forms;
using System;

namespace BlazorWASMCustomAuth.Client.Pages;
public partial class ApplicationAuthenticationProviderViewEdit
{
    [CascadingParameter] private Task<AuthenticationState> authenticationState { get; set; }
    [Parameter] public int ApplicationId { get; set; }
    [Parameter] public int ApplicationAuthenticationProviderId { get; set; }

    private ApplicationAuthenticationProviderDto model { get; set; }
    private List<ApplicationRoleDto> roleList { get; set; }

    int DefaultApplicationRoleIdValue = 0;

    private bool _loaded;
    private bool _AccessView;
    private bool _AccessEdit;
    private List<BreadcrumbItem> _breadcrumbs;

    protected override async Task OnInitializedAsync()
    {
        var state = await authenticationState;
        SetPermissions(state);

        if (!_AccessView)
            _navigationManager.NavigateTo("/noaccess");
        else
        {
            await LoadData();
            await LoadApplicationRoleData(model.ApplicationId);

            _loaded = true;
        }

        _breadcrumbs = new List<BreadcrumbItem>
        {
            new BreadcrumbItem("Applications", href: "Applications"),
            new BreadcrumbItem("Applications View/Edit", href: $"ApplicationViewEdit/{ ApplicationId }"),
            new BreadcrumbItem("Application Authentication Provider View/Edit", href: null, disabled: true)
        };
    }
    private void SetPermissions(AuthenticationState state)
    {
        _AccessView = securityService.HasPermission(state.User, Access.ApplicationAuthenticationProvider.View);
        _AccessEdit = securityService.HasPermission(state.User, Access.ApplicationAuthenticationProvider.Edit);
    }

    private async Task LoadData()
    {
        var result = await securityService.ApplicationAuthenticationProviderGetAsync(ApplicationAuthenticationProviderId);
        if (result != null)
        { 
            model = result.Result;
            DefaultApplicationRoleIdValue = model.DefaultApplicationRoleId == null ? 0 : (int)model.DefaultApplicationRoleId;
        }
    }

    private async Task LoadApplicationRoleData(int applicationId)
    {
        var NONERole = new ApplicationRoleDto() { Id = 0, RoleName = "NONE" };
        var request = new ApplicationPagedRequest { PageNumber = -1, ApplicationId = applicationId };
        var response = await securityService.ApplicationRolesGetAsync(request);

        if (response != null)
        {
            roleList = response.Result;
            roleList.Insert(0, NONERole);            
        }
        else
        {
            roleList = new List<ApplicationRoleDto>() { NONERole };
        }
    }
    private async Task Edit()
    {
        if (DefaultApplicationRoleIdValue == 0)
            model.DefaultApplicationRoleId = null;
        else
            model.DefaultApplicationRoleId = DefaultApplicationRoleIdValue;

        model.ApplicationId = ApplicationId;
        var result = await securityService.ApplicationAuthenticationProviderEditAsync(model);

        if (result != null)
            if (result.HasError)
                Snackbar.Add(result.Message, Severity.Error);
            else
                Snackbar.Add(result.Message, Severity.Success);
        else
            Snackbar.Add("An Unknown Error Has Occured", Severity.Error);
    }

    private async Task CancelChanges()
    {
        Snackbar.Add("Edit canceled", Severity.Warning);
        await LoadData();
    }
}
