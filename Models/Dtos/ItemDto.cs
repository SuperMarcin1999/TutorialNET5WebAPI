using System;

namespace TutorialNET5WebAPI.Models.Dtos
{
    public class ItemDto
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
