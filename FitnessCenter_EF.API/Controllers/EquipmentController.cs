using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.Equipment;
using FitnessCenter_EF.DAL.Paging.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter_EF.API.Controllers
{
    [Route("ef/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        public EquipmentController(IEquipmentService EquipmentService)
        {
            this.EquipmentService = EquipmentService;
        }
        private readonly IEquipmentService EquipmentService;

        [HttpGet]
        public async Task<ActionResult> GetAllEquipmentAsync([FromQuery] EquipmentParameters parameters)
        {
            try
            {
                var list = await EquipmentService.GetAllAsync(parameters);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EquipmentDTO>> GetEquipmentByIdAsync(Guid id)
        {
            try
            {
                var entity = await EquipmentService.GetAsync(id);
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
        public async Task<ActionResult<Guid>> AddEquipmentAsync(CreateEquipmentDTO newEntity)
        {
            try
            {
                var id = await EquipmentService.CreateAsync(newEntity);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateEquipmentAsync(UpdateEquipmentDTO updateEntity)
        {
            try
            {
                await EquipmentService.UpdateAsync(updateEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteEquipmentAsync(Guid id)
        {
            try
            {
                await EquipmentService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
