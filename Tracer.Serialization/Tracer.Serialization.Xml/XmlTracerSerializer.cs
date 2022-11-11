using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Core;
using Tracer.Serialization.Abstractions;
using System.Xml.Serialization;

namespace Tracer.Serialization.Xml;

public class XmlTracerSerializer
{
    public string Format { get; } = ".xml";

    public void Serialize(TraceResult traceResult, Stream to)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(TraceResult));
        serializer.Serialize(to, traceResult);

    }
}
