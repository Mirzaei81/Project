using Microsoft.AspNetCore.Mvc;
using ApiDotNet.Repository;
using ApiDotNet.Dtos;
using ApiDotNet.Models;

namespace ApiDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController :ControllerBase
    {
        private readonly IItemRepository _repository ;

        public ItemController(IItemRepository repository)
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
        public ActionResult<ItemDto> getItem(int id)
        {
            var  item = _repository.GetItem(id);
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
                name = itemDto.name,
                Price = itemDto.Price,
                DateCreated = DateTime.UtcNow
            };
           _repository.CreateItem(item);
           return CreatedAtAction(nameof(getItem), new {id = item.Id} ,item.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id,UpdateItemDto itemDto)
        {
            var existingItem = _repository.GetItem(id);
            if(existingItem == null)
                return NotFound();

            Item updatedItem = existingItem with 
            {
                name = itemDto.name,
                Price = itemDto.Price
            };
            _repository.UpdateItem(updatedItem);
            return NoContent();
        }
        
        
        [HttpDelete("{id}")]
        public ActionResult DeleleItem(int id)
        {
            var existingItem = _repository.GetItem(id);
            if(existingItem == null)
                return NotFound();
            _repository.DeleteItem(id);
            return NoContent();                          
        }
    }
}
    
