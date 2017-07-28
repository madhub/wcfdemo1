using Demo.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;



namespace Demo.Service
{
    [ServiceBehavior(IncludeExceptionDetailInFaults =true)]
    public class MessageServiceManager : IMessageService
    {
        public string GetComputerName()
        {
            Console.WriteLine("Message Received :GetComputerName");
            //return Environment.MachineName;
            //throw new FaultException("Invalid Arguments");
            // throw new ArgumentException("Invalid Arguments");
             throw new FaultException<ArgumentException>(new ArgumentException("Invalid arguments"));
           // throw new FaultException<ArgumentException>(new ArgumentNullException("Arg null"));
        }

        public string GetEnvironmentVariableValue(string key)
        {
            Console.WriteLine("Message Received :GetEnvironmentVariableValue");
            return Environment.GetEnvironmentVariable(key);
            
        }

        public Stream GetFileData(string fileName)
        {
            Console.WriteLine("Message Received :GetFileData");
            return new FileStream(fileName, FileMode.Open);
        }
    }
}

