using Tracer.Core;
using System.Xml.Serialization;
using Tracer.Serialization.Abstractions;

namespace Tracer.Serialization.Xml;

public class XmlTracerSerializer : ITraceResultSerializer
{
    public string Format { get; } = ".xml";

    public void Serialize(TraceResult traceResult, Stream to)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(TraceResult));
        serializer.Serialize(to, traceResult);

    }
}
