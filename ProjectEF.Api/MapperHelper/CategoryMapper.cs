using AutoMapper;
using ProjectEF.Domain.DomainModels;
using ProjectEF.Shared.CommandsModels;
using ProjectEF.Shared.DataObjectLayer;
using System.Runtime.CompilerServices;

namespace ProjectEF.Api.MapperHelper
{
    public static class CategoryMapper
    {
        private static MapperConfiguration DtoConfig
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Category, CategoryDto>();
                });
            }
        }

        private static MapperConfiguration DomainConfig
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CategoryDto, Category>();
                });
            }
        }

        public static Category CreateMapper(this CreateCategory CC)
        {
            var CreatedModel = new Category()
            {
                CategoryId = Guid.NewGuid(),
                Name = CC.Name,
            };

            return CreatedModel;
        }
        public static Category UpdateMapper(this UpdateCategory CC, Guid Id)
        {
            var UpdatedModel = new Category()
            {
                CategoryId = Id,
                Name = CC.Name,
            };

            return UpdatedModel;
        }

        public static CategoryDto ToDto(this Category CC)
        {
            return new Mapper(DtoConfig).Map<CategoryDto>(CC); ;
        }

        public static IEnumerable<CategoryDto> ToDto(this IEnumerable<Category> CC)
        {
            return new Mapper(DtoConfig).Map<IEnumerable<CategoryDto>>(CC); ;
        }

        public static Category ToDomain(this CategoryDto CC)
        {
            return new Mapper(DomainConfig).Map<Category>(CC); ;
        }

        public static IEnumerable<Category> ToDomain(this IEnumerable<CategoryDto> CC)
        {

            return new Mapper(DomainConfig).Map<IEnumerable<Category>>(CC); ;
        }
    }
}
