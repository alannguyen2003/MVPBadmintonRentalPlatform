using BusinessObject;

namespace Repository.Interface;

public interface IRoleRepository
{
    public Task<List<Role>> GetAllRoles();
    public Task AddRole(Role role);
    public Task AddRangeRoleAsync(List<Role> roles);
}