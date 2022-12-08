using Microsoft.EntityFrameworkCore;
using RubiconTask.Data;
using RubiconTask.Envelopes.Requests;
using RubiconTask.Envelopes.Responses;
using RubiconTask.Helpers.Exceptions;
using RubiconTask.Helpers.ServiceHelpers;
using RubiconTask.Models;
using RubiconTask.Services.Interfaces;

namespace RubiconTask.Services;

/// <summary>
/// The service for the blog posts.
/// </summary>
/// <seealso cref="IBlogPostService"/>
public sealed class BlogPostService : IBlogPostService
{
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlogPostService"/> class.
    /// </summary>
    /// <param name="databaseContext">Database context</param>
    public BlogPostService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    /// <inheritdoc/>
    public async Task<BlogPostsResponseDto> GetBlogPostsAsync(string? tag)
    {
        var query = _databaseContext.BlogPosts.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(tag))
        {
            query = query.Where(bp => bp.TagList.Any(t => t.Tag.Name == tag));
        }

        query = query.OrderBy(x => x.CreatedAt);
        
        var blogPosts = await query.Select(bp => new BlogPostResponseDto
        {
            Slug = bp.Slug,
            Title = bp.Title,
            Description = bp.Desctription,
            Body = bp.Body,
            TagList = bp.TagList.Select(t => t.Tag.Name).ToArray(),
            CreatedAt = bp.CreatedAt,
            UpdatedAt = bp.UpdatedAt,
        }).ToArrayAsync();
        
        return new BlogPostsResponseDto
        {
            BlogPosts = blogPosts,
            PostsCount = blogPosts.Length,
        };
    }

    /// <inheritdoc/>
    public async Task<BlogPostResponseDto> GetBlogPostBySlugAsync(string slug)
    {
        var blogPost = await _databaseContext.BlogPosts
            .AsNoTracking()
            .Where(bp => bp.Slug == slug)
            .Select(bp => new BlogPostResponseDto
            {
                Slug = bp.Slug,
                Title = bp.Title,
                Description = bp.Desctription,
                Body = bp.Body,
                TagList = bp.TagList.Select(t => t.Tag.Name).ToArray(),
                CreatedAt = bp.CreatedAt,
                UpdatedAt = bp.UpdatedAt,
            }).FirstOrDefaultAsync();

        if (blogPost is null)
        {
            throw new BlogPostNotFoundException();
        }

        return blogPost;
    }

    /// <inheritdoc/>
    public async Task<BlogPostResponseDto> CreateBlogPostAsync(CreateBlogPostRequestDto blogPostDto)
    {
        var blogPost = new BlogPost
        {
            Id = Guid.NewGuid(),
            Slug = blogPostDto.Title.GenerateSlug(),
            Title = blogPostDto.Title,
            Desctription = blogPostDto.Description,
            Body = blogPostDto.Body,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        
        await _databaseContext.BlogPosts.AddAsync(blogPost);

        foreach (var tag in blogPostDto.TagList)
        {
            var dbTag = await _databaseContext.Tags.FirstOrDefaultAsync(t => t.Name == tag);
            if (dbTag is null)
            {
                var addedTag = await _databaseContext.Tags.AddAsync(new Tag { Name = tag });
                await _databaseContext.SaveChangesAsync();
                dbTag = addedTag.Entity;
            }
            var newBlogPostTag = new BlogPostXrefTag
            {
                BlogPostId = blogPost.Id,
                TagId = dbTag.Id,
            };
            await _databaseContext.BlogPostTag.AddAsync(newBlogPostTag);
        }
        
        await _databaseContext.SaveChangesAsync();
        
        return new BlogPostResponseDto
        {
            Slug = blogPost.Slug,
            Title = blogPost.Title,
            Description = blogPost.Desctription,
            Body = blogPost.Body,
            TagList = blogPost.TagList.Select(t => t.Tag.Name).ToArray(),
            CreatedAt = blogPost.CreatedAt,
            UpdatedAt = blogPost.UpdatedAt,
        };
        
    }

    /// <inheritdoc/>
    public async Task<BlogPostResponseDto> UpdateBlogPostAsync(UpdateBlogPostRequestDto blogPostDto, string slug)
    {
        var existingBlogPost = await _databaseContext.BlogPosts.FirstOrDefaultAsync(bp => bp.Slug == slug);
        
        if (existingBlogPost is null)
        {
            throw new BlogPostNotFoundException();
        }

        if (blogPostDto.Title != existingBlogPost.Title)
        {
            existingBlogPost.Slug = blogPostDto.Title.GenerateSlug();
            existingBlogPost.Title = blogPostDto.Title;
        }
        
        existingBlogPost.Desctription = string.IsNullOrWhiteSpace(blogPostDto.Desctription) ? existingBlogPost.Body : blogPostDto.Desctription;
        
        existingBlogPost.Body = string.IsNullOrWhiteSpace(blogPostDto.Body) ? existingBlogPost.Body : blogPostDto.Body;

        await _databaseContext.SaveChangesAsync();

        return new BlogPostResponseDto
        {
            Slug = existingBlogPost.Slug,
            Title = existingBlogPost.Title,
            Description = existingBlogPost.Desctription,
            Body = existingBlogPost.Body,
            TagList = _databaseContext.BlogPostTag.Where(bpt => bpt.BlogPostId == existingBlogPost.Id).Select(bpt => bpt.Tag.Name).ToArray(),
            CreatedAt = existingBlogPost.CreatedAt,
            UpdatedAt = DateTime.UtcNow,
        };
    }

    /// <inheritdoc/>
    public async Task DeleteBlogPostAsync(string slug)
    {
        var post = await _databaseContext.BlogPosts.FirstOrDefaultAsync(x => x.Slug == slug);

        if (post is null)
        {
            throw new BlogPostNotFoundException();
        }
        
        _databaseContext.BlogPosts.Remove(post);
        
        await _databaseContext.SaveChangesAsync();
    }
}