using AluguelNotebooksGamerApi.CQRS.Commands;
using AluguelNotebooksGamerApi.Data;
using AluguelNotebooksGamerApi.Entities;
using MediatR;

namespace AluguelNotebooksGamerApi.CQRS.Handlers
{
    public class AddModelHandler : IRequestHandler<AddModelCommand, Model>
    {
        private readonly ApplicationDbContext? _context;
        public async Task<Model> Handle(AddModelCommand request, CancellationToken cancellationToken)
        {
            await _context.AddAsync(request.Model);
            await _context.SaveChangesAsync();

            return request.Model;
        }
    }
}
