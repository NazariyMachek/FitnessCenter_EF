using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.Booking;
using FitnessCenter_EF.DAL.Paging.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter_EF.API.Controllers
{
    [Route("ef/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public BookingController(IBookingService BookingService)
        {
            this.BookingService = BookingService;
        }
        private readonly IBookingService BookingService;

        [HttpGet]
        public async Task<ActionResult> GetAllBookingAsync([FromQuery] BookingParameters parameters)
        {
            try
            {
                var list = await BookingService.GetAllAsync(parameters);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BookingDTO>> GetBookingByIdAsync(Guid id)
        {
            try
            {
                var entity = await BookingService.GetAsync(id);
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
        public async Task<ActionResult<Guid>> AddBookingAsync(CreateBookingDTO newEntity)
        {
            try
            {
                var id = await BookingService.CreateAsync(newEntity);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateBookingAsync(UpdateBookingDTO updateEntity)
        {
            try
            {
                await BookingService.UpdateAsync(updateEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteBookingAsync(Guid id)
        {
            try
            {
                await BookingService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
