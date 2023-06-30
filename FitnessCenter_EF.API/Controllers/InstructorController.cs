using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.Instructor;
using FitnessCenter_EF.DAL.Paging.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter_EF.API.Controllers
{
    [Route("ef/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        public InstructorController(IInstructorService InstructorService)
        {
            this.InstructorService = InstructorService;
        }
        private readonly IInstructorService InstructorService;

        [HttpGet]
        public async Task<ActionResult> GetAllInstructorAsync([FromQuery] InstructorParameters parameters)
        {
            try
            {
                var list = await InstructorService.GetAllAsync(parameters);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<InstructorDTO>> GetInstructorByIdAsync(Guid id)
        {
            try
            {
                var entity = await InstructorService.GetAsync(id);
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
        public async Task<ActionResult<Guid>> AddInstructorAsync(CreateInstructorDTO newEntity)
        {
            try
            {
                var id = await InstructorService.CreateAsync(newEntity);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateInstructorAsync(UpdateInstructorDTO updateEntity)
        {
            try
            {
                await InstructorService.UpdateAsync(updateEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteInstructorAsync(Guid id)
        {
            try
            {
                await InstructorService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
