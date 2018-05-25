using System.Collections.Concurrent;
using System.Threading.Tasks;
using WpfTutorial.ChuckNorrisFactsModule.Exceptions;
using WpfTutorial.ChuckNorrisFactsModule.Transformers;
using WpfTutorial.ChuckNorrisFactsModule.ViewModels;
using WpfTutorial.Models;
using WpfTutorial.Service;

namespace WpfTutorial.ChuckNorrisFactsModule.Services
{
	public class ChuckNorrisService : IChuckNorrisService
	{
		private readonly IChuckNorrisFactsService _service;
		private readonly ITransform<ChuckNorrisFact, ChuckNorrisFactViewModel> _transformer;

		public ChuckNorrisService(IChuckNorrisFactsService service,
			ITransform<ChuckNorrisFact, ChuckNorrisFactViewModel> transformer)
		{
			_service = service;
			_transformer = transformer;
		}

		public async Task<ChuckNorrisFactViewModel> GetOneFactAsync()
		{
			var fact = await _service.GetOneFactAsync();

			if (fact == null)
			{
				throw new NullFactsException("Something went wrong while gathering a fact. Fact is null");
			}

			return _transformer.Transform(fact);
		}

		public Task<ChuckNorrisFactViewModel[]> GetMultipleFactsAsync(int numberOfFacts)
		{
			var concurentBag = new ConcurrentBag<Task<ChuckNorrisFactViewModel>>();

			Parallel.For(0, numberOfFacts, i => concurentBag.Add(GetOneFactAsync()));

			return Task.WhenAll(concurentBag);
		}
	}
}
