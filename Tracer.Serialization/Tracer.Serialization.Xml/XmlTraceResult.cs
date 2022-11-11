using System.Xml.Serialization;
using Tracer.Core;

namespace Tracer.Serialization.Xml;

public class XmlTraceResult
{
    [XmlElement("threads")]
    public IReadOnlyList<XmlThreadData> RunningThreads { get; }

    public XmlTraceResult(TraceResult traceResult)
    {
        RunningThreads = traceResult.RunningThreads.Select(thread => new XmlThreadData(thread)).ToList();
    }
}
