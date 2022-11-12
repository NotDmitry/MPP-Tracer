using Tracer.Core;
using Tracer.Serialization;
using Tracer.Serialization.Abstractions;

var tracer = new Tracer.Core.Tracer();
var foo = new Foo(tracer);
var bar = new Bar(tracer);
var c = new C(tracer);


var thread1 = new Thread(foo.MyMethod);
var thread2 = new Thread(bar.InnerMethod);
var thread3 = new Thread(c.M0);

thread1.Start();
thread2.Start();
thread3.Start();

thread1.Join();
thread2.Join();
thread3.Join();

var traceResult = tracer.GetTraceResult();

var dlls = DllLoader.LoadPlugins<ITraceResultSerializer>("D:\\VsRepos\\MPP\\MPP-Tracer\\Tracer\\Tracer.Example\\plugins");
DllLoader.PrintSerializeResult(dlls, traceResult);


public class Foo
{
    private Bar _bar;
    private ITracer _tracer;

    public Foo(ITracer tracer)
    {
        _tracer = tracer;
        _bar = new Bar(_tracer);
    }

    public void MyMethod()
    {
        _tracer.StartTrace();
        Thread.Sleep(200);
        _bar.InnerMethod();
        Thread.Sleep(50);
        _tracer.StopTrace();
    }
}

public class Bar
{
    private ITracer _tracer;

    public Bar(ITracer tracer)
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

public class C
{
    private ITracer _tracer;

    public C(ITracer tracer)
    {
        _tracer = tracer;
    }

    public void M0()
    {
        M1();
        M2();
    }

    private void M1()
    {
        _tracer.StartTrace();
        Thread.Sleep(100);
        _tracer.StopTrace();
    }

    private void M2()
    {
        _tracer.StartTrace();
        Thread.Sleep(200);
        _tracer.StopTrace();
    }
}