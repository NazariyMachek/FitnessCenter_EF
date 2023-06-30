using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Models
{
    [Table("Attendance")]
    public class Attendance
    {
        [Key]
        public Guid AttendanceId { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public Guid ClassId { get; set; }
        [Required]
        public DateTime AttendanceDate { get; set; }
        public Customer Customer { get; set; } = null!;
        public Class Class { get; set; } = null!;
    }
}
