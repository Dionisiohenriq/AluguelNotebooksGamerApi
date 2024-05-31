using AluguelNotebooksGamerApi.Entities;
using MediatR;

namespace AluguelNotebooksGamerApi.CQRS.Notifications
{
    public record ModelAddedNotification(Model Model) : INotification;
}
