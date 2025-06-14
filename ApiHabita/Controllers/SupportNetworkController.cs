using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.SupportNetwork;
using AutoMapper;

public class SupportNetworkController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public SupportNetworkController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SupportNetworkDto>>> Get()
    {
        var SupportNetwork = await _unitOfWork.SupportNetworks.GetAllAsync();
        return _mapper.Map<List<SupportNetworkDto>>(SupportNetwork);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SupportNetworkDto>> Get(int id)
    {
        var SupportNetwork = await _unitOfWork.Countries.GetByIdAsync(id);
        if (SupportNetwork == null)
        {
            return NotFound($"SupportNetwork with id {id} was not found.");
        }
        return _mapper.Map<SupportNetworkDto>(SupportNetwork);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SupportNetwork>> Post(SupportNetworkDto supportNetworkDto)
    {
        var supportNetwork = _mapper.Map<SupportNetwork>(supportNetworkDto);
        _unitOfWork.SupportNetworks.Add(supportNetwork);
        await _unitOfWork.SaveAsync();
        if (supportNetworkDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = supportNetworkDto.Id }, supportNetworkDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] SupportNetworkDto supportNetworkDto)
    {
        // Validación: objeto nulo
        if (supportNetworkDto == null)
            return NotFound();
        var supportNetwork = _mapper.Map<SupportNetwork>(supportNetworkDto);
        _unitOfWork.SupportNetworks.Update(supportNetwork);
        await _unitOfWork.SaveAsync();
        return Ok(supportNetworkDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var SupportNetwork = await _unitOfWork.SupportNetworks.GetByIdAsync(id);
        if (SupportNetwork == null)
            return NotFound();
        _unitOfWork.SupportNetworks.Remove(SupportNetwork);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}