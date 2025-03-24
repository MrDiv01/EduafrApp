using EEWF.Application.Core;
using EEWF.Domain.DTOs.Graduate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Graduate.Queries.GetGraduateById
{
    public class GetGraduateByIdQuery:IRequest<ServiceResult<GraduateDto>>
    {
        public GetGraduateByIdQuery(int graduateId)
        {
            GraduateId = graduateId;
        }
        public int GraduateId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public string Comment { get; set; }
    }
}
