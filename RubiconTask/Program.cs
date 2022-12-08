using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RubiconTask.Data;
using RubiconTask.Helpers.EnvironmentSettings;
using RubiconTask.Services;
using RubiconTask.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var defaultConnection = builder.Configuration.GetSection(nameof(ConnectionStrings)).Get<ConnectionStrings>()
        .DefaultConnection;
    options.UseSqlServer(defaultConnection);
});

builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));
builder.Services.Configure<SeedSettings>(builder.Configuration.GetSection(nameof(SeedSettings)));

builder.Services.AddTransient<IBlogPostService, BlogPostService>();
builder.Services.AddTransient<ITagService, TagService>();
builder.Services.AddTransient<ICommentService, CommentService>();
var app = builder.Build();

var scope = app.Services.CreateScope();

await using var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
await context.Database.MigrateAsync();

var seedOptions = app.Services.GetService<IOptions<SeedSettings>>();
var commentService = scope.ServiceProvider.GetService<ICommentService>();
var blogPostService = scope.ServiceProvider.GetService<IBlogPostService>();

var databaseSeeder = new DatabaseSeeder(seedOptions, blogPostService, commentService, context);
await databaseSeeder.SeedAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();