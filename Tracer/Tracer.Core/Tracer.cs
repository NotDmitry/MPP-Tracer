using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core;

public class Tracer : ITracer
{
    //
    public void StartTrace()
    {
        var stackTracer = new StackTrace();

        MethodBase methodInfo = stackTracer.GetFrame(1)!.GetMethod()!;

        string className = methodInfo.DeclaringType?.Name ?? string.Empty;
        string methodName = methodInfo.Name;
    }

    //
    public void StopTrace()
    {

    }

    //
    public TraceResult GetTraceResult()
    {
        throw new NotImplementedException();
    }

}