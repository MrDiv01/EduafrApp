//using EEWF.Application.Core;
//using EEWF.Application.Interfaces;
//using EEWF.Domain.DTOs.Carousel;
//using EEWF.Domain.DTOs.Question;
//using EEWF.Domain.Entities;
//using EEWF.Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EEWF.Infrastructure.Services
//{
//    public class QuizQuestionService : IQuizQuestionService
//    {
//        private readonly ApplicationDbContext _applicationDbContext;

//        public QuizQuestionService(ApplicationDbContext applicationDbContext)
//        {
//            _applicationDbContext = applicationDbContext;
//        }
//        public async Task<ServiceResult<List<Question>>> GetQuestionByLevelId(int id)
//        {
//            var result = await _applicationDbContext.Questions.Include(x => x.Variants).Where(x => x.LevelId == id).Select(x => new Question
//            {
//                Point = x.Point,
//                Query = x.Query,
//                Variants = x.Variants,
//                LevelId = x.LevelId
//            }).ToListAsync();
//            return ServiceResult<List<Question>>.OK(result);
//        }
//        public async Task<ServiceResult<List<QuestionDto>>> GetQuestionPointById(int id)
//        {
//            var result = await _applicationDbContext.Questions.Where(x => x.Id == id).
//                                                                        Select(x => new QuestionDto
//                                                                        {
//                                                                            Query = x.Query,
//                                                                            LevelId = x.LevelId,
//                                                                            Point = x.Point
//                                                                        }).ToListAsync();
//            return ServiceResult<List<QuestionDto>>.OK(result);
//        }


//    }
//}
