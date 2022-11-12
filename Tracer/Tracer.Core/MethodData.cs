using System.Diagnostics;

namespace Tracer.Core;

// Contains data reated to methods
public class MethodData
{
    public string MethodName { get; set; }
    public string DeclaringClassName { get; set; }
    public Stopwatch MethodWatch { get; set; }
    public List<MethodData> NestedMethods { get; set; }
    public long MethodElapsedTime { get; set; } = 0; 

    public MethodData(string methodName, string declaringClassName)
    {
        MethodName = methodName;
        DeclaringClassName = declaringClassName;
        MethodWatch = new();
        NestedMethods = new(); 
    }
     
}
