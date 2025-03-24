using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Contact;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Contact.Queries.GetContactById
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ServiceResult<ContactDto>>
    {
        private readonly IContactService _contactService;

        public GetContactByIdQueryHandler(IContactService contactService)
        {
            _contactService = contactService;
        }
        public async Task<ServiceResult<ContactDto>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _contactService.GetContactById(request.ContactId);

            return result;
        }
    }
}
