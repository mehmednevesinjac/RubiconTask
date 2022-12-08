namespace RubiconTask.Models;

/// <summary>
/// Tag model.
/// </summary>
public sealed class Tag
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets the Name.
    /// </summary>
    /// <value>
    /// The Name.
    /// </value>
    public string Name { get; set; }
    
    /// <summary>
    /// Gets or sets the reference table for BlogPost-Tags.
    /// </summary>
    /// <value>
    /// The BlogPost-Tags.
    /// </value>
    public ICollection<BlogPostXrefTag> BlogPosts { get; set; }
}