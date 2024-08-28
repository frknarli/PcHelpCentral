using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace PcHelpCentralApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<SolutionDtoForInsertion, Solution>();
            CreateMap<SolutionDtoForUpdate, Solution>().ReverseMap();
            CreateMap<UserDtoForCreation, IdentityUser>();
            CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();
        }
    }
}
