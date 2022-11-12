using Tracer.Core;
using System.Xml.Serialization;
using Tracer.Serialization.Abstractions;

namespace Tracer.Serialization.Xml;

// Convert TraceResult object into XML format
public class XmlTracerSerializer : ITraceResultSerializer
{
    public string Format { get; } = ".xml";

    public void Serialize(TraceResult traceResult, Stream to)
    {
        var xmlData = new XmlTraceResult(traceResult);
        XmlSerializer serializer = new XmlSerializer(typeof(XmlTraceResult));
        serializer.Serialize(to, xmlData);

    }
}
