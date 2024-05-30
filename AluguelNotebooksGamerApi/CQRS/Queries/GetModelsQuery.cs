using AluguelNotebooksGamerApi.Entities;
using MediatR;

namespace AluguelNotebooksGamerApi.CQRS.Queries
{
    public record GetModelsQuery() : IRequest<IEnumerable<Model>>;
}
