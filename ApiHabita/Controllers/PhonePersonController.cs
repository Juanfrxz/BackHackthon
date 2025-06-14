using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.PhonePerson;
using AutoMapper;

public class PhonePersonController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public PhonePersonController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PhonePersonDto>>> Get()
    {
        var PhonePerson = await _unitOfWork.PhonePersons.GetAllAsync();
        return _mapper.Map<List<PhonePersonDto>>(PhonePerson);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PhonePersonDto>> Get(int id)
    {
        var PhonePerson = await _unitOfWork.PhonePersons.GetByIdAsync(id);
        if (PhonePerson == null)
        {
            return NotFound($"PhonePerson with id {id} was not found.");
        }
        return _mapper.Map<PhonePersonDto>(PhonePerson);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PhonePerson>> Post(PhonePersonDto phonePersonDto)
    {
        var phonePerson = _mapper.Map<PhonePerson>(phonePersonDto);
        _unitOfWork.PhonePersons.Add(phonePerson);
        await _unitOfWork.SaveAsync();
        if (phonePersonDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = phonePersonDto.Id }, phonePersonDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] PhonePersonDto phonePersonDto)
    {
        // Validación: objeto nulo
        if (phonePersonDto == null)
            return NotFound();
        var phonePerson = _mapper.Map<PhonePerson>(phonePersonDto);
        _unitOfWork.PhonePersons.Update(phonePerson);
        await _unitOfWork.SaveAsync();
        return Ok(phonePersonDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var PhonePerson = await _unitOfWork.PhonePersons.GetByIdAsync(id);
        if (PhonePerson == null)
            return NotFound();
        _unitOfWork.PhonePersons.Remove(PhonePerson);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}