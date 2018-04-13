using System;

namespace BleedifyModels.Validators
{	
	/// <summary>
	/// Exceptie de validare aruncata in cadrul
	/// metodelor de validare
	/// </summary>
	public class ValidationException : ApplicationException
	{
		public ValidationException(string message) : base(message) { }
	}
}