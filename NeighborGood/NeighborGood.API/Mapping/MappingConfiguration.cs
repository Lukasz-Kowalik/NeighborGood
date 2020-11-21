using AutoMapper;
using NeighborGood.API.DTOs.Requests;
using NeighborGood.Models.Entity;

namespace NeighborGood.API.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<RegisterUserRequest, User>();
        }
    }
}