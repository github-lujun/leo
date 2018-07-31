using Leo.Remoting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace Leo.Remoting.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //ChannelServices.RegisterChannel(new TcpClientChannel(),false);
            RemoteObject remoteobj = (RemoteObject)Activator.GetObject(typeof(RemoteObject),"tcp://localhost:6666/mytcp");
            //RemoteObject remoteobj = (RemoteObject)Activator.GetObject(typeof(RemoteObject), "http://localhost:7777/myhttp");
            /*RemotingConfiguration.RegisterActivatedClientType(typeof(RemoteObject), "tcp://localhost:6666/mytcp");
            remoteobj = new RemoteObject();*/
            //remoteobj = (RemoteObject)Activator.CreateInstance(typeof(RemoteObject), null, new UrlAttribute("tcp://localhost:6666/mytcp"));
            Console.WriteLine("1 + 2 = " + remoteobj.sum(1, 2).ToString());
            Console.ReadLine();
        }
    }
}
