using Microsoft.AspNetCore.Mvc;
using CatlogApi.Repository;
using CatlogApi.Dtos;
using CatlogApi.Models;

namespace CatlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController :ControllerBase
    {
        private  readonly IDiscountRepository  _repository;    

        public DiscountController(IDiscountRepository repository,DiscountDto context)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<DiscountDto>> GetDiscounts()
        {
            var items = (await _repository.GetDiscounts()).Select(item => item.AsDiscountDto());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiscountDto>> getDiscount(int id)
        {
            var  discount = await _repository.GetDiscount(id);
            if(discount != null)
                return Ok(discount.AsDiscountDto());
            else

                return NotFound("there is no item with this id");
            
        }

        [HttpPost]
        public ActionResult<DiscountDto> CreateItem(CreateItemDto itemDto)
        {
           Discount item = new()
            {
                 name = itemDto.Name ?? string.Empty,
            };
           _repository.CreateDiscount(item);
           return CreatedAtAction(nameof(getDiscount), new {id = item.Id} ,item.AsDiscountDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDiscount(int id,DiscountDto discount)
        {
            var existingDiscount = await _repository.GetDiscount(id);
            if(existingDiscount == null)
                return NotFound();

            Discount updatedDiscount = existingDiscount with 
            {
                name = discount.name ?? string.Empty,
                amount = discount.amount
            };
            await _repository.UpdateDiscount(updatedDiscount);
            return NoContent();
        }
        
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleleDiscount(int id)
        {
            var existingDiscount = await _repository.GetDiscount(id);
            if(existingDiscount == null)
                return NotFound();
            await _repository.DeleteDiscount(existingDiscount);
            return NoContent();                          
        }
    }
}
