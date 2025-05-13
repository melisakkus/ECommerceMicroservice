using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Commands
{
    public record UpdateAddressCommand
    {
        public int AddressId { get; init; }
        public string UserId { get; init; }
        public string Name { get; init; }
        public string SurName { get; init; }
        public string City { get; init; }
        public string District { get; init; }
        public string AddressLine { get; init; }
    }
}
