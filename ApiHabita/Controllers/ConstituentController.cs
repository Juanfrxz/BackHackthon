using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.Constituent;
using AutoMapper;

public class ConstituentController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public ConstituentController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ConstituentDto>>> Get()
    {
        var Constituent = await _unitOfWork.Constituents.GetAllAsync();
        return _mapper.Map<List<ConstituentDto>>(Constituent);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ConstituentDto>> Get(int id)
    {
        var Constituent = await _unitOfWork.Constituents.GetByIdAsync(id);
        if (Constituent == null)
        {
            return NotFound($"Constituent with id {id} was not found.");
        }
        return _mapper.Map<ConstituentDto>(Constituent);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Constituent>> Post(ConstituentDto constituentDto)
    {
        var constituent = _mapper.Map<Constituent>(constituentDto);
        _unitOfWork.Constituents.Add(constituent);
        await _unitOfWork.SaveAsync();
        if (constituentDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = constituentDto.Id }, constituentDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] ConstituentDto constituentDto)
    {
        // Validación: objeto nulo
        if (constituentDto == null)
            return NotFound();
        var constituent = _mapper.Map<Constituent>(constituentDto);
        _unitOfWork.Constituents.Update(constituent);
        await _unitOfWork.SaveAsync();
        return Ok(constituentDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Constituent = await _unitOfWork.Constituents.GetByIdAsync(id);
        if (Constituent == null)
            return NotFound();
        _unitOfWork.Constituents.Remove(Constituent);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}