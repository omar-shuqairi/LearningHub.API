using LearningHub.Core.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface IUserLoginRepository
    {
        List<UserLogin> GetAllUsersLogin();
        void CreateUserLogin(UserLogin userLogin);
        void UpdateUserLogin(UserLogin userLogin);
        void DeleteUserLogin(int id);
        UserLogin GetUserLoginById(int id);
    }
}
