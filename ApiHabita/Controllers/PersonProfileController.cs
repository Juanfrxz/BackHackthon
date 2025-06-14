using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.PersonProfile;
using AutoMapper;

public class PersonProfileController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public PersonProfileController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonProfileDto>>> Get()
    {
        var PersonProfile = await _unitOfWork.PersonProfiles.GetAllAsync();
        return _mapper.Map<List<PersonProfileDto>>(PersonProfile);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonProfileDto>> Get(int id)
    {
        var PersonProfile = await _unitOfWork.PersonProfiles.GetByIdAsync(id);
        if (PersonProfile == null)
        {
            return NotFound($"PersonProfile with id {id} was not found.");
        }
        return _mapper.Map<PersonProfileDto>(PersonProfile);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonProfile>> Post(PersonProfileDto personProfileDto)
    {
        var personProfile = _mapper.Map<PersonProfile>(personProfileDto);
        _unitOfWork.PersonProfiles.Add(personProfile);
        await _unitOfWork.SaveAsync();
        if (personProfileDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = personProfileDto.Id }, personProfileDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] PersonProfileDto personProfileDto)
    {
        // Validación: objeto nulo
        if (personProfileDto == null)
            return NotFound();
        var personProfile = _mapper.Map<PersonProfile>(personProfileDto);
        _unitOfWork.PersonProfiles.Update(personProfile);
        await _unitOfWork.SaveAsync();
        return Ok(personProfileDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var PersonProfile = await _unitOfWork.PersonProfiles.GetByIdAsync(id);
        if (PersonProfile == null)
            return NotFound();
        _unitOfWork.PersonProfiles.Remove(PersonProfile);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}