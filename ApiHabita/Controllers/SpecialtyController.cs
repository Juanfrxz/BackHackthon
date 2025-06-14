using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.Specialty;
using AutoMapper;

public class SpecialtyController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public SpecialtyController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SpecialtyDto>>> Get()
    {
        var Specialty = await _unitOfWork.Specialtys.GetAllAsync();
        return _mapper.Map<List<SpecialtyDto>>(Specialty);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SpecialtyDto>> Get(int id)
    {
        var Specialty = await _unitOfWork.Specialtys.GetByIdAsync(id);
        if (Specialty == null)
        {
            return NotFound($"Specialty with id {id} was not found.");
        }
        return _mapper.Map<SpecialtyDto>(Specialty);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Specialty>> Post(SpecialtyDto specialtyDto)
    {
        var specialty = _mapper.Map<Specialty>(specialtyDto);
        _unitOfWork.Specialtys.Add(specialty);
        await _unitOfWork.SaveAsync();
        if (specialtyDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = specialtyDto.Id }, specialtyDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] SpecialtyDto specialtyDto)
    {
        // Validación: objeto nulo
        if (specialtyDto == null)
            return NotFound();
        var specialty = _mapper.Map<Specialty>(specialtyDto);
        _unitOfWork.Specialtys.Update(specialty);
        await _unitOfWork.SaveAsync();
        return Ok(specialtyDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Specialty = await _unitOfWork.Specialtys.GetByIdAsync(id);
        if (Specialty == null)
            return NotFound();
        _unitOfWork.Specialtys.Remove(Specialty);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}