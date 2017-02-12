using Microsoft.Practices.Unity;
using Syntheseopdracht2.BL;
using Syntheseopdracht2.DA.Unity;

namespace Syntheseopdracht2.UI.Unity
{
    public class UnityPresentatieConfiguratie : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.AddNewExtension<UnityDataAccessConfiguratie>();
            Container.RegisterType<IGenreLogica, GenreLogica>(new TransientLifetimeManager());
            Container.RegisterType<IBoekLogica, BoekLogica>(new TransientLifetimeManager());
        }
    }
}
