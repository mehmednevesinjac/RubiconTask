using Microsoft.AspNetCore.Mvc;
using RubiconTask.Envelopes.Responses;
using RubiconTask.Services.Interfaces;

namespace RubiconTask.Controllers;

/// <summary>
/// The controller for handling Tag related requests.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly ITagService _tagService;

    /// <summary>
    /// Initializes a new instance of the <see cref="TagsController"/> class.
    /// </summary>
    /// <param name="tagService">Tag service.</param>
    public TagsController(ITagService tagService)
    {
        _tagService = tagService;
    }
    
    /// <summary>
    /// Gets all tags.
    /// </summary>
    /// <returns>The HTTP response with a list of tags.</returns>
    [HttpGet]
    public async Task<ActionResult<TagsResponseDto>> GetAllTags()
    {
        return Ok(await _tagService.GetTagsAsync());
    }
}