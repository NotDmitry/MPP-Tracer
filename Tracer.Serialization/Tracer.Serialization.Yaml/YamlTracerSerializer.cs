using Tracer.Core;
using Tracer.Serialization.Abstractions;
using YamlDotNet.Serialization;

namespace Tracer.Serialization.Yaml
{
    public class YamlTracerSerializer : ITraceResultSerializer
    {
        public string Format { get; } = ".yaml";

        public void Serialize(TraceResult traceResult, Stream to)
        {
            var yamlSerializer = new Serializer();
            using (var writer = new StreamWriter(to)) 
            { 
                yamlSerializer.Serialize(writer, traceResult);
            }

        }
    }
}
