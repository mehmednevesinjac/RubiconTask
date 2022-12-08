namespace RubiconTask.Envelopes.Responses;

/// <summary>
/// Data transfer object for the Comment response.
/// </summary>
public class CommentResponseDto
{
    /// <summary>
    /// Gets or sets Identifier.
    /// </summary>
    /// <value>
    /// The Identifier.
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
}