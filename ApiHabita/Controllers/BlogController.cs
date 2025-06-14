using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiHabita.Controllers;
using Application.DTOs;
using Application.DTOs.Blog;
using AutoMapper;

public class BlogController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork; //<- Se inyecta la unidad de trabajo
    private readonly IMapper _mapper; //<- Se inyecta el mapeador de AutoMapper
    public BlogController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<BlogDto>>> Get()
    {
        var Blog = await _unitOfWork.Blogs.GetAllAsync();
        return _mapper.Map<List<BlogDto>>(Blog);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BlogDto>> Get(int id)
    {
        var Blog = await _unitOfWork.Blogs.GetByIdAsync(id);
        if (Blog == null)
        {
            return NotFound($"Blog with id {id} was not found.");
        }
        return _mapper.Map<BlogDto>(Blog);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Blog>> Post(BlogDto blogDto)
    {
        var blog = _mapper.Map<Blog>(blogDto);
        _unitOfWork.Blogs.Add(blog);
        await _unitOfWork.SaveAsync();
        if (blogDto == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = blogDto.Id }, blogDto);
    }

    // PUT: api/Productos/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] BlogDto blogDto)
    {
        // Validación: objeto nulo
        if (blogDto == null)
            return NotFound();
        var blog = _mapper.Map<Blog>(blogDto);
        _unitOfWork.Blogs.Update(blog);
        await _unitOfWork.SaveAsync();
        return Ok(blogDto);
    }
    
    //DELETE: api/Productos
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Blog = await _unitOfWork.Blogs.GetByIdAsync(id);
        if (Blog == null)
            return NotFound();
        _unitOfWork.Blogs.Remove(Blog);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}