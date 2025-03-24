using EEWF.Application.Core;
using EEWF.Domain.DTOs.About;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.About.Queries.GetAboutById
{
    public class GetAboutByIdQuery:IRequest<ServiceResult<AboutDto>>
    {
        public GetAboutByIdQuery(int aboutId)
        {
            AboutId = aboutId;
        }
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
