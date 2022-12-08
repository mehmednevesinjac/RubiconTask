using Microsoft.AspNetCore.Mvc;
using RubiconTask.Envelopes.Requests;
using RubiconTask.Envelopes.Responses;
using RubiconTask.Helpers.Exceptions;
using RubiconTask.Services.Interfaces;

namespace RubiconTask.Controllers;

/// <summary>
/// The controller for handling blog posts related requests.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public sealed class PostsController : ControllerBase
{
    private readonly IBlogPostService _blogPostService;
    private readonly ICommentService _commentService;

    /// <summary>
    /// Initializes a new instance of the <see cref="PostsController"/> class.
    /// </summary>
    /// <param name="blogPostService">Blog post service.</param>
    /// <param name="commentService">Comment service.</param>
    public PostsController(IBlogPostService blogPostService, ICommentService commentService)
    {
        _blogPostService = blogPostService;
        _commentService = commentService;
    }

    /// <summary>
    /// Gets all blog posts.
    /// </summary>
    /// <param name="tag">Tag filter for blog posts.</param>
    /// <returns>The HTTP response with list of blog posts.</returns>
    [HttpGet]
    public async Task<ActionResult<BlogPostsResponseDto>> GetAllPosts([FromQuery] string? tag)
    {
        return Ok(await _blogPostService.GetBlogPostsAsync(tag));
    }

    /// <summary>
    /// Gets a blog post by its slug.
    /// </summary>
    /// <param name="slug">Slug identifier for blog post.</param>
    /// <returns>The HTTP response with a blog post.</returns>
    [HttpGet("{slug}")]
    public async Task<ActionResult<BlogPostsResponseDto>> GetPostBySlug([FromRoute] string slug)
    {
        try
        {
            return Ok(await _blogPostService.GetBlogPostBySlugAsync(slug));
        }
        catch (BlogPostNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Adds a new blog post.
    /// </summary>
    /// <param name="blogPostRequestDto">The request data.</param>
    /// <returns>The HTTP response with the newly created blog post.</returns>
    [HttpPost]
    public async Task<ActionResult<BlogPostResponseDto>> AddPost([FromBody] CreateBlogPostRequestDto blogPostRequestDto)
    {
        return Ok(await _blogPostService.CreateBlogPostAsync(blogPostRequestDto));
    }

    /// <summary>
    /// Updates the blog post.
    /// </summary>
    /// <param name="blogPostRequestDto">The request data.</param>
    /// <param name="slug">Slug identifier for a blog post.</param>
    /// <returns>The HTTP response with the updated blog post.</returns>
    [HttpPut]
    public async Task<ActionResult<BlogPostResponseDto>> UpdatePost(
        [FromBody] UpdateBlogPostRequestDto blogPostRequestDto, [FromQuery] string slug)
    {
        try
        {
            return Ok(await _blogPostService.UpdateBlogPostAsync(blogPostRequestDto, slug));
        }
        catch (BlogPostNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Deletes the blog post.
    /// </summary>
    /// <param name="slug">Slug identifier for a blog post.</param>
    /// <returns>The HTTP response.</returns>
    [HttpDelete]
    public async Task<ActionResult> DeletePost([FromQuery] string slug)
    {
        try
        {
            await _blogPostService.DeleteBlogPostAsync(slug);
            return Ok();
        }
        catch (BlogPostNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Adds a new comment to a blog post.
    /// </summary>
    /// <param name="commentRequestDto">The request data.</param>
    /// <param name="slug">Slug identifier for a blog post.</param>
    /// <returns>The HTTP response with created comment.</returns>
    [HttpPost("{slug}/comments")]
    public async Task<ActionResult<CommentResponseDto>> AddComment([FromBody] CreateCommentRequestDto commentRequestDto,
        [FromRoute] string slug)
    {
        try
        {
            return Ok(await _commentService.CreateComment(commentRequestDto, slug));
        }
        catch (BlogPostNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Gets all comments for a blog post.
    /// </summary>
    /// <param name="slug">Slug identifier for a blog post.</param>
    /// <returns>The HTTP response with with list of comments.</returns>
    [HttpGet("{slug}/comments")]
    public async Task<ActionResult<CommentResponseDto>> GetAllComments([FromRoute] string? slug)
    {
        return Ok(await _commentService.GetAllComments(slug));
    }

    /// <summary>
    /// Gets a comment by its id.
    /// </summary>
    /// <param name="slug">Slug identifier for a blog post.</param>
    /// <param name="commentId">The comment identifier.</param>
    /// <returns>The HTTP response with a comment.</returns>
    [HttpGet("{slug}/comments/{commentId:guid}")]
    public async Task<ActionResult<CommentResponseDto>> GetCommentById([FromRoute] string? slug,
        [FromRoute] Guid commentId)
    {
        try
        {
            return Ok(await _commentService.GetComment(commentId));
        }
        catch (CommentNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Deletes a comment.
    /// </summary>
    /// <param name="commentId">The comment identifier</param>
    /// <param name="slug">Slug identifier for a blog post.</param>
    /// <returns>The HTTP response.</returns>
    [HttpDelete("{slug}/comments/{commentId:guid}")]
    public async Task<ActionResult> DeleteComment([FromRoute] Guid commentId,[FromRoute] string slug)
    {
        try
        {
            await _commentService.DeleteComment(commentId);
            return Ok();
        }
        catch (CommentNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}