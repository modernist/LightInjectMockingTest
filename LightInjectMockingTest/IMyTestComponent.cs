using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightInjectMockingTest
{
    public interface IMyTestComponent
    {
        void Start();
        void Stop();

        bool IsRunning { get; }

        int Operation(int x);
    }
}
