using Microsoft.AspNetCore.Mvc;
using CatlogApi.Repository;
using CatlogApi.Dtos;
using CatlogApi.Models;

namespace CatlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController:ControllerBase
    {
        private  readonly IItemRepository  _repository;    

        public ItemController(IItemRepository repository,ItemContext context)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItems()
        {
            var items = (await _repository.GetItems()).Select(item => item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> getItem(int id)
        {
            var  item = await _repository.GetItem(id);
            if(item != null)
                return Ok(item.AsDto());
            else
                return NotFound("there is no item with this id");
            
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
           Item item = new()
            {
                Name = itemDto.Name ?? string.Empty,
                Price = itemDto.Price,
                DateCreated = DateTime.UtcNow
            };

           _repository.CreateItem(item);
           return CreatedAtAction(nameof(getItem), new {id = item.Id} ,item.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(int id,UpdateItemDto itemDto)
        {
            var existingItem = await _repository.GetItem(id);
            if(existingItem == null)
                return NotFound();

            Item updatedItem = existingItem with 
            {
                Name = itemDto.name ?? string.Empty,
                Price = itemDto.Price
            };
            await _repository.UpdateItem(updatedItem);
            return NoContent();
        }
        
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleleItem(int id)
        {
            var existingItem = await _repository.GetItem(id);
            if(existingItem == null)
                return NotFound();
            await _repository.DeleteItem(existingItem);
            return NoContent();                          
        }
    }
}
    
