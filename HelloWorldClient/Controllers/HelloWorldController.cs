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

        public HelloWorldController(IHelloWorldService helloWorldService)
        {
            _HelloWorldService = helloWorldService;
        }
        //
        // GET: /HelloWorld/
        public string Index()
        {
            // based off the great research at http://trycatch.me/adding-custom-message-headers-to-a-wcf-service-using-inspectors-behaviors/
            ClaimsHeaderContext.HeaderInformation.Token = DateTime.Now.ToLongTimeString();

            var response = _HelloWorldService.SayHello(new Person() { FirstName = "John", LastName = "Smith", Age = 35 });
            return response;
        }
	}
}