using EEWF.Application.Core;
using EEWF.Application.Interfaces;
using EEWF.Domain.DTOs.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Category.Queries.GetCategory
{
    public class GetCategoryQuery:IRequest<ServiceResult<List<CategoryDto>>>
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}
