using System;
using System.Globalization;
using System.Windows.Data;
using static System.Int32;

namespace BleedifyPersonal.ViewModels
{
	public class StringToIntConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int v = (int)value;
			if (v == 0)
				return string.Empty;
			return v.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var s = (string)value;
			if (string.IsNullOrEmpty(s))
				return 0;

			int j;
			return TryParse(s, out j) ? j : 0;
		}
	}
}