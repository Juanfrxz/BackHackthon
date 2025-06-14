using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.EmotionalType;
using AutoMapper;

public class EmotionalTypeController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public EmotionalTypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmotionalTypeDto>>> Get()
    {
        var EmotionalType = await _unitOfWork.EmotionalTypes.GetAllAsync();
        return _mapper.Map<List<EmotionalTypeDto>>(EmotionalType);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmotionalTypeDto>> Get(int id)
    {
        var EmotionalType = await _unitOfWork.EmotionalTypes.GetByIdAsync(id);
        if (EmotionalType == null)
        {
            return NotFound($"EmotionalType with id {id} was not found.");
        }
        return _mapper.Map<EmotionalTypeDto>(EmotionalType);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Post(EmotionalTypeDto emotionalTypeDto)
    {
        var emotionalType = _mapper.Map<EmotionalType>(emotionalTypeDto);
        _unitOfWork.EmotionalTypes.Add(emotionalType);
        await _unitOfWork.SaveAsync();
        if (emotionalTypeDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = emotionalTypeDto.Id }, emotionalTypeDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] EmotionalTypeDto emotionalTypeDto)
    {
        // Validación: objeto nulo
        if (emotionalTypeDto == null)
            return NotFound();
        var emotionalType = _mapper.Map<EmotionalType>(emotionalTypeDto);
        _unitOfWork.EmotionalTypes.Update(emotionalType);
        await _unitOfWork.SaveAsync();
        return Ok(emotionalTypeDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var EmotionalType = await _unitOfWork.EmotionalTypes.GetByIdAsync(id);
        if (EmotionalType == null)
            return NotFound();
        _unitOfWork.EmotionalTypes.Remove(EmotionalType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}