﻿using AutoMapper;
using DsK.AuthServer.Security.EntityFramework.Models;

namespace DsK.AuthServer.Security.Shared;
public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        //ActionDtos
        CreateMap<ApplicationCreateDto, Application>().ReverseMap();
        CreateMap<ApplicationUpdateDto, Application>().ReverseMap();
        CreateMap<ApplicationAuthenticationProviderCreateDto, ApplicationAuthenticationProvider>().ReverseMap();
        CreateMap<ApplicationAuthenticationProviderUpdateDto, ApplicationAuthenticationProvider>().ReverseMap();
        CreateMap<ApplicationAuthenticationProviderValidateDto, ApplicationAuthenticationProvider>().ReverseMap();
        CreateMap<ApplicationPermissionCreateDto, ApplicationPermission>().ReverseMap();
        CreateMap<ApplicationPermissionUpdateDto, ApplicationPermission>().ReverseMap();
        CreateMap<ApplicationRolePermissionChangeDto, ApplicationRolePermission>().ReverseMap();
        CreateMap<ApplicationRoleCreateDto, ApplicationRole>().ReverseMap();
        CreateMap<ApplicationRoleUpdateDto, ApplicationRole>().ReverseMap();        
        CreateMap<ApplicationAuthenticationProviderUserMappingUpdateDto, ApplicationAuthenticationProviderUserMapping>().ReverseMap();
        CreateMap<UserPermissionChangeDto, UserPermission>().ReverseMap();
        CreateMap<UserCreateDto, User>().ReverseMap();
        CreateMap<MyProfileUpdateDto, User>().ReverseMap();
        CreateMap<UserCreateDto, UserRegisterDto>().ReverseMap();
        CreateMap<UserRoleChangeDto, UserRole>().ReverseMap();
        CreateMap<ApplicationUserChangeDto, ApplicationUser>().ReverseMap();

        //.ForMember(dest => dest.ConfirmEmail,
        //           opt => opt.MapFrom(src => src.Email));
        //CreateMap<User, UserCreateDto>();

        //CreateMap<User, User>().ReverseMap().ForMember(dest => dest.Username, act => act.Ignore());

        //ModelDtos
        CreateMap<ApplicationUserDto, ApplicationUser>().ReverseMap()
            .ForMember(dest => dest.Application, opt => opt.MapFrom(src => src.Application));
        CreateMap<ApplicationDto, Application>().ReverseMap();
        CreateMap<ApplicationAuthenticationProviderDto, ApplicationAuthenticationProvider>().ReverseMap();
        CreateMap<ApplicationPermissionDto, ApplicationPermission>().ReverseMap();
        CreateMap<ApplicationRolePermissionGridDto, ApplicationPermission>().ReverseMap();
        CreateMap<ApplicationRoleDto, ApplicationRole>().ReverseMap();
        CreateMap<ApplicationRolePermissionDto, ApplicationRolePermission>().ReverseMap();
        CreateMap<ApplicationAuthenticationProviderUserMappingDto, ApplicationAuthenticationProviderUserMapping>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<UserLogDto, UserLog>().ReverseMap();
        CreateMap<UserPermissionDto, UserPermission>().ReverseMap();
        CreateMap<UserRoleDto, UserRole>().ReverseMap();
        //CreateMap<UserRoleGridDto, ApplicationRole>().ReverseMap();
        //CreateMap<UserPermissionGridDto, ApplicationPermission>().ReverseMap();

        CreateMap<ApplicationAuthenticationProviderUserTokenDto, ApplicationAuthenticationProviderUserToken>().ReverseMap();
    }
}
