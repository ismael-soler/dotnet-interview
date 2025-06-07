// imports
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

// set namespace within the project
namespace TodoApi.Tools;

// To declare this an MCP tool
[McpServerToolType]
public static class TodoListMcpTools
{
    [McpServerTool, Description("get Todo LISTS from the DB")]
    public static async Task<string> GetTodoLists(HttpClient client)
    // NOTE: The HttpClient object is the way to make the web requests to the API
    {
        // Call the API
        using var jsonDocument = await client.ReadJsonDocumentAsync("/api/todolists");
        // returns a JsonElement
        var root = jsonDocument.RootElement;

        if (root.GetArrayLength() == 0)
        {
            return "No lists available.";
        }

        return root.GetRawText();
    }
}