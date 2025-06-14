using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.RiskType;
using AutoMapper;

public class RiskTypeController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public RiskTypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RiskTypeDto>>> Get()
    {
        var RiskType = await _unitOfWork.RiskTypes.GetAllAsync();
        return _mapper.Map<List<RiskTypeDto>>(RiskType);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RiskTypeDto>> Get(int id)
    {
        var RiskType = await _unitOfWork.RiskTypes.GetByIdAsync(id);
        if (RiskType == null)
        {
            return NotFound($"RiskType with id {id} was not found.");
        }
        return _mapper.Map<RiskTypeDto>(RiskType);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RiskType>> Post(RiskTypeDto riskTypeDto)
    {
        var riskType = _mapper.Map<RiskType>(riskTypeDto);
        _unitOfWork.RiskTypes.Add(riskType);
        await _unitOfWork.SaveAsync();
        if (riskTypeDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = riskTypeDto.Id }, riskTypeDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] RiskTypeDto riskTypeDto)
    {
        // Validación: objeto nulo
        if (riskTypeDto == null)
            return NotFound();
        var riskType = _mapper.Map<RiskType>(riskTypeDto);
        _unitOfWork.RiskTypes.Update(riskType);
        await _unitOfWork.SaveAsync();
        return Ok(riskTypeDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var RiskType = await _unitOfWork.RiskTypes.GetByIdAsync(id);
        if (RiskType == null)
            return NotFound();
        _unitOfWork.RiskTypes.Remove(RiskType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}