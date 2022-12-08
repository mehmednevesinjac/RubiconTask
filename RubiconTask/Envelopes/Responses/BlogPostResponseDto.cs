namespace RubiconTask.Envelopes.Responses;

/// <summary>
/// Data transfer object for the Blog Post response.
/// </summary>
public sealed class BlogPostResponseDto
{
    /// <summary>
    /// Gets or sets Slug.
    /// </summary>
    /// <value>
    /// The Slug.
    /// </value>
    public string Slug { get; set; }    

    /// <summary>
    /// Gets or sets Title.
    /// </summary>
    /// <value>
    /// The Title.
    /// </value>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets Description.
    /// </summary>
    /// <value>
    /// The Description.
    /// </value>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets Body.
    /// </summary>
    /// <value>
    /// The Body.
    /// </value>
    public string Body { get; set; }
    
    /// <summary>
    /// Gets or sets Tag list.
    /// </summary>
    /// <value>
    /// The Tag list.
    /// </value>
    public string[] TagList { get; set; }

    /// <summary>
    /// Gets or sets Created at date and time.
    /// </summary>
    /// <value>
    /// The Created at date and time.
    /// </value>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// Gets or sets Updated at date and time.
    /// </summary>
    /// <value>
    /// The Updated at date and time.
    /// </value>
    public DateTime UpdatedAt { get; set; }
}