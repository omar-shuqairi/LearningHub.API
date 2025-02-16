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
    public class RoleRepository : IRoleRepository
    {

        private readonly IDbContext _dbContext;
        public RoleRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public void CreateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("role_name", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("role_package.createrole", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteRole(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("role_package.deleterole", p, commandType: CommandType.StoredProcedure);
        }

        public List<Role> GetAllRoles()
        {
            IEnumerable<Role> result = _dbContext.Connection.Query<Role>
              ("role_package.getallroles", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Role GetRoleById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Role> result = _dbContext.Connection.Query<Role>
               ("role_package.getrolebyid", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("id", role.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("role_name", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("role_package.updaterole", p, commandType: CommandType.StoredProcedure);
        }
    }
}
