using RubiconTask.Envelopes.Requests;

namespace RubiconTask.Test.Data;

public static class BlogPostData
{
    public static readonly CreateBlogPostRequestDto CreateBlogPostRequestDto = new()
    {
        Title = "Test title",
        Description = "Test description",
        Body = "Test body",
        TagList = new[] { "test", "test2" }
    };
}