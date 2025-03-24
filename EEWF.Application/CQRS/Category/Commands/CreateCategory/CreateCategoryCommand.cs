using EEWF.Application.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand:IRequest<ServiceResult<int>>
    {
        public CreateCategoryCommand(string name, string icon, string desription)
        {
            Name = name;
            Icon = icon;
            Description = desription;
        }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}
