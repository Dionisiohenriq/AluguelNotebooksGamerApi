using AluguelNotebooksGamerApi.Entities;
using MediatR;

namespace AluguelNotebooksGamerApi.CQRS.Commands
{
    public record DeleteModelCommand(int Id) : IRequest<Model>;


}
