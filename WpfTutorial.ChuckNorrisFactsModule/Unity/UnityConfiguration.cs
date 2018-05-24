using System.Net.Http;
using Microsoft.Practices.Unity;
using WpfTutorial.ChuckNorrisFactsModule.Services;
using WpfTutorial.ChuckNorrisFactsModule.Transformers;
using WpfTutorial.ChuckNorrisFactsModule.ViewModels;
using WpfTutorial.Models;
using WpfTutorial.Service;

namespace WpfTutorial.ChuckNorrisFactsModule.Unity
{
    public static class UnityConfiguration
    {
        private static IUnityContainer ConfigureWithHttpClient(this IUnityContainer container)
        {
            container.RegisterInstance(new HttpClient());

            return container;
        }

	    private static IUnityContainer ConfigureWithTransformers(this IUnityContainer container)
	    {
		    container
			    .RegisterType<ITransform<ChuckNorrisFact, ChuckNorrisFactViewModel>, ChuckNorrisFactViewModelTransformer>();

		    return container;
	    }
		
		/// <summary>
		/// Configures the unity with service
		/// </summary>
		/// <param name="container"></param>
		/// <returns></returns>
		public static IUnityContainer ConfigureWithService(this IUnityContainer container)
        {
	        container
				.ConfigureWithHttpClient()
				.ConfigureWithTransformers();
			
            container.RegisterType<IChuckNorrisFactsService, ChuckNorrisFactsService>(
                new InjectionConstructor(
                    new ResolvedParameter<HttpClient>()
                )
            );

	        container.RegisterType<IChuckNorrisService, ChuckNorrisService>(
		        new InjectionConstructor(
			        container.Resolve<IChuckNorrisFactsService>(),
			        container.Resolve<ITransform<ChuckNorrisFact, ChuckNorrisFactViewModel>>()
		        )
	        );

            return container;
        } 
    }
}
