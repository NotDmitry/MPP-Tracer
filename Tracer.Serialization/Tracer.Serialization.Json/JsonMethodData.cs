using System.Text.Json.Serialization;
using Tracer.Core;

namespace Tracer.Serialization.Json;

public class JsonMethodData
{
    [JsonPropertyName("name")]
    public string MethodName { get; set; }

    [JsonPropertyName("class")]
    public string DeclaringClassName { get; set; }

    [JsonPropertyName("time")]
    public string MethodElapsedTime { get; set; }
    
    [JsonPropertyName("methods")]
    public List<JsonMethodData> NestedMethods { get; set; }
    

    public JsonMethodData(MethodData methodData)
    {
        MethodName = methodData.MethodName;
        DeclaringClassName = methodData.DeclaringClassName;
        MethodElapsedTime = $"{methodData.MethodElapsedTime} milliseconds";
        NestedMethods = methodData.NestedMethods.Select(method => new JsonMethodData(method)).ToList();
    }
}
