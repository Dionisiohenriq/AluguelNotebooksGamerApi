using AluguelNotebooksGamerApi.CQRS.Queries;
using AluguelNotebooksGamerApi.Data;
using AluguelNotebooksGamerApi.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using NuGet.Protocol.Plugins;

namespace AluguelNotebooksGamerApi.CQRS.Handlers
{
    public class GetModelByIdHandler : IRequestHandler<GetModelByIdQuery, Model>
    {
        private readonly ApplicationDbContext _context;
        public GetModelByIdHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Model> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
        {
            await _context.
        }
    }
}
