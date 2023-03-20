using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TutorialNET5WebAPI.Helpers;
using TutorialNET5WebAPI.Models;
using TutorialNET5WebAPI.Models.Dtos;
using TutorialNET5WebAPI.Repositories;
using TutorialNET5WebAPI.Repositories.interfaces;

namespace TutorialNET5WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository repository;

        public ItemsController(IItemRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            return repository.GetItems().Select(i => i.AsDto());
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
                return NotFound();

            var itemDto = item.AsDto();

            return Ok(itemDto);
        }

        [HttpPost]
        public ActionResult<ItemDto> PostItem([FromBody]CreateItemDto dto)
        {
            var item = dto.AsItem();
            repository.AddItem(item);
            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
            //1 par -> jaka funkcja dostane info o stworzonym elemencie, id elementu, wlasciwy obiekt do zwrocenia
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem([FromBody] UpdateItemDto dto, Guid id)
        {
            var existingItem = repository.GetItem(id);

            if (existingItem is null)
                return NotFound();

            Item updatingItem = existingItem with
            {
                Name = dto.Name,
                Price = dto.Price
            };

            repository.UpdateItem(updatingItem, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem([FromQuery] Guid id)
        {
            repository.RemoveItem(id);
            return Ok();
        }
    }
}
