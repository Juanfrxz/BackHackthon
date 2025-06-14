using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.Country;
using AutoMapper;

public class CountryController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public CountryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CountryDto>>> Get()
    {
        var Country = await _unitOfWork.Countries.GetAllAsync();
        return _mapper.Map<List<CountryDto>>(Country);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CountryDto>> Get(int id)
    {
        var Country = await _unitOfWork.Countries.GetByIdAsync(id);
        if (Country == null)
        {
            return NotFound($"Country with id {id} was not found.");
        }
        return _mapper.Map<CountryDto>(Country);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Post(CountryDto countryDto)
    {
        var country = _mapper.Map<Country>(countryDto);
        _unitOfWork.Countries.Add(country);
        await _unitOfWork.SaveAsync();
        if (countryDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = countryDto.Id }, countryDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] CountryDto countryDto)
    {
        // Validación: objeto nulo
        if (countryDto == null)
            return NotFound();
        var country = _mapper.Map<Country>(countryDto);
        _unitOfWork.Countries.Update(country);
        await _unitOfWork.SaveAsync();
        return Ok(countryDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Country = await _unitOfWork.Countries.GetByIdAsync(id);
        if (Country == null)
            return NotFound();
        _unitOfWork.Countries.Remove(Country);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}