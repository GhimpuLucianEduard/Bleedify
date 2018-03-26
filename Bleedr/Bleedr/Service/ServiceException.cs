using System;

namespace Bleedr.Service
{
	public class ServiceException : ApplicationException
	{
		/// <summary>
		/// Exceptie specifica servicelor
		/// </summary>
		public ServiceException(string message) : base(message)
		{
		}

	}
}