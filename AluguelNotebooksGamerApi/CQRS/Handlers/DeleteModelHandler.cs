using AluguelNotebooksGamerApi.CQRS.Commands;
using AluguelNotebooksGamerApi.Data;
using AluguelNotebooksGamerApi.Entities;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AluguelNotebooksGamerApi.CQRS.Handlers
{
    public class DeleteModelHandler : IRequestHandler<DeleteModelCommand, Model>
    {
        private readonly ApplicationDbContext _context;

        public DeleteModelHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Model> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            var model = await _context.FindAsync<Model>(request.Id);
            model.Delete();
            var result = _context.Update(model);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
