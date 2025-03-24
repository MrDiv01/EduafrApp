using EEWF.Application.Core;
using EEWF.Domain.DTOs.Education;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Education.Queries.GetEducationByLevelId
{
    public class GetEducationByLevelIdQuery:IRequest<ServiceResult<List<EducationDto>>>
    {
        public GetEducationByLevelIdQuery(int levelId)
        {
            LevelId = levelId;
        }
        public int LevelId { get; set; }
    }
}
