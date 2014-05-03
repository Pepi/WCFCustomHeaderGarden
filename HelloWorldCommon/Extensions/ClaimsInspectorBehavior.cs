using HelloWorldCommon.DataContracts;
using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace HelloWorldCommon.Extensions
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ClaimsInspectorBehavior : Attribute, IDispatchMessageInspector,
        IClientMessageInspector, IEndpointBehavior, IServiceBehavior
    {
        #region IDispatchMessageInspector

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            //Retrieve Inbound Object from Request

            var header = request.Headers.GetHeader<ClaimsHeader>("claims-header", "s");

            if (header != null)
            {
                //ClaimHeaderServerContextExtension.Current.ClaimHeader = header;
                OperationContext.Current.IncomingMessageProperties.Add("ClaimsHeader", header);
            }

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            //No need to do anything else

        }

        #endregion

        #region IClientMessageInspector

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            //Instantiate new HeaderObject with values from ClientContext;
            var dataToSend = new ClaimsHeader
            {
                Token = ClaimsHeaderContext.HeaderInformation.Token,
                AccountId = ClaimsHeaderContext.HeaderInformation.AccountId,
                RequestId = ClaimsHeaderContext.HeaderInformation.RequestId
            };

            var typedHeader = new MessageHeader<ClaimsHeader>(dataToSend);
            var untypedHeader = typedHeader.GetUntypedHeader("claims-header", "s");

            request.Headers.Add(untypedHeader);
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            //No need to do anything else
        }

        #endregion

        #region IEndpointBehavior

        public void Validate(ServiceEndpoint endpoint)
        {

        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            var channelDispatcher = endpointDispatcher.ChannelDispatcher;
            if (channelDispatcher == null) return;
            foreach (var ed in channelDispatcher.Endpoints)
            {
                var inspector = new ClaimsInspectorBehavior();
                ed.DispatchRuntime.MessageInspectors.Add(inspector);
            }
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            var inspector = new ClaimsInspectorBehavior();
            clientRuntime.MessageInspectors.Add(inspector);
        }

        #endregion

        #region IServiceBehaviour

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher cDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (var eDispatcher in cDispatcher.Endpoints)
                {
                    eDispatcher.DispatchRuntime.MessageInspectors.Add(new ClaimsInspectorBehavior());
                }
            }
        }

        #endregion

    }
}
