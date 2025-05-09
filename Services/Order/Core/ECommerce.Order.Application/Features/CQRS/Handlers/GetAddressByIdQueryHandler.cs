using ECommerce.Order.Application.Features.CQRS.Queries;
using ECommerce.Order.Application.Features.CQRS.Results;
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
    public class GetAddressByIdQueryHandler(IRepository<Address> repository)
    {
        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var result = await repository.GetByIdAsync(query.id);
            if(result is null)
            {
                throw new Exception("Adres bilgisi bulunamadı.");
            }
            return result.Adapt<GetAddressByIdQueryResult>();
        }
    }
}
