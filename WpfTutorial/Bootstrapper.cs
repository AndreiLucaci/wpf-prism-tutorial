using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;

namespace WpfTutorial
{
    public class Bootstrapper : UnityBootstrapper
    {
	    protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

		protected override IUnityContainer CreateContainer()
		{
			return new UnityContainer();
		}

		protected override void ConfigureModuleCatalog()
		{
			base.ConfigureModuleCatalog();
			var moduleCatalog = (ModuleCatalog) ModuleCatalog;
			moduleCatalog.AddModule(typeof(ChuckNorrisFactsModule.ChuckNorrisFactsModule));
		}

		protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Shell) Shell;
            Application.Current.MainWindow.Show();
        }
    }
}
