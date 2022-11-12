using Tracer.Core;
using Tracer.Serialization.Abstractions;
using YamlDotNet.Serialization;

namespace Tracer.Serialization.Yaml;

// Convert TraceResult object into YAMLformat
public class YamlTracerSerializer : ITraceResultSerializer
{
    public string Format { get; } = ".yaml";
    public void Serialize(TraceResult traceResult, Stream to)
    {
        var yamlData = new YamlTraceResult(traceResult);

        var yamlSerializer = new Serializer();
        using (var writer = new StreamWriter(to)) 
        { 
            yamlSerializer.Serialize(writer, yamlData);
        }

    }
}
