using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.Region;
using AutoMapper;

public class RegionController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public RegionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RegionDto>>> Get()
    {
        var Region = await _unitOfWork.Regions.GetAllAsync();
        return _mapper.Map<List<RegionDto>>(Region);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RegionDto>> Get(int id)
    {
        var Region = await _unitOfWork.Regions.GetByIdAsync(id);
        if (Region == null)
        {
            return NotFound($"Region with id {id} was not found.");
        }
        return _mapper.Map<RegionDto>(Region);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Post(RegionDto regionDto)
    {
        var region = _mapper.Map<Country>(regionDto);
        _unitOfWork.Countries.Add(region);
        await _unitOfWork.SaveAsync();
        if (regionDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = regionDto.Id }, regionDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] RegionDto regionDto)
    {
        // Validación: objeto nulo
        if (regionDto == null)
            return NotFound();
        var region = _mapper.Map<Region>(regionDto);
        _unitOfWork.Regions.Update(region);
        await _unitOfWork.SaveAsync();
        return Ok(regionDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Region = await _unitOfWork.Regions.GetByIdAsync(id);
        if (Region == null)
            return NotFound();
        _unitOfWork.Regions.Remove(Region);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}