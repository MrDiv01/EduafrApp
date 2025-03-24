using EEWF.Application.Core;
using EEWF.Domain.DTOs.Appeal;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Appeal.Queries.GetAppeal
{
    public class GetAppealQuery:IRequest<ServiceResult<List<AppealDto>>>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
