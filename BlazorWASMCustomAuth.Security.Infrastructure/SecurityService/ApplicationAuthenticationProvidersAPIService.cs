﻿using BlazorWASMCustomAuth.Security.EntityFramework.Models;
using BlazorWASMCustomAuth.Security.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System;

namespace BlazorWASMCustomAuth.Security.Infrastructure;
public partial class SecurityService
{
    public async Task<APIResult<ApplicationAuthenticationProviderDto>> ApplicationAuthenticationProvidersCreate(ApplicationAuthenticationProviderCreateDto model)
    {
        APIResult<ApplicationAuthenticationProviderDto> result = new APIResult<ApplicationAuthenticationProviderDto>();
        int recordsCreated = 0;

        var record = new ApplicationAuthenticationProvider();
        Mapper.Map(model, record);

        db.ApplicationAuthenticationProviders.Add(record);

        try
        {
            recordsCreated = await db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            result.HasError = true;
            result.Message = ex.InnerException.Message;
        }

        if (recordsCreated == 1)
        {
            result.Result = Mapper.Map(record, result.Result);
            result.Message = "Record Created";
        }

        return result;
    }
    public async Task<APIResult<List<ApplicationAuthenticationProviderDto>>> ApplicationAuthenticationProvidersGet(int ApplicationId, int Id, int PageNumber, int PageSize, string SearchString, string Orderby)
    {
        var result = new APIResult<List<ApplicationAuthenticationProviderDto>>();

        string ordering = "Id";
        if (!string.IsNullOrWhiteSpace(Orderby))
        {
            string[] OrderBy = Orderby.Split(',');
            ordering = string.Join(",", OrderBy);
        }
        result.Paging.CurrentPage = PageNumber;
        PageNumber = PageNumber == 0 ? 1 : PageNumber;
        PageSize = PageSize == 0 ? 10 : PageSize;
        int count = 0;
        List<ApplicationAuthenticationProvider> items;
        if (!string.IsNullOrWhiteSpace(SearchString))
        {
            count = await db.ApplicationAuthenticationProviders
                .Where(m => m.Name.Contains(SearchString))
                .CountAsync();

            items = await db.ApplicationAuthenticationProviders.OrderBy(ordering)
                .Where(m => m.Name.Contains(SearchString))
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }
        else if (Id != 0)
        {
            count = await db.ApplicationAuthenticationProviders
                .Where(u => u.Id == Id)
                .CountAsync();

            items = await db.ApplicationAuthenticationProviders.OrderBy(ordering)
                .Where(u => u.Id == Id)
                .ToListAsync();
        }
        else if (PageNumber == -1)
        {
            count = await db.ApplicationAuthenticationProviders.Where(u => u.ApplicationId == ApplicationId).CountAsync();
            items = await db.ApplicationAuthenticationProviders.Where(u => u.ApplicationId == ApplicationId).ToListAsync();
        }
        else
        {
            count = await db.ApplicationAuthenticationProviders.Where(u => u.ApplicationId == ApplicationId).CountAsync();
            items = await db.ApplicationAuthenticationProviders.Where(u => u.ApplicationId == ApplicationId).OrderBy(ordering)
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }
        result.Paging.TotalItems = count;
        result.Result = Mapper.Map<List<ApplicationAuthenticationProvider>, List<ApplicationAuthenticationProviderDto>>(items);
        return result;
    }
    public async Task<ApplicationAuthenticationProvider> ApplicationAuthenticationProviderGet(Guid ApplicationAuthenticationProviderGUID)
    {
        if (ApplicationAuthenticationProviderGUID == Guid.Empty)
        {
            var applicationAuthenticationProvider = await db.ApplicationAuthenticationProviders.Where(u => u.Id == 1).Include(x => x.Application).FirstOrDefaultAsync();
            return applicationAuthenticationProvider;
        }
        else
        {
            var applicationAuthenticationProvider = await db.ApplicationAuthenticationProviders.Where(u => u.ApplicationAuthenticationProviderGuid == ApplicationAuthenticationProviderGUID).Include(x => x.Application).FirstOrDefaultAsync();
            return applicationAuthenticationProvider;
        }
    }
    public async Task<APIResult<string>> ApplicationAuthenticationProvidersUpdate(ApplicationAuthenticationProviderDto model)
    {
        APIResult<string> result = new APIResult<string>();

        int recordsUpdated = 0;
        var record = await db.ApplicationAuthenticationProviders.FirstOrDefaultAsync(x => x.Id == model.Id);

        if (record != null)
            Mapper.Map(model, record);

        try
        {
            recordsUpdated = await db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            result.HasError = true;
            result.Message = ex.InnerException.Message;
        }

        if (recordsUpdated == 1)
            result.Message = "Record Updated";

        return result;
    }
    public async Task<APIResult<string>> ApplicationAuthenticationProvidersDelete(int id)
    {
        APIResult<string> result = new APIResult<string>();
        int recordsDeleted = 0;

        var record = await db.ApplicationAuthenticationProviders.FirstOrDefaultAsync(x => x.Id == id);

        try
        {
            if (record.AuthenticationProviderType == "Local")
            {
                result.HasError = true;
                result.Message = "Local Authentication Provider can't be deleted";
            }
            else
            {
                db.Remove(record);
                recordsDeleted = await db.SaveChangesAsync();
            }

        }
        catch (Exception ex)
        {
            result.HasError = true;
            result.Message = ex.Message;
        }

        result.Result = recordsDeleted.ToString();

        return result;
    }

    public async Task<APIResult<string>> ApplicationAuthenticationProviderDisableEnabled(int id)
    {
        APIResult<string> result = new APIResult<string>();
        int recordsUpdated = 0;

        var record = await db.ApplicationAuthenticationProviders.FirstOrDefaultAsync(x => x.Id == id);

        try
        {
            if (record.AuthenticationProviderType == "Local")
            {
                result.HasError = true;
                result.Message = "Local Authentication Provider can't be disabled";
            }
            else
            {
                if (record.ApplicationAuthenticationProviderDisabled == true)
                    record.ApplicationAuthenticationProviderDisabled = false;
                else
                    record.ApplicationAuthenticationProviderDisabled = true;
                recordsUpdated = await db.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            result.HasError = true;
            result.Message = ex.Message;
        }

        result.Result = recordsUpdated.ToString();

        return result;
    }
}
