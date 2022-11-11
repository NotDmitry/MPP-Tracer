using System.Collections.Concurrent;

namespace Tracer.Core;

public class ThreadData
{ 
    public int ThreadId { get; set; }
    public long ThreadElapsedTime { get; set; } = 0;
    public ConcurrentStack<MethodData> ThreadStack { get; set; }
    public List<MethodData> RootMethods{ get; set; }
    public ThreadData(int threadId)
    {
        ThreadId = threadId;
        ThreadStack = new();
        RootMethods = new();
    }
    
}
