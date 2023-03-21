using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return repository.GetItemsAsync().Select(i => i.AsDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItem(Guid id)
        {
            var item = await repository.GetItemAsync(id);

            if (item is null)
                return NotFound();

            var itemDto = item.AsDto();

            return Ok(itemDto);
        }

        [HttpPost]
        public ActionResult<ItemDto> PostItem([FromBody]CreateItemDto dto)
        {
            var item = dto.AsItem();
            repository.AddItemAsync(item);
            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
            //1 par -> jaka funkcja dostane info o stworzonym elemencie, id elementu, wlasciwy obiekt do zwrocenia
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem([FromBody] UpdateItemDto dto, Guid id)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null)
                return NotFound();

            Item updatingItem = existingItem with
            {
                Name = dto.Name,
                Price = dto.Price
            };

            repository.UpdateItemAsync(updatingItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem([FromQuery] Guid id)
        {
            repository.RemoveItemAsync(id);
            return Ok();
        }
    }
}
