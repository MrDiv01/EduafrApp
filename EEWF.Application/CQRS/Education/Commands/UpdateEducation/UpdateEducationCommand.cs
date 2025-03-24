using EEWF.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Education.Commands.UpdateEducation
{
    public class UpdateEducationCommand:IRequest<ServiceResult<int>>
    {
        public UpdateEducationCommand(string name, string description, IFormFile imageFile, int educationId)
        {
            Name = name;
            Description = description;
            ImageFile = imageFile;
            EducationId = educationId;
        }
        public int EducationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
