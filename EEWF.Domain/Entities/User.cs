using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string SureName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public int UserRoleId { get; set; }
    }
}
