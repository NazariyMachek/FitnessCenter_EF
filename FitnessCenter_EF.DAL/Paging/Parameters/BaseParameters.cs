using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Paging.Parameters
{
    public abstract class BaseParameters
    {
        private const int MaxPageSize = 100;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 20;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        public string? OrderBy { get; set; } = default!;
        public string? Fields { get; set; } = default!;
    }
}
