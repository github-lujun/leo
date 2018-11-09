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
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StackExchange.Redis;

namespace Leo.ConsoleApp
{
     class Program
    {
        delegate void G();

        static void G1()
        {
            //Debug.WriteLine("G1 to do.");
            Debug.Assert(false, "bad");
            Console.WriteLine("hello");
            //Debug.WriteLine("G1 done.");
        }

        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            /*IDatabase db = redis.GetDatabase();
            string key = "name";
            string value = "junlu";
            db.StringSet(key, value);
            Console.WriteLine(db.StringGet(key));*/

            ISubscriber subscriber = redis.GetSubscriber();
            subscriber.Subscribe("message", (channel, message) =>
            {
                Console.WriteLine(message);
            });
            subscriber.Publish("message", "hello");
            /*G g;
            g = G1;
            g();*/
            /*Task.Run(() =>
            {
                //while (true)
                //{ 
                for (int i = 0; i < 10; i++)
                {
                    var factory = new ConnectionFactory() { HostName = "localhost" };
                        //using ()
                        //{
                    var connection = factory.CreateConnection();
                            //using ()
                            //{
                    var channel = connection.CreateModel();
                    channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    string message = "Hello World!"+i;
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
                    Thread.Sleep(5000);
                }
                //}
                //}
                //Thread.Sleep(2000);
                //}
            });*/
            /*Task.Run(() =>
            {
                //while (true)
                //{
                var factory = new ConnectionFactory() { HostName = "localhost" };
                    //using ()
                    //{
                var connection = factory.CreateConnection();
                        //using ()
                        //{
                var channel = connection.CreateModel();
                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);
                };
                channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);
                        //}
                    //}
                    //Thread.Sleep(5000);
                //}
            });*/
            /*Task.Run(() =>
            {
                Console.WriteLine("hello");
            });
            //TestParallel();*/
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

        static Task GetTask()
        {
            return Task.FromResult(0);
        }
    }
}
