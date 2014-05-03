using HelloWorldCommon.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldCommon.ServiceContracts
{
    [ServiceContract]
    public interface IGoodbyeWorldService
    {
        [OperationContract]
        string SayFarewell(Person person);
    }
}
