using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.Habit;
using AutoMapper;

public class HabitController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public HabitController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<HabitDto>>> Get()
    {
        var Habit = await _unitOfWork.Habits.GetAllAsync();
        return _mapper.Map<List<HabitDto>>(Habit);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<HabitDto>> Get(int id)
    {
        var Habit = await _unitOfWork.Habits.GetByIdAsync(id);
        if (Habit == null)
        {
            return NotFound($"Habit with id {id} was not found.");
        }
        return _mapper.Map<HabitDto>(Habit);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Habit>> Post(HabitDto habitDto)
    {
        var habit = _mapper.Map<Habit>(habitDto);
        _unitOfWork.Habits.Add(habit);
        await _unitOfWork.SaveAsync();
        if (habitDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = habitDto.Id }, habitDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] HabitDto habitDto)
    {
        // Validación: objeto nulo
        if (habitDto == null)
            return NotFound();
        var habit = _mapper.Map<Habit>(habitDto);
        _unitOfWork.Habits.Update(habit);
        await _unitOfWork.SaveAsync();
        return Ok(habitDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Habit = await _unitOfWork.Habits.GetByIdAsync(id);
        if (Habit == null)
            return NotFound();
        _unitOfWork.Habits.Remove(Habit);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}