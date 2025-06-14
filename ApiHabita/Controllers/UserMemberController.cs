using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.UserMember;
using AutoMapper;
using Domain.Entities.Auth;

public class UserMemberController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
        public UserMemberController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<UserMemberDto>>> Get()
    {
        var UserMember = await _unitOfWork.UserMembers.GetAllAsync();
        return _mapper.Map<List<UserMemberDto>>(UserMember);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserMemberDto>> Get(int id)
    {
        var UserMember = await _unitOfWork.UserMembers.GetByIdAsync(id);
        if (UserMember == null)
        {
            return NotFound($"UserMember with id {id} was not found.");
        }
        return _mapper.Map<UserMemberDto>(UserMember);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserMember>> Post(UserMemberDto userMemberDto)
    {
        var userMember = _mapper.Map<UserMember>(userMemberDto);
        _unitOfWork.UserMembers.Add(userMember);
        await _unitOfWork.SaveAsync();
        if (userMemberDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = userMemberDto.Id }, userMemberDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] UserMemberDto userMemberDto)
    {
        // Validación: objeto nulo
        if (userMemberDto == null)
            return NotFound();
        var userMember = _mapper.Map<UserMember>(userMemberDto);
        _unitOfWork.UserMembers.Update(userMember);
        await _unitOfWork.SaveAsync();
        return Ok(userMemberDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var UserMember = await _unitOfWork.UserMembers.GetByIdAsync(id);
        if (UserMember == null)
            return NotFound();
        _unitOfWork.UserMembers.Remove(UserMember);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}