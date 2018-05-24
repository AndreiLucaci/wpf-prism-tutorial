using System.Windows;
using System.Windows.Controls;

namespace WpfTutorial.ChuckNorrisFactsModule.Views
{
	/// <summary>
	/// Interaction logic for NumericUpDown.xaml
	/// </summary>
	public partial class NumericUpDown : UserControl
	{
		private int _numValue = 0;

		public int NumValue
		{
			get => _numValue;
			set
			{
				_numValue = value;
				txtNum.Text = value.ToString();
			}
		}


		public NumericUpDown()
		{
			InitializeComponent();
		}

		private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (txtNum == null)
			{
				return;
			}

			if (!int.TryParse(txtNum.Text, out _numValue))
				txtNum.Text = _numValue.ToString();

		}

		private void cmdUp_Click(object sender, RoutedEventArgs e)
		{
			NumValue++;
		}

		private void cmdDown_Click(object sender, RoutedEventArgs e)
		{
			NumValue--;
		}
	}
}
