using AutoMapper;
using NeighborGood.API.DTOs.Responses;
using NeighborGood.Models.Entity;

namespace NeighborGood.API.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration(string profileName) : base(profileName)
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserResponse>();
            });
        }
    }
}