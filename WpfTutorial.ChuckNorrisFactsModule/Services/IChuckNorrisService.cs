using System.Threading.Tasks;
using WpfTutorial.ChuckNorrisFactsModule.ViewModels;

namespace WpfTutorial.ChuckNorrisFactsModule.Services
{
	public interface IChuckNorrisService
	{
		Task<ChuckNorrisFactViewModel> GetOneFactAsync();
		Task<ChuckNorrisFactViewModel[]> GetMultipleFactsAsync(int numberOfFacts);
	}
}
