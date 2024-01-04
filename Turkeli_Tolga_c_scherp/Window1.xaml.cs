using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Turkeli_Tolga_c_scherp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        double upgrade1PrijsSecret = 11000;
        double upgrade2PrijsSecret = 55000;
        double upgrade3PrijsSecret = 550000;
        double upgrade4PrijsSecret = 55000000;
        double upgrade5PrijsSecret = 5500000000;
        double upgrade6PrijsSecret = 550000000000;

       
        public Window1()
        {
            InitializeComponent();

            DispatcherTimer updateSchermSecret = new DispatcherTimer();
            updateSchermSecret.Interval = TimeSpan.FromSeconds(1);
            updateSchermSecret.Tick += updateSchermSecret_Tick;
            updateSchermSecret.Start();
        }

        private void prijs (Label prijzen, double upgradePrijsSecret)
        {
            prijzen.Content = "Price: " + (upgradePrijsSecret);
        }

        private void updateSchermSecret_Tick(object sender, EventArgs e) 
        {
            prijs(lblPrijsSecret1, upgrade1PrijsSecret);
            prijs(lblPrijsSecret2, upgrade2PrijsSecret);
            prijs(lblPrijsSecret3, upgrade3PrijsSecret);
            prijs(lblPrijsSecret4, upgrade4PrijsSecret);
            prijs(lblPrijsSecret5, upgrade5PrijsSecret);
            prijs(lblPrijsSecret6, upgrade6PrijsSecret);
        }


    }

}
