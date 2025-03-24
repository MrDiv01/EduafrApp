//using EEWF.Application.Core;
//using EEWF.Application.Interfaces;
//using EEWF.Domain.DTOs.Variant;
//using EEWF.Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EEWF.Infrastructure.Services
//{
//    public class VariantService : IQuizVariant
//    {
//        private readonly ApplicationDbContext _dbContext;

//        public VariantService(ApplicationDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }
//        public async Task<ServiceResult<List<VariantDto>>> GetVariantDtoByQuestionId(int Id)
//        {
//            var result = await _dbContext.Variants.Where(x => x.QuestionId == Id).Select(x => new VariantDto
//            {
//                  Description = x.Description,
//                   IsCorrect = x.IsCorrect,
//                     Name = x.Name,
//            }).ToListAsync();
//            return ServiceResult<List<VariantDto>>.OK(result);
//        }
//    }
//}
