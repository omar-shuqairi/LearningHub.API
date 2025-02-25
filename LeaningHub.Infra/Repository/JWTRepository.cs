using Dapper;
using LeaningHub.Infra.common;
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
    public class JWTRepository : IJWTRepository
    {

        private readonly IDbContext _dbContext;
        public JWTRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserLogin Auth(UserLogin userLogin)
        {

            var p = new DynamicParameters();
            p.Add("user_name", userLogin.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("pass_word", userLogin.Passwordd, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<UserLogin>("Login_package.User_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
