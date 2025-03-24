using EEWF.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Teacher.Commands.UpdateTeacher
{
    public class UpdateTeacherCommand:IRequest<ServiceResult<int>>
    {
        public UpdateTeacherCommand(string name, string surname, string description, int teacherCategoryId, IFormFile imageFile)
        {
            Name = name;
            Surname = surname;
            Description = description;
            ImageFile = imageFile;
            TeacherCategoryId = teacherCategoryId;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public int TeacherCategoryId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
