using EEWF.Application.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.TeacherCategory.Commands.CreateTeacherCategory
{
    public class CreateTeacherCategoryCommand:IRequest<ServiceResult<int>>
    {
        public CreateTeacherCategoryCommand(string name)
        {
            Name = name;
        }
        public int TeacherCategoryId { get; set; }
        public string Name { get; set; }
    }
}
