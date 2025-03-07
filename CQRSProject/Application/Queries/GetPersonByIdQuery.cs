using MediatR;
using CQRSApp.Domain.Entities;
using System;

namespace CQRSApp.Application.Queries
{
    public class GetPersonByIdQuery : IRequest<Person>
    {
        public Guid Id { get; set; }

        public GetPersonByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
