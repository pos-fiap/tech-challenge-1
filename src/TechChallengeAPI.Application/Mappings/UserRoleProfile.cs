using AutoMapper;
using TechChallenge.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Mappings
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRoleDto, IEnumerable<UserRole>>().ConvertUsing<GetFromRoleIds>();
        }
    }
    public class GetFromRoleIds :
             ITypeConverter<UserRoleDto, IEnumerable<UserRole>>
    {
        IEnumerable<UserRole> ITypeConverter<UserRoleDto, IEnumerable<UserRole>>.Convert
            (UserRoleDto source, IEnumerable<UserRole> destination, ResolutionContext context)
        {
            /*first mapp from People, then from Team*/
            foreach (var model in source.RoleIds.Select
                    (e => context.Mapper.Map<UserRole>(e)))
            {
                context.Mapper.Map(source, model);
                yield return model;
            }
        }
    }
}
