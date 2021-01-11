using Moq;
using NUnit.Framework;

namespace SingleOrderSortForMultipleColumnsInNLogNTime.Tests.File
{
	[TestFixture]
	public class FilePathValidatorTests
	{
		[Test]
		public void IsValidInputFilePath_Returns_false_If_FilePath_Is_Empty()
		{
			var config = new Mock<IConfiguration>();
			var filePathValidator = new FilePathValidator(config.Object);

			// giving an empty file path
			config.SetupProperty(c => c.FilePath, "");

			var exists = filePathValidator.IsValidInputFilePath();
			Assert.That(exists is false);
		}
	}
}
