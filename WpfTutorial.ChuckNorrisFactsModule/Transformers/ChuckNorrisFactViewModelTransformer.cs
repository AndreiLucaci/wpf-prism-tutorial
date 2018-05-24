using System.Linq;
using WpfTutorial.ChuckNorrisFactsModule.ViewModels;
using WpfTutorial.Models;

namespace WpfTutorial.ChuckNorrisFactsModule.Transformers
{
	public class ChuckNorrisFactViewModelTransformer
		: ITransform<ChuckNorrisFact, ChuckNorrisFactViewModel>
	{
		public ChuckNorrisFactViewModel Transform(ChuckNorrisFact @from)
		{
			if (from == null) return null;
			return new ChuckNorrisFactViewModel
			{
				IconUrl = from.IconUrl,
				Id = from.Id,
				Url = from.Url,
				Value = from.Value
			};
		}
	}
}
