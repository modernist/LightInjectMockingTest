using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightInjectMockingTest
{
    public class Application
    {
        public IServiceContainer ServiceContainer { get; private set; }

        public Application()
        {
            ServiceContainer = new ServiceContainer();
            ServiceContainer.Register<IMyTestComponent, MyTestComponent>(new PerContainerLifetime());
        }

        public void Start()
        {
            var component = ServiceContainer.GetInstance<IMyTestComponent>();
            component?.Start();            
        }

        public void Stop()
        {
            var component = ServiceContainer.GetInstance<IMyTestComponent>();
            component?.Stop();
        }

        public int TestOperation(int x)
        {
            var component = ServiceContainer.GetInstance<IMyTestComponent>();
            return component?.Operation(x) ?? int.MinValue;
        }
    }
}
