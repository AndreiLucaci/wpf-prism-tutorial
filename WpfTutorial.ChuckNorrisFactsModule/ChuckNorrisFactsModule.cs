using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using WpfTutorial.ChuckNorrisFactsModule.Unity;

namespace WpfTutorial.ChuckNorrisFactsModule
{
    public class ChuckNorrisFactsModule : IModule
    {
	    private readonly IRegionManager _regionManager;
	    private readonly IUnityContainer _contaiener;
	    protected IUnityContainer Container;

	    public ChuckNorrisFactsModule(IRegionManager regionManager, IUnityContainer contaiener)
	    {
		    _regionManager = regionManager;
		    _contaiener = contaiener;
	    }

		public void Initialize()
		{
			_contaiener
				.ConfigureWithService();

	        _regionManager.RegisterViewWithRegion("MainRegion", typeof(Views.ChuckNorrisFactsGathererView));
        }
    }
}
