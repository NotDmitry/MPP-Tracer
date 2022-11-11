using Tracer.Core;
using YamlDotNet.Serialization;

namespace Tracer.Serialization.Yaml;

public class YamlThreadData
{
    [YamlMember(Alias = "id")]
    public int ThreadId { get; set; }

    [YamlMember(Alias = "time")]
    public string ThreadElapsedTime { get; set; }

    [YamlMember(Alias = "methods")]
    public List<YamlMethodData> RootMethods { get; set; }

    public YamlThreadData(ThreadData threadData)
    {
        ThreadId = threadData.ThreadId;
        ThreadElapsedTime = $"{threadData.ThreadElapsedTime} milliseconds";
        RootMethods = threadData.RootMethods.Select(method => new YamlMethodData(method)).ToList();
    }
}
