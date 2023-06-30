using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.EquipmentClass;
using FitnessCenter_EF.DAL.Paging.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter_EF.API.Controllers
{
    [Route("ef/[controller]")]
    [ApiController]
    public class EquipmentClassController : ControllerBase
    {
        public EquipmentClassController(IEquipmentClassService EquipmentClassService)
        {
            this.EquipmentClassService = EquipmentClassService;
        }
        private readonly IEquipmentClassService EquipmentClassService;

        [HttpGet]
        public async Task<ActionResult> GetAllEquipmentClassAsync([FromQuery] EquipmentClassParameters parameters)
        {
            try
            {
                var list = await EquipmentClassService.GetAllAsync(parameters);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{EquipmentId:guid}/{ClassId:guid}")]
        public async Task<ActionResult<EquipmentClassDTO>> GetEquipmentClassByIdAsync(Guid EquipmentId, Guid ClassId)
        {
            try
            {
                var entity = await EquipmentClassService.GetAsync(EquipmentId, ClassId);
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
        public async Task<ActionResult<Guid>> AddEquipmentClassAsync(CreateEquipmentClassDTO newEntity)
        {
            try
            {
                var id = await EquipmentClassService.CreateAsync(newEntity);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateEquipmentClassAsync(UpdateEquipmentClassDTO updateEntity)
        {
            try
            {
                await EquipmentClassService.UpdateAsync(updateEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{EquipmentId:guid}/{ClassId:guid}")]
        public async Task<ActionResult> DeleteEquipmentClassAsync(Guid EquipmentId, Guid ClassId)
        {
            try
            {
                await EquipmentClassService.DeleteAsync(EquipmentId, ClassId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
