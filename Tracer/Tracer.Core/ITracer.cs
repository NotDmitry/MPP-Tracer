namespace Tracer.Core;

public interface ITracer
{
    // Call at start
    void StartTrace();

    // Call at the end
    void StopTrace();
    
    // Shoud return measurement results
    TraceResult GetTraceResult();
}
