using System.Globalization;
using RubiconTask.Constants;

namespace RubiconTask.Helpers.Exceptions;

/// <summary>
/// Blog post not found exception class.
/// </summary>
public class CommentNotFoundException : EntityNotFoundException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CommentNotFoundException"/> class.
    /// </summary>
    /// <param name="message">Message to return.</param>
    public CommentNotFoundException(string message = ExceptionMessagesConstants.CommentNotFound) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CommentNotFoundException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="args">The arguments.</param>
    public CommentNotFoundException(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}