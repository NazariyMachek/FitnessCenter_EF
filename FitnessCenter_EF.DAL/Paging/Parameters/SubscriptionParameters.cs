using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Paging.Parameters
{
    public class SubscriptionParameters : BaseParameters
    {
        public decimal MinPrice { get; set; } = 0;
        public decimal MaxPrice { get; set; } = 1000000;
        public bool ValidYPriceRange => MaxPrice > MinPrice;

        public string CustomerName { get; set; } = string.Empty;

        public SubscriptionParameters()
        {
            OrderBy = "SubscriptionId";
        }
    }
}
