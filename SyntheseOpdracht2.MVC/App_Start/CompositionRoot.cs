using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using SyntheseOpdracht2.MVC.DI;
using SyntheseOpdracht2.MVC.DI.Unity;
using SyntheseOpdracht2.MVC.DI.Unity.ContainerExtensions;
using Syntheseopdracht2.BL.Unity;

internal class CompositionRoot
{
    public static IDependencyInjectionContainer Compose()
    {
        var container = new UnityContainer();
        container.AddNewExtension<MvcSiteMapProviderContainerExtension>();
        container.AddNewExtension<UnityBusinessConfiguratie>();

        return new UnityDependencyInjectionContainer(container);
    }
}
