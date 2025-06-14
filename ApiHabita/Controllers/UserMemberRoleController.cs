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
        return _mapper.Map<List<UserMemberRoleDto>>(UserMemberRole);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserMemberRoleDto>> Get(int id)
    {
        var UserMemberRole = await _unitOfWork.UserMemberRoles.GetByIdAsync(id);
        if (UserMemberRole == null)
        {
            return NotFound($"UserMemberRole with id {id} was not found.");
        }
        return _mapper.Map<UserMemberRoleDto>(UserMemberRole);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserMemberRole>> Post(UserMemberRoleDto userMemberRoleDto)
    {
        var userMemberRole = _mapper.Map<UserMemberRole>(userMemberRoleDto);
        _unitOfWork.UserMemberRoles.Add(userMemberRole);
        await _unitOfWork.SaveAsync();
        if (userMemberRoleDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = userMemberRoleDto.Id }, userMemberRoleDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] UserMemberRoleDto userMemberRoleDto)
    {
        // Validación: objeto nulo
        if (userMemberRoleDto == null)
            return NotFound();
        var userMemberRole = _mapper.Map<UserMemberRole>(userMemberRoleDto);
        _unitOfWork.UserMemberRoles.Update(userMemberRole);
        await _unitOfWork.SaveAsync();
        return Ok(userMemberRoleDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var UserMemberRole = await _unitOfWork.UserMemberRoles.GetByIdAsync(id);
        if (UserMemberRole == null)
            return NotFound();
        _unitOfWork.UserMemberRoles.Remove(UserMemberRole);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}