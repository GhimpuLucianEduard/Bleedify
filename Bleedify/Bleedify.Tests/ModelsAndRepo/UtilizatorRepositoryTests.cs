using System;
using System.Linq;
using BleedifyModels.ModelsEF;
using BleedifyModels.Repositories;
using BleedifyModels.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bleedify.Tests
{	
	[TestClass]
	public class UtilizatorRepositoryTests
	{
		#region Private Testing fields

		private static UtilizatorRepository _utilizatorRepository;

		#endregion

		#region Initialize and Cleanup

		[TestInitialize]
		public void InitializeTest()
		{
			_utilizatorRepository = new UtilizatorRepository(new UtilizatorValidator());
		}

		[TestCleanup]
		public void CleanUpTest()
		{
			_utilizatorRepository.GetAll().ToList().ForEach(x =>
			{
				if ((x.TipUtilizator.CompareTo("TEST")==0))
				{
					_utilizatorRepository.Delete(x.Id);
				}
			});
		}

		#endregion

		#region Tests

		[TestMethod]
		public void AddUtilizatorTest()
		{
			var size = _utilizatorRepository.GetAll().Count();
			
			try
			{
				var utilizatorTest1 = new Utilizator
				{
					UserName = "plswork",
					Password = "ds3124a",
					TipUtilizator = "TEST"
				};

				var utilizatorTest2 = new Utilizator
				{
					UserName = "wwwt2",
					Password = "ds33a",
					TipUtilizator = "TEST"
				};

				_utilizatorRepository.Add(utilizatorTest1);
				_utilizatorRepository.Add(utilizatorTest2);

			}
			catch (Exception)
			{
				Assert.Fail();
			}

			var size2 = _utilizatorRepository.GetAll().Count();

			Assert.IsTrue(size2==size+2);
		}

		[TestMethod]
		public void DeleteUserTest()
		{
			var size = _utilizatorRepository.GetAll().Count();
			try
			{
				var utilizatorTest1 = new Utilizator
				{
					UserName = "tbd21",
					Password = "ds3124a",
					TipUtilizator = "TEST"
				};

				var utilizatorTest2 = new Utilizator
				{
					UserName = "tbd33",
					Password = "ds33a",
					TipUtilizator = "TEST"
				};

				_utilizatorRepository.Add(utilizatorTest1);
				_utilizatorRepository.Add(utilizatorTest2);

				_utilizatorRepository.Delete(utilizatorTest2.Id);
				_utilizatorRepository.Delete(utilizatorTest1.Id);

			}
			catch (Exception)
			{
				Assert.Fail();
			}

			var size2 = _utilizatorRepository.GetAll().Count();

			Assert.IsTrue(size2 == size);
		}


		#endregion




	}
}