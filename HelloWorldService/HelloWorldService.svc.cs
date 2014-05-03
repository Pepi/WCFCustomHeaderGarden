using HelloWorldCommon.DataContracts;
using HelloWorldCommon.Extensions;
using HelloWorldCommon.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelloWorldService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HelloWorldService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HelloWorldService.svc or HelloWorldService.svc.cs at the Solution Explorer and start debugging.
    [ClaimsInspectorBehavior]
    public class HelloWorldService : IHelloWorldService
    {
        public ClaimsHeader HeaderInformation
        {
            get
            {
                var claimsHeader =
                    OperationContext.Current.IncomingMessageProperties.FirstOrDefault(f => f.Key == "ClaimsHeader").Value as
                    ClaimsHeader;

                return claimsHeader;
            }
        }

        public string SayHello(Person person)
        {
            return string.Format("Nice to meet you {0} {1} {2}", person.FirstName, person.LastName, HeaderInformation.Token);
        }
    }
}
