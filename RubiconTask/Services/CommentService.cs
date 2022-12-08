using Microsoft.EntityFrameworkCore;
using RubiconTask.Data;
using RubiconTask.Envelopes.Requests;
using RubiconTask.Envelopes.Responses;
using RubiconTask.Helpers.Exceptions;
using RubiconTask.Models;
using RubiconTask.Services.Interfaces;

namespace RubiconTask.Services;

/// <summary>
/// The service for comments.
/// </summary>
/// <seealso cref="ICommentService"/>
public sealed class CommentService : ICommentService
{
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommentService"/> class.
    /// </summary>
    /// <param name="databaseContext">Database context</param>
    public CommentService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    /// <inheritdoc/>
    public async Task<CommentResponseDto> CreateComment(CreateCommentRequestDto commentDto, string slug)
    {
        var postId = await _databaseContext.BlogPosts.Where(bp => bp.Slug == slug).Select(bp => bp.Id).FirstOrDefaultAsync();
        
        if (postId == Guid.Empty)
        {
            throw new BlogPostNotFoundException();
        }

        await _databaseContext.Comments.AddAsync(new Comment
        {
            Id = Guid.NewGuid(),
            Body = commentDto.Body,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            BlogPostId = postId,
        });

        await _databaseContext.SaveChangesAsync();
        
        return new CommentResponseDto(){Body = commentDto.Body};
    }

    /// <inheritdoc/>
    public async Task DeleteComment(Guid commentId)
    {
        var comment = await _databaseContext.Comments.FirstOrDefaultAsync(c => c.Id == commentId);

        if (comment is null)
        {
            throw new CommentNotFoundException();
        }
        
        _databaseContext.Comments.Remove(comment);
        
        await _databaseContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task<CommentResponseDto> GetComment(Guid commentId)
    {
        var comment = await _databaseContext.Comments.Where(c => c.Id == commentId).Select(c => new CommentResponseDto
        {
            Id = c.Id,
            Body = c.Body,
            CreatedAt = c.CreatedAt,
            UpdatedAt = c.UpdatedAt
        }).FirstOrDefaultAsync();

        if (comment is null)
        {
            throw new CommentNotFoundException();
        }

        return comment;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<CommentResponseDto>> GetAllComments(string slug)
    {
        var comments = await _databaseContext.Comments.Where(c => c.BlogPost.Slug == slug).Select(c => new CommentResponseDto
        {
            Id = c.Id,
            Body = c.Body,
            CreatedAt = c.CreatedAt,
            UpdatedAt = c.UpdatedAt
        }).ToListAsync();

        return comments;
    }
}