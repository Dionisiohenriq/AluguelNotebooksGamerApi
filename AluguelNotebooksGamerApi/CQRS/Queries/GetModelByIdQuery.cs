using AluguelNotebooksGamerApi.Entities;
using MediatR;

namespace AluguelNotebooksGamerApi.CQRS.Queries
{
    public record GetModelByIdQuery(int Id) : IRequest<Model>;
}
