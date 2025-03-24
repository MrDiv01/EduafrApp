//using EEWF.Application.Core;
//using EEWF.Application.CQRS.QuizForm.Commands.CreateQuizForm;
//using EEWF.Application.CQRS.QuizForm.Commands.UpdateQuizForm;
//using EEWF.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace EEWF.Application.Interfaces
//{
//    public interface IQuizFormService
//    {
//        Task<ServiceResult<int>> CreateQuizForm(CreateQuizFormCommand command);
//        Task<ServiceResult<int>> GetFormId(string name,string surename,string mail,string phone);
//        Task<ServiceResult<int>> UpdateQuizForm(int id,int correct, int incorrect, int count, int levelId);
//        public void SaveQuizData();
//    }
//}
