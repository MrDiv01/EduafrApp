using EEWF.Application.Core;
using EEWF.Application.CQRS.Contact.Command.UpdateContact;
using EEWF.Domain.DTOs.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.Interfaces
{
    public interface IContactService
    {
        Task<ServiceResult<ContactDto>> GetContact();
        Task<ServiceResult<ContactDto>> GetContactById(int contactId);
        Task<ServiceResult<int>> UpdateContact(UpdateContactCommand command);
    }
}
