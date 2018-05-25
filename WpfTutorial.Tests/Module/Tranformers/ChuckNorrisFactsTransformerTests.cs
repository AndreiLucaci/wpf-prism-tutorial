using NUnit.Framework;
using WpfTutorial.ChuckNorrisFactsModule.Transformers;
using WpfTutorial.Models;

namespace WpfTutorial.Tests.Module.Tranformers
{
	[TestFixture]
	public class ChuckNorrisFactsTransformerTests
	{
		[Test]
		public void Transformer_With_Null_Fact_Returns_Null()
		{
			var sut = new ChuckNorrisFactViewModelTransformer();

			var result = sut.Transform(null);

			Assert.IsNull(result);
		}

		[Test]
		public void Transformer_With_Valid_Fact_Transforms_Correctly()
		{
			var expectedString = "someExpectedString";
			var givenFact = new ChuckNorrisFact
			{
				Value = expectedString,
				IconUrl = expectedString,
				Id = expectedString,
				Url = expectedString
			};

			var sut = new ChuckNorrisFactViewModelTransformer();

			var result = sut.Transform(givenFact);

			Assert.IsNotNull(result);
			Assert.IsNull(result.Category);
			Assert.AreEqual(expectedString, result.Value);
			Assert.AreEqual(expectedString, result.IconUrl);
			Assert.AreEqual(expectedString, result.Id);
			Assert.AreEqual(expectedString, result.Url);
		}
	}
}
