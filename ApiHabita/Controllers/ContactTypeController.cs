using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.ContactType;
using AutoMapper;

public class ContactTypeController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public ContactTypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactTypeDto>>> Get()
    {
        var ContactType = await _unitOfWork.ContactTypes.GetAllAsync();
        return _mapper.Map<List<ContactTypeDto>>(ContactType);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactTypeDto>> Get(int id)
    {
        var ContactType = await _unitOfWork.ContactTypes.GetByIdAsync(id);
        if (ContactType == null)
        {
            return NotFound($"ContactType with id {id} was not found.");
        }
        return _mapper.Map<ContactTypeDto>(ContactType);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactType>> Post(ContactTypeDto contactTypeDto)
    {
        var contactType = _mapper.Map<ContactType>(contactTypeDto);
        _unitOfWork.ContactTypes.Add(contactType);
        await _unitOfWork.SaveAsync();
        if (contactTypeDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = contactTypeDto.Id }, contactTypeDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] ContactTypeDto contactTypeDto)
    {
        // Validación: objeto nulo
        if (contactTypeDto == null)
            return NotFound();
        var contactType = _mapper.Map<ContactType>(contactTypeDto);
        _unitOfWork.ContactTypes.Update(contactType);
        await _unitOfWork.SaveAsync();
        return Ok(contactTypeDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var ContactType = await _unitOfWork.ContactTypes.GetByIdAsync(id);
        if (ContactType == null)
            return NotFound();
        _unitOfWork.ContactTypes.Remove(ContactType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}