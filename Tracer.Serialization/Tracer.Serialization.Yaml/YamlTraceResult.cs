using Tracer.Core;
using YamlDotNet.Serialization;

namespace Tracer.Serialization.Yaml;

public class YamlTraceResult
{
    [YamlMember(Alias = "threads")]
    public IReadOnlyList<YamlThreadData> RunningThreads { get; }

    public YamlTraceResult(TraceResult traceResult)
    {
        RunningThreads = traceResult.RunningThreads.Select(thread => new YamlThreadData(thread)).ToList();
    }
}
