using BusinessObject;

namespace Service.Interface;

public interface IRoleService
{
    public Task<List<Role>> GetAllRoles();
    public Task AddRole(Role role);
    public Task AddRangeRoleAsync(List<Role> roles);
}