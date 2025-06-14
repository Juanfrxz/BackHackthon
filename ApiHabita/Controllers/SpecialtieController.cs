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
        return Ok(_mapper.Map<List<SpecialtieDto>>(Specialtie));
    }

    [HttpGet("{specialtyId:int}/{professionalId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SpecialtieDto>> Get(int specialtyId, int professionalId)
    {
        var Specialtie = await _unitOfWork.Specialties.GetByIdsAsync(specialtyId, professionalId);
        if (Specialtie == null)
            return NotFound($"Specialtie with keys ({specialtyId}, {professionalId}) not found.");

        return Ok(_mapper.Map<SpecialtieDto>(Specialtie));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SpecialtieDto>> Post([FromBody] SpecialtieDto specialtieDto)
    {
        var specialtie = _mapper.Map<Specialtie>(specialtieDto);
        _unitOfWork.Specialties.Add(specialtie);
        await _unitOfWork.SaveAsync();
        if (specialtieDto == null)
            return BadRequest();

        return CreatedAtAction(nameof(Get), new { specialtyId = specialtieDto.SpecialtyId, professionalId = specialtieDto.ProfessionalId }, specialtieDto);
    }

    [HttpPut("{specialtyId:int}/{professionalId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int specialtyId, int professionalId, [FromBody] SpecialtieDto specialtieDto)
    {
        if (specialtieDto == null || specialtieDto.SpecialtyId != specialtyId || specialtieDto.ProfessionalId != professionalId)
            return BadRequest("Mismatched or invalid data.");
        var existing = await _unitOfWork.Specialties.GetByIdsAsync(specialtyId, professionalId);
        if (existing == null)
            return NotFound();
        var specialtie = _mapper.Map<Specialtie>(specialtieDto);
        _unitOfWork.Specialties.Update(specialtie);
        await _unitOfWork.SaveAsync();
        return Ok(specialtieDto);
    }

    [HttpDelete("{specialtyId:int}/{professionalId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int specialtyId, int professionalId)
    {
        var Specialtie = await _unitOfWork.Specialties.GetByIdsAsync(specialtyId, professionalId);
        if (Specialtie == null)
            return NotFound();
        _unitOfWork.Specialties.Remove(Specialtie);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}