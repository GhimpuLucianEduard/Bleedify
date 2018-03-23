using System;
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
using System.Windows.Shapes;
using WpfApp1.model;
using WpfApp1.service;

namespace WpfApp1
{
    public partial class SecondWindow : Window
    {
        Window LoginWindow;
        BigService bigService;

        private void excursieDatagrid_AutoGeneratingColumn(Excursie sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "idObiectiv" || e.PropertyName == "idFirma")
            {
                e.Cancel = true;
            }
        }

        public void Refresh()
        {
            excursieDatagrid.ItemsSource = bigService.getExcursieService().FindAll();
            clientDatagrid.ItemsSource = bigService.getClientService().FindAll();
            filteredDatagrid1.ItemsSource = bigService.getExcursieService().filter(obiectivTextbox.Text, 0, 0);
        }


        internal SecondWindow(Window LoginWindow, BigService bigService)
        {
            InitializeComponent();
            this.LoginWindow = LoginWindow;
            this.bigService = bigService;
            excursieDatagrid.ItemsSource = bigService.getExcursieService().FindAll();
            clientDatagrid.ItemsSource = bigService.getClientService().FindAll();
            filteredDatagrid1.ItemsSource = bigService.getExcursieService().filter("", 0, 0);
        }


        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            string obiectiv = obiectivTextbox.Text;
            int after = Int32.Parse(afterTextbox.Text);
            int before = Int32.Parse(beforeTextbox.Text);

            if(obiectiv == "")
            {
                MessageBox.Show("Campul de obiectiv trebuie completat", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (after > before)
            {
                MessageBox.Show("Nu ati setat corect orele", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                filteredDatagrid1.ItemsSource = bigService.getExcursieService().filter(obiectiv, after, before);
            }
            
        }

        private void addclientButton_Click(object sender, RoutedEventArgs e)
        {
            int idClient = 0;
            try
            {
                idClient = Int32.Parse(idclientTextbox.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("Be sure to complete all the fields properly", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            string nume = numeTextbox.Text;
            string nrtel = nrtelTextbox.Text;

            if(nume == "" || nrtel == "")
            {
                MessageBox.Show("Be sure to complete all the fields properly", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                bigService.getClientService().Save(new Client(idClient, nume, nrtel));
                Refresh();
            }
        }

        private void rezervareButton_Click(object sender, RoutedEventArgs e)
        {
            int nrRezervari = 0;
            Excursie excursie = (Excursie)filteredDatagrid1.SelectedItem;
            Client client = (Client)clientDatagrid.SelectedItem;
            if(excursie == null || client == null)
            {
                MessageBox.Show("Make sure you selected items from both tables", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                try
                {
                    nrRezervari = Int32.Parse(rezervareTextbox.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Be sure to complete all the fields properly", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                if(nrRezervari < 1)
                {
                    MessageBox.Show("NrRezervari must be > 0", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                try
                {
                    bigService.getRezervareService().Save(new Rezervare(excursie.Id, client.Id, nrRezervari));
                    Refresh();
                }
                catch(Exception)
                {
                    MessageBox.Show("This client already has some reserved places for this trip", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }
    }
}
