namespace RubiconTask.Envelopes.Requests;

/// <summary>
/// Data transfer object for the Update Blog Post request.
/// </summary>
public sealed class UpdateBlogPostRequestDto
{
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

}