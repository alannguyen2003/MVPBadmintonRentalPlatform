using BusinessObject;
using DataAccess;
using Repository.Interface;

namespace Repository;

public class RoleRepository : IRoleRepository
{
    public async Task<List<Role>> GetAllRoles()
    {
        return await RoleDAO.Instance.GetAllRoles();
    }

    public async Task AddRole(Role role)
    {
        await RoleDAO.Instance.AddRole(role);
    }
}