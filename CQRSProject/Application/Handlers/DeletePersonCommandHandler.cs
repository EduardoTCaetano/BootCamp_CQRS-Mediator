using MediatR;
using CQRSApp.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using CQRSApp.Application.Commands;

namespace CQRSApp.Application.Handlers
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IPersonRepository _repository;

        public DeletePersonCommandHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeletePersonByIdAsync(request.Id);
        }
    }
}
