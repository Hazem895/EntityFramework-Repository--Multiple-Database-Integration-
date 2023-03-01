using AutoMapper;
using ProjectEF.Domain.DomainModels;
using ProjectEF.Shared.CommandsModels;
using ProjectEF.Shared.DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEF.Api.MapperHelper
{
    public static class ItemsMapper
    {
        private static MapperConfiguration DtoConfig
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Item, ItemDto>();
                });
            }
        }

        private static MapperConfiguration DomainConfig
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ItemDto, Item>();
                });
            }
        }


        public static Item CreateMapper(this CreateItem CC)
        {
            var CreatedModel = new Item()
            {
                ItemId = Guid.NewGuid(),
                Name = CC.Name,
                Price= CC.Price,
                Qty= CC.Qty,
                CategoryId= CC.CategoryId,
                ImagePath= CC.ImagePath,
            };

            return CreatedModel;
        }
        public static Item UpdateMapper(this UpdateItem CC, Guid Id)
        {
            var UpdatedModel = new Item()
            {
                ItemId = Id,
                Name = CC.Name,
                Price = CC.Price,
                Qty = CC.Qty,
                CategoryId = CC.CategoryId,
                ImagePath = CC.ImagePath,
            };

            return UpdatedModel;
        }

        public static ItemDto ToDto(this Item CC)
        {
            return new Mapper(DtoConfig).Map<ItemDto>(CC); ;
        }

        public static IEnumerable<ItemDto> ToDto(this IEnumerable<Item> CC)
        {
            return new Mapper(DtoConfig).Map<IEnumerable<ItemDto>>(CC); ;
        }

        public static Item ToDomain(this ItemDto CC)
        {
            return new Mapper(DomainConfig).Map<Item>(CC); ;
        }

        public static IEnumerable<Item> ToDomain(this IEnumerable<ItemDto> CC)
        {

            return new Mapper(DomainConfig).Map<IEnumerable<Item>>(CC); ;
        }
    }
}
