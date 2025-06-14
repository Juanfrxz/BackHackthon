using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.PersonType;
using AutoMapper;

public class PersonTypeController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public PersonTypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonTypeDto>>> Get()
    {
        var PersonType = await _unitOfWork.PersonTypes.GetAllAsync();
        return _mapper.Map<List<PersonTypeDto>>(PersonType);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonTypeDto>> Get(int id)
    {
        var PersonType = await _unitOfWork.Countries.GetByIdAsync(id);
        if (PersonType == null)
        {
            return NotFound($"PersonType with id {id} was not found.");
        }
        return _mapper.Map<PersonTypeDto>(PersonType);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonType>> Post(PersonTypeDto personTypeDto)
    {
        var personType = _mapper.Map<PersonType>(personTypeDto);
        _unitOfWork.PersonTypes.Add(personType);
        await _unitOfWork.SaveAsync();
        if (personTypeDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = personTypeDto.Id }, personTypeDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] PersonTypeDto personTypeDto)
    {
        // Validación: objeto nulo
        if (personTypeDto == null)
            return NotFound();
        var personType = _mapper.Map<PersonType>(personTypeDto);
        _unitOfWork.PersonTypes.Update(personType);
        await _unitOfWork.SaveAsync();
        return Ok(personTypeDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var PersonType = await _unitOfWork.PersonTypes.GetByIdAsync(id);
        if (PersonType == null)
            return NotFound();
        _unitOfWork.PersonTypes.Remove(PersonType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}