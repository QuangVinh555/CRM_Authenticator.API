using Infrastructure.Entites;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator.Application.Features.V1.Commands.PQChucNangWeb
{
    public class CreatePQChucNangWebCommand : CreateOrUpdatePQChucNangWebCommand, IRequest<bool>
    {

    }

    public class CreatePQChucNangWebCommandHandler : IRequestHandler<CreatePQChucNangWebCommand,bool>
    {
        private readonly CRMContext _context;

        public CreatePQChucNangWebCommandHandler(CRMContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CreatePQChucNangWebCommand request, CancellationToken cancellationToken)
        {
            var PQChucNangWeb = new RolePageFunctionMapping();
            var newPage = new PageCommand();
            // Page
            if(request.ListPages.Count > 0)
            {
                foreach (var page in request.ListPages)
                {
                    // function
                    if(page.ListFunctions.Count > 0)
                    {
                        foreach(var function in page.ListFunctions)
                        {
                            PQChucNangWeb.RoleId = request.RoleId;
                            PQChucNangWeb.PageId = page.PageId;
                            PQChucNangWeb.FunctionId = function.FunctionId;

                            _context.RolePageFunctionMappings.Add(PQChucNangWeb);
                            await _context.SaveChangesAsync();  
                        }
                    }
                }
            }

            return true;
        }
    }
}
