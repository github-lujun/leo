using Leo.Remoting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace Leo.Remoting
{
    class Program
    {
        static void Main(string[] args)
        {
            //注册通道
            ChannelServices.RegisterChannel(new TcpServerChannel(6666), false);
            //ChannelServices.RegisterChannel(new TcpServerChannel(7777), false);
            //注册远程对象
            //RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject), "mytcp", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject),"mytcp", WellKnownObjectMode.SingleCall);
            /*RemotingConfiguration.ApplicationName = "mytcp";
            RemotingConfiguration.RegisterActivatedServiceType(typeof(RemoteObject));*/

            //ChannelServices.RegisterChannel(new HttpServerChannel(7777), false);
            //RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject), "myhttp", WellKnownObjectMode.SingleCall);

            System.Console.WriteLine("Press Any Key");
            System.Console.ReadLine();
        }
    }
}
