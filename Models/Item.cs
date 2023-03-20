using System;

namespace TutorialNET5WebAPI.Models
{
    public record Item
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

    }
}
