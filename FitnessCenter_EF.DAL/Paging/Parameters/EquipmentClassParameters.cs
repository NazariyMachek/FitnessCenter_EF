using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Paging.Parameters
{
    public class EquipmentClassParameters : BaseParameters
    {
        public EquipmentClassParameters()
        {
            OrderBy = "EquipmentId, ClassId";
        }
    }
}
