using Tracer.Core;
using System.Text.Json.Serialization;

namespace Tracer.Serialization.Json;

public class JsonThreadData
{
    [JsonPropertyName("id")]
    public int ThreadId { get; set; }

    [JsonPropertyName("time")]
    public string ThreadElapsedTime { get; set; }

    [JsonPropertyName("methods")]
    public List<JsonMethodData> RootMethods { get; set; }

    public JsonThreadData(ThreadData threadData)
    {
        ThreadId = threadData.ThreadId;
        ThreadElapsedTime = $"{threadData.ThreadElapsedTime} milliseconds";
        RootMethods = threadData.RootMethods.Select(method => new JsonMethodData(method)).ToList();
    }
}
