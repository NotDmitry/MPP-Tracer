using System.Xml.Serialization;
using Tracer.Core;

namespace Tracer.Serialization.Xml;

// Copy of MethodData from Tracer.Core for using with XML attributes
public class XmlMethodData
{
    [XmlAttribute("name")]
    public string MethodName = string.Empty;

    [XmlAttribute("class")]
    public string DeclaringClassName = string.Empty;

    [XmlAttribute("time")]
    public string MethodElapsedTime = string.Empty;

    [XmlElement("methods")]
    public List<XmlMethodData> NestedMethods;

    public XmlMethodData() => NestedMethods = new List<XmlMethodData>();

    public XmlMethodData(MethodData methodData)
    {
        MethodName = methodData.MethodName;
        DeclaringClassName = methodData.DeclaringClassName;
        MethodElapsedTime = $"{methodData.MethodElapsedTime} milliseconds";
        NestedMethods = methodData.NestedMethods.Select(method => new XmlMethodData(method)).ToList();
    }
}
