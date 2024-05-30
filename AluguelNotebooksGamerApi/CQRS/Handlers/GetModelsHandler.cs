using AluguelNotebooksGamerApi.CQRS.Queries;
using AluguelNotebooksGamerApi.Data;
using AluguelNotebooksGamerApi.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AluguelNotebooksGamerApi.CQRS.Handlers
{
    public class GetModelsHandler : IRequestHandler<GetModelsQuery, IEnumerable<Model>>
    {
        private readonly ApplicationDbContext _context;
        public GetModelsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Model>> Handle(GetModelsQuery request, CancellationToken cancellationToken)
        {
            return [.. await _context.Models.ToListAsync()];
        }
    }
}
