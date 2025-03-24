using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.Entities
{
    public class AppealAnswer:BaseEntity
    {
        public string Answer { get; set; }
        //Appeal
        public int AppealId { get; set; }
        public Appeal Appeal { get; set; }
    }
}
