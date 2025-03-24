using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.About;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.About.Queries.GetAboutById
{
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, ServiceResult<AboutDto>>
    {
        private readonly IAboutService _aboutService;

        public GetAboutByIdQueryHandler(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public async Task<ServiceResult<AboutDto>> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _aboutService.GetAboutById(request.AboutId);

            return result;
        }
    }
}
