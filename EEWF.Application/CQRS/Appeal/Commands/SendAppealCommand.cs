using EEWF.Application.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Appeal.Commands
{
    public class SendAppealCommand:IRequest<ServiceResult<int>>
    {
        public SendAppealCommand(string name, string surname, string email, string subject, string message)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Subject = subject;
            Message = message;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
		public bool IsAnswer { get; set; }
	}
}
