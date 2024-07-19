using MediatR;

namespace CQRSApp.Application.Commands
{
    public class DeletePersonCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeletePersonCommand(Guid id)
        {
            Id = id;
        }
    }
}
