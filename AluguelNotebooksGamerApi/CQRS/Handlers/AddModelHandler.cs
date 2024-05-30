using AluguelNotebooksGamerApi.CQRS.Commands;
using AluguelNotebooksGamerApi.Data;
using MediatR;

namespace AluguelNotebooksGamerApi.CQRS.Handlers
{
    public class AddModelHandler : IRequestHandler<AddModelCommand>
    {
        private readonly ApplicationDbContext _context;
        public async Task Handle(AddModelCommand request, CancellationToken cancellationToken)
        {
            await _context.AddAsync(request.model);
            await _context.SaveChangesAsync();

            return;
        }
    }
}
