using EEWF.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Graduate.Commands.UpdateGraduate
{
    public class UpdateGraduateCommand:IRequest<ServiceResult<int>>
    {
        public UpdateGraduateCommand(string name, string degree, string comment, int graduateId, IFormFile imageFile)
        {
            Name = name;
            Degree = degree;
            Comment = comment;
            GraduateId = graduateId;
            ImageFile = imageFile;
        }
        public int GraduateId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public string Comment { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
