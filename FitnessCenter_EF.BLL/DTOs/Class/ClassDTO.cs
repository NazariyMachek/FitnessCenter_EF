using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.BLL.DTOs.Class
{
    public class ClassDTO
    {
        public Guid ClassId { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public string InstructorName { get; set; } = string.Empty;
        public string Schedule { get; set; } = string.Empty;
    }
}
