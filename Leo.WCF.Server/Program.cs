using Leo.WCF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Leo.WCF.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(PersonService));
            host.Open();
            Console.WriteLine("service start.");
            Console.Read();
            host.Close();
        }
    }
}
