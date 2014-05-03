using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using HelloWorldCommon.ServiceContracts;
using System.ServiceModel;

namespace HelloWorldClient
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      container.RegisterType<IHelloWorldService>(
          new ContainerControlledLifetimeManager(),
          new InjectionFactory(
              (c) => new ChannelFactory<IHelloWorldService>("BasicHttpBinding_IHelloWorldService").CreateChannel()));

      container.RegisterType<IGoodbyeWorldService>(
          new ContainerControlledLifetimeManager(),
          new InjectionFactory(
              (c) => new ChannelFactory<IGoodbyeWorldService>("BasicHttpBinding_IGoodbyeWorldService").CreateChannel()));

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}