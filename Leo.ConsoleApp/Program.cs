using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//Import log4net classess.
using log4net;
using log4net.Config;

namespace Leo.ConsoleApp
{
     class Program
    {
        static void Main(string[] args)
        {
            TestParallel();
            Console.Read();
        }

        static void TestParallel()
        {
            List<int> list = new List<int>();

            Parallel.For(1, 9, p =>
            {
                list.Add(p);
                Console.WriteLine($"index：{p}，taskid：{Task.CurrentId}，threadid：{Thread.CurrentThread.ManagedThreadId}");
            });

            Parallel.ForEach(list, l =>
            {
                Console.WriteLine(l);
            });

            Parallel.Invoke(() => 
            {
                Console.WriteLine(1);
            }, () => 
            {
                Console.WriteLine(2);
            });
        }
     }
}
