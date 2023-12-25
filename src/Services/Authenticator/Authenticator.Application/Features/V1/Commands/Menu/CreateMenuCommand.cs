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

    }
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, bool>
    {
        public Task<bool> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
