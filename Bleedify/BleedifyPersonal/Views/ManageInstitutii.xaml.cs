﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BleedifyPersonal.ViewModels;

namespace BleedifyPersonal.Views
{
	/// <summary>
	/// Interaction logic for ManageInstitutiixaml.xaml
	/// </summary>
	public partial class ManageInstitutii : UserControl
	{
		public ManageInstitutiiViewModel ViewModel
		{
			get { return DataContext as ManageInstitutiiViewModel; }
			set { DataContext = value; }

		}

		public ManageInstitutii()
		{
			InitializeComponent();
			DataContext = new ManageInstitutiiViewModel();
		}
	}
}
