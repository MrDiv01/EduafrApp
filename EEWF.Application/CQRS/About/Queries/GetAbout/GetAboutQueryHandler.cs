using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.About;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.About.Queries.GetAbout
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, ServiceResult<AboutDto>>
    {
        private readonly IAboutService _aboutService;

        public GetAboutQueryHandler(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public async Task<ServiceResult<AboutDto>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var result = await _aboutService.GetAbout();

            return result;
        }
    }
}
