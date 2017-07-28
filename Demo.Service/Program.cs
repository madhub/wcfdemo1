using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service
{
    class Program
    {

        static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(MessageServiceManager));

            serviceHost.Open();
            Console.WriteLine("Service Started ... Press Enter to exit");
            Console.ReadLine();
            serviceHost.Close();

        }
    }
}
