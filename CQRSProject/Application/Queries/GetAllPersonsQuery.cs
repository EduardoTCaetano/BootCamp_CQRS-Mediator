using MediatR;
using CQRSApp.Domain.Entities;
using System.Collections.Generic;

namespace CQRSApp.Application.Queries
{
    public class GetAllPersonsQuery : IRequest<IEnumerable<Person>>
    {
    }
}
