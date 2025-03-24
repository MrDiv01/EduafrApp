//using EEWF.Application.Core;
//using EEWF.Application.CQRS.QuizForm.Commands.CreateQuizForm;
//using EEWF.Application.CQRS.QuizForm.Commands.UpdateQuizForm;
//using EEWF.Application.Interfaces;
//using EEWF.Domain.Entities;
//using EEWF.Infrastructure.Data;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

//namespace EEWF.Infrastructure.Services
//{
//    public class QuizFormService : IQuizFormService
//    {
//        private readonly ApplicationDbContext _applicationDbContext;

//        public QuizFormService(ApplicationDbContext applicationDbContext)
//        {
//            _applicationDbContext = applicationDbContext;
//        }
//        public async Task<ServiceResult<int>> CreateQuizForm(CreateQuizFormCommand command)
//        {
//            QuizForm quizForm = new QuizForm()
//            {
//                Name = command.Name,
//                SureName = command.SureName,
//                Email = command.Email,
//                PhoneNumber = command.PhoneNumber,
//            };
//            await _applicationDbContext.QuizForms.AddAsync(quizForm);
//            await _applicationDbContext.SaveChangesAsync();
//            return ServiceResult<int>.OK(quizForm.Id);
//        }

//        public async Task<ServiceResult<int>> GetFormId(string name, string surename, string email, string phone)
//        {
//            var result = await _applicationDbContext.QuizForms.Where(x => x.Name == name &&
//                                                                        x.SureName == surename &&
//                                                                         x.Email == email &&
//                                                                         x.PhoneNumber == phone).Select(x => new QuizForm
//                                                                         {
//                                                                             Id = x.Id,
//                                                                         }).FirstOrDefaultAsync();
//            return ServiceResult<int>.OK(result.Id);
//        }


//        public async Task<ServiceResult<int>> UpdateQuizForm(int id, int correct, int incorrect, int count, int levelId)
//        {
//            var result = await _applicationDbContext.QuizForms.Where(x => x.Id == id).FirstOrDefaultAsync();
//            int Tp = count;
//            int Tc = correct;
//            int Ti = incorrect;
//            int Li = levelId;

//            result.Point = Tp;
//            result.CorectAnswerCount = Tc;
//            result.FalseAnswerCount = Ti;
//            result.LevelId = Li;

//            //await _applicationDbContext.QuizForms.AddAsync(result);
//            _applicationDbContext.SaveChanges();
//            return ServiceResult<int>.OK(result.Id);
//        }
//        public void SaveQuizData()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
