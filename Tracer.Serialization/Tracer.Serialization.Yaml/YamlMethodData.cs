using Tracer.Core;
using YamlDotNet.Serialization;

namespace Tracer.Serialization.Yaml;

// Copy of MethodData from Tracer.Core for using with YAML attributes
public class YamlMethodData
{
    [YamlMember(Alias = "name")]
    public string MethodName { get; set; }

    [YamlMember(Alias = "class")]
    public string DeclaringClassName { get; set; }

    [YamlMember(Alias = "time")]
    public string MethodElapsedTime { get; set; }

    [YamlMember(Alias = "methods")]
    public List<YamlMethodData> NestedMethods { get; set; }


    public YamlMethodData(MethodData methodData)
    {
        MethodName = methodData.MethodName;
        DeclaringClassName = methodData.DeclaringClassName;
        MethodElapsedTime = $"{methodData.MethodElapsedTime} milliseconds";
        NestedMethods = methodData.NestedMethods.Select(method => new YamlMethodData(method)).ToList();
    }
}
