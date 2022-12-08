using Microsoft.EntityFrameworkCore;
using RubiconTask.Models;

namespace RubiconTask.Data;

/// <summary>
/// Database context class.
/// It will use SQL database.
/// </summary>
public sealed class DatabaseContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseContext"/> class.
    /// </summary>
    /// <param name="options">Database context options.</param>
    public DatabaseContext(DbContextOptions options) : base(options)
    {
        
    }
    
    /// <summary>
    /// Gets or sets Blog Posts.
    /// </summary>
    /// <value>
    /// The Blog Posts.
    /// </value>
    public DbSet<BlogPost>? BlogPosts { get; set; }
    
    /// <summary>
    /// Gets or sets Comments.
    /// </summary>
    /// <value>
    /// The Comments.
    /// </value>
    public DbSet<Comment>? Comments { get; set; }
    
    /// <summary>
    /// Gets or sets Tags.
    /// </summary>
    /// <value>
    /// The Tags.
    /// </value>
    public DbSet<Tag>? Tags { get; set; }

    /// <summary>
    /// Gets or sets the reference table for BlogPost-Tag.
    /// </summary>
    /// <value>
    /// The Blog post tag.
    /// </value>
    public DbSet<BlogPostXrefTag>? BlogPostTag { get; set; }
}