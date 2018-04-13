namespace BleedifyModels.ModelsEF
{	
	/// <summary>
	/// Singleton class to get the Context for the models
	/// </summary>
	public static class ContextGetter
	{
		private static BleedifyDB ContextInstance;

		public static BleedifyDB GetContext()
		{
			return ContextInstance ?? (ContextInstance = new BleedifyDB());
		}
	}
}