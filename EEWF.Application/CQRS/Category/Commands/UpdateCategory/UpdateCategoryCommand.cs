using EEWF.Application.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommand:IRequest<ServiceResult<int>>
    {
        public UpdateCategoryCommand(int categoryId, string name, string icon, string desription)
        {
            CategoryId = categoryId;
            Name = name;
            Icon = icon;
            Description = desription;
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}
