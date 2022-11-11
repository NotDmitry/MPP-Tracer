using Tracer.Core;
using Tracer.Serialization;
using Tracer.Serialization.Abstractions;

var tracer = new Tracer.Core.Tracer();
var foo = new Foo(tracer);
foo.MyMethod();

var traceResult = tracer.GetTraceResult();

var dlls = DllLoader.LoadPlugins<ITraceResultSerializer>("D:\\VsRepos\\MPP\\MPP-Tracer\\Tracer\\Tracer.Example\\plugins");
DllLoader.PrintSerializeResult(dlls, traceResult);


public class Foo
{
    private Bar _bar;
    private ITracer _tracer;

    internal Foo(ITracer tracer)
    {
        _tracer = tracer;
        _bar = new Bar(_tracer);
    }

    public void MyMethod()
    {
        _tracer.StartTrace();
        Thread.Sleep(100);
        _bar.InnerMethod();
        _tracer.StopTrace();
    }
}

public class Bar
{
    private ITracer _tracer;

    internal Bar(ITracer tracer)
    {
        _tracer = tracer;
    }

    public void InnerMethod()
    {
        _tracer.StartTrace();
        Thread.Sleep(200);
        _tracer.StopTrace();
    }
}