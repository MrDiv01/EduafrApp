using EEWF.Application.Core;
using EEWF.Domain.DTOs.Contact;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Contact.Queries.GetContactById
{
    public class GetContactByIdQuery:IRequest<ServiceResult<ContactDto>>
    {
        public GetContactByIdQuery(int contactId)
        {
            ContactId = contactId;
        }
        public int ContactId { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
    }
}
