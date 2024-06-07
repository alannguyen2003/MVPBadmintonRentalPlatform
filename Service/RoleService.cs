using BusinessObject;
using Repository.Interface;
using Service.Interface;

namespace Service;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    
    
    public async Task<List<Role>> GetAllRoles()
    {
        return await _roleRepository.GetAllRoles();
    }

    public async Task AddRole(Role role)
    {
        await _roleRepository.AddRole(role);
    }
}