using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CQRSApp.Domain.Interfaces;
using CQRSApp.Application.Commands;

namespace CQRSApp.Application.Handlers
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        private readonly IPersonRepository _repository;

        public UpdatePersonCommandHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _repository.GetPersonByIdAsync(request.Id);
            if (person == null)
            {
                return false;
            }

            person.Name = request.Name;
            person.Age = request.Age;
            person.TaxId = request.TaxId;

            return await _repository.UpdatePersonAsync(person);
        }
    }
}
