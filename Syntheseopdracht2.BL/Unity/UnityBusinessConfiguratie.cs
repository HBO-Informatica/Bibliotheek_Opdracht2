using Microsoft.Practices.Unity;
using Syntheseopdracht2.DA.Unity;

namespace Syntheseopdracht2.BL.Unity
{
    public class UnityBusinessConfiguratie : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.AddNewExtension<UnityDataAccessConfiguratie>();
            Container.RegisterType<IGenreLogica, GenreLogica>(new TransientLifetimeManager());
            Container.RegisterType<IBoekLogica, BoekLogica>(new TransientLifetimeManager());
        }
    }
}
