using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.Subscription;
using FitnessCenter_EF.DAL.Paging.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter_EF.API.Controllers
{
    [Route("ef/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        public SubscriptionController(ISubscriptionService SubscriptionService)
        {
            this.SubscriptionService = SubscriptionService;
        }
        private readonly ISubscriptionService SubscriptionService;

        [HttpGet]
        public async Task<ActionResult> GetAllSubscriptionAsync([FromQuery] SubscriptionParameters parameters)
        {
            if (!parameters.ValidYPriceRange)
            {
                return BadRequest("Max year cannot be less than min year");
            }
            try
            {
                var list = await SubscriptionService.GetAllAsync(parameters);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SubscriptionDTO>> GetSubscriptionByIdAsync(Guid id)
        {
            try
            {
                var entity = await SubscriptionService.GetAsync(id);
                if (entity == null)
                {
                    return NotFound();
                }
                else
                {

                    return Ok(entity);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> AddSubscriptionAsync(CreateSubscriptionDTO newEntity)
        {
            try
            {
                var id = await SubscriptionService.CreateAsync(newEntity);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateSubscriptionAsync(UpdateSubscriptionDTO updateEntity)
        {
            try
            {
                await SubscriptionService.UpdateAsync(updateEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteSubscriptionAsync(Guid id)
        {
            try
            {
                await SubscriptionService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
