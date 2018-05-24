namespace WpfTutorial.ChuckNorrisFactsModule.Transformers
{
	public interface ITransform<in TFrom, out TTo>
	{
		TTo Transform(TFrom from);
	}
}
