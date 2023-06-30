using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.BLL.DTOs.Attendance
{
    public class UpdateAttendanceDTO
    {
        public Guid AttendanceId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ClassId { get; set; }
        public DateTime AttendanceDate { get; set; }
    }
}
