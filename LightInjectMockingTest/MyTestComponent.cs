using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightInjectMockingTest
{
    public class MyTestComponent : IMyTestComponent
    {
        public bool IsRunning
        {
            get; private set;
        }

        public int Operation(int x)
        {
            return x;
        }

        public void Start()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }
}
