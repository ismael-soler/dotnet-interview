using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder
    .Services.AddDbContext<TodoContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("TodoContext"))
    )
    .AddEndpointsApiExplorer()
    .AddControllers();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Tell .NET to set up an MCp server
builder.Services.AddMcpServer()
    // Specify communication through stdio
    .WithStdioServerTransport()
    // Instruct MCP server to find and register any tools
    // defined within the project code. 
    .WithToolsFromAssembly();

// Create Https Client for the MCP tools
builder.Services.AddSingleton(_ =>
{
    // Set up the http address.
    var client = new HttpClient() { BaseAddress = new Uri("http://localhost:5083") };
    // Set up the UserAgent value (dont know what this is)
    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("lists-tool", "1.0"));
    // Returns the fully configured HttpClient instance.
    return client;
});

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.Run();
