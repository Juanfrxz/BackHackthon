using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.EmotionalCategory;
using AutoMapper;

public class EmotionalCaterogyController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public EmotionalCaterogyController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmotionalCategoryDto>>> Get()
    {
        var EmotionalCaterogy = await _unitOfWork.EmotionalCategories.GetAllAsync();
        return _mapper.Map<List<EmotionalCategoryDto>>(EmotionalCaterogy);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmotionalCategoryDto>> Get(int id)
    {
        var EmotionalCategory = await _unitOfWork.EmotionalCategories.GetByIdAsync(id);
        if (EmotionalCategory == null)
        {
            return NotFound($"EmotionalCategory with id {id} was not found.");
        }
        return _mapper.Map<EmotionalCategoryDto>(EmotionalCategory);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmotionalCategory>> Post(EmotionalCategoryDto emotionalCategoryDto)
    {
        var emotionalCategory = _mapper.Map<EmotionalCategory>(emotionalCategoryDto);
        _unitOfWork.EmotionalCategories.Add(emotionalCategory);
        await _unitOfWork.SaveAsync();
        if (emotionalCategoryDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = emotionalCategoryDto.Id }, emotionalCategoryDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] EmotionalCategoryDto emotionalCategoryDto)
    {
        // Validación: objeto nulo
        if (emotionalCategoryDto == null)
            return NotFound();
        var emotionalCategory = _mapper.Map<EmotionalCategory>(emotionalCategoryDto);
        _unitOfWork.EmotionalCategories.Update(emotionalCategory);
        await _unitOfWork.SaveAsync();
        return Ok(emotionalCategoryDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var EmotionalCategory = await _unitOfWork.EmotionalCategories.GetByIdAsync(id);
        if (EmotionalCategory == null)
            return NotFound();
        _unitOfWork.EmotionalCategories.Remove(EmotionalCategory);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}