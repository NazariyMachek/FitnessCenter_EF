using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.BLL.DTOs.Class
{
    public class CreateClassDTO
    {
        public string ClassName { get; set; } = string.Empty;
        public Guid InstructorId { get; set; }
        public string Schedule { get; set; } = string.Empty;
        public int MaxCapacity { get; set; }
    }
}
