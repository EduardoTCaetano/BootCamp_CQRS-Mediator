using MediatR;
using CQRSApp.Domain.Entities;
using CQRSApp.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using CQRSApp.Application.Queries;

namespace CQRSApp.Application.Handlers
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person>
    {
        private readonly IPersonRepository _repository;

        public GetPersonByIdQueryHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetPersonByIdAsync(request.Id);
        }
    }
}
