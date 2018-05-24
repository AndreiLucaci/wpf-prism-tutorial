namespace WpfTutorial.ChuckNorrisFactsModule.ViewModels
{
	public class ChuckNorrisFactViewModel
    {
	    public string Category { get; set; }

	    public string IconUrl { get; set; }

	    public string Id { get; set; }

	    public string Url { get; set; }

	    public string Value { get; set; }

		public override string ToString()
		{
			return $"{Value.Substring(0, 30)}...";
		}
	}
}
