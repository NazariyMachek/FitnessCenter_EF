using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.BLL.DTOs.Equipment
{
    public class UpdateEquipmentDTO
    {
        public Guid EquipmentId { get; set; }
        public string EquipmentName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
