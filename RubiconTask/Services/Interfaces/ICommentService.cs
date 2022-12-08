using RubiconTask.Envelopes.Requests;
using RubiconTask.Envelopes.Responses;

namespace RubiconTask.Services.Interfaces;

/// <summary>
/// The interface for the service that handles comments.
/// </summary>
public interface ICommentService
{
    /// <summary>
    /// Creates a new comment.
    /// </summary>
    /// <param name="commentDto">The comment data.</param>
    /// <param name="slug">Slug to identify which blog post the comments is attached to.</param>
    /// <returns>Newly created comment.</returns>
    Task<CommentResponseDto> CreateComment(CreateCommentRequestDto commentDto,string slug);
    
    /// <summary>
    /// Deletes the comment
    /// </summary>
    /// <param name="commentId">The comment identifier.</param>
    /// <returns>Tack completion</returns>
    Task DeleteComment(Guid commentId);
    
    /// <summary>
    /// Gets a comment by its identifier.
    /// </summary>
    /// <param name="commentId">The comment identifier.</param>
    /// <returns>The comment.</returns>
    Task<CommentResponseDto> GetComment(Guid commentId);
    
    /// <summary>
    /// Gets all comments for a blog post.
    /// </summary>
    /// <param name="slug">Blog post slug.</param>
    /// <returns>List of comment for a specific blog post.</returns>
    Task<IEnumerable<CommentResponseDto>> GetAllComments(string slug);
}