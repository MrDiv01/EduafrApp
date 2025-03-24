using EEWF.Application.Core;
using EEWF.Domain.DTOs.Level;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Level.Queries.GetLevelById
{
    public class GetLevelByIdQuery:IRequest<ServiceResult<LevelDto>>
    {
        public GetLevelByIdQuery(int levelId)
        {
            LevelId = levelId;
        }
        public int LevelId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
    }
}
