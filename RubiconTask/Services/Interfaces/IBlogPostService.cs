using RubiconTask.Envelopes.Requests;
using RubiconTask.Envelopes.Responses;

namespace RubiconTask.Services.Interfaces;

/// <summary>
/// The interface for the service that handles the blog posts.
/// </summary>
public interface IBlogPostService
{
    /// <summary>
    /// Gets all blog posts.
    /// </summary>
    /// <param name="tag">Tag to filter by.</param>
    /// <returns>List of blog posts.</returns>
    Task<BlogPostsResponseDto> GetBlogPostsAsync(string tag);
    
    /// <summary>
    /// Gets a blog post by its slug.
    /// </summary>
    /// <param name="slug">Slug to find the blog post.</param>
    /// <returns>Blog post object with the given slug.</returns>
    Task<BlogPostResponseDto> GetBlogPostBySlugAsync(string slug);
    
    /// <summary>
    /// Creates a new blog post.
    /// </summary>
    /// <param name="blogPostDto">Blog post request data.</param>
    /// <returns>Newly created blog post.</returns>
    Task<BlogPostResponseDto> CreateBlogPostAsync(CreateBlogPostRequestDto blogPostDto);
    
    /// <summary>
    /// Updates an existing blog post.
    /// </summary>
    /// <param name="blogPostDto">Blog post request data.</param>
    /// <param name="slug">Slug to find the blog post.</param>
    /// <returns>Updated blog post.</returns>
    Task<BlogPostResponseDto> UpdateBlogPostAsync(UpdateBlogPostRequestDto blogPostDto, string slug);
    
    /// <summary>
    /// Deletes a blog post.
    /// </summary>
    /// <param name="slug">Slug to find the blog post.</param>
    /// <returns>Task completion</returns>
    Task DeleteBlogPostAsync(string slug);
}