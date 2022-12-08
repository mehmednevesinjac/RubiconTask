using System.ComponentModel.DataAnnotations;

namespace RubiconTask.Envelopes.Requests;

/// <summary>
/// Data transfer object for the Create Blog Post request.
/// </summary>
public sealed class CreateBlogPostRequestDto
{
    /// <summary>
    /// Gets or sets Title.
    /// </summary>
    /// <value>
    /// The Title.
    /// </value>
    [Required]
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets Description.
    /// </summary>
    /// <value>
    /// The Description.
    /// </value>
    [Required]
    public string Description { get; set; }
    
    /// <summary>
    /// Gets or sets Body.
    /// </summary>
    /// <value>
    /// The Body.
    /// </value>
    [Required]
    public string Body { get; set; }
    
    /// <summary>
    /// Gets or sets Tag list.
    /// </summary>
    /// <value>
    /// The Tag list.
    /// </value>
    public string[] TagList { get; set; }
}