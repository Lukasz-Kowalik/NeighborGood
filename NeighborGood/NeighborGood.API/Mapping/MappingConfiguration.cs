using AutoMapper;
using NeighborGood.API.DTOs.Responses;
using NeighborGood.Models.Entity;

namespace NeighborGood.API.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration(string profileName) : base(profileName)
        {
            CreateMap<User, UserResponse>();
        }
    }
}