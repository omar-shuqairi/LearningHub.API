using LeaningHub.Infra.Services;
using LearningHub.Core.data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;

        public UserLoginController(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        [HttpGet]
        public List<UserLogin> GetAllUserLogin()
        {
            return _userLoginService.GetAllUsersLogin();
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public UserLogin GetUserLoginById(int id)
        {
            return _userLoginService.GetUserLoginById(id);
        }


        [HttpPost]
        public void CreateUserLogin(UserLogin userLogin)
        {
            _userLoginService.CreateUserLogin(userLogin);
        }

        [HttpPut]
        public void UpdateUserLogin(UserLogin userLogin)
        {
            _userLoginService.UpdateUserLogin(userLogin);
        }

        [HttpDelete]
        [Route("DeleteUserLogin{id}")]

        public void DeleteUserLogin(int id)
        {
            _userLoginService.DeleteUserLogin(id);
        }
    }
}
