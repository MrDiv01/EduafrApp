using EEWF.Application.Core;
using EEWF.Application.CQRS.Contact.Command.UpdateContact;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Contact;
using EEWF.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Infrastructure.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _context;

        public ContactService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResult<ContactDto>> GetContact()
        {
            var contact = await _context.Contacts.Select(x => new ContactDto
            {
                ContactId = x.Id,
                Location = x.Location,
                Phone = x.Phone,
                Mail = x.Mail,
            }).FirstOrDefaultAsync();

            return ServiceResult<ContactDto>.OK(contact);
        }

        public async Task<ServiceResult<ContactDto>> GetContactById(int contactId)
        {
            var contact = await _context.Contacts.Where(x => x.Id == contactId).Select(x => new ContactDto
            {
                ContactId = x.Id,
                Location = x.Location,
                Phone = x.Phone,
                Mail = x.Mail,
            }).FirstOrDefaultAsync();

            return ServiceResult<ContactDto>.OK(contact);
        }

        public async Task<ServiceResult<int>> UpdateContact(UpdateContactCommand command)
        {
            var existContact = await _context.Contacts.Where(x => x.Id == command.ContactId).FirstOrDefaultAsync();

            existContact.Phone = command.Phone;
            existContact.Mail = command.Mail;
            existContact.Location = command.Location;

            await _context.SaveChangesAsync();

            return ServiceResult<int>.OK(existContact.Id);
        }
    }
}
