using System.Diagnostics;

namespace Tracer.Core;

public class MethodData
{
    public string MethodName { get; set; }
    public string DeclaringClassName { get; set; }
    public Stopwatch MethodWatch { get; set; }
    public List<MethodData> NestedMethods { get; set; }
    public TimeSpan MethodElapsedTime { get; set; } = TimeSpan.Zero; 

    public MethodData(string methodName, string declaringClassName)
    {
        MethodName = methodName;
        DeclaringClassName = declaringClassName;
        MethodWatch = new();
        NestedMethods = new(); 
    }
     
}
