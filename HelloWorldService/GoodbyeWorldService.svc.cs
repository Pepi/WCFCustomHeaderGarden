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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GoodbyeWorldService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GoodbyeWorldService.svc or GoodbyeWorldService.svc.cs at the Solution Explorer and start debugging.
    [ClaimsInspectorBehavior]
    public class GoodbyeWorldService : IGoodbyeWorldService
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

        public string SayFarewell(Person person)
        {
            return string.Format("Farewell!<br>{0}<br>{1}<br>{2}<br>{3}<br>{4}", person.FirstName, person.LastName, HeaderInformation.Token, HeaderInformation.AccountId, HeaderInformation.RequestId);
        }
    }
}
