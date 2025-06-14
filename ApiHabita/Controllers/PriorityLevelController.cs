using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.PriorityLevel;
using AutoMapper;

public class PriorityLevelController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public PriorityLevelController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PriorityLevelDto>>> Get()
    {
        var PriorityLevel = await _unitOfWork.PriorityLevels.GetAllAsync();
        return _mapper.Map<List<PriorityLevelDto>>(PriorityLevel);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PriorityLevelDto>> Get(int id)
    {
        var PriorityLevel = await _unitOfWork.Countries.GetByIdAsync(id);
        if (PriorityLevel == null)
        {
            return NotFound($"PriorityLevel with id {id} was not found.");
        }
        return _mapper.Map<PriorityLevelDto>(PriorityLevel);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PriorityLevel>> Post(PriorityLevelDto priorityLevelDto)
    {
        var priorityLevel = _mapper.Map<PriorityLevel>(priorityLevelDto);
        _unitOfWork.PriorityLevels.Add(priorityLevel);
        await _unitOfWork.SaveAsync();
        if (priorityLevelDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = priorityLevelDto.Id }, priorityLevelDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] PriorityLevelDto priorityLevelDto)
    {
        // Validación: objeto nulo
        if (priorityLevelDto == null)
            return NotFound();
        var priorityLevel = _mapper.Map<PriorityLevel>(priorityLevelDto);
        _unitOfWork.PriorityLevels.Update(priorityLevel);
        await _unitOfWork.SaveAsync();
        return Ok(priorityLevelDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var PriorityLevel = await _unitOfWork.PriorityLevels.GetByIdAsync(id);
        if (PriorityLevel == null)
            return NotFound();
        _unitOfWork.PriorityLevels.Remove(PriorityLevel);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}