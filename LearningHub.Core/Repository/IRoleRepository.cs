﻿using LearningHub.Core.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface IRoleRepository
    {
        List<Role> GetAllRoles();
        void CreateRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int id);
        Role GetRoleById(int id);
    }
}
