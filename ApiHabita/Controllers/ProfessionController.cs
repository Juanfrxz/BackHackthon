using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.Profession;
using AutoMapper;

public class ProfessionController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public ProfessionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProfessionDto>>> Get()
    {
        var Profession = await _unitOfWork.Professions.GetAllAsync();
        return _mapper.Map<List<ProfessionDto>>(Profession);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProfessionDto>> Get(int id)
    {
        var Profession = await _unitOfWork.Countries.GetByIdAsync(id);
        if (Profession == null)
        {
            return NotFound($"Profession with id {id} was not found.");
        }
        return _mapper.Map<ProfessionDto>(Profession);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Profession>> Post(ProfessionDto professionDto)
    {
        var profession = _mapper.Map<Profession>(professionDto);
        _unitOfWork.Professions.Add(profession);
        await _unitOfWork.SaveAsync();
        if (professionDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = professionDto.Id }, professionDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] ProfessionDto professionDto)
    {
        // Validación: objeto nulo
        if (professionDto == null)
            return NotFound();
        var profession = _mapper.Map<Profession>(professionDto);
        _unitOfWork.Professions.Update(profession);
        await _unitOfWork.SaveAsync();
        return Ok(professionDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Profession = await _unitOfWork.Professions.GetByIdAsync(id);
        if (Profession == null)
            return NotFound();
        _unitOfWork.Professions.Remove(Profession);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}