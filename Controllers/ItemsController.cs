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
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            return (await repository.GetItemsAsync()).Select(i => i.AsDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item = await repository.GetItemAsync(id);

            if (item is null)
                return NotFound();

            var itemDto = item.AsDto();

            return Ok(itemDto);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostItemAsync([FromBody]CreateItemDto dto)
        {
            var item = dto.AsItem();
            await repository.AddItemAsync(item);
            return CreatedAtAction(nameof(GetItemAsync), new {id = item.Id}, item.AsDto());
            //1 par -> jaka funkcja dostane info o stworzonym elemencie, id elementu, wlasciwy obiekt do zwrocenia
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync([FromBody] UpdateItemDto dto, Guid id)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null)
                return NotFound();

            Item updatingItem = existingItem with
            {
                Name = dto.Name,
                Price = dto.Price
            };

            await repository.UpdateItemAsync(updatingItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            await repository.RemoveItemAsync(id);
            return Ok();
        }
    }
}
