using EEWF.Application.Core;
using EEWF.Domain.DTOs.CategoryTeacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.Interfaces
{
    public interface ICategoryTeacherService
    {
        Task<ServiceResult<CategoryTeacherDto>> GetCategoryTeacher();
    }
}
