using System;
using TutorialNET5WebAPI.Models;
using TutorialNET5WebAPI.Models.Dtos;

namespace TutorialNET5WebAPI.Helpers
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
        public static Item AsItem(this CreateItemDto dto)
        {
            return new Item()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Price = dto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
        }
        public static Item AsItem(this ItemDto dto)
        {
            return new Item()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Price = dto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
        }
    }
}
