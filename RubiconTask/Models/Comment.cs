namespace RubiconTask.Models;

/// <summary>
/// Comment model.
/// </summary>
public sealed class Comment
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets Body.
    /// </summary>
    /// <value>
    /// The Body.
    /// </value>
    public string Body { get; set; }
    
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

    /// <summary>
    /// Gets or sets the Blog Post.
    /// </summary>
    /// <value>
    /// The Blog Post.
    /// </value>
    public BlogPost BlogPost { get; set; }
    
    /// <summary>
    /// Gets or sets the Blog Post identifier.
    /// </summary>
    /// <value>
    /// The Blog Post identifier.
    /// </value>
    public Guid BlogPostId { get; set; }
}