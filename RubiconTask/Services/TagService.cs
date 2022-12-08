using Microsoft.EntityFrameworkCore;
using RubiconTask.Data;
using RubiconTask.Envelopes.Responses;
using RubiconTask.Services.Interfaces;

namespace RubiconTask.Services;

/// <summary>
/// The service for tags.
/// </summary>
/// <seealso cref="ITagService"/>
public sealed class TagService : ITagService
{
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="TagService"/> class.
    /// </summary>
    /// <param name="databaseContext">Database context</param>
    public TagService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    /// <inheritdoc/>
    public async Task<TagsResponseDto> GetTagsAsync()
    {
        return new TagsResponseDto
        {
            Tags = await _databaseContext.Tags.Select(t => t.Name).ToArrayAsync()
        };
    }
}