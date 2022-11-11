using System.Xml.Serialization;
using Tracer.Core;

namespace Tracer.Serialization.Xml;

public class XmlTraceResult
{
    [XmlElement("threads")]
    public List<XmlThreadData> RunningThreads;

    public XmlTraceResult() => RunningThreads = new List<XmlThreadData>();

    public XmlTraceResult(TraceResult traceResult)
    {
        RunningThreads = traceResult.RunningThreads.Select(thread => new XmlThreadData(thread)).ToList();
    }
}
