using ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    class CreateOrderingCommandHandler(IRepository<Ordering> _repository) : IRequestHandler<CreateOrderingCommand>
    {
        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {

            var ordering = new Ordering
            {
                UserId = request.UserId,
                OrderDate = request.OrderDate,
            };
            await _repository.CreateAsync(ordering);
        }
    }
}
