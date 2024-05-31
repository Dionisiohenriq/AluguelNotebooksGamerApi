using AluguelNotebooksGamerApi.CQRS.Notifications;
using AluguelNotebooksGamerApi.Data;
using AluguelNotebooksGamerApi.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AluguelNotebooksGamerApi.CQRS.Handlers
{
    public class CacheInvalidationHandler : INotificationHandler<ModelAddedNotification>
    {
        private readonly ApplicationDbContext _context;

        public CacheInvalidationHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ModelAddedNotification notification, CancellationToken cancellationToken)
        {
            var model = await _context.FindAsync<Model>(notification.Model.Id);

            var notify = $"{model} evt: Cache Invalidated";

            await Task.FromResult(notify);
        }
    }
}
