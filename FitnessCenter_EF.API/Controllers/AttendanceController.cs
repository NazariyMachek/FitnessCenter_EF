using FitnessCenter_EF.BLL.Contracts;
using FitnessCenter_EF.BLL.DTOs.Attendance;
using FitnessCenter_EF.DAL.Paging.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter_EF.API.Controllers
{
    [Route("ef/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        public AttendanceController(IAttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;
        }
        private readonly IAttendanceService attendanceService;

        [HttpGet]
        public async Task<ActionResult> GetAllAttendanceAsync([FromQuery]AttendanceParameters parameters)
        {
            try
            {
                var list = await attendanceService.GetAllAsync(parameters);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AttendanceDTO>> GetAttendanceByIdAsync(Guid id)
        {
            try
            {
                var entity = await attendanceService.GetAsync(id);
                if (entity == null)
                {
                    return NotFound();
                }
                else {

                    return Ok(entity);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> AddAttendanceAsync(CreateAttendanceDTO newEntity)
        {
            try
            {
                var id = await attendanceService.CreateAsync(newEntity);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateAttendanceAsync(UpdateAttendanceDTO updateEntity)
        {
            try
            {
                await attendanceService.UpdateAsync(updateEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAttendanceAsync(Guid id)
        {
            try
            {
                await attendanceService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
