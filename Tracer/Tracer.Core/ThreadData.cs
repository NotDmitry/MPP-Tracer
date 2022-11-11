using System.Collections.Concurrent;

namespace Tracer.Core;

public class ThreadData
{ 
    public int ThreadId { get; set; }
    public TimeSpan ThreadElapsedTime { get; set; } = TimeSpan.Zero;
    public ConcurrentStack<MethodData> ThreadStack { get; set; }
    public List<MethodData> RootMethods{ get; set; }
    public ThreadData(int threadId)
    {
        ThreadId = threadId;
        ThreadStack = new();
        RootMethods = new();
    }
    
}
