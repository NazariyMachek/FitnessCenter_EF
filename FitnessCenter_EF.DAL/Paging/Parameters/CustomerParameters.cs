using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Paging.Parameters
{
    public class CustomerParameters : BaseParameters
    {
        public CustomerParameters()
        {
            OrderBy = "CustomerId";
        }
    }
}
