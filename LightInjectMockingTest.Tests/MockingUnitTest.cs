using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using LightInject;
using LightInject.Mocking;

namespace LightInjectMockingTest.Tests
{
    [TestClass]
    public class MockingUnitTest
    {
        [TestMethod]
        public void TestWithoutMocking()
        {
            var app = new Application();

            app.Start();

            var component = app.ServiceContainer.GetInstance<IMyTestComponent>();
            Assert.IsNotNull(component);
            Assert.IsTrue(component.IsRunning);
            Assert.AreEqual(app.TestOperation(5), 5);
        }

        [TestMethod]
        public void TestWithMocking()
        {
            var app = new Application();
            app.Start();

            var mock = new Mock<IMyTestComponent>();
            mock.Setup(c => c.Operation(It.IsAny<int>())).Returns<int>(i => -i);

            var component = app.ServiceContainer.GetInstance<IMyTestComponent>();

            Assert.IsNotNull(component);
            Assert.IsTrue(component.IsRunning);
            Assert.IsInstanceOfType(component, typeof(MyTestComponent));

            app.ServiceContainer.StartMocking<IMyTestComponent>(() => mock.Object);

            var mocked = app.ServiceContainer.GetInstance<IMyTestComponent>();
            Assert.IsNotInstanceOfType(mocked, typeof(MyTestComponent));

            Assert.AreEqual(app.TestOperation(5), -5);
        }
    }
}
