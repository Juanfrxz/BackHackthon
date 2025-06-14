using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.Role;
using AutoMapper;
using Domain.Entities.Auth;

public class RoleController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public RoleController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RoleDto>>> Get()
    {
        var Role = await _unitOfWork.Roles.GetAllAsync();
        return _mapper.Map<List<RoleDto>>(Role);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RoleDto>> Get(int id)
    {
        var Role = await _unitOfWork.Roles.GetByIdAsync(id);
        if (Role == null)
        {
            return NotFound($"Role with id {id} was not found.");
        }
        return _mapper.Map<RoleDto>(Role);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Role>> Post(RoleDto roleDto)
    {
        var role = _mapper.Map<Role>(roleDto);
        _unitOfWork.Roles.Add(role);
        await _unitOfWork.SaveAsync();
        if (roleDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = roleDto.Id }, roleDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] RoleDto roleDto)
    {
        // Validación: objeto nulo
        if (roleDto == null)
            return NotFound();
        var role = _mapper.Map<Role>(roleDto);
        _unitOfWork.Roles.Update(role);
        await _unitOfWork.SaveAsync();
        return Ok(roleDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Role = await _unitOfWork.Roles.GetByIdAsync(id);
        if (Role == null)
            return NotFound();
        _unitOfWork.Roles.Remove(Role);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}