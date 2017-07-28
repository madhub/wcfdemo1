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
            //1. this will fault the channel
            // throw new InvalidDataException("Invalid data");

            //2. throwing which not declared in the contract via FaultException
            //throw new FaultException("Invalid Arguments");

            //3. throwing which not declared in the contract via FaultException<T>
            //throw new FaultException<InvalidDataException>(new InvalidDataException("Invalid arguments"));

            //4. throwing which is declared in the contract via FaultException<T>
            //throw new FaultException<ArgumentException>(new ArgumentException("Invalid arguments"));

            //5. throwing exception via FaultException<ExceptionDetails>
            //ArgumentException exception =new ArgumentException("Some error");
            //ExceptionDetail detail = new ExceptionDetail(exception);
            //throw new FaultException<ExceptionDetail>(detail, exception.Message);



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

