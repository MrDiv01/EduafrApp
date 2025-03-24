using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Level;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Level.Queries.GetLevel
{
    public class GetLevelQueryHandler : IRequestHandler<GetLevelQuery, ServiceResult<List<LevelDto>>>
    {
        private readonly ILevelService _levelService;

        public GetLevelQueryHandler(ILevelService levelService)
        {
            _levelService = levelService;
        }
        public async Task<ServiceResult<List<LevelDto>>> Handle(GetLevelQuery request, CancellationToken cancellationToken)
        {

            var result = await _levelService.GetLevel();

            return result;

        }
    }
}
