using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    internal class SampleService
    {
        private readonly IDependency _dependency;
        public SampleService(IDependency dependency)
        {
            _dependency = dependency;
        }

        public bool Start()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Sample Service Started...");
            _dependency.Write();
            Console.WriteLine("--------------------------------");
            return true;
        }

        public bool Stop()
        {
            return true;
        }
    }
}
