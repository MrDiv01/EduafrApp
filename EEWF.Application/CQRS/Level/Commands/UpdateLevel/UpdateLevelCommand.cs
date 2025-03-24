using EEWF.Application.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEWF.Application.CQRS.Level.Commands.UpdateLevel
{
    public class UpdateLevelCommand:IRequest<ServiceResult<int>>
    {
        public UpdateLevelCommand(int levelId , string name, string url)
        {
            LevelId = levelId;
            Name = name;
            URL = url;
        }
        public int LevelId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

    }
}
