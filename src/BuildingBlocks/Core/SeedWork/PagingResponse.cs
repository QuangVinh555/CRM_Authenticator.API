using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SeedWork
{
    public class PagingResponse
    {
        public int? ResultsCount { get; set; }
        public int? RecordsTotal { get; set; }
        public int? PagesCount { get; set; }
    }
}
