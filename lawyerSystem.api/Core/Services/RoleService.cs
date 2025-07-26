using AutoMapper;
using lawyerSystem.api.Core.Dtos.Role;
using lawyerSystem.api.Core.Interfaces;
using lawyerSystem.api.Domain.Models;
using System.Data;

namespace lawyerSystem.api.Core.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<RoleDto> CreateRoleAsync(CreateRoleCommand roleCommand)
    {
        if (roleCommand == null)
        {
            throw new ArgumentNullException(nameof(roleCommand), "Role command cannot be null");
        }

        var role = new Role
        {
            Name = roleCommand.Name
        };

        await _roleRepository.AddAsync(role);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<RoleDto>(role);
    }

    public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
    {
        var roles = await _roleRepository.GetAllRolesAsync();
        return _mapper.Map<IEnumerable<RoleDto>>(roles);
    }

    public async Task<RoleDto> GetRoleByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Role name cannot be null or empty", nameof(name));
        }

        var role = await _roleRepository.GetRoleByName(name);

        if (role == null)
        {
            throw new KeyNotFoundException($"Role with name '{name}' not found");
        }

        return _mapper.Map<RoleDto>(role); 
    }

    public async Task<RoleDto> GetRoleByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Role ID cannot be empty", nameof(id));
        }
        var role = await _roleRepository.GetRoleByIdAsync(id);

        return _mapper.Map<RoleDto>(role);
    }

    public async Task UpdateRole(Guid Id,UpdateRoleCommand roleCommand)
    {
        if (roleCommand == null)
        {
            throw new ArgumentNullException(nameof(roleCommand), "Role command cannot be null");
        }

        var role = await _roleRepository.GetRoleByIdAsync(Id);

        if (role == null)
        {
            throw new KeyNotFoundException("Role not found");
        }

        if (roleCommand.Name != role.Name)
        {
            role.Name = roleCommand.Name;
            await _roleRepository.UpdateRoleAsync(role);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
