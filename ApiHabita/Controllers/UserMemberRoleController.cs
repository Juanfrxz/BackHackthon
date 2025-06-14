using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.UserMemberRole;
using AutoMapper;
using Domain.Entities.Auth;

public class UserMemberRoleController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public UserMemberRoleController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<UserMemberRoleDto>>> Get()
    {
        var UserMemberRole = await _unitOfWork.UserMemberRoles.GetAllAsync();
        return Ok(_mapper.Map<List<UserMemberRoleDto>>(UserMemberRole));
    }

    [HttpGet("{userMemberId:int}/{roleId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserMemberRoleDto>> Get(int userMemberId, int roleId)
    {
        var UserMemberRole = await _unitOfWork.UserMemberRoles.GetByIdsAsync(userMemberId, roleId);
        if (UserMemberRole == null)
            return NotFound($"UserMemberRole with keys ({userMemberId}, {roleId}) not found.");

        return Ok(_mapper.Map<UserMemberRoleDto>(UserMemberRole));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserMemberRoleDto>> Post([FromBody] UserMemberRoleDto userMemberRoleDto)
    {
        var userMemberRole = _mapper.Map<UserMemberRole>(userMemberRoleDto);
        _unitOfWork.UserMemberRoles.Add(userMemberRole);
        await _unitOfWork.SaveAsync();
        if (userMemberRoleDto == null)
            return BadRequest();

        return CreatedAtAction(nameof(Get), new { userMemberIdId = userMemberRoleDto.UserMemberId, roleId = userMemberRoleDto.RoleId }, userMemberRoleDto);
    }

    [HttpPut("{userMemberId:int}/{roleId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int userMemberId, int roleId, [FromBody] UserMemberRoleDto userMemberRoleDto)
    {
        if (userMemberRoleDto == null || userMemberRoleDto.UserMemberId != userMemberId || userMemberRoleDto.RoleId != roleId)
            return BadRequest("Mismatched or invalid data.");
        var existing = await _unitOfWork.UserMemberRoles.GetByIdsAsync(userMemberId, roleId);
        if (existing == null)
            return NotFound();
        var userMemberRole = _mapper.Map<UserMemberRole>(userMemberRoleDto);
        _unitOfWork.UserMemberRoles.Update(userMemberRole);
        await _unitOfWork.SaveAsync();
        return Ok(userMemberRoleDto);
    }

    [HttpDelete("{userMemberId:int}/{roleId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int userMemberId, int roleId)
    {
        var UserMemberRole = await _unitOfWork.UserMemberRoles.GetByIdsAsync(userMemberId, roleId);
        if (UserMemberRole == null)
            return NotFound();
        _unitOfWork.UserMemberRoles.Remove(UserMemberRole);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}