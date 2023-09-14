﻿using BlazorWASMCustomAuth.Security.EntityFramework.Models;
using BlazorWASMCustomAuth.Security.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Data;

namespace BlazorWASMCustomAuth.Security.Infrastructure
{
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
        public async Task<APIResult<List<ApplicationAuthenticationProviderDto>>> ApplicationAuthenticationProvidersGet(int applicationid, int id, int pageNumber, int pageSize, string searchString, string orderBy)
        {
            var result = new APIResult<List<ApplicationAuthenticationProviderDto>>();

            string ordering = "Id";
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                string[] OrderBy = orderBy.Split(',');
                ordering = string.Join(",", OrderBy);
            }
            result.Paging.CurrentPage = pageNumber;
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = 0;
            List<ApplicationAuthenticationProvider> items;
            count = await db.ApplicationAuthenticationProviders.Where(x => x.ApplicationId == applicationid).CountAsync();

            items = await db.ApplicationAuthenticationProviders.Where(x => x.ApplicationId == applicationid).OrderBy(ordering)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                //count = await db.AuthenticationProviders
                //    .Where(m => m.AuthenticationProviderName.Contains(searchString) || m.AuthenticationProviderType.Contains(searchString))
                //    .CountAsync();

                //items = await db.AuthenticationProviders.OrderBy(ordering)
                //    .Where(m => m.AuthenticationProviderName.Contains(searchString) || m.AuthenticationProviderType.Contains(searchString))
                //    .Skip((pageNumber - 1) * pageSize)
                //    .Take(pageSize)
                //    .ToListAsync();
            }
            else if (id != 0)
            {
                //count = await db.AuthenticationProviders
                //    .Where(u => u.Id == id)
                //    .CountAsync();

                //items = await db.AuthenticationProviders.OrderBy(ordering)
                //    .Where(u => u.Id == id)
                //    .ToListAsync();
            }
            else
            {
                //count = await db.ApplicationAuthenticationProviders.Where(x => x.ApplicationId == applicationid).CountAsync();

                //items = await db.ApplicationAuthenticationProviders.Where(x => x.ApplicationId == applicationid).OrderBy(ordering)
                //    .Skip((pageNumber - 1) * pageSize)
                //    .Take(pageSize)
                //    .ToListAsync();
            }
            result.Paging.TotalItems = count;
            result.Result = Mapper.Map<List<ApplicationAuthenticationProvider>, List<ApplicationAuthenticationProviderDto>>(items);
            return result;
        }

        public async Task<ApplicationAuthenticationProvider> ApplicationApplicationAuthenticationProviderGet(int id)
        {
            var applicationAuthenticationProvider = await db.ApplicationAuthenticationProviders.Where(u => u.Id == id).FirstOrDefaultAsync();
            return applicationAuthenticationProvider;
        }
        public async Task<APIResult<string>> ApplicationAuthenticationProvidersUpdate(ApplicationAuthenticationProviderUpdateDto model)
        {
            APIResult<string> result = new APIResult<string>();

            int recordsUpdated = 0;
            var record = await db.ApplicationAuthenticationProviders.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (record.AuthenticationProviderType == "Local")
            {
                result.HasError = true;
                result.Message = "Local Authentication Provider can't be updated";
            }

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
    }
}