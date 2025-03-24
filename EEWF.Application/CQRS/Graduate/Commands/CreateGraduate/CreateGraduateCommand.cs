using EEWF.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Graduate.Commands.CreateGraduate
{
    public class CreateGraduateCommand:IRequest<ServiceResult<int>>
    {
        public CreateGraduateCommand(string name, string degree, string comment, IFormFile imageFile)
        {
            Name = name;
            Degree = degree; 
            Comment = comment;
            ImageFile = imageFile;
        }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public string Comment { get; set; }
        public IFormFile ImageFile { get; set;}
    }
}
