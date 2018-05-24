using System.Threading.Tasks;
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
			return _transformer.Transform(fact);
		}
	}
}
