using EEWF.Application.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.TeacherCategory.Commands.UpdateTeacherCategory
{
    public class UpdateTeacherCategoryCommand:IRequest<ServiceResult<int>>
    {
        public UpdateTeacherCategoryCommand(string name, int categoryId)
        {
            TeacherCategoryId = categoryId;
            Name = name;
        }
        public int TeacherCategoryId { get; set; }
        public string Name { get; set; }
    }
}
