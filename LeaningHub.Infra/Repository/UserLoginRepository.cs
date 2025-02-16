using Dapper;
using LearningHub.Core.common;
using LearningHub.Core.data;
using LearningHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaningHub.Infra.Repository
{
    public class UserLoginRepository : IUserLoginRepository
    {

        private readonly IDbContext _dbContext;
        public UserLoginRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public void CreateUserLogin(UserLogin userLogin)
        {
            var p = new DynamicParameters();
            p.Add("user_name", userLogin.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("pass_word", userLogin.Passwordd, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("role_id", userLogin.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("student_id", userLogin.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("userlogin_package.createuser", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteUserLogin(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("userlogin_package.deleteuser", p, commandType: CommandType.StoredProcedure);
        }

        public List<UserLogin> GetAllUsersLogin()
        {
            IEnumerable<UserLogin> result = _dbContext.Connection.Query<UserLogin>
              ("userlogin_package.getallusers", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public UserLogin GetUserLoginById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<UserLogin> result = _dbContext.Connection.Query<UserLogin>
               ("userlogin_package.getuserbyid", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateUserLogin(UserLogin userLogin)
        {
            var p = new DynamicParameters();
            p.Add("id", userLogin.Loginid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("user_name", userLogin.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("pass_word", userLogin.Passwordd, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("role_id", userLogin.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("student_id", userLogin.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("userlogin_package.updateuser", p, commandType: CommandType.StoredProcedure);
        }
    }
}
