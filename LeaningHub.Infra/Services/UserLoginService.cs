using LearningHub.Core.data;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaningHub.Infra.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserLoginRepository _userLoginRepository;

        public UserLoginService(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }

        public void CreateUserLogin(UserLogin userLogin)
        {
            _userLoginRepository.CreateUserLogin(userLogin);
        }

        public void DeleteUserLogin(int id)
        {
            _userLoginRepository.DeleteUserLogin(id);
        }

        public List<UserLogin> GetAllUsersLogin()
        {
            return _userLoginRepository.GetAllUsersLogin();
        }

        public UserLogin GetUserLoginById(int id)
        {
            return _userLoginRepository.GetUserLoginById(id);
        }

        public void UpdateUserLogin(UserLogin userLogin)
        {
            _userLoginRepository.UpdateUserLogin(userLogin);
        }
    }
}
