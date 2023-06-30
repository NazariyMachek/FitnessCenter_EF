using FitnessCenter_EF.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace FitnessCenter_EF.DAL.Helpers
{
    public class SortHelper<T> : ISortHelper<T>
    {
        public IQueryable<T> ApplySort(IQueryable<T> entities, string? orderByString)
        {
            if (!entities.Any() || string.IsNullOrWhiteSpace(orderByString))
            {
                return entities;
            }
            var orderParams = orderByString.Trim().Split(',');
            var propertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var strBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                {
                    continue;
                }
                var propFromQueryName = param.Trim().Split(" ")[0];
                var objProperty = propertyInfo.FirstOrDefault(pi => 
                    pi.Name.Equals(propFromQueryName, StringComparison.InvariantCultureIgnoreCase));
                if (objProperty == null)
                {
                    continue;
                }
                var sortOrder = param.EndsWith("desc") ? "descending" : "ascending";
                strBuilder.Append($"{objProperty.Name} {sortOrder}, ");
            }
            var orderQuery = strBuilder.ToString().TrimEnd(',', ' ');
            return entities.OrderBy(orderQuery);
        }
    }
}
