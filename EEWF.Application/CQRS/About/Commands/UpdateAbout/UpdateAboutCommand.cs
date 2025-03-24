using EEWF.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.About.Commands.UpdateAbout
{
    public class UpdateAboutCommand:IRequest<ServiceResult<int>>
    {
        public UpdateAboutCommand(int aboutId, string title, string description, IFormFile imageFile)
        {
            AboutId = aboutId;
            Title = title;
            Description = description;
            ImageFile = imageFile;
        }
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
