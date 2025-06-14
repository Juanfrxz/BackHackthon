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
        return Ok(_mapper.Map<List<ConstituentDto>>(Constituent));
    }

    [HttpGet("{supportnetworkId:int}/{priorityLevelId:int}/{typeRelationId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ConstituentDto>> Get(int supportnetworkId, int priorityLevelId, int typeRelationId)
    {
        var Constituent = await _unitOfWork.Constituents.GetByIdsAsync(supportnetworkId, priorityLevelId, typeRelationId);
        if (Constituent == null)
            return NotFound($"Constituent with keys ({supportnetworkId}, {priorityLevelId}, {typeRelationId}) not found.");

        return Ok(_mapper.Map<ConstituentDto>(Constituent));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ConstituentDto>> Post([FromBody] ConstituentDto constituentDto)
    {
        var constituent = _mapper.Map<Constituent>(constituentDto);
        _unitOfWork.Constituents.Add(constituent);
        await _unitOfWork.SaveAsync();
        if (constituentDto == null)
            return BadRequest();

        return CreatedAtAction(nameof(Get), new { supportnetworkId = constituentDto.SupportnetworkId, priorityLevelId = constituentDto.PriorityLevelId, typeRelationId = constituentDto.TypeRelationId }, constituentDto);
    }

    [HttpPut("{supportnetworkId:int}/{priorityLevelId:int}/{typeRelationId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int supportnetworkId, int priorityLevelId, int typeRelationId, [FromBody] ConstituentDto constituentDto)
    {
        if (constituentDto == null || constituentDto.SupportnetworkId != supportnetworkId || constituentDto.PersonprofileId != priorityLevelId || constituentDto.TypeRelationId != typeRelationId)
            return BadRequest("Mismatched or invalid data.");
        var existing = await _unitOfWork.Constituents.GetByIdsAsync(supportnetworkId, priorityLevelId, typeRelationId);
        if (existing == null)
            return NotFound();
        var constituent = _mapper.Map<Constituent>(constituentDto);
        _unitOfWork.Constituents.Update(constituent);
        await _unitOfWork.SaveAsync();
        return Ok(constituentDto);
    }

    [HttpDelete("{supportnetworkId:int}/{priorityLevelId:int}/{typeRelationId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int supportnetworkId, int priorityLevelId, int typeRelationId)
    {
        var Constituent = await _unitOfWork.Constituents.GetByIdsAsync(supportnetworkId, priorityLevelId, typeRelationId);
        if (Constituent == null)
            return NotFound();
        _unitOfWork.Constituents.Remove(Constituent);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}