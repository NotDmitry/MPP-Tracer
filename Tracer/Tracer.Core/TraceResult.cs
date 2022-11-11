namespace Tracer.Core;

public class TraceResult
{

    public IReadOnlyList<ThreadData> RunningThreads { get; }

    public TraceResult(IReadOnlyList<ThreadData> runningThreads)
    {
        RunningThreads = runningThreads;
    }

}

