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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using log4net.Config;
using WpfApp1.model;
using WpfApp1.repository;

using WpfApp1.service;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        private BigService bigService;

        public MainWindow()
        {
            SortedList<String, String> props = new SortedList<string, string>();
            props.Add("ConnectionString", GetConnectionStringByName("tasksDB"));
            AgentRepository agentRepo = new AgentRepository(props);
            AgentService agentService = new AgentService(agentRepo);

            ClientRepository clientRepo = new ClientRepository(props);
            ClientService clientService = new ClientService(clientRepo);

            ExcursieRepository excursieRepo = new ExcursieRepository(props);
            ExcursieService excursieService = new ExcursieService(excursieRepo);

            RezervareRepository rezervareRepo = new RezervareRepository(props);
            RezervareService rezervareService = new RezervareService(rezervareRepo);

            BigService bigService = new BigService(agentService, clientService, excursieService, rezervareService);
            this.bigService = bigService;

            InitializeComponent();
            usernameTextbox.Text = "faust";
            passwordTextbox.Password = "qwedcxzas";

        }

        static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextbox.Text;
            string password = passwordTextbox.Password.ToString();
            bool logged = bigService.loginAgent(username, password);

            if(logged)
            {
                SecondWindow second = new SecondWindow(this, bigService);
                second.Show();
                usernameTextbox.Clear();
                passwordTextbox.Clear();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username/password Combination", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
