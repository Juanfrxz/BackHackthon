using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.EmotionalBlog;
using AutoMapper;

public class EmotionalBlogController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public EmotionalBlogController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmotionalBlogDto>>> Get()
    {
        var EmotionalBlog = await _unitOfWork.EmotionalBlogs.GetAllAsync();
        return _mapper.Map<List<EmotionalBlogDto>>(EmotionalBlog);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmotionalBlogDto>> Get(int id)
    {
        var EmotionalBlog = await _unitOfWork.EmotionalBlogs.GetByIdAsync(id);
        if (EmotionalBlog == null)
        {
            return NotFound($"EmotionalBlog with id {id} was not found.");
        }
        return _mapper.Map<EmotionalBlogDto>(EmotionalBlog);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmotionalBlog>> Post(EmotionalBlogDto emotionalBlogDto)
    {
        var emotionalBlog = _mapper.Map<EmotionalBlog>(emotionalBlogDto);
        _unitOfWork.EmotionalBlogs.Add(emotionalBlog);
        await _unitOfWork.SaveAsync();
        if (emotionalBlogDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = emotionalBlogDto.Id }, emotionalBlogDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] EmotionalBlogDto emotionalBlogDto)
    {
        // Validación: objeto nulo
        if (emotionalBlogDto == null)
            return NotFound();
        var emotionalBlog = _mapper.Map<EmotionalBlog>(emotionalBlogDto);
        _unitOfWork.EmotionalBlogs.Update(emotionalBlog);
        await _unitOfWork.SaveAsync();
        return Ok(emotionalBlogDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var EmotionalBlog = await _unitOfWork.EmotionalBlogs.GetByIdAsync(id);
        if (EmotionalBlog == null)
            return NotFound();
        _unitOfWork.EmotionalBlogs.Remove(EmotionalBlog);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}