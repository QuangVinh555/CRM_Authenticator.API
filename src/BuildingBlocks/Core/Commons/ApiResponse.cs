using Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commons
{
    public class ApiResponse
    {
        public int Code { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string DeveloperMessage { get; set; }
        public object Data { get; set; }
    }
    public class ApiSuccessResponse<T>
    {
        public int Code { get; set; } = 200;
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public T Data { get; set; }
        public PagingResponse Paging { get; set; } = new PagingResponse();
    }
}
