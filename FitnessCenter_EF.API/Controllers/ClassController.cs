using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.Class;
using FitnessCenter_EF.DAL.Paging.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter_EF.API.Controllers
{
    [Route("ef/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        public ClassController(IClassService ClassService)
        {
            this.ClassService = ClassService;
        }
        private readonly IClassService ClassService;

        [HttpGet]
        public async Task<ActionResult> GetAllClassAsync([FromQuery] ClassParameters parameters)
        {
            try
            {
                var list = await ClassService.GetAllAsync(parameters);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClassDTO>> GetClassByIdAsync(Guid id)
        {
            try
            {
                var entity = await ClassService.GetAsync(id);
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
        public async Task<ActionResult<Guid>> AddClassAsync(CreateClassDTO newEntity)
        {
            try
            {
                var id = await ClassService.CreateAsync(newEntity);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateClassAsync(UpdateClassDTO updateEntity)
        {
            try
            {
                await ClassService.UpdateAsync(updateEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteClassAsync(Guid id)
        {
            try
            {
                await ClassService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
