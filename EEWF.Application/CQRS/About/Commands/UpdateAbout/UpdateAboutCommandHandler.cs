using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.About.Commands.UpdateAbout
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand, ServiceResult<int>>
    {
        private readonly IAboutService _aboutService;
        public UpdateAboutCommandHandler(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public async Task<ServiceResult<int>> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var result = await _aboutService.UpdateAbout(request);

            return result;
        }
    }
}
