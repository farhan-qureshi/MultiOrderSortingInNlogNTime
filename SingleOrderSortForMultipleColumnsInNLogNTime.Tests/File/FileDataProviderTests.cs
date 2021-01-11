using Moq;
using NUnit.Framework;
using System;

namespace SingleOrderSortForMultipleColumnsInNLogNTime.Tests.File
{
	[TestFixture]
	public class FileDataProviderTests
	{
		[Test]
		public void Read_ThrowsException_With_Correct_ErrorMessage_When_FilePath_Does_Not_Exist()
		{
			var _filePathValidator = new Mock<IFilePathValidator>();
			var _fileHeaderInfo = new Mock<IFileHeaderInfo>();
			var _filePathInfo = new Mock<IFilePathInfo>();

			var fileDataProvider = new FileDataProvider(_filePathValidator.Object, _fileHeaderInfo.Object, _filePathInfo.Object);

			// setup / stub the internally used function calls with expected data
			_filePathValidator.Setup(v => v.IsValidInputFilePath())
				.Returns(false);

			try
			{
				fileDataProvider.Read();
			}
			catch(Exception ex)
			{
				Assert.AreEqual("File does not exist. Please correct the configuration settings.", ex.Message);
			}
		}
	}
}
