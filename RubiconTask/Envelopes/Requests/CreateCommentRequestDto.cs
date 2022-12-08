using System.ComponentModel.DataAnnotations;

namespace RubiconTask.Envelopes.Requests;

/// <summary>
/// Data transfer object for creating a new comment request.
/// </summary>
public class CreateCommentRequestDto
{
    /// <summary>
    /// Gets or sets Body.
    /// </summary>
    /// <value>
    /// The Body.
    /// </value>
    [Required]
    public string Body { get; set; }
}