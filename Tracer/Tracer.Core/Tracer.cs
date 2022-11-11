using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core;

public class Tracer : ITracer
{

    private readonly ConcurrentDictionary<int, ThreadData> _threadsData = new();

    //
    public void StartTrace()
    {
        StackTrace stackTracer = new();

        MethodBase? methodInfo = stackTracer.GetFrame(1)?.GetMethod()!;

        if (methodInfo is null) 
            return;

        int currentThreadID = Thread.CurrentThread.ManagedThreadId;
        
        string className = methodInfo.DeclaringType?.Name ?? string.Empty;
        string methodName = methodInfo.Name;
        MethodData runningMethodData = new(methodName, className);

        ThreadData currentThreadData = _threadsData.GetOrAdd(currentThreadID, new ThreadData(currentThreadID));

        if (currentThreadData.ThreadStack.IsEmpty)
            currentThreadData.RootMethods.Add(runningMethodData);
        else
            currentThreadData.ThreadStack.First().NestedMethods.Add(runningMethodData);

        currentThreadData.ThreadStack.Push(runningMethodData);
        runningMethodData.MethodWatch.Start();


    }

    //
    public void StopTrace()
    {
        int threadID = Thread.CurrentThread.ManagedThreadId;
        if (_threadsData[threadID].ThreadStack.TryPop(out var methodData))
        {
            methodData.MethodWatch.Stop();
            methodData.MethodElapsedTime = methodData.MethodWatch.Elapsed;
        }
    }

    //
    public TraceResult GetTraceResult()
    {
        throw new NotImplementedException();
    }

}