using Microsoft.EntityFrameworkCore;

namespace RubiconTask.Models;

/// <summary>
/// Blog post model.
/// </summary>
[Index(nameof(Slug), IsUnique = true)]
public sealed class BlogPost
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public Guid Id { get; set; }
    
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
    public string Desctription { get; set; }

    /// <summary>
    /// Gets or sets Body.
    /// </summary>
    /// <value>
    /// The Body.
    /// </value>
    public string Body { get; set; }
    
    /// <summary>
    /// Gets or sets the reference table for Tags.
    /// </summary>
    /// <value>
    /// The Tag list.
    /// </value>
    public ICollection<BlogPostXrefTag> TagList { get; set; }
    
    /// <summary>
    /// Gets or sets Comments.
    /// </summary>
    /// <value>
    /// The Comments.
    /// </value>
    public ICollection<Comment> Comments { get; set; }
    
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