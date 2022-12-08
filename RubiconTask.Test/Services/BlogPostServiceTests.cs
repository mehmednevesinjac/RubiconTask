using RubiconTask.Data;
using RubiconTask.Services;
using RubiconTask.Test.Data;
using RubiconTask.Test.Helpers;

namespace RubiconTask.Test.Services;

public sealed class BlogPostServiceTests : IDisposable
{
    private readonly DatabaseContext _databaseContextMock;
    private readonly BlogPostService _systemUnderTest;

    public void Dispose()
    {
        _databaseContextMock.Database.EnsureDeleted();
        _databaseContextMock.Dispose();
    }

    public BlogPostServiceTests()
    {
        _databaseContextMock = InMemoryDatabaseFactory.CreateInMemoryDatabase();
        _databaseContextMock.Database.EnsureCreated();
        _systemUnderTest = new BlogPostService(_databaseContextMock);
    }
    
    [Fact]
    public async Task CreateBlogPostAsync_WhenBlogPostIsCreated_ShouldReturnCreatedBlogPost()
    {
        // Arrange
        var createBlogRequest = BlogPostData.CreateBlogPostRequestDto;
        // Act
        var result = await _systemUnderTest.CreateBlogPostAsync(createBlogRequest);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(createBlogRequest.Title, result.Title);
        Assert.Equal(createBlogRequest.Description, result.Description);
        Assert.Equal(createBlogRequest.Body, result.Body);
        Assert.Equal(createBlogRequest.TagList, result.TagList);
    }
}