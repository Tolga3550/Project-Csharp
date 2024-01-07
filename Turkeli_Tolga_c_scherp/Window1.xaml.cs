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

        double upgrade1PrijsBonus = 11000;
        double upgrade2PrijsBonus = 55000;
        double upgrade3PrijsBonus = 550000;
        double upgrade4PrijsBonus = 55000000;
        double upgrade5PrijsBonus = 5500000000;
        double upgrade6PrijsBonus = 550000000000;

        double upgrade1InkomenBonus = 0;
        double upgrade2InkomenBonus = 0;
        double upgrade3InkomenBonus = 0;
        double upgrade4InkomenBonus = 0;
        double upgrade5InkomenBonus = 0;
        double upgrade6InkomenBonus = 0;

        double levelUpgradeBonus = 0;

       
        public Window1()
        {
            InitializeComponent();

            DispatcherTimer updateSchermBonus = new DispatcherTimer();
            updateSchermBonus.Interval = TimeSpan.FromSeconds(1);
            updateSchermBonus.Tick += updateSchermBonus_Tick;
            updateSchermBonus.Start();

            
        }

        private void prijs (Label prijzen, double upgradePrijsBonus)
        {
            prijzen.Content = "Price: " + (upgradePrijsBonus);
        }

        private void updateSchermBonus_Tick(object sender, EventArgs e) 
        {
            prijs(lblPrijsBonus1, upgrade1PrijsBonus);
            prijs(lblPrijsBonus2, upgrade2PrijsBonus);
            prijs(lblPrijsBonus3, upgrade3PrijsBonus);
            prijs(lblPrijsBonus4, upgrade4PrijsBonus);
            prijs(lblPrijsBonus5, upgrade5PrijsBonus);
            prijs(lblPrijsBonus6, upgrade6PrijsBonus);
        }


       

        private void upgrade1Bonus_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void upgrade2Bonus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void upgrade3Bonus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void upgrade4Bonus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void upgrade5Bonus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void upgrade6Bonus_Click(object sender, RoutedEventArgs e)
        {

        }

        public Window1(double clicks1)
        {

        }
    }

}
