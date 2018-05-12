using System;
using BleedifyModels.ModelsEF;

namespace DomainViewModels
{
	public class ComponentaViewModel : BaseViewModel
	{
		private int _id;
		private string _tipComponenta;
		private int _idDonatie;
		private DateTime _dataDepunere;
		private int _idPrimitor;
		private string _stare;
		private Donatie _donatie;
		private Pacient _pacient;

		public int Id
		{
			get { return _id; }
			set { SetValue(ref _id, value); }
		}

		public string TipComponenta
		{
			get { return _tipComponenta; }
			set { SetValue(ref _tipComponenta, value); }
		}
	}
}