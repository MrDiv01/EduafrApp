using EEWF.Application.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Level.Commands.CreateLevel
{
    public class CreateLevelCommand:IRequest<ServiceResult<int>>
    {
        public CreateLevelCommand(string name, string url)
        {
            Name = name;
            URL = url;
        }
        public string Name { get; set; }
        public string URL { get; set; }
    }
}
