using Infrastructure.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator.Application.Features.V1.Commands.PQChucNangWeb
{
    public class UpdatePQChucNangWebCommand : CreateOrUpdatePQChucNangWebCommand, IRequest<bool>
    {

    }

    public class UpdatePQChucNangWebCommandHandler : IRequestHandler<UpdatePQChucNangWebCommand, bool>
    {
        private readonly CRMContext _context;

        public UpdatePQChucNangWebCommandHandler(CRMContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdatePQChucNangWebCommand request, CancellationToken cancellationToken)
        {
            return true;
        }
    }
}
