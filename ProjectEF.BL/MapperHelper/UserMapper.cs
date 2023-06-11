using AutoMapper;
using ProjectEF.Domain.DomainModels;
using ProjectEF.Shared.CommandsModels;
using ProjectEF.Shared.DataObjectLayer;
using System.Runtime.CompilerServices;

namespace ProjectEF.BL.MapperHelper
{
    public static class UserMapper
    {
        private static MapperConfiguration DtoConfig
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserDTO>();
                });
            }
        }

        private static MapperConfiguration DomainConfig
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserDTO, User>();
                });
            }
        }

        //public static User CreateMapper(this CreateCategory CC)
        //{
        //    var CreatedModel = new User()
        //    {
        //        CategoryId = Guid.NewGuid(),
        //        Name = CC.Name,
        //    };

        //    return CreatedModel;
        //}
        //public static User UpdateMapper(this UpdateCategory CC, Guid Id)
        //{
        //    var UpdatedModel = new User()
        //    {
        //        CategoryId = Id,
        //        Name = CC.Name,
        //    };

        //    return UpdatedModel;
        //}

        public static UserDTO ToDto(this User CC)
        {
            return new Mapper(DtoConfig).Map<UserDTO>(CC); ;
        }

        public static IEnumerable<UserDTO> ToDto(this IEnumerable<User> CC)
        {
            return new Mapper(DtoConfig).Map<IEnumerable<UserDTO>>(CC); ;
        }

        public static User ToDomain(this UserDTO CC)
        {
            return new Mapper(DomainConfig).Map<User>(CC); ;
        }

        public static IEnumerable<User> ToDomain(this IEnumerable<UserDTO> CC)
        {

            return new Mapper(DomainConfig).Map<IEnumerable<User>>(CC); ;
        }
    }
}
