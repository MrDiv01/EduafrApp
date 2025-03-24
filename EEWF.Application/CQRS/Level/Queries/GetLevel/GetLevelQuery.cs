using EEWF.Application.Core;
using EEWF.Domain.DTOs.Level;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Level.Queries.GetLevel
{
    public class GetLevelQuery:IRequest<ServiceResult<List<LevelDto>>>
    {

        public int LevelId { get; set; }

        public string Name { get; set; }
    }
}
