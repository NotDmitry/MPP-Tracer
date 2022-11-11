namespace Tracer.Core;

public interface ITracer
{
    // Call at start
    void StartTrace();

    // Call at the end
    void StopTrace();
    
    // Return measurement results
    TraceResult GetTraceResult();
}
