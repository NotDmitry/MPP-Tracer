namespace Tracer.Core;

public class ThreadData
{ 
    public int ThreadId { get; set; }
    public TimeSpan ThreadElapsedTime { get; set; }
    public List<MethodData> RootMethods{ get; set; }
    public ThreadData(int threadId)
    {
        ThreadId = threadId;
        RootMethods = new();
    }
    
}
