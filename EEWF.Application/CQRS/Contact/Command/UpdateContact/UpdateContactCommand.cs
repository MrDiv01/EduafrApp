using EEWF.Application.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Contact.Command.UpdateContact
{
    public class UpdateContactCommand:IRequest<ServiceResult<int>>
    {
        public UpdateContactCommand(int contactId, string location, string phone, string mail)
        {
            ContactId = contactId;
            Location = location;
            Phone = phone;
            Mail = mail;
        }
        public int ContactId { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
    }
}
