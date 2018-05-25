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
			return $"{SafeSubstring(Value, 0, 30)}...";
		}

	    private string SafeSubstring(string original, int start, int end)
	    {
		    try
		    {
			    return original.Substring(start, end);
		    }
		    catch
		    {
			    return original;
		    }
	    }
	}
}
