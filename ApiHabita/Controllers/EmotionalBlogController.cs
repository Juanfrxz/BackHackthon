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
        return Ok(_mapper.Map<List<EmotionalBlogDto>>(EmotionalBlog));
    }

    [HttpGet("{emotionalTypeId:int}/{blogId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EmotionalBlogDto>> Get(int emotionalTypeId, int blogId)
    {
        var EmotionalBlog = await _unitOfWork.EmotionalBlogs.GetByIdsAsync(emotionalTypeId, blogId);
        if (EmotionalBlog == null)
            return NotFound($"EmotionalBlog with keys ({emotionalTypeId}, {blogId}) not found.");

        return Ok(_mapper.Map<EmotionalBlogDto>(EmotionalBlog));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmotionalBlogDto>> Post([FromBody] EmotionalBlogDto emotionalBlogDto)
    {
        var emotionalBlog = _mapper.Map<EmotionalBlog>(emotionalBlogDto);
        _unitOfWork.EmotionalBlogs.Add(emotionalBlog);
        await _unitOfWork.SaveAsync();
        if (emotionalBlogDto == null)
            return BadRequest();

        return CreatedAtAction(nameof(Get), new { emotionalTypeId = emotionalBlogDto.EmotionalTypeId, blogId = emotionalBlogDto.BlogId }, emotionalBlogDto);
    }

    [HttpPut("{emotionalTypeId:int}/{blogId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int emotionalTypeId, int blogId, [FromBody] EmotionalBlogDto emotionalBlogDto)
    {
        if (emotionalBlogDto == null || emotionalBlogDto.EmotionalTypeId != emotionalTypeId || emotionalBlogDto.BlogId != blogId)
            return BadRequest("Mismatched or invalid data.");
        var existing = await _unitOfWork.EmotionalBlogs.GetByIdsAsync(emotionalTypeId, blogId);
        if (existing == null)
            return NotFound();
        var emotionalBlog = _mapper.Map<EmotionalBlog>(emotionalBlogDto);
        _unitOfWork.EmotionalBlogs.Update(emotionalBlog);
        await _unitOfWork.SaveAsync();
        return Ok(emotionalBlogDto);
    }

    [HttpDelete("{emotionalTypeId:int}/{blogId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int emotionalTypeId, int blogId)
    {
        var EmotionalBlog = await _unitOfWork.EmotionalBlogs.GetByIdsAsync(emotionalTypeId, blogId);
        if (EmotionalBlog == null)
            return NotFound();
        _unitOfWork.EmotionalBlogs.Remove(EmotionalBlog);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}