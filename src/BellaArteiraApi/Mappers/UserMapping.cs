using AutoMapper;

using BellaArteira.Api.Models;
using BellaArteira.Core.Entities;

namespace BellaArteira.Api.Mappers
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<UserModel, User>().ReverseMap();
        }
    }
}
