﻿using BlazorWASMCustomAuth.Security.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using BlazorWASMCustomAuth.Client.Services;

namespace BlazorWASMCustomAuth.Client.Components;
public partial class ApplicationPermissions
{
    [CascadingParameter] private Task<AuthenticationState> authenticationState { get; set; }
    public List<ApplicationPermissionGridDto> applicationPermissions { get; set; }
    [Parameter] public int ApplicationId { get; set; }

    private MudTable<ApplicationPermissionDto> _table;
    private IEnumerable<ApplicationPermissionDto> _pagedData;
    private bool _loaded;
    private int _totalItems;
    private int _currentPage;
    private string _searchString = "";
    private bool _AccessApplicationPermissionsView;
    private bool _AccessApplicationPermissionsEdit;
    private bool _AccessApplicationPermissionsCreate;

    protected override async Task OnInitializedAsync()
    {
        var state = await authenticationState;
        SetPermissions(state);

        if (!_AccessApplicationPermissionsView)
            _navigationManager.NavigateTo("/noaccess");
    }
    private void SetPermissions(AuthenticationState state)
    {
        _AccessApplicationPermissionsView = securityService.HasPermission(state.User, Access.ApplicationPermissions.View);
        _AccessApplicationPermissionsEdit = securityService.HasPermission(state.User, Access.ApplicationPermissions.Edit);
        _AccessApplicationPermissionsCreate = securityService.HasPermission(state.User, Access.ApplicationPermissions.Create);
    }

    private async Task LoadData(int pageNumber, int pageSize, TableState state)
    {
        var request = new ApplicationPagedRequest { PageSize = pageSize, PageNumber = pageNumber + 1, SearchString = _searchString, Orderby = state.ToPagedRequestString(), ApplicationId = ApplicationId };
        var response = await securityService.ApplicationPermissionsGetAsync(request);
        if (!response.HasError)
        {
            _totalItems = response.Paging.TotalItems;
            _currentPage = response.Paging.CurrentPage;
            _pagedData = response.Result;
        }
        else
        {
            Snackbar.Add(response.Message, Severity.Error);
        }
    }

    private void CreateApplicationPermission()
    {
        _navigationManager.NavigateTo($"/ApplicationPermissionCreate/{ApplicationId}");
    }

    private void ViewApplicationPermission(int id)
    {
        _navigationManager.NavigateTo($"/ApplicationPermissionViewEdit/{ApplicationId}/{id}");
    }

    private async Task<TableData<ApplicationPermissionDto>> ServerReload(TableState state)
    {
        await LoadData(state.Page, state.PageSize, state);
        _loaded = true;
        base.StateHasChanged();
        return new TableData<ApplicationPermissionDto> { TotalItems = _totalItems, Items = _pagedData };
    }


    private void OnSearch(string text)
    {
        _searchString = text;
        _table.ReloadServerData();
    }
}
