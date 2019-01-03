using Quartz;
using Quartz.Impl;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Leo.WindowsService
{
    public partial class Service : ServiceBase
    {
        private IScheduler scheduler;

        public Service()
        {
            InitializeComponent();
            this.scheduler = new StdSchedulerFactory().GetScheduler().Result;
        }

        protected override void OnStart(string[] args)
        {
            scheduler.Start();
        }

        protected override void OnStop()
        {
            if (!scheduler.IsShutdown)
                scheduler.Shutdown(false);
        }
    }

    public class Job : IJob
    {
        private IConnection connection;
        private IModel channel;

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                connection = factory.CreateConnection();
                channel = connection.CreateModel();
                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);
                    throw new Exception();
                };
                channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);
            }
            catch (Exception)
            {
                if(!channel.IsClosed)
                channel.Close();

                if(connection.IsOpen)
                connection.Close();
            }
            return Task.FromResult(0);
        }
    }
}
