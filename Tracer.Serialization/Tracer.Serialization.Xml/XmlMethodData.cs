using System.Xml.Serialization;
using Tracer.Core;

namespace Tracer.Serialization.Xml;

public class XmlMethodData
{
    [XmlAttribute("name")]
    public string MethodName { get; set; } = string.Empty;

    [XmlAttribute("class")]
    public string DeclaringClassName { get; set; } = string.Empty;

    [XmlAttribute("time")]
    public string MethodElapsedTime { get; set; } = string.Empty;

    [XmlElement("methods")]
    public List<XmlMethodData> NestedMethods { get; set; }

    public XmlMethodData() => NestedMethods = new List<XmlMethodData>();

    public XmlMethodData(MethodData methodData)
    {
        MethodName = methodData.MethodName;
        DeclaringClassName = methodData.DeclaringClassName;
        MethodElapsedTime = $"{methodData.MethodElapsedTime} milliseconds";
        NestedMethods = methodData.NestedMethods.Select(method => new XmlMethodData(method)).ToList();
    }
}
