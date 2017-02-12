using Microsoft.Practices.Unity;

namespace Syntheseopdracht2.DA.Unity
{
    public class UnityDataAccessConfiguratie : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IBoekenDatabase, BoekenDatabase>(new ContainerControlledLifetimeManager());
        }
    }
}
