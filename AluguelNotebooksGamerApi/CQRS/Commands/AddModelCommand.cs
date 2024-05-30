using AluguelNotebooksGamerApi.Entities;
using MediatR;

namespace AluguelNotebooksGamerApi.CQRS.Commands
{
    public record AddModelCommand(Model model): IRequest;


}

