using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.RefreshToken;
using AutoMapper;

public class RefreshTokenController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public RefreshTokenController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RefreshTokenDto>>> Get()
    {
        var RefreshToken = await _unitOfWork.RefreshTokens.GetAllAsync();
        return _mapper.Map<List<RefreshTokenDto>>(RefreshToken);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RefreshTokenDto>> Get(int id)
    {
        var RefreshToken = await _unitOfWork.RefreshTokens.GetByIdAsync(id);
        if (RefreshToken == null)
        {
            return NotFound($"RefreshToken with id {id} was not found.");
        }
        return _mapper.Map<RefreshTokenDto>(RefreshToken);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RefreshToken>> Post(RefreshTokenDto refreshTokenDto)
    {
        var refreshToken = _mapper.Map<RefreshToken>(refreshTokenDto);
        _unitOfWork.RefreshTokens.Add(refreshToken);
        await _unitOfWork.SaveAsync();
        if (refreshTokenDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = refreshTokenDto.Id }, refreshTokenDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] RefreshTokenDto refreshTokenDto)
    {
        // Validación: objeto nulo
        if (refreshTokenDto == null)
            return NotFound();
        var refreshToken = _mapper.Map<RefreshToken>(refreshTokenDto);
        _unitOfWork.RefreshTokens.Update(refreshToken);
        await _unitOfWork.SaveAsync();
        return Ok(refreshTokenDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var RefreshToken = await _unitOfWork.RefreshTokens.GetByIdAsync(id);
        if (RefreshToken == null)
            return NotFound();
        _unitOfWork.RefreshTokens.Remove(RefreshToken);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}