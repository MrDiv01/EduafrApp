using EEWF.Domain.DTOs.Appeal;
using EEWF.Domain.DTOs.AppealAnswer;
using EEWF.Domain.Entities;

namespace EEWF.MVC.Areas.Admin.ViewModels
{
    public class AppealViewModel
    {
        public AppealAnswerDto AppealAnswer { get; set; }
        public AppealDto Appeal { get; set; }
    }
}
