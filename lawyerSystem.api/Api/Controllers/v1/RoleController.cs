using lawyerSystem.api.Core.Dtos.Role;
using lawyerSystem.api.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lawyerSystem.api.Api.Controllers.v1;

[ApiController]
[Route("api/v1/[roles]")]
[Authorize(Roles = "Admin")]
public class RolesController : Controller
{
    public readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _roleService.GetAllRolesAsync();
        return Ok(roles);
    }

    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> GetRoleById(Guid Id)
    {
        var role = await _roleService.GetRoleByIdAsync(Id);

        if (role == null)
        {
            NotFound("Role command cannot be null");
        }

        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> PostRole([FromBody] CreateRoleCommand roleCommand)
    {
        if (roleCommand == null)
        {
            BadRequest("Role command cannot be null");
        }

        var newRole = await _roleService.CreateRoleAsync(roleCommand);

        return CreatedAtAction(nameof(GetRoleById), new { id = newRole.Id }, newRole);

    }

    [HttpPatch("{Id:guid}")]
    public async Task<IActionResult> UpdateRole(Guid Id, [FromBody] UpdateRoleCommand roleCommand)
    {
        if (roleCommand == null)
        {
            BadRequest("Role command cannot be null");
        }

        await _roleService.UpdateRole(Id ,roleCommand);

        return NoContent();
    }
}
