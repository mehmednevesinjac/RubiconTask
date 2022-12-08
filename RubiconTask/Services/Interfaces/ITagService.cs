using RubiconTask.Envelopes.Responses;

namespace RubiconTask.Services.Interfaces;

/// <summary>
/// The interface for the service that handles the logic for the tags.
/// </summary>
public interface ITagService
{
    /// <summary>
    /// Gets all tags from the database.
    /// </summary>
    /// <returns>List of tags.</returns>
    Task<TagsResponseDto> GetTagsAsync();
}