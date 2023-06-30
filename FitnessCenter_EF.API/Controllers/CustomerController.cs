using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.Customer;
using FitnessCenter_EF.DAL.Paging.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter_EF.API.Controllers
{
    [Route("ef/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerController(ICustomerService CustomerService)
        {
            this.CustomerService = CustomerService;
        }
        private readonly ICustomerService CustomerService;

        [HttpGet]
        public async Task<ActionResult> GetAllCustomerAsync([FromQuery] CustomerParameters parameters)
        {
            try
            {
                var list = await CustomerService.GetAllAsync(parameters);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerByIdAsync(Guid id)
        {
            try
            {
                var entity = await CustomerService.GetAsync(id);
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
        public async Task<ActionResult<Guid>> AddCustomerAsync(CreateCustomerDTO newEntity)
        {
            try
            {
                var id = await CustomerService.CreateAsync(newEntity);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCustomerAsync(UpdateCustomerDTO updateEntity)
        {
            try
            {
                await CustomerService.UpdateAsync(updateEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteCustomerAsync(Guid id)
        {
            try
            {
                await CustomerService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
