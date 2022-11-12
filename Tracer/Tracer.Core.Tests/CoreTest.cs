namespace Tracer.Core.Tests
{
    [TestClass]
    public class CoreTest
    {
        [TestMethod]
        public void Tracer_GetOnlyMethodName_SingleThread()
        {
            // Arrange
            var tracer = new Tracer();
            var bar = new Bar(tracer);

            // Act
            bar.InnerMethod();
            var traceResult = tracer.GetTraceResult();

            //Assert
            Assert.AreEqual("InnerMethod", traceResult.RunningThreads.First().RootMethods.First().MethodName);
        }

        [TestMethod]
        public void Tracer_RootMethodCount_SingleThread()
        {
            // Arrange
            var tracer = new Tracer();
            var c = new C(tracer);
            var expected = 2;

            // Act
            c.M0();
            var traceResult = tracer.GetTraceResult();
            

            //Assert
            Assert.AreEqual(expected, traceResult.RunningThreads.First().RootMethods.Count);
        }

        [TestMethod]
        public void Tracer_ThreadElapsedTime_IsEqualTo_MethodsSumTime_SingleThread()
        {
            // Arrange
            var tracer = new Tracer();
            var c= new C(tracer);

            // Act
            c.M0();
            var traceResult = tracer.GetTraceResult();
            long methodSum = 0;
            foreach (var method in traceResult.RunningThreads.First().RootMethods)
            {
                methodSum += method.MethodElapsedTime;
            }

            //Assert
            Assert.AreEqual(traceResult.RunningThreads.First().ThreadElapsedTime, methodSum);
        }

        [TestMethod]
        public void Tracer_ThreadCount_ThreeThreads()
        {
            // Arrange
            var tracer = new Tracer();

            var foo = new Foo(tracer);
            var bar = new Bar(tracer);
            var c = new C(tracer);

            var thread1 = new Thread(foo.MyMethod);
            var thread2 = new Thread(bar.InnerMethod);
            var thread3 = new Thread(c.M0);

            var expected = 3;

            // Act
            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            var traceResult = tracer.GetTraceResult();

            //Assert
            Assert.AreEqual(traceResult.RunningThreads.Count, expected);
        }

        [TestMethod]
        public void Tracer_InnerMethod_ClassName_SingleThread()
        {
            // Arrange
            var tracer = new Tracer();
            var foo = new Foo(tracer);
            var expected = "Bar";

            // Act
            foo.MyMethod();
            var traceResult = tracer.GetTraceResult();

            //Assert
            Assert.AreEqual(traceResult.RunningThreads.First()
                .RootMethods.First().NestedMethods.First().DeclaringClassName, expected);
        }

        [TestMethod]
        public void Tracer_NestedMethods_TotalCount_TwoThreads()
        {
            // Arrange
            var tracer = new Tracer();

            var foo1 = new Foo(tracer);
            var foo2 = new Foo(tracer);

            var thread1 = new Thread(foo1.MyMethod);
            var thread2 = new Thread(foo2.MyMethod);

            var expected = 2;

            // Act
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            var traceResult = tracer.GetTraceResult();

            var result = 0;

            result += traceResult.RunningThreads.First().RootMethods.First().NestedMethods.Count;
            result += traceResult.RunningThreads.Last().RootMethods.First().NestedMethods.Count;

            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}