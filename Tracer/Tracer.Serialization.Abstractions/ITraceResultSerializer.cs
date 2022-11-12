using Tracer.Core;

namespace Tracer.Serialization.Abstractions;

// This interface is intended for serializer plugins
public interface ITraceResultSerializer
{
    string Format { get; }
    void Serialize(TraceResult traceResult, Stream to);
}
