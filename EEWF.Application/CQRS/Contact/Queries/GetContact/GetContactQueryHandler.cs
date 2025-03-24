using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Contact;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Contact.Queries.GetContact
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, ServiceResult<ContactDto>>
    {
        private readonly IContactService _contact;

        public GetContactQueryHandler(IContactService contact)
        {
            _contact = contact;
        }
        public Task<ServiceResult<ContactDto>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var result = _contact.GetContact();
            return result;
        }
    }
}
