using System;
using System.Globalization;
using System.Windows.Data;

namespace BleedifyDonator.ViewModels
{
	public class DataToBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var data = (DateTime) value;
			if (data > DateTime.Now)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}
	}
}