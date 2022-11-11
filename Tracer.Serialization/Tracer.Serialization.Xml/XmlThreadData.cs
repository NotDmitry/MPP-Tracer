using System.Xml.Serialization;
using Tracer.Core;

namespace Tracer.Serialization.Xml;

public class XmlThreadData
{
    [XmlAttribute("id")]
    public int ThreadId = 0;

    [XmlAttribute("time")]
    public string ThreadElapsedTime = string.Empty;

    [XmlElement("methods")]
    public List<XmlMethodData> RootMethods;

    public XmlThreadData() => RootMethods = new List<XmlMethodData>();
    public XmlThreadData(ThreadData threadData)
    {
        ThreadId = threadData.ThreadId;
        ThreadElapsedTime = $"{threadData.ThreadElapsedTime} milliseconds";
        RootMethods = threadData.RootMethods.Select(method => new XmlMethodData(method)).ToList();
    }
}
