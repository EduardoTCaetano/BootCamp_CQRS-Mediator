using MediatR;

namespace CQRSApp.Application.Commands
{
    public class UpdatePersonCommand : IRequest<bool>
    {
        public Guid Id { get; }
        public string Name { get; }
        public int Age { get; }
        public string TaxId { get; }

        public UpdatePersonCommand(Guid id, string name, int age, string taxId)
        {
            Id = id;
            Name = name;
            Age = age;
            TaxId = taxId;
        }
    }
}