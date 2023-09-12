﻿using AutoMapper;
using BlazorWASMCustomAuth.Security.EntityFramework.Models;

namespace BlazorWASMCustomAuth.Security.Shared;
public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        //ActionDtos
        CreateMap<ApplicationCreateDto, Application>().ReverseMap();
        CreateMap<ApplicationUpdateDto, Application>().ReverseMap();
        CreateMap<AuthenticationProviderMappingCreateDto, AuthenticationProvider>().ReverseMap();
        CreateMap<AuthenticationProviderMappingUpdateDto, AuthenticationProvider>().ReverseMap();
        CreateMap<PermissionCreateDto, ApplicationPermission>().ReverseMap();
        CreateMap<PermissionUpdateDto, ApplicationPermission>().ReverseMap();
        CreateMap<RolePermissionChangeDto, ApplicationRolePermission>().ReverseMap();        
        CreateMap<RoleCreateDto, ApplicationRole>().ReverseMap();
        CreateMap<RoleUpdateDto, ApplicationRole>().ReverseMap();
        CreateMap<UserAuthenticationProviderCreateDto, UserAuthenticationProviderMapping>().ReverseMap();
        CreateMap<UserAuthenticationProviderUpdateDto, UserAuthenticationProviderMapping>().ReverseMap();
        CreateMap<UserPermissionChangeDto, UserPermission>().ReverseMap();
        CreateMap<UserCreateDto, User>().ReverseMap();
        CreateMap<UserCreateDto, UserRegisterDto>().ReverseMap();
        CreateMap<UserRoleChangeDto, UserRole>().ReverseMap();

        //.ForMember(dest => dest.ConfirmEmail,
        //           opt => opt.MapFrom(src => src.Email));
        //CreateMap<User, UserCreateDto>();

        //CreateMap<User, User>().ReverseMap().ForMember(dest => dest.Username, act => act.Ignore());

        //ModelDtos
        CreateMap<ApplicationDto, Application>().ReverseMap();
        CreateMap<AuthenticationProviderDto, AuthenticationProvider>().ReverseMap();
        CreateMap<ApplicationPermissionDto, ApplicationPermission>().ReverseMap();
        CreateMap<RolePermissionGridDto, ApplicationPermission>().ReverseMap();
        CreateMap<ApplicationRoleDto, ApplicationRole>().ReverseMap();
        CreateMap<ApplicationRolePermissionDto, ApplicationRolePermission>().ReverseMap();
        CreateMap<UserAuthenticationProviderMappingDto, UserAuthenticationProviderMapping>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();        
        CreateMap<UserLogDto, UserLog>().ReverseMap();
        CreateMap<UserPasswordDto, UserPassword>().ReverseMap();
        CreateMap<UserPermissionDto, UserPermission>().ReverseMap();
        CreateMap<UserRoleDto, UserRole>().ReverseMap();
        CreateMap<UserRoleGridDto, ApplicationRole>().ReverseMap();
        CreateMap<UserPermissionGridDto, ApplicationPermission>().ReverseMap();

        CreateMap<UserTokenDto, UserToken>().ReverseMap();
    }  
}
