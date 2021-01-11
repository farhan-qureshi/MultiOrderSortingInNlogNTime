using System.IO;

namespace SingleOrderSortForMultipleColumnsInNLogNTime
{
	/// <summary>
	/// Validates the input file
	/// </summary>
	public class FilePathValidator : IFilePathValidator
	{
		private IConfiguration _configuration;
		public FilePathValidator(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public bool IsValidInputFilePath()
		{
			var exists = false;
			if(!string.IsNullOrEmpty(_configuration.FilePath))
				exists = File.Exists(_configuration.FilePath);

			return exists;
		}
	}
}
