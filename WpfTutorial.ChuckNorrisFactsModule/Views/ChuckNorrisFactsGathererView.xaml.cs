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
using WpfTutorial.ChuckNorrisFactsModule.Services;

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
		{
			_service = service;
		}

		private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			var itemsCount = NumericUpDown.NumValue;
			for (var i = 0; i < itemsCount; i++)
			{
				var fact = await _service.GetOneFactAsync();
				Facts.Items.Add(fact);
			}
		}
	}
}
