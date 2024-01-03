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
using System.Windows.Threading;

namespace Turkeli_Tolga_c_scherp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //timer
        private int aantalSeconden = 0;

        private DispatcherTimer timerUpdateClicks;

        double clicks1 = 100000; //clicks
        double totaalClicksAlles = 1000000000;
        //upgrades
        private bool upgrade1Gekocht = false;
        private bool upgrade2Gekocht = false;
        private bool upgrade3Gekocht = false;
        private bool upgrade4Gekocht = false;
        private bool upgrade5Gekocht = false;
        private bool upgrade6Gekocht = false;
        private bool upgrade7Gekocht = false;

        double passiefinkomen = 0;
        double totaalGespendeerd = 0;

        double upgrade1Prijs = 15;
        double upgrade2Prijs = 100;
        double upgrade3Prijs = 1100;
        double upgrade4Prijs = 12000;
        double upgrade5Prijs = 130000;
        double upgrade6Prijs = 1400000;
        double upgrade7Prijs = 20000000;


        double Upgrade1Inkomen = 0.1;
        double Upgrade2Inkomen = 1;
        double Upgrade3Inkomen = 8;
        double Upgrade4Inkomen = 47;
        double Upgrade5Inkomen = 260;
        double Upgrade6Inkomen = 1400;
        double Upgrade7Inkomen = 7800;


        int levelUpgrade1 = 0;
        int levelUpgrade2 = 0;
        int levelUpgrade3 = 0;
        int levelUpgrade4 = 0;
        int levelUpgrade5 = 0;
        int levelUpgrade6 = 0;
        int levelUpgrade7 = 0;

        //fotos
        private bool mousePressed = false;
        bool verkleinen = false;



        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timerInvestering = new DispatcherTimer();
            timerInvestering.Interval = TimeSpan.FromSeconds(1);
            timerInvestering.Tick += TimerInvestering_Tick;
            timerInvestering.Start();

            DispatcherTimer TimerUpdateScherm = new DispatcherTimer();
            TimerUpdateScherm.Interval = TimeSpan.FromMilliseconds(10);
            TimerUpdateScherm.Tick += TimerUpdateScherm_Tick;
            TimerUpdateScherm.Start();

        }

        private void TimerUpdateScherm_Tick(object sender, EventArgs e)
        {

            lblTijd.Content = $"Tijd: " + DateTime.Now.ToString("HH:mm:ss");
            lblClicks.Content = $"Clicks: {VeranderGroteNummer(Math.Floor(clicks1))}";

            UpdateWindowTitle();

            UpdateIsEnabled(upgrade1, upgrade1Prijs, levelUpgrade1);
            UpdateIsEnabled(upgrade2, upgrade2Prijs, levelUpgrade2);
            UpdateIsEnabled(upgrade3, upgrade3Prijs, levelUpgrade3);
            UpdateIsEnabled(upgrade4, upgrade4Prijs, levelUpgrade4);
            UpdateIsEnabled(upgrade5, upgrade5Prijs, levelUpgrade5);
            UpdateIsEnabled(upgrade6, upgrade6Prijs, levelUpgrade6);
            UpdateIsEnabled(upgrade7, upgrade7Prijs, levelUpgrade7);
        }

        private void AutoClicker_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mousePressed = true;
            clicks1++;
            totaalClicksAlles++;
            GrootteFoto(0.95);
            verkleinen = true;

        }

        private void AutoClicker_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mousePressed = false;
            GrootteFoto(1);
            verkleinen = false;
        }

        private void GrootteFoto(double grootte)
        {
            AutoGrootte.ScaleX = grootte;
            AutoGrootte.ScaleY = grootte;
        }


        private void Upgrade_Click(ref double upgradePrijs, ref int levelUpgrade, ref bool upgradeGekocht, Label prijs, Button upgradeButton, Label upgradeCountLabel, ref double UpgradeInkomen, TextBlock tbUpgrade)
        {
            if (upgradePrijs <= clicks1)
            {
                totaalGespendeerd += upgradePrijs;

                if (levelUpgrade <= 4) // maximum 5 levels per upgrade
                {
                    clicks1 -= upgradePrijs;
                    upgradeGekocht = true;
                    levelUpgrade++; //elke keer dat je op een upgradebutton klikt ga je een level hoger
                    upgradePrijs = upgradePrijs * Math.Pow(1.15, levelUpgrade);
                    prijs.Content = "\nPrice: " + (Math.Ceiling(upgradePrijs));


                    // Aantal x gekocht
                    int purchaseCount = int.Parse(upgradeCountLabel.Content.ToString()); //declareert purchaseCount en zet het om in een string om te 'showen' in de label
                    purchaseCount++;
                    upgradeCountLabel.Content = purchaseCount.ToString();

                }
                else
                {
                    MessageBox.Show("You reached the maximum level of this upgrade!");
                }

            }
            else
            {
                MessageBox.Show("You dont have enough clicks!");
            }
            lblAantalGespendeerd.Content = "Clicks:" + (Math.Floor(totaalGespendeerd));

            //dit is voor de ToolTip
            tbUpgrade.Text = GeneratePassiefInkomenApart(UpgradeInkomen, levelUpgrade);
        }

        private void Upgrade1_Click(object sender, RoutedEventArgs e)
        {
            Upgrade_Click(ref upgrade1Prijs, ref levelUpgrade1, ref upgrade1Gekocht, lblPrijs1, upgrade1, lblUpgradeCount1, ref Upgrade1Inkomen, tbUpgrade1);
        }
        private void Upgrade2_Click(object sender, RoutedEventArgs e)
        {
            Upgrade_Click(ref upgrade2Prijs, ref levelUpgrade2, ref upgrade2Gekocht, lblPrijs2, upgrade2, lblUpgradeCount2, ref Upgrade2Inkomen, tbUpgrade2);
        }
        private void Upgrade3_Click(object sender, RoutedEventArgs e)
        {
            Upgrade_Click(ref upgrade3Prijs, ref levelUpgrade3, ref upgrade3Gekocht, lblPrijs3, upgrade3, lblUpgradeCount3, ref Upgrade3Inkomen, tbUpgrade3);
        }
        private void Upgrade4_Click(object sender, RoutedEventArgs e)
        {
            Upgrade_Click(ref upgrade4Prijs, ref levelUpgrade4, ref upgrade4Gekocht, lblPrijs4, upgrade4, lblUpgradeCount4, ref Upgrade4Inkomen, tbUpgrade4);
        }
        private void Upgrade5_Click(object sender, RoutedEventArgs e)
        {
            Upgrade_Click(ref upgrade5Prijs, ref levelUpgrade5, ref upgrade5Gekocht, lblPrijs5, upgrade5, lblUpgradeCount5, ref Upgrade5Inkomen, tbUpgrade5);
        }
        private void Upgrade6_Click(object sender, RoutedEventArgs e)
        {
            Upgrade_Click(ref upgrade6Prijs, ref levelUpgrade6, ref upgrade6Gekocht, lblPrijs6, upgrade6, lblUpgradeCount6, ref Upgrade6Inkomen, tbUpgrade6);
        }
        private void Upgrade7_Click(object sender, RoutedEventArgs e)
        {
            Upgrade_Click(ref upgrade7Prijs, ref levelUpgrade7, ref upgrade7Gekocht, lblPrijs7, upgrade7, lblUpgradeCount7, ref Upgrade7Inkomen, tbUpgrade7);
        }

        private double UpgradeVermenigvuldiger(int levelUpgrade)
        {

            double vermenigvuldiger = 1;
            switch (levelUpgrade)
            {
                case 1:
                    vermenigvuldiger = 1;
                    break;
                case 2:
                    vermenigvuldiger = 1.5;
                    break;
                case 3:
                    vermenigvuldiger = 2;
                    break;
                case 4:
                    vermenigvuldiger = 2.5;
                    break;
                case 5:
                    vermenigvuldiger = 12.5;
                    break;
            }
            return vermenigvuldiger;
        }

        private void UpgradePassiefInkomen(double upgradeInkomen, int levelUpgrade)
        {
            double vermenigvuldiger = UpgradeVermenigvuldiger(levelUpgrade);
            passiefinkomen += upgradeInkomen * vermenigvuldiger;

            if (aantalSeconden % 1 == 0)
            {
                clicks1 += upgradeInkomen * vermenigvuldiger;
                totaalClicksAlles += upgradeInkomen * vermenigvuldiger;
            }
        }

        private void TimerInvestering_Tick(object sender, EventArgs e)
        {
            aantalSeconden++;
            passiefinkomen = 0; //reset passief inkomen
            if (upgrade1Gekocht)
            {
                UpgradePassiefInkomen(Upgrade1Inkomen, levelUpgrade1);
            }
            if (upgrade2Gekocht)
            {
                UpgradePassiefInkomen(Upgrade2Inkomen, levelUpgrade2);
            }
            if (upgrade3Gekocht)
            {
                UpgradePassiefInkomen(Upgrade3Inkomen, levelUpgrade3);
            }
            if (upgrade4Gekocht)
            {
                UpgradePassiefInkomen(Upgrade4Inkomen, levelUpgrade4);
            }
            if (upgrade5Gekocht)
            {
                UpgradePassiefInkomen(Upgrade5Inkomen, levelUpgrade5);
            }
            if (upgrade6Gekocht)
            {
                UpgradePassiefInkomen(Upgrade6Inkomen, levelUpgrade6);
            }
            if (upgrade7Gekocht)
            {
                UpgradePassiefInkomen(Upgrade7Inkomen, levelUpgrade7);
            }
            lblPassiefInkomen.Content = "Passive income: " + passiefinkomen + "/s";
        }

        private string GeneratePassiefInkomenApart(double UpgradeInkomen, int levelUpgrade)
        {
            double passiefInkomen = 0;

            double vermenigvuldiger = UpgradeVermenigvuldiger(levelUpgrade);
            passiefInkomen = UpgradeInkomen * vermenigvuldiger;

            return $"Passief inkomen: {VeranderGroteNummer(passiefInkomen)} /s";

        }

        private void UpdateIsEnabled(Button upgradeButton, double upgradePrijs, double levelUpgrade)
        {
            if (levelUpgrade == 0)
            {
                upgradeButton.IsEnabled = clicks1 >= upgradePrijs;
            }
            else
            {
                upgradeButton.IsEnabled = false;
            }
            if (levelUpgrade >= 1)
            {
                upgradeButton.IsEnabled = true;
            }
        }

        private void UpdateWindowTitle() // voor titel van de applicatie
        {
            string cookieScore = VeranderGroteNummer(clicks1);

            this.Title = $"Auto Clicker - Score: {cookieScore}";
        }

        private string VeranderGroteNummer(double VeranderdeNummer)
        {
            if (VeranderdeNummer >= 1000000000)
            {
                double VeranderNum = VeranderdeNummer / 1000000000.0;
                return $"{VeranderNum:N3} Billion";
            }
            else if (VeranderdeNummer >= 1000000)
            {
                double VeranderNum = VeranderdeNummer / 1000000.0;
                return $"{VeranderNum:N3} Million";
            }

            string HonderdduizendTallen;
            if (VeranderdeNummer >= 1000)
            {
                HonderdduizendTallen = VeranderdeNummer.ToString("### ###");
            }
            else
            {
                HonderdduizendTallen = $"{VeranderdeNummer:F2}";
            }

            return $"{HonderdduizendTallen}";
        }


    }
}
