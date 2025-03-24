using EEWF.Application.Core;
using EEWF.Domain.DTOs.Contact;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Contact.Queries.GetContact
{
    public class GetContactQuery:IRequest<ServiceResult<ContactDto>>
    {
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
    }
}
