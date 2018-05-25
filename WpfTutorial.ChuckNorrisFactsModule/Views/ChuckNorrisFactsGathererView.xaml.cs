using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfTutorial.ChuckNorrisFactsModule.Exceptions;
using WpfTutorial.ChuckNorrisFactsModule.Services;
using WpfTutorial.ChuckNorrisFactsModule.ViewModels;

namespace WpfTutorial.ChuckNorrisFactsModule.Views
{
	/// <summary>
	/// Interaction logic for ChuckNorrisFactsGathererView.xaml
	/// </summary>
	public partial class ChuckNorrisFactsGathererView : UserControl
	{
		private readonly IChuckNorrisService _service;

		public ChuckNorrisFactsGathererView()
		{
			InitializeComponent();
		}

		public ChuckNorrisFactsGathererView(IChuckNorrisService service)
			: this()
		{
			_service = service;
		}

		private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			var itemsCount = NumericUpDown.NumValue;

			if (itemsCount > 0)
			{
				try
				{
					if (itemsCount == 1)
					{
						await LoadOneFactAsync();
					}
					else
					{
						await LoadMultipleAsync(itemsCount);
					}
				}
				catch (NullFactsException ex)
				{
					MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

		private async Task LoadOneFactAsync()
		{
			var fact = await _service.GetOneFactAsync();
			Facts.Items.Add(fact);
		}

		private async Task LoadMultipleAsync(int count)
		{
			foreach (var fact in await _service.GetMultipleFactsAsync(count))
			{
				Facts.Items.Add(fact);
			}
		}

		private void ListBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (Facts.SelectedItem != null)
			{
				var viewModel = (ChuckNorrisFactViewModel)Facts.SelectedItem;
				DetailsView.SetViewModel(viewModel);
			}
		}

		private void DetailsView_Loaded(object sender, RoutedEventArgs e)
		{

		}

		private void ButtonClean_OnClick(object sender, RoutedEventArgs e)
		{
			Facts.Items.Clear();
		}
	}
}
