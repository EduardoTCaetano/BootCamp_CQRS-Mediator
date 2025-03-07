using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CQRSApp.Application.Commands;
using CQRSApp.Domain.Entities;
using CQRSApp.Domain.Interfaces;

namespace CQRSApp.Application.Handlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, Guid>
    {
        private readonly IPersonRepository _personRepository;

        public CreatePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Age = request.Age,
                TaxId = request.TaxId
            };

            await _personRepository.AddAsync(person);
            await _personRepository.SaveChangesAsync();

            return person.Id;
        }
    }
}
