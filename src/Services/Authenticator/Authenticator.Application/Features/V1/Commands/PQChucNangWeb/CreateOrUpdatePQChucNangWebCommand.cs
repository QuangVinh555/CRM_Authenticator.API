using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator.Application.Features.V1.Commands.PQChucNangWeb
{
    public class CreateOrUpdatePQChucNangWebCommand
    {
        public Guid RoleId { get; set; }
        public List<PageCommand> ListPages { get; set; } = new();
    }

    public class PageCommand
    {
        public Guid PageId { get; set; }
        public List<FunctionCommand> ListFunctions { get; set; } = new();
    }

    public class FunctionCommand
    {
        public Guid FunctionId { get; set; }
    }
}
