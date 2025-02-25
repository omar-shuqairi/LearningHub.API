using LearningHub.Core.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Services
{
    public interface IJWTService
    {
        string Auth(UserLogin userLogin);
    }
}
