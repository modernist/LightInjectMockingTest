using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightInjectMockingTest.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Application();
            app.Start();
            System.Console.WriteLine(app.TestOperation(5));
            System.Console.ReadKey();
        }
    }
}
