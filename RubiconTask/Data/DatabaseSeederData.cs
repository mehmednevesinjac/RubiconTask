using RubiconTask.Envelopes.Requests;

namespace RubiconTask.Data;

public  static class DatabaseSeederData
{
    public static readonly string[] TitleList = { "Title1", "Title2", "Title3" };
    public static readonly string[] TagList = { "Tag1", "Tag2", "Tag3" , "Tag 4"};

    public static readonly CreateBlogPostRequestDto[] BlogPosts = {
        new CreateBlogPostRequestDto
        {
            Title = TitleList[0],
            Description = "Description 1",
            Body = "Body 1",
            TagList = new[]
            {
                TagList[0], TagList[1]
            }
        },
        new CreateBlogPostRequestDto()
        {
            Title = TitleList[1],
            Description = "Description 2",
            Body = "Body 2",
            TagList = new[]
            {
                TagList[0], TagList[3]
            }
        },
        new CreateBlogPostRequestDto()
        {
            Title = TitleList[2],
            Description = "Description 3",
            Body = "Body 3",
            TagList = new[]
            {
                TagList[0], TagList[1], TagList[2], TagList[3]
            }
        }
    };

    public static readonly CreateCommentRequestDto[] Comments = new CreateCommentRequestDto[]
    {
        new CreateCommentRequestDto
        {
            Body = "Body 1"
        },
        new CreateCommentRequestDto
        {
            Body = "Body 2"
        },
        new CreateCommentRequestDto
        {
            Body = "Body 3"
        },
        new CreateCommentRequestDto
        {
            Body = "Body 4"
        },
    };
}