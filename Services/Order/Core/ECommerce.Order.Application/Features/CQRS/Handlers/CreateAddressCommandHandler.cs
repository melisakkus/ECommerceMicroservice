using ECommerce.Order.Application.Features.CQRS.Commands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Handlers
{
    public class CreateAddressCommandHandler(IRepository<Address> _repository)
    {
        public async Task Handle(CreateAddressCommand command)
        {
            var address = command.Adapt<Address>();
            await _repository.CreateAsync(address);
        }
    }
}
