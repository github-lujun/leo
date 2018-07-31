using System;
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
    class Person
    {
        /// <summary>
        /// 只读字段，初始化后构造函数仍可以再修改一次。
        /// </summary>
        public readonly string Name = "lujun";
        public Person()
        {
            Console.WriteLine(this.Name);
            this.Name = "jack";
            Console.WriteLine(this.Name);
        }
    }

     class Program
      {
        //创建计时器
        private static readonly Stopwatch Watch = new Stopwatch();
  
        private static readonly object obj=new object();
        private static void Main(string[] args)
        {
            //MyTestMethod1();
            //MyTestMethod2();
            //TestCancellationTokenTask();
            //MyTestMethod3();
            MyTestMethod4();
            Console.Read();
        }

        private static void MyTestMethod4()
        {
            
        }

        private static void MyTestMethod3()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            //cts.Cancel();
            var isCancel = cts.IsCancellationRequested;
            Console.WriteLine(isCancel);
        }

        public static void TestCancellationTokenTask()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            try
            {
                Task task = Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        //当任务取消时，这段检测代码将永远不会被执行，因为任务已经被取消了
                        if (cts.Token.IsCancellationRequested)
                        {
                            Console.WriteLine("=====Task=====");
                            Console.WriteLine("任务被取消");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("=====Task=====");
                            Console.WriteLine("子线程打印：{0}", i);
                            Thread.Sleep(1000);
                        }
                    }
                }, cts.Token);

                for (int i = 0; i < 5; i++)
                {
                    if (i == 3)
                    {
                        Console.WriteLine("=====Main=====");
                        Console.WriteLine("主线程抛出异常");
                        throw new Exception("测试");
                    }

                    Console.WriteLine("=====Main=====");
                    Console.WriteLine("主线程打印：{0}", i);
                    Thread.Sleep(1000);
                }

                task.Wait();
            }
            catch
            {
                //cts.Cancel();
            }
            Console.WriteLine(cts.IsCancellationRequested);
        }

        public static void MyTestMethod2()
        {
            Console.WriteLine("start...");
            var canceled = false;
            Task.Run(() => 
            {
                Console.WriteLine(2);
            }, new CancellationToken(canceled));
            Console.WriteLine("end...");
        }

        public static void MyTestMethod1()
        {
            var task = Task.Run<int>(()=> { return 1; });
            //task.Wait();//多余
            var result = task.Result;
            Console.WriteLine(result);
        }
    
        private static void Test1()
        {
            Task.Run(() =>
            {
                using (FileStream fs = new FileStream(@"C:/a.text", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    while (true)
                    {
                        byte[] a = new byte[2];
                        fs.Read(a, 0, a.Length);
                        fs.Write(a, 0, a.Length);
                    }
                    fs.Close();
                    fs.Dispose();
                }
            });
            Task.Run(() =>
            {
                Console.WriteLine("File" + System.IO.File.Exists(@"C:/a.text"));
            });
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<int> t = new Task<int>(() => { return 1; }, cts.Token);
            t.Start();
            //前台线程，无线程池
            var tread = new System.Threading.Thread(() => { });
            Console.WriteLine(tread.IsBackground);
            //后台线程，有线程池
            Parallel.For(0, 5, i =>
            {
                Console.WriteLine(i);
            });
            int workerThreads = 0;//2047
            int completionPortThreads = 0;//1000
            ThreadPool.SetMinThreads(2, 5);
            ThreadPool.SetMaxThreads(5, 10);
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine(workerThreads + "," + completionPortThreads);
            for (int i = 0; i < 5; i++)
            {
                Task.Run(() =>
                {
                    Thread.Sleep(10000);
                    Console.WriteLine($"i {Thread.CurrentThread.ManagedThreadId} am finished");
                });
                /*new Thread(() =>
                {
                    Thread.Sleep(5000);
                    ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
                    Console.WriteLine(workerThreads + "," + completionPortThreads);
                }).Start();*/
                /*ThreadPool.QueueUserWorkItem(state=> 
                {
                    Thread.Sleep(6000);
                    //ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
                    //Console.WriteLine(workerThreads + "," + completionPortThreads);
                });*/
            }
            Thread.Sleep(5000);
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine(workerThreads + "," + completionPortThreads);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var task = Task.Run(() =>
            {
                Thread.Sleep(5000);
                ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
                Console.WriteLine(workerThreads + "," + completionPortThreads);
                Console.WriteLine($"i {Thread.CurrentThread.ManagedThreadId} am finished");
                Console.WriteLine("hello");
            });
            var isFinish = task.Wait(18000);
            Console.WriteLine(isFinish);
            //Taskg();
            //new Task(()=> { }).Start();
            //net4
            /*Task.Factory.StartNew(() => 
            {
                return 1;
            });*/
            //net4.5

            /*Task<int>.Run(() => 
            {
                return 1;
            }).ContinueWith((task)=> 
            {
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine(task.Result);
            });
            Task<int>.Run(() =>
            {
                return 2;
            }).ContinueWith((task) =>
            {

                Console.WriteLine(task.Result);
            });*/


            //Task.Factory.ContinueWhenAll(null, (data) => { });
            /*Task t1 = new Task(() =>
            {
                Console.WriteLine("yo yo");
            });
            Console.WriteLine(t1.Status);*/
            /*Task t1 = Task.Run(()=> 
            {
                Console.WriteLine("now");
            });*/
            /*t1.Start();
            while (!t1.IsCompleted)
            {
                t1.Wait();
                Console.WriteLine(t1.Status);
            }
            Console.WriteLine(t1.Status);*/
            //Taskg().Wait();
            /*Task.Run(() =>
            {
                return 1;
            }).ContinueWith((t)=> 
            {
                Console.WriteLine(5);
            });*/
            //var t = Tuple.Create(1, 1.0, true, 'a', "hello", new List<int> { 1 });
            //Console.WriteLine(t.Item1);
            //MainAsync(args);//.GetAwaiter().GetResult();
            //GetTask().Wait();
            //GetTask().Wait();
            //var r = task.Result;
            //Console.WriteLine(r);
            /*var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                //var r = awaiter.GetResult();
                var r = task.Result;
                Console.WriteLine(r);
            });*/
            /*while (!awaiter.IsCompleted)
            {
            }*/
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }
        private static async Task TaskAsync()
        {
            Console.WriteLine("outer1:"+System.Threading.Thread.CurrentThread.ManagedThreadId);
            await Task.Run(() =>
            {
                Console.WriteLine("inner1:" + System.Threading.Thread.CurrentThread.ManagedThreadId);
            });
            Console.WriteLine("outer2:" + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }
        private static void Taskg()
        {
            /*var r = await Task.Run<int>(() =>
            {
                return 1;
            });
            Console.WriteLine(r);*/
            var r1 = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000);
                return 1;
            });

            //Console.WriteLine(r1);

            var r2 = Task.Run(() =>
            {
                return 2;
            });

            //Console.WriteLine(r2);
            //Task.WaitAll(r1, r2);
            Task.Factory.ContinueWhenAll(new Task[] { r1, r2 }, (r) =>
            {
                r[0].ContinueWith((a1) => 
                {
                    Console.WriteLine(a1);
                });
                r[1].ContinueWith((a2) =>
                {
                    Console.WriteLine(a2);
                });
            });

        }
        /// <summary>
        /// task taskawaiter
        /// </summary>
        /// <param name="args"></param>
        private static IEnumerable<int> Get(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                yield return arr[i];
            }
        }

        private static async Task GetTask1()
        {
            await Task.Run(()=> { });
        }

        private static async Task GetTask()
        {
            await GetTask1();
            FileStream fs = new FileStream(@"H:\test.txt", FileMode.Open);
            byte[] arr=new byte[(int)fs.Length];
            var r = fs.BeginRead(arr, 0, (int)fs.Length, ar => 
            {
                if (ar.IsCompleted)
                {
                    Console.WriteLine(arr.Length);
                }
            },null);
            var count = fs.EndRead(r);
            /*Action a = () =>
            {
                Console.WriteLine(2);
            };


            a();
            var task = Task.Run(()=> 
            {
                return 1;
            });
            return await task;*/
        }

        /*private static System.Threading.Tasks.ValueType<int> GetValueTask()
        {

        }*/

        private static void MainAsync(string[] args)
        {
            Task.Run(()=> 
            {
                System.Threading.Thread.Sleep(5000);
            });

            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000);
            });
            /*foreach (var item in Get(new[] { 1,2,3,4}))
            {
                //Console.WriteLine(item);
            }*/
            //var client = new WebClient();
            /*client.DownloadStringCompleted += (s,e)=> 
            {
                Console.WriteLine(e.Result);
            };
            client.DownloadStringAsync(new Uri("http://www.baidu.com"));*/
            //var r = await client.DownloadStringTaskAsync("http://www.baidu.com");
            //Console.WriteLine(r);
            //Stopwatch w = new Stopwatch();
            /*double n = 0;
            for (int j = 0; j < 10; j++)
            {

            long m = 0;
            
            for (int i = 0; i < 10000; i++)
            {*/
            /*var task1 = Task.Run(()=> 
            {
                System.Threading.Thread.Sleep(4000);
                return 1;
            });
            var task2 = Task.Run(() => 
            {
                System.Threading.Thread.Sleep(8000);
                return 2;
            });*/
            //Console.WriteLine(task1.Result);
            //Console.WriteLine(task2.Result);
            //w.Start();
            //Console.WriteLine("outer1:" + System.Threading.Thread.CurrentThread.ManagedThreadId);
            //Task.WaitAll(task1, task2);

            //Console.WriteLine("outer2:" + System.Threading.Thread.CurrentThread.ManagedThreadId);
            //Console.WriteLine(task1.GetAwaiter().GetResult() + "," + task2.GetAwaiter().GetResult());
            //m += w.ElapsedTicks;
            //w.Reset();
            //w.Stop();
            //Console.WriteLine(w.ElapsedMilliseconds);
            /*}
                n += m / 10000.0;
            }*/
            //Console.WriteLine(n / 10.0);
            //Console.WriteLine("outer0:" + System.Threading.Thread.CurrentThread.ManagedThreadId);
            //TaskAsync();
            //Console.WriteLine("outer3:" + System.Threading.Thread.CurrentThread.ManagedThreadId);
            //启动计时器
            //Watch.Start();

            //const string url1 = "http://www.cnblogs.com/";
            //const string url2 = "http://www.cnblogs.com/liqingwen/";

            //两次调用 CountCharacters 方法（下载某网站内容，并统计字符的个数）
            //Task<int> t1 = CountCharacters(1, url1);
            //Task<int> t2 = CountCharacters(2, url2);

            //三次调用 ExtraOperation 方法（主要是通过拼接字符串达到耗时操作）
            /*for (var i = 0; i< 3; i++)
            {
                ExtraOperation(i + 1);
            }*/

            //控制台输出
            //Console.WriteLine($"{url1} 的字符个数：{t1.Result}");
            //Console.WriteLine($"{url2} 的字符个数：{t2.Result}");
            //var t1 = T1();
            //var t2 = T2();
            //Console.WriteLine(t2.Result);
            //Console.WriteLine(t1.Result);
            /*int workerThreads;
            int completionPortThreads;
            System.Threading.ThreadPool.SetMaxThreads(10, 10);
            System.Threading.ThreadPool.SetMinThreads(5, 5);*/
            //for (int i = 0; i < 15; i++)
            //{
            //lock (obj)
            //{
            /*System.Threading.ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine(workerThreads);
            Console.WriteLine(completionPortThreads);
            System.Threading.ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine(workerThreads);
            Console.WriteLine(completionPortThreads);
            System.Threading.ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine(workerThreads);
            Console.WriteLine(completionPortThreads);*/
            //Console.WriteLine($"------------------{i}------------------");
            /*Task.Run(() =>
            {
                    while (true)
                    {
                        lock (obj) { 
                        if (i == 10)
                        {
                            Console.WriteLine($"------------------i am {i}------------------");
                            System.Threading.ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
                            Console.WriteLine(workerThreads);
                            Console.WriteLine(completionPortThreads);
                            System.Threading.ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);
                            Console.WriteLine(workerThreads);
                            Console.WriteLine(completionPortThreads);
                            System.Threading.ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
                            Console.WriteLine(workerThreads);
                            Console.WriteLine(completionPortThreads);
                            Console.WriteLine($"------------------i am {i}------------------");
                            break;
                        }
                    }
                }
            });
            //}
        }*/
            /*System.Threading.ThreadPool.GetMaxThreads(out workerThreads,out completionPortThreads);
            Console.WriteLine(workerThreads);
            Console.WriteLine(completionPortThreads);
            System.Threading.ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine(workerThreads);
            Console.WriteLine(completionPortThreads);
            System.Threading.ThreadPool.GetAvailableThreads(out workerThreads,out completionPortThreads);
            Console.WriteLine(workerThreads);
            Console.WriteLine(completionPortThreads);
            List<int> list = new List<int>();
            for (int i = 0; i <20; i++)
            {
                Console.WriteLine(i);
                System.Threading.Thread.Sleep(2000);
                System.Threading.ThreadPool.QueueUserWorkItem((obj) =>
                {
                    if (!list.Contains(i)) list.Add(i);
                    System.Threading.Thread.Sleep(1000);
                });
            }
            Console.WriteLine($"------------------------------------");
            System.Threading.ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine(workerThreads);
            Console.WriteLine(completionPortThreads);
            System.Threading.ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine(workerThreads);
            Console.WriteLine(completionPortThreads);
            System.Threading.ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine(workerThreads);
            Console.WriteLine(completionPortThreads);
            System.Threading.ThreadPool.QueueUserWorkItem((obj) =>
            {
                while (true) foreach (var item in list)
                    {
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine(item);
                    }
            });*/
            //Console.Read();
        }

        private static Task<string> T1()
        {
            return Task.Run<string>(() =>
            {
                System.Threading.Thread.Sleep(5000);
                return "hello";
            });
        }

        private static async Task<string> T2()
        {
            return await Task.Run<string>(() =>
            {
                //System.Threading.Thread.Sleep(5000);
                return "world";
            });
        }

        /// <summary>
        /// 统计字符个数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        private static async Task<int> CountCharacters(int id, string address)
         {
             var wc = new WebClient();
             Console.WriteLine($"开始调用 id = {id}：{Watch.ElapsedMilliseconds} ms");

            //var result = await wc.DownloadStringTaskAsync(address);
            var result = await Task<string>.Run(()=> 
            {
                if (id == 1)
                {
                    System.Threading.Thread.Sleep(10000);
                }
                return "12345";
            });
             Console.WriteLine($"调用完成 id = {id}：{Watch.ElapsedMilliseconds} ms");
 
             return result.Length;
         }
 
        /// <summary>
        /// 额外操作
        /// </summary>
        /// <param name="id"></param>
        private static void ExtraOperation(int id)
        {
            //这里是通过拼接字符串进行一些相对耗时的操作
            var s = "";
 
            for (var i = 0; i< 6000; i++)
            {
                s += i;
            }
 
            Console.WriteLine($"id = {id} 的 ExtraOperation 方法完成：{Watch.ElapsedMilliseconds} ms");
        }
     }

    class Program1
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// 数字转中文
        /// </summary>
        /// <param name="number">eg: 22</param>
        /// <returns></returns>
        public static string NumberToChinese(int number)
        {
            string res = string.Empty;
            string str = number.ToString();
            string schar = str.Substring(0, 1);
            switch (schar)
            {
                case "1":
                    res = "一";
                    break;
                case "2":
                    res = "二";
                    break;
                case "3":
                    res = "三";
                    break;
                case "4":
                    res = "四";
                    break;
                case "5":
                    res = "五";
                    break;
                case "6":
                    res = "六";
                    break;
                case "7":
                    res = "七";
                    break;
                case "8":
                    res = "八";
                    break;
                case "9":
                    res = "九";
                    break;
                default:
                    res = "零";
                    break;
            }
            if (str.Length > 1)
            {
                switch (str.Length)
                {
                    case 2:
                    case 6:
                        res += "十";
                        break;
                    case 3:
                    case 7:
                        res += "百";
                        break;
                    case 4:
                        res += "千";
                        break;
                    case 5:
                        res += "万";
                        break;
                    default:
                        res += "";
                        break;
                }
                res += NumberToChinese(int.Parse(str.Substring(1, str.Length - 1)));
            }
            return res;
        }

        static int reverse(int x)
        {
            int signal = x > 0 ? 1 : -1;
            x = x > 0 ? x : x * -1;
            int length = 1;
            while (x % 10 == 0) { x /= 10; }
            int y = x;
            while ((y /= 10) != 0)
            {
                length++;
            }
            int r = 0;
            while (length > 0) { 
                r += (x % 10) * plus(10, (length - 1));
                x /= 10;
                length--;
            }
            return r * signal;
        }

        static int plus(int x, int times)
        {
            if (times == 0) return 1;
            while (times > 1)
            {
                x *= x;
                times--;
            }
            return x;
        }

        static async Task<int> AsyncTest1()
        {
            /*Task<int> task = new Task<int>(() =>
            {
                return 1;
            });
            return task;*/
            /*await Task.Factory.StartNew(() =>
            {
                var count = 100;
                while (count > 0)
                {
                    if (count % 2 == 0)
                    {
                        Console.WriteLine($"{count}偶数");
                    }
                    System.Threading.Thread.Sleep(100);
                    count--;
                }
            });*/
            /*Task<int> task = new Task<int>(()=> 
            {
                System.Threading.Thread.Sleep(5000);
                return 1;
            });*/
            //task.Start();
            //var r = await task;
            //return r;
            var a = "";
            await Task.Run(() =>
            {
                a = "1";
                System.Threading.Thread.Sleep(5000);
            });
            return a.Length;
        }
        static async Task<int> AsyncTest2()
        {
            /*await Task.Run(() =>
            {
                var count = 100;
                while (count > 0)
                {
                    if (count % 2 != 0)
                    {
                        Console.WriteLine($"{count}qi数");
                    }
                    System.Threading.Thread.Sleep(100);
                    count--;
                }
            });*/
            /*Task<int> task = new Task<int>(() =>
            {
                return 2;
            });
            //task.Start();
            var r = await task;
            return r;*/
            var a = "";
            await Task.Run(() =>
            {
                a = "12";
            });
            return a.Length;
        }

        static void Main1(string[] args)
        {
            Task<int> task1 = AsyncTest1();
            Task<int> task2 = AsyncTest2();
            Console.WriteLine(task1.Result);
            Console.WriteLine(task2.Result);
            //AsyncTest().GetAwaiter().GetResult();
            //Task.WhenAll(new Task[] { AsyncTest1, AsyncTest2 });
            /*int result=0;
            result = awaiter.GetResult();
            var isCompleted = false;
            while (!isCompleted)
            {
                isCompleted = awaiter.IsCompleted;
                if (isCompleted)
                {
                    result = awaiter.GetResult();
                    break;
                }
            }
            Console.WriteLine(result);*/


            //var date = new DateTime();
            //Console.WriteLine(date);

            //var r = reverse(789);
            //var p = new Person();
            //Console.WriteLine(p.Name);
            /*for (int i = 0; i < 145; i++)
            {
                Console.WriteLine(NumberToChinese(i));
            }*/
            //Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            Console.Read();
            //if (args.Length == 0)
            //{
            //    Console.Write("命令行应用程序：Leo.ConsoleApp，版本：v1.0.0。");
            //}
            //else {
            //    Console.Write(args[0]);
            //}
            //decimal num = 100.126M;
            //Console.WriteLine(num.ToString("0.00"));
            //Console.WriteLine(Math.Round(num, 2));
            //XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, System.Configuration.ConfigurationManager.AppSettings["log4net.config"])));
            //for (int i = 0; i < 1000; i++)
            //{
            //    log.Info("Entering");
            //    log.Info("Exiting");
            //}

            //int i = 0;
            //int j = 0;
            //var c = i == 0 || ++i > 1;
            //var d = j == 0 | ++j > 1;
            //Console.WriteLine(i);
            //Console.WriteLine(j);
        }
    }
}
