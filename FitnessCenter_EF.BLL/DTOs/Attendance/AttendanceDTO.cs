using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.BLL.DTOs.Attendance
{
    public class AttendanceDTO
    {
        public Guid AttendanceId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime AttendanceDate { get; set; }
        public string ClassName { get; set; } = string.Empty;
    }
}
