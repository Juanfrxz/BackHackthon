using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.City;
using AutoMapper;

public class CityController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public CityController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CityDto>>> Get()
    {
        var City = await _unitOfWork.Cities.GetAllAsync();
        return _mapper.Map<List<CityDto>>(City);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CityDto>> Get(int id)
    {
        var City = await _unitOfWork.Cities.GetByIdAsync(id);
        if (City == null)
        {
            return NotFound($"City with id {id} was not found.");
        }
        return _mapper.Map<CityDto>(City);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<City>> Post(CityDto cityDto)
    {
        var city = _mapper.Map<City>(cityDto);
        _unitOfWork.Cities.Add(city);
        await _unitOfWork.SaveAsync();
        if (cityDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = cityDto.Id }, cityDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] CityDto cityDto)
    {
        // Validación: objeto nulo
        if (cityDto == null)
            return NotFound();
        var city = _mapper.Map<City>(cityDto);
        _unitOfWork.Cities.Update(city);
        await _unitOfWork.SaveAsync();
        return Ok(cityDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var City = await _unitOfWork.Cities.GetByIdAsync(id);
        if (City == null)
            return NotFound();
        _unitOfWork.Cities.Remove(City);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}