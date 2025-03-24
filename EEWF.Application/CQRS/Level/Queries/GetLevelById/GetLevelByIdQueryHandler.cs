using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Level;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Level.Queries.GetLevelById
{
    public class GetLevelByIdQueryHandler : IRequestHandler<GetLevelByIdQuery, ServiceResult<LevelDto>>
    {
        private readonly ILevelService _levelService;
        public GetLevelByIdQueryHandler(ILevelService levelService)
        {
            _levelService = levelService;
        }
        public async Task<ServiceResult<LevelDto>> Handle(GetLevelByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _levelService.GetLevelById(request.LevelId);

            return result;
        }
    }
}
