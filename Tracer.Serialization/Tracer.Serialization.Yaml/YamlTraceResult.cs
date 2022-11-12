using Tracer.Core;
using YamlDotNet.Serialization;

namespace Tracer.Serialization.Yaml;

// Copy of TraceResult from Tracer.Core for using with YAML attributes
public class YamlTraceResult
{
    [YamlMember(Alias = "threads")]
    public IReadOnlyList<YamlThreadData> RunningThreads { get; }

    public YamlTraceResult(TraceResult traceResult)
    {
        RunningThreads = traceResult.RunningThreads.Select(thread => new YamlThreadData(thread)).ToList();
    }
}
