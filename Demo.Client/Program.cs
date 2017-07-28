using Demo.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Demo.Client
{
    public class ServiceClient : ClientBase<IMessageService>, IMessageService
    {
        public string GetComputerName()
        {
            return base.Channel.GetComputerName();
        }

        public string GetEnvironmentVariableValue(string key)
        {
            return base.Channel.GetEnvironmentVariableValue(key);
        }

        public Stream GetFileData(string fileName)
        {
            return base.Channel.GetFileData(fileName);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            ServiceClient sc = new ServiceClient();
            try
            {
                var computerName = sc.GetComputerName();
                Console.WriteLine(computerName);
            }
            catch (FaultException<DivideByZeroException> edbe)
            {
                Console.WriteLine("FaultException<DivideByZeroException>");
            }
            catch (FaultException<ArgumentNullException> ane)
            {
                Console.WriteLine("FaultException<ArgumentNullException>");
            }
            catch (FaultException<ExceptionDetail> fee)
            {
                Console.WriteLine("Exception is thrown by service \n\r Exception Type:{0}\r\n FaultException<ExceptionDetail> \r\n Message:{1}\r\n Proxy State:{2}",
                    fee.GetType().Name,
                    fee.Detail.Message,
                    sc.State.ToString());
            }
            catch (FaultException fe)
            {
                Console.WriteLine("FaultException is thrown by service \n\r Exception Type:{0}\r\n FaultException \r\n Message:{1}\r\n Proxy State:{2}",
                    fe.GetType().Name,
                    fe.Message,
                    sc.State.ToString());
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception is thrown by service \n\r Exception Type:{0}\r\n Message:{1}\r\n Proxy State:{2}",
                    exp.GetType().Name,
                    exp.Message, 
                    sc.State.ToString());
                
            }
            try
            {
                Console.WriteLine(sc.GetEnvironmentVariableValue("LOGONSERVER"));
            }
            catch (Exception)
            {
                Console.WriteLine("Second call failed");
                ServiceClient sc2 = new ServiceClient();
                Console.WriteLine(sc2.GetEnvironmentVariableValue("LOGONSERVER"));
                
            }
            

            sc.Close();

            Console.ReadLine();


        }

        private static void Sf_Opening(object sender, EventArgs e)
        {
            Console.WriteLine("Sf_Opening");
        }

        private static void Sf_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Sf_Opened");
        }

        private static void Sf_Faulted(object sender, EventArgs e)
        {
            Console.WriteLine("Channel Sf_Faulted");
        }
    }
}
