using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.TypeRelation;
using AutoMapper;

public class TypeRelationController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public TypeRelationController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TypeRelationDto>>> Get()
    {
        var TypeRelation = await _unitOfWork.TypeRelations.GetAllAsync();
        return _mapper.Map<List<TypeRelationDto>>(TypeRelation);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TypeRelationDto>> Get(int id)
    {
        var TypeRelation = await _unitOfWork.Countries.GetByIdAsync(id);
        if (TypeRelation == null)
        {
            return NotFound($"TypeRelation with id {id} was not found.");
        }
        return _mapper.Map<TypeRelationDto>(TypeRelation);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TypeRelation>> Post(TypeRelationDto typeRelationDto)
    {
        var typeRelation = _mapper.Map<TypeRelation>(typeRelationDto);
        _unitOfWork.TypeRelations.Add(typeRelation);
        await _unitOfWork.SaveAsync();
        if (typeRelationDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = typeRelationDto.Id }, typeRelationDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] TypeRelationDto typeRelationDto)
    {
        // Validación: objeto nulo
        if (typeRelationDto == null)
            return NotFound();
        var typeRelation = _mapper.Map<TypeRelation>(typeRelationDto);
        _unitOfWork.TypeRelations.Update(typeRelation);
        await _unitOfWork.SaveAsync();
        return Ok(typeRelationDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var TypeRelation = await _unitOfWork.TypeRelations.GetByIdAsync(id);
        if (TypeRelation == null)
            return NotFound();
        _unitOfWork.TypeRelations.Remove(TypeRelation);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}