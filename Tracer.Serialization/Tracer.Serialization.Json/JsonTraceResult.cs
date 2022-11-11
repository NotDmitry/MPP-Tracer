using System.Text.Json.Serialization;
using Tracer.Core;

namespace Tracer.Serialization.Json;

public class JsonTraceResult
{
    [JsonPropertyName("threads")]
    public IReadOnlyList<JsonThreadData> RunningThreads { get; }

    public JsonTraceResult(TraceResult traceResult)
    {
        RunningThreads = traceResult.RunningThreads.Select(thread => new JsonThreadData(thread)).ToList();
    }
}
