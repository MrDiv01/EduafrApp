using EEWF.Application.Core;
using EEWF.Domain.DTOs.About;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.About.Queries.GetAbout
{
    public class GetAboutQuery:IRequest<ServiceResult<AboutDto>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
