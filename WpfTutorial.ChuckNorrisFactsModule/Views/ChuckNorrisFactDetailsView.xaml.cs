using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfTutorial.ChuckNorrisFactsModule.ViewModels;

namespace WpfTutorial.ChuckNorrisFactsModule.Views
{
	/// <summary>
	/// Interaction logic for ChuckNorrisFactDetailsView.xaml
	/// </summary>
	public partial class ChuckNorrisFactDetailsView : UserControl
	{
		private ChuckNorrisFactViewModel _viewModel;

		public ChuckNorrisFactDetailsView()
		{
			InitializeComponent();
		}

		public void SetViewModel(ChuckNorrisFactViewModel viewModel)
		{
			_viewModel = viewModel;
			DataContext = null;
			DataContext = viewModel;
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			if (_viewModel != null)
			{
				System.Diagnostics.Process.Start(_viewModel.Url);
			}
		}
	}
}
