namespace RubiconTask.Envelopes.Responses;

/// <summary>
/// Data transfer object for the Blog Posts response.
/// </summary>
public sealed class BlogPostsResponseDto
{
    /// <summary>
    /// Gets or sets array of <see cref="BlogPostResponseDto"/> objects.
    /// </summary>
    /// <value>
    /// The Created at date and time.
    /// </value>
    public BlogPostResponseDto[] BlogPosts { get; set; }
    
    /// <summary>
    /// Gets or sets Posts count.
    /// </summary>
    /// <value>
    /// The Posts count.
    /// </value>
    public int PostsCount { get; set; }
}