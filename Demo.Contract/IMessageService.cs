using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Contract
{
    

    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        [FaultContract(typeof(DivideByZeroException))]
        [FaultContract(typeof(ArgumentNullException))]
        string GetComputerName();

        [OperationContract]
        string GetEnvironmentVariableValue(String key);
        [OperationContract]
        Stream GetFileData(String fileName);
    }
}
