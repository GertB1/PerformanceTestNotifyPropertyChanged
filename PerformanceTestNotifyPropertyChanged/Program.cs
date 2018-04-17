using BenchmarkDotNet.Running;
using System;

namespace Performance.Test.NotifyPropertyChanged
{
    public class Program
    {
        static public void Main(string[] args)
        {
            BenchmarkRunner.Run<TestPerformance>();
            Console.ReadKey();
        }
    }
}
