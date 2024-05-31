using AluguelNotebooksGamerApi.Entities;
using MediatR;

namespace AluguelNotebooksGamerApi.CQRS.Commands
{
    public record UpdateModelCommand(Model Model) : IRequest<Model>;

}
