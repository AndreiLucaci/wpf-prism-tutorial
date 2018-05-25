using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WpfTutorial.ChuckNorrisFactsModule.Exceptions;
using WpfTutorial.ChuckNorrisFactsModule.Services;
using WpfTutorial.ChuckNorrisFactsModule.Transformers;
using WpfTutorial.ChuckNorrisFactsModule.ViewModels;
using WpfTutorial.Models;
using WpfTutorial.Service;

namespace WpfTutorial.Tests.Module.Service
{
	[TestFixture]
	public class ChuckNorrisServiceTests
	{
		private Mock<IChuckNorrisFactsService> _moqService;
		private Mock<ITransform<ChuckNorrisFact, ChuckNorrisFactViewModel>> _transformMoq;

		[SetUp]
		public void SetUp()
		{
			_moqService = new Mock<IChuckNorrisFactsService>();
			_transformMoq = new Mock<ITransform<ChuckNorrisFact, ChuckNorrisFactViewModel>>();
		}

		[Test]
		public void Service_With_Fact_Null_Throws_Exception()
		{
			_moqService.Setup(x => x.GetOneFactAsync()).ReturnsAsync(() => null);

			var sut = new ChuckNorrisService(_moqService.Object, _transformMoq.Object);

			Assert.ThrowsAsync<NullFactsException>(() => sut.GetOneFactAsync());
		}

		[Test]
		public void Service_With_Valid_Facts_Calls_Transformer()
		{
			var expectedFactToBeTransformed = new ChuckNorrisFact();
			_moqService.Setup(x => x.GetOneFactAsync()).ReturnsAsync(() => expectedFactToBeTransformed);

			var sut = new ChuckNorrisService(_moqService.Object, _transformMoq.Object);

			Assert.DoesNotThrowAsync(() => sut.GetOneFactAsync());
			_transformMoq.Verify(x => x.Transform(expectedFactToBeTransformed), Times.Once);
		}

		[Test]
		public async Task Service_With_Valid_Facts_Returns_The_Correct_Transformed_Value()
		{
			var givenFact = new ChuckNorrisFact();
			var expectedFact = new ChuckNorrisFactViewModel();

			_transformMoq.Setup(x => x.Transform(givenFact)).Returns(() => expectedFact);
			_moqService.Setup(x => x.GetOneFactAsync()).ReturnsAsync(() => givenFact);

			var sut = new ChuckNorrisService(_moqService.Object, _transformMoq.Object);

			var result = await sut.GetOneFactAsync();

			Assert.IsNotNull(result);
			Assert.AreEqual(expectedFact, result);

			_transformMoq.Verify(x => x.Transform(givenFact), Times.Once);
		}
	}
}
