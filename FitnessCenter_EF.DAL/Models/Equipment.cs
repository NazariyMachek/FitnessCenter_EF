using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Models
{
    [Table("Equipment")]
    public class Equipment
    {
        [Key]
        public Guid EquipmentId { get; set; }
        [Required]
        [MaxLength(100)]
        public string EquipmentName { get; set; } = string.Empty;
        [Required]
        public int Quantity { get; set; }
        public ICollection<EquipmentClass> EquipmentClass { get; set; } = default!;
    }
}
