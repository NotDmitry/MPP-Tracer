using System.Diagnostics;

namespace Tracer.Core
{
    internal class MethodData
    {
        public string MethodName { get; set; }
        public string DeclaringClassName { get; set; }
        public Stopwatch MethodWatch { get; set; }
        public List<MethodData> NestedMethods { get; set; }

        public MethodData(string methodName, string declaringClassName, Stopwatch methodWatch)
        {
            MethodName = methodName;
            DeclaringClassName = declaringClassName;
            MethodWatch = methodWatch;
            NestedMethods = new(); 
        }
         
    }
}
