using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Models
{
    [Table("Classes")]
    public class Class
    {
        [Key]
        public Guid ClassId { get; set; }
        [Required]
        [MaxLength(60)]
        public string ClassName { get; set; } = string.Empty;
        [Required]
        public Guid InstructorId { get; set; }
        [Required]
        [MaxLength(300)]
        public string Schedule { get; set; } = string.Empty;
        [Required]
        public int MaxCapacity { get; set; }
        public Instructor Instructor { get; set; } = null!;
        public ICollection<Attendance> Attendances { get; set; } = default!;
        public ICollection<Booking> Bookings { get; set; } = default!;
        public ICollection<EquipmentClass> EquipmentClass { get; set; } = default!;
    }
}
