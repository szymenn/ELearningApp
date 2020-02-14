using AutoMapper;
using ELearningApp.Core.Dtos.ApiModels.Auth;
using ELearningApp.Core.Dtos.InputModels.Auth;
using ELearningApp.Core.Entities.Auth;
using Microsoft.AspNetCore.Identity;

namespace ELearningApp.Api.MapperConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IdentityUser, UserApiModel>();
            CreateMap<RegisterInputModel, User>();
            CreateMap<LoginInputModel, User>();
        }
    }
}