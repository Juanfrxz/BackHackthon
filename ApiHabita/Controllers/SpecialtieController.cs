using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.Specialtie;
using AutoMapper;

public class SpecialtieController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public SpecialtieController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SpecialtieDto>>> Get()
    {
        var Specialtie = await _unitOfWork.Specialties.GetAllAsync();
        return _mapper.Map<List<SpecialtieDto>>(Specialtie);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SpecialtieDto>> Get(int id)
    {
        var Specialtie = await _unitOfWork.Specialties.GetByIdAsync(id);
        if (Specialtie == null)
        {
            return NotFound($"Specialtie with id {id} was not found.");
        }
        return _mapper.Map<SpecialtieDto>(Specialtie);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Specialtie>> Post(SpecialtieDto specialtieDto)
    {
        var specialtie = _mapper.Map<Specialtie>(specialtieDto);
        _unitOfWork.Specialties.Add(specialtie);
        await _unitOfWork.SaveAsync();
        if (specialtieDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = specialtieDto.Id }, specialtieDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] SpecialtieDto specialtieDto)
    {
        // Validación: objeto nulo
        if (specialtieDto == null)
            return NotFound();
        var specialtie = _mapper.Map<Specialtie>(specialtieDto);
        _unitOfWork.Specialties.Update(specialtie);
        await _unitOfWork.SaveAsync();
        return Ok(specialtieDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Specialtie = await _unitOfWork.Specialties.GetByIdAsync(id);
        if (Specialtie == null)
            return NotFound();
        _unitOfWork.Specialties.Remove(Specialtie);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}