using EEWF.Domain.DTOs.Appeal;
using EEWF.Domain.DTOs.Contact;

namespace EEWF.MVC.ViewModels
{
    public class ContactViewModel
    {
        public ContactDto Contact { get; set; }
        public AppealDto Appeal { get; set; }
    }
}
