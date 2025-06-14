using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.Professional;
using AutoMapper;

public class ProfessionalController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public ProfessionalController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProfessionalDto>>> Get()
    {
        var Professional = await _unitOfWork.Professionals.GetAllAsync();
        return _mapper.Map<List<ProfessionalDto>>(Professional);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProfessionalDto>> Get(int id)
    {
        var Professional = await _unitOfWork.Professionals.GetByIdAsync(id);
        if (Professional == null)
        {
            return NotFound($"Professional with id {id} was not found.");
        }
        return _mapper.Map<ProfessionalDto>(Professional);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Professional>> Post(ProfessionalDto professionalDto)
    {
        var professional = _mapper.Map<Professional>(professionalDto);
        _unitOfWork.Professionals.Add(professional);
        await _unitOfWork.SaveAsync();
        if (professionalDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = professionalDto.Id }, professionalDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] ProfessionalDto professionalDto)
    {
        // Validación: objeto nulo
        if (professionalDto == null)
            return NotFound();
        var professional = _mapper.Map<Professional>(professionalDto);
        _unitOfWork.Professionals.Update(professional);
        await _unitOfWork.SaveAsync();
        return Ok(professionalDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Professional = await _unitOfWork.Professionals.GetByIdAsync(id);
        if (Professional == null)
            return NotFound();
        _unitOfWork.Professionals.Remove(Professional);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}