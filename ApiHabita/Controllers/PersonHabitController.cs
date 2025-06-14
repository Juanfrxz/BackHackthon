using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.PersonHabit;
using AutoMapper;

public class PersonHabitController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public PersonHabitController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonHabitDto>>> Get()
    {
        var PersonHabit = await _unitOfWork.PersonHabits.GetAllAsync();
        return _mapper.Map<List<PersonHabitDto>>(PersonHabit);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonHabitDto>> Get(int id)
    {
        var PersonHabit = await _unitOfWork.PersonHabits.GetByIdAsync(id);
        if (PersonHabit == null)
        {
            return NotFound($"PersonHabit with id {id} was not found.");
        }
        return _mapper.Map<PersonHabitDto>(PersonHabit);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonHabit>> Post(PersonHabitDto personHabitDto)
    {
        var personHabit = _mapper.Map<PersonHabit>(personHabitDto);
        _unitOfWork.PersonHabits.Add(personHabit);
        await _unitOfWork.SaveAsync();
        if (personHabitDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = personHabitDto.Id }, personHabitDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] PersonHabitDto personHabitDto)
    {
        // Validación: objeto nulo
        if (personHabitDto == null)
            return NotFound();
        var personHabit = _mapper.Map<PersonHabit>(personHabitDto);
        _unitOfWork.PersonHabits.Update(personHabit);
        await _unitOfWork.SaveAsync();
        return Ok(personHabitDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var PersonHabit = await _unitOfWork.PersonHabits.GetByIdAsync(id);
        if (PersonHabit == null)
            return NotFound();
        _unitOfWork.PersonHabits.Remove(PersonHabit);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}