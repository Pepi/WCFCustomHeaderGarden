using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldCommon.DataContracts
{
    [DataContract]
    public class ClaimsHeader
    {
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public int AccountId { get; set; }
        [DataMember]
        public int RequestId { get; set; }
    }
}
