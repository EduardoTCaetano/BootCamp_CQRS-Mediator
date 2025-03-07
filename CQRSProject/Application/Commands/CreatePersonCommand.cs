using MediatR;
using System;

namespace CQRSApp.Application.Commands
{
    public class CreatePersonCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string TaxId { get; set; }
    }
}
