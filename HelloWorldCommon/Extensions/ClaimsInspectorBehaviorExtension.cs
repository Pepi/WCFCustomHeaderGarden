using System;
using System.ServiceModel.Configuration;

namespace HelloWorldCommon.Extensions
{
    public class ClaimsInspectorBehaviorExtension : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new ClaimsInspectorBehavior();
        }

        public override Type BehaviorType
        {
            get { return typeof(ClaimsInspectorBehavior); }
        }
    }
}
