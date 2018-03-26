using System;

namespace Bleedr.Model
{
	/// <summary>
	/// Exceptie specifica validatoarelor
	/// </summary>
	public class ValidationException : ApplicationException
	{
		public ValidationException(string message) : base(message) { }
	}
}