using Microsoft.EntityFrameworkCore;

namespace RubiconTask.Models;

/// <summary>
/// The BlogPost-Tag reference table.
/// </summary>
[PrimaryKey(nameof(BlogPostId),nameof(TagId))]
public sealed class BlogPostXrefTag
{
    /// <summary>
    /// Gets or sets the Blog Post identifier.
    /// </summary>
    /// <value>
    /// The Blog Post identifier.
    /// </value>
    public Guid BlogPostId { get; set; }
    
    /// <summary>
    /// Gets or sets the Blog Post.
    /// </summary>
    /// <value>
    /// The Blog Post.
    /// </value>
    public BlogPost BlogPost { get; set; }
    
    /// <summary>
    /// Gets or sets the Tag identifier.
    /// </summary>
    /// <value>
    /// The Tag identifier.
    /// </value>
    public Guid TagId { get; set; }
    
    /// <summary>
    /// Gets or sets the Tag.
    /// </summary>
    /// <value>
    /// The Tag.
    /// </value>
    public Tag Tag { get; set; }
}