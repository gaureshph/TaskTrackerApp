using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Repository.DbEntities;
using TaskTracker.Repository.Repositories;
using TaskTracker.API.Dtos.InputDtos.Tags;
using TaskTracker.API.Dtos.OutputDtos.Tags;

namespace TaskTrackerApp.API.Controllers;

[ApiController]
[Route("tags")]
public class TagsController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ITagsRepository tagsRepository;

    public TagsController(IMapper mapper, ITagsRepository tagsRepository)
    {
        this.mapper = mapper;
        this.tagsRepository = tagsRepository;
    }

    [HttpGet(Name = "GetTags")]
    public async Task<IActionResult> GetTags()
    {
        var tags = await tagsRepository.GetTagsAsync();
        var tagDtos = mapper.Map<List<TagDto>>(tags);

        return Ok(tagDtos);
    }

    [HttpGet("{tagId}", Name = "GetTagById")]
    public async Task<IActionResult> GetTagById(int tagId)
    {
        var tag = await tagsRepository.GetTagByIdAsync(tagId);
        if (tag == null)
        {
            return NotFound();
        }

        var tagDto = mapper.Map<TagDto>(tag);

        return Ok(tagDto);
    }

    [HttpPost(Name = "CreateTag")]
    public async Task<IActionResult> CreateTag([FromBody] TagCreationDto tagCreationDto)
    {
        var tag = mapper.Map<Tag>(tagCreationDto);
        await tagsRepository.CreateTagAsync(tag);

        return CreatedAtAction("GetTagById", new { id = tag.Id }, tag);
    }

    [HttpDelete("{tagId}", Name = "DeleteTag")]
    public async Task<IActionResult> DeleteTag(int tagId)
    {
        var tag = await tagsRepository.GetTagByIdAsync(tagId);
        if (tag == null)
        {
            return NotFound();
        }

        await tagsRepository.DeleteTagAsync(tag);

        return NoContent();
    }
}
