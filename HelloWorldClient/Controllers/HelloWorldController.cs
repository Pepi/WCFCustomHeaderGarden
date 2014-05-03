using HelloWorldCommon.DataContracts;
using HelloWorldCommon.Extensions;
using HelloWorldCommon.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldClient.Controllers
{
    public class HelloWorldController : Controller
    {
        private IHelloWorldService _HelloWorldService;
        private IGoodbyeWorldService _GoodbyeWorldService;

        public HelloWorldController(IHelloWorldService helloWorldService, IGoodbyeWorldService goodbyeWorldService)
        {
            _HelloWorldService = helloWorldService;
            _GoodbyeWorldService = goodbyeWorldService;
            ClaimsHeaderContext.HeaderInformation.Token = Guid.NewGuid().ToString();
            ClaimsHeaderContext.HeaderInformation.AccountId = 23;
            ClaimsHeaderContext.HeaderInformation.RequestId = 135;
        }
        //
        // GET: /HelloWorld/
        public string Index()
        {
            var person = new Person() { FirstName = "John", LastName = "Smith", Age = 35 };
            var helloResponse = _HelloWorldService.SayHello(person);
            var goodbyeResponse = _GoodbyeWorldService.SayFarewell(person);

            return string.Format("{0}<br>{1}", helloResponse, goodbyeResponse);
        }
	}
}