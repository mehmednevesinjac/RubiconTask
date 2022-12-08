using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RubiconTask.Helpers.EnvironmentSettings;
using RubiconTask.Helpers.ServiceHelpers;
using RubiconTask.Services.Interfaces;

namespace RubiconTask.Data;

public class DatabaseSeeder
{
    private readonly DatabaseContext _context;
    private readonly SeedSettings _seedSettings;
    private readonly IBlogPostService _blogPostService;
    private readonly ICommentService _commentService;

    public DatabaseSeeder(IOptions<SeedSettings> seedSettings,
        IBlogPostService blogPostService, ICommentService commentService, DatabaseContext context)
    {
        _blogPostService = blogPostService;
        _commentService = commentService;
        _context = context;
        _seedSettings = seedSettings.Value;
    }

    public async Task SeedAsync()
    {
        if (_seedSettings.ShouldSeed.HasValue && _seedSettings.ShouldSeed.Value)
        {
            await SeedBlogPostsAsync();
            await SeedCommentsAsync();
        }
    }

    private async Task SeedBlogPostsAsync()
    {
        if (await _context.BlogPosts.AnyAsync())
        {
            return;
        }
        await _blogPostService.CreateBlogPostAsync(DatabaseSeederData.BlogPosts[1]);
        await _blogPostService.CreateBlogPostAsync(DatabaseSeederData.BlogPosts[0]);
        await _blogPostService.CreateBlogPostAsync(DatabaseSeederData.BlogPosts[2]);
        }

    private async Task SeedCommentsAsync()
    {
        if (await _context.Comments.AnyAsync())
        {
            return;
        }
        await _commentService.CreateComment(DatabaseSeederData.Comments[0],
            DatabaseSeederData.BlogPosts[0].Title.GenerateSlug());
        await _commentService.CreateComment(DatabaseSeederData.Comments[1],
            DatabaseSeederData.BlogPosts[0].Title.GenerateSlug());
        await _commentService.CreateComment(DatabaseSeederData.Comments[2],
            DatabaseSeederData.BlogPosts[1].Title.GenerateSlug());
        await _commentService.CreateComment(DatabaseSeederData.Comments[3],
            DatabaseSeederData.BlogPosts[1].Title.GenerateSlug());
        await _commentService.CreateComment(DatabaseSeederData.Comments[0],
            DatabaseSeederData.BlogPosts[2].Title.GenerateSlug());
        await _commentService.CreateComment(DatabaseSeederData.Comments[1],
            DatabaseSeederData.BlogPosts[2].Title.GenerateSlug());
    }
}