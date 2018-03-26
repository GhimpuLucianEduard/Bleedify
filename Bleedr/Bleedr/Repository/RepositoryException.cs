using System;

namespace Bleedr.Repository
{
	/// <summary>
	/// Exceptie specifica repositoarelor
	/// </summary>
	public class RepositoryException : ApplicationException
	{
		public RepositoryException(string message) : base(message)
		{
		}
	}
}