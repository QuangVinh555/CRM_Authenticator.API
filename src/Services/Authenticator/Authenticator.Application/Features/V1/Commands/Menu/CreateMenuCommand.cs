using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator.Application.Features.V1.Commands.Menu
{
    public class CreateMenuCommand : IRequest<bool>
    {
        public string MenuCode { get; set; }
        public string MenuName { get; set; }
        public string Icon { get; set; }
        public string OrderIndex { get; set; }
    }
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, bool>
    {
        public Task<bool> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {

            throw new NotImplementedException();
        }
    }
}
