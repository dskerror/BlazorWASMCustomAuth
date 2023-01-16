﻿
using Blazored.LocalStorage;
using BlazorWASMCustomAuth.Client.Security;
using BlazorWASMCustomAuth.PagingSortingFiltering;
using BlazorWASMCustomAuth.Security.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http.Headers;

namespace BlazorWASMCustomAuth.Client.Services
{
	public class SecurityService
	{
		private readonly AuthenticationStateProvider _customAuthenticationProvider;
		private readonly ILocalStorageService _localStorageService;
		private readonly HttpClient _httpClient;
		public SecurityService(ILocalStorageService localStorageService,
			AuthenticationStateProvider customAuthenticationProvider,
			HttpClient httpClient)
		{
			_localStorageService = localStorageService;
			_customAuthenticationProvider = customAuthenticationProvider;
			_httpClient = httpClient;
		}
		public async Task<bool> LoginAsync(UserLoginModel model)
		{
			var response = await _httpClient.PostAsJsonAsync<UserLoginModel>("/api/security/userlogin", model);
			if (!response.IsSuccessStatusCode)
			{
				return false;
			}
			TokenModel tokenModel = await response.Content.ReadFromJsonAsync<TokenModel>() ?? new TokenModel("", "");
			if (tokenModel == null)
			{
				return false;
			}
			await _localStorageService.SetItemAsync("token", tokenModel.Token);
			await _localStorageService.SetItemAsync("refreshToken", tokenModel.RefreshToken);
			((CustomAuthenticationProvider)_customAuthenticationProvider).Notify();
			return true;
		}

        public async Task<bool> UserCreate(UserCreateModel model)
        {
            var response = await _httpClient.PostAsJsonAsync<UserCreateModel>("/api/security/usercreate", model);
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            TokenModel tokenModel = await response.Content.ReadFromJsonAsync<TokenModel>() ?? new TokenModel("", "");
            if (tokenModel == null)
            {
                return false;
            }
            await _localStorageService.SetItemAsync("token", tokenModel.Token);
            await _localStorageService.SetItemAsync("refreshToken", tokenModel.RefreshToken);
            ((CustomAuthenticationProvider)_customAuthenticationProvider).Notify();
            return true;
        }
        public async Task<UsersGetDTO> UsersGet(PagingSortingFilteringRequest request)
        {
			var token = await _localStorageService.GetItemAsync<string>("token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            //return await _httpClient.GetFromJsonAsync<List<string>>("/test/todos");

            var response = await _httpClient.GetAsync("/api/Security/UsersGet");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseAsString = await response.Content.ReadAsStringAsync();

            try
            {
                var responseObject = JsonSerializer.Deserialize<UsersGetDTO>(responseAsString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    ReferenceHandler = ReferenceHandler.Preserve,
                    IncludeFields = true
                });
                return responseObject;
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
                return null;

            }
        }
        public async Task<bool> LogoutAsync()
		{
			await _localStorageService.RemoveItemAsync("token");
			((CustomAuthenticationProvider)_customAuthenticationProvider).Notify();
			return true;
		}
	}
}
