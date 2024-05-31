using AluguelNotebooksGamerApi.CQRS.Notifications;
using AluguelNotebooksGamerApi.Data;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AluguelNotebooksGamerApi.CQRS.Handlers
{
    public class EmailHandler : INotificationHandler<ModelAddedNotification>
    {
        private readonly ApplicationDbContext _context;

        public EmailHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ModelAddedNotification notification, CancellationToken cancellationToken)
        {
            var model = await _context.FindAsync<Model>(notification.Model.Id);

            var notify = $"{model} evt: Email sent";

            await Task.FromResult(notify);
        }
    }
}
