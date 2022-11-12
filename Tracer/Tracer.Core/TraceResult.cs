namespace Tracer.Core;

// Result view
public class TraceResult
{

    public IReadOnlyList<ThreadData> RunningThreads { get; }

    public TraceResult(IReadOnlyList<ThreadData> runningThreads)
    {
        RunningThreads = runningThreads;
    }

}

