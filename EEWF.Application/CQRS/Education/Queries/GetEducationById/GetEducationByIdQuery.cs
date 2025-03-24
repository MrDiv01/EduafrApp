using EEWF.Application.Core;
using EEWF.Domain.DTOs.Education;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Education.Queries.GetEducationById
{

    public class GetEducationByIdQuery:IRequest<ServiceResult<EducationDto>>
    {
        public GetEducationByIdQuery(int educationId)
        {
            EducationId = educationId;
        }
        public int EducationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
    }

}
