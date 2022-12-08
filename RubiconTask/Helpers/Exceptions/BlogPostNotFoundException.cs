using System.Globalization;
using RubiconTask.Constants;

namespace RubiconTask.Helpers.Exceptions;

/// <summary>
/// Blog post not found exception class.
/// </summary>
public class BlogPostNotFoundException : EntityNotFoundException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BlogPostNotFoundException"/> class.
    /// </summary>
    /// <param name="message">Message to return.</param>
    public BlogPostNotFoundException(string message = ExceptionMessagesConstants.PostNotFound) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BlogPostNotFoundException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="args">The arguments.</param>
    public BlogPostNotFoundException(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}