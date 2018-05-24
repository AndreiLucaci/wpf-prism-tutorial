using System.Net.Http;
using Microsoft.Practices.Unity;
using WpfTutorial.Service;

namespace WpfTutorial.Unity
{
    public static class UnityConfiguration
    {
        /// <summary>
        /// Configures the unity with HttpClient
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static IUnityContainer ConfigureWithHttpClient(this IUnityContainer container)
        {
            container.RegisterInstance(new HttpClient());

            return container;
        }

        /// <summary>
        /// Configures the unity with service
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static IUnityContainer ConfigureWithService(this IUnityContainer container)
        {
            container.RegisterType<IChuckNorrisFactsService, ChuckNorrisFactsService>(
                new InjectionConstructor(
                    new ResolvedParameter<HttpClient>()
                )
            );

            return container;
        } 
    }
}
