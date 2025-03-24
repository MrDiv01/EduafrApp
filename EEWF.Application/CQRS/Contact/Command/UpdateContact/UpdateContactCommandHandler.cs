using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Contact.Command.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ServiceResult<int>>
    {
        private readonly IContactService _contactService;
        public UpdateContactCommandHandler(IContactService contactService)
        {
            _contactService = contactService;
        }
        public async Task<ServiceResult<int>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var result = await _contactService.UpdateContact(request);

            return result;
        }
    }
}
