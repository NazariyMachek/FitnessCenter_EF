using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Models
{
    [Table("EquipmentClass")]
    public class EquipmentClass
    {
        public Guid EquipmentClassId { get; set; }
        public Guid EquipmentId { get; set; }
        public Guid ClassId { get; set; }
        public Equipment Equipment { get; set; } = null!;
        public Class Class { get; set; } = null!;
    }
}
