using Authentication.Domain.Dto.User;
using Authentication.Domain.Entity;
using AutoMapper;
using System.Collections.Generic;

namespace Authentication.Domain
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<User, ValidateUserResponseDTO>();

            CreateMap<User, GetUserResponseDTO>();

            CreateMap<List<User>, GetUserListResponseDTO>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src));
        }
    }
}
