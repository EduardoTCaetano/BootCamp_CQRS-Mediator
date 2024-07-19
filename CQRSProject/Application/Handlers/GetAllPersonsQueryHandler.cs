using MediatR;
using CQRSApp.Domain.Entities;
using CQRSApp.Domain.Interfaces;

using CQRSApp.Application.Queries;

namespace CQRSApp.Application.Handlers
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, IEnumerable<Person>>
    {
        private readonly IPersonRepository _repository;

        public GetAllPersonsQueryHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Person>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllPersonsAsync();
        }
    }
}
