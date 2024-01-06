using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Media;
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
    ///
    /// Interaction logic for MainWindow.xaml
    /// Author: Tolga Turkeli
    /// Create Date: 17-11-2023
    /// Documentatie: C# Cookie clicker project
    /// Dit is mijn allereerste C# project, had het in het begin moeilijk mee maar door er rustig aan te werken en informatie op te zoeken is het me toch wel gelukt.
    /// Heb extra veel achter de computer gezeten, vooral deze laatste weken. Vandaag 03/01/2024 ben ik eindelijk klaar met het project en ik heb het gevoel dat ik oprecht veel heb bijgeleerd uit deze project.
    /// Ik heb beetje mijn creativiteit gebruikt om niet gewoon een normale cookieclicker te maken, maar een autoclicker met verschillende auto's en mod upgrades voor de autoliefhebbers.
    /// Ik heb een fictieve naamgeving gegeven aan de upgrades etc. omdat ik vind dat dat beter past bij een spel.
    ///

    public partial class MainWindow : Window
    {

        //timer
        private int aantalSeconden = 890;

        //clicks
        double clicks1 = 10000000000;
        double totaalClicksAlles = 1000000000;

        //upgrades
        private bool upgrade1Gekocht = false;
        private bool upgrade2Gekocht = false;
        private bool upgrade3Gekocht = false;
        private bool upgrade4Gekocht = false;
        private bool upgrade5Gekocht = false;
        private bool upgrade6Gekocht = false;
        private bool upgrade7Gekocht = false;

        private bool geluid1VoorLevel5 = false;
        private bool geluid2VoorLevel5 = false;
        private bool geluid3VoorLevel5 = false;
        private bool geluid4VoorLevel5 = false;
        private bool geluid5VoorLevel5 = false;
        private bool geluid6VoorLevel5 = false;
        private bool geluid7VoorLevel5 = false;

        bool Auto1Unlocked = false;
        bool Auto2Unlocked = false;
        bool Auto3Unlocked = false;

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

        //achievements
        bool ach10kClicks = false;
        bool ach25kClicks = false;
        bool ach50kClicks = false;
        bool ach75kClicks = false;
        bool ach100kClicks = false;
        bool ach150kClicks = false;
        bool ach200kClicks = false;
        bool ach300kClicks = false;
        bool ach400kClicks = false;
        bool ach500kClicks = false;
        bool ach1mClicks = false;
        bool achMaxLvlHyper = false;
        bool achMaxLvlSpeed = false;
        bool achMaxLvlInfinity = false;
        bool achUnlockAllUpgr = false;
        bool ach15MinPlay = false;
        bool ach30minPlay = false;
        bool ach1hPlay = false;
        //deze nog doen
        bool achUnlockAllBonus = false;
        bool achUnlockEaster = false;
       

        bool IsAchMaxLvlHyperDone = false;
        bool IsAchMaxLvlSpeedDone = false;
        bool IsAchMaxLvlInfinityDone = false;
        bool IsAch15MinPlayDone = false;
        bool IsAch30MinPlayDone = false;
        bool IsAch1hPlayDone = false;
        private SoundPlayer dingSound;

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

            // geluid
            dingSound = new SoundPlayer("/");
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

            //veranderen van auto image, als je bepaald aantal clicks hebt word de image veranderd.
            if (clicks1 >= 100000 && clicks1 < 999999 && !Auto1Unlocked)
            {
                Auto1Unlocked = true;
                AutoClicker.Source = new BitmapImage(new Uri("Image/100kClicksAuto.png", UriKind.Relative));
                MessageBox.Show("Congrats! You unlocked a new car!");
                AutoClicker.Margin = new Thickness(0, 20, 0, 0);
            }
            if (clicks1 >= 1000000 && clicks1 < 999999999 && !Auto2Unlocked)
            {
                Auto2Unlocked = true;
                AutoClicker.Source = new BitmapImage(new Uri("Image/1milClicksAuto.png", UriKind.Relative));
                AutoClicker.Margin = new Thickness(0, 150, 0, 0);
                MessageBox.Show("Congrats! You unlocked a new car!");
            }
            if (clicks1 >= 1000000000 && !Auto3Unlocked)
            {
                Auto3Unlocked = true;
                AutoClicker.Source = new BitmapImage(new Uri("Image/1miljardClicksAuto.png", UriKind.Relative));
                AutoClicker.Margin = new Thickness(0, 200, 0, 0);
                MessageBox.Show("Congrats! You unlocked the game creators favourite car!");
            }

            //achievements
            if (clicks1 >= 10000 && !ach10kClicks)
            {
                ach10kClicks = true;
                MessageBox.Show("Congratulations! Achievement unlocked: 10k Clicks!");
                txtAch1.Visibility = Visibility.Visible;
                imgCheck1.Visibility = Visibility.Visible;
                imgAch1.Visibility = Visibility.Visible;

            }
            if (clicks1 >= 25000 && !ach25kClicks)
            {
                ach25kClicks = true;
                MessageBox.Show("Congratulations! Achievement unlocked: 25k Clicks!");
                txtAch2.Visibility = Visibility.Visible;
                imgCheck2.Visibility = Visibility.Visible;
                imgAch2.Visibility = Visibility.Visible;
            }
            if (clicks1 >= 50000 && !ach50kClicks)
            {
                ach50kClicks = true;
                MessageBox.Show("Congratulations! Achievement unlocked: 50k Clicksç");
                txtAch3.Visibility = Visibility.Visible;
                imgCheck3.Visibility = Visibility.Visible;
                imgAch3.Visibility = Visibility.Visible;
            }
            if (clicks1 >= 75000 && !ach75kClicks)
            {
                ach75kClicks = true;
                MessageBox.Show("Congratulations! Achievement unlocked: 75k Clicks!");
                txtAch4.Visibility = Visibility.Visible;
                imgCheck4.Visibility = Visibility.Visible;
                imgAch4.Visibility = Visibility.Visible;
            }
            if (clicks1 >= 100000 && !ach100kClicks)
            {
                ach100kClicks = true;
                MessageBox.Show("Congratulations! Achievement unlocked: 100k Clicks!");
                txtAch5.Visibility = Visibility.Visible;
                imgCheck5.Visibility = Visibility.Visible;
                imgAch5.Visibility = Visibility.Visible;
            }
            if (clicks1 >= 150000 && !ach150kClicks)
            {
                ach150kClicks = true;
                MessageBox.Show("Congratulations! Achievement unlocked: 150k Clicks!");
                txtAch6.Visibility = Visibility.Visible;
                imgCheck6.Visibility = Visibility.Visible;
                imgAch6.Visibility = Visibility.Visible;
            }
            if (clicks1 >= 200000 && !ach200kClicks)
            {
               ach200kClicks = true;
                MessageBox.Show("Congratulations! Achievement unlocked: 200k Clicks!");
                txtAch7.Visibility = Visibility.Visible;
                imgCheck7.Visibility = Visibility.Visible;
                imgAch7.Visibility = Visibility.Visible;
            }
            if (clicks1 >= 300000 && !ach300kClicks)
            {
                ach300kClicks = true;
                MessageBox.Show("Congratulations! Achievement unlocked: 300k Clicks!");
                txtAch8.Visibility = Visibility.Visible;
                imgCheck8.Visibility = Visibility.Visible;
                imgAch8.Visibility = Visibility.Visible;
            }
            if (clicks1 >= 400000 && !ach400kClicks)
            {
                ach400kClicks = true;
                MessageBox.Show("Congratulations! Achievement unlocked: 400k Clicks!");
                txtAch9.Visibility = Visibility.Visible;
                imgCheck9.Visibility = Visibility.Visible;
                imgAch9.Visibility = Visibility.Visible;
            }
            if (clicks1 >= 500000 && !ach500kClicks)
            {
                ach500kClicks = true;
                MessageBox.Show("Congratulations! Achievement unlocked: 500k Clicks!");
                txtAch10.Visibility = Visibility.Visible;
                imgCheck10.Visibility = Visibility.Visible;
                imgAch10.Visibility = Visibility.Visible;
            }
            if (clicks1 >= 1000000 && !ach1mClicks)
            {
                ach1mClicks = true;
                MessageBox.Show("Congratulations! Achievement unlocked: 1 million Clicks!");
                txtAch11.Visibility = Visibility.Visible;
                imgCheck11.Visibility = Visibility.Visible;
                imgAch11.Visibility = Visibility.Visible;
            }
            AchievementsActies();
        }


        private void AutoClicker_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mousePressed = true;
            clicks1++;
            totaalClicksAlles++;
            GrootteFoto(0.95);
            verkleinen = true;
            UpdateInvestmentButtonVisibility();

            

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


        /// <summary>
        /// Methode om geen herhaaldelijke code te maken, het behandelt upgrade klik-gebeurtenissen.
        /// </summary>
        /// <param name="upgradePrijs">Kosten van de upgrade</param>
        /// <param name="levelUpgrade">Leven van de upgrade</param>
        /// <param name="upgradeGekocht">Een bool, is upgradegekocht true of false?</param>
        /// <param name="prijs">Label 'prijs', waar de upgradePrijs in word laten zien</param>
        /// <param name="UpgradeButton">De button upgrade bijvoorbeeld 'speedracer'</param>
        /// <param name="upgradeCountLabel">Hoeveel keer is de upgrade gekocht?</param>
        /// <param name="UpgradeInkomen">Inkomsten van de upgrade 'passief inkomen'</param>
        /// <param name="tbUpgrade">textblock voor tooltip, hier zie je per upgrade je passief inkomen</param>
        /// <param name="pictureIcon">icon voor als je level 1 van de upgrade bent, verschijnt in het midden v/d venster</param>
        /// <param name="pictureIconLevel2">icon voor als je level 2 van de upgrade bent, verschijnt in het midden v/d venster</param>
        /// <param name="pictureIconLevel3">icon voor als je level 3 van de upgrade bent, verschijnt in het midden v/d venster</param>
        /// <param name="pictureIconLevel4">icon voor als je level 4 van de upgrade bent, verschijnt in het midden v/d venster</param>
        /// <param name="pictureIconLevel5">icon voor als je level 5 van de upgrade bent, verschijnt in het midden v/d venster</param>
        private void Upgrade_Click(ref double upgradePrijs, ref int levelUpgrade, ref bool upgradeGekocht, Label prijs, Button upgradeButton, Label upgradeCountLabel, ref double UpgradeInkomen, TextBlock tbUpgrade, Image pictureIcon, Image pictureIconLevel2, Image pictureIconLevel3, Image pictureIconLevel4, Image pictureIconLevel5, ref bool geluidVoorLevel5)
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
                    prijs.Content = $"\nPrice: {VeranderGroteNummer(Math.Ceiling(upgradePrijs))}";
                    PlayUpgradeSound(); // geluid gaat af als je op button klikt

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
                PlaySadSound();
            }
            lblAantalGespendeerd.Content = "Clicks spent: " + VeranderGroteNummer(Math.Floor(totaalGespendeerd));

            // dit is voor de icoontjes in het midden vd scherm visible te maken
            if (levelUpgrade == 1)
            {
                pictureIcon.Visibility = Visibility.Visible;
            }
            if (levelUpgrade == 2)
            {
                pictureIconLevel2.Visibility = Visibility.Visible;
            }
            if (levelUpgrade == 3)
            {
                pictureIconLevel3.Visibility = Visibility.Visible;
            }
            if (levelUpgrade == 4)
            {
                pictureIconLevel4.Visibility = Visibility.Visible;
            }
            if (levelUpgrade == 5)
            {
                pictureIconLevel5.Visibility = Visibility.Visible;
            }
            if (levelUpgrade == 5 && !geluidVoorLevel5)
            {
                PlayHappySound();
                MessageBox.Show("Congrats! you reached the maximum level of this upgrade!\nHereby i gift you a boost so you will get 5x more passive income from this upgrade!", "A little gift :)");
                geluidVoorLevel5 = true;
            }

            //dit is voor de ToolTip
            tbUpgrade.Text = GeneratePassiefInkomenApart(UpgradeInkomen, levelUpgrade);
            UnlockedVisibility();
            UnlockAllUpgradesAch();
        }

        private void Upgrade1_Click(object sender, RoutedEventArgs e)
        {
            Upgrade_Click(ref upgrade1Prijs, ref levelUpgrade1, ref upgrade1Gekocht, lblPrijs1, upgrade1, lblUpgradeCount1, ref Upgrade1Inkomen, tbUpgrade1, pictureIcon1, pictureIcon1Level2, pictureIcon1Level3, pictureIcon1Level4, pictureIcon1Level5, ref geluid1VoorLevel5);
            CheckMaxLevelUpgradesAch();
            AchievementsActies();
        }
        private void Upgrade2_Click(object sender, RoutedEventArgs e)
        {
            Upgrade_Click(ref upgrade2Prijs, ref levelUpgrade2, ref upgrade2Gekocht, lblPrijs2, upgrade2, lblUpgradeCount2, ref Upgrade2Inkomen, tbUpgrade2, pictureIcon2, pictureIcon2Level2, pictureIcon2Level3, pictureIcon2Level4, pictureIcon2Level5, ref geluid2VoorLevel5);
        }
        private void Upgrade3_Click(object sender, RoutedEventArgs e)
        {
            Upgrade_Click(ref upgrade3Prijs, ref levelUpgrade3, ref upgrade3Gekocht, lblPrijs3, upgrade3, lblUpgradeCount3, ref Upgrade3Inkomen, tbUpgrade3, pictureIcon3, pictureIcon3Level2, pictureIcon3Level3, pictureIcon3Level4, pictureIcon3Level5, ref geluid3VoorLevel5);
        }
        private void Upgrade4_Click(object sender, RoutedEventArgs e)
        {
            Upgrade_Click(ref upgrade4Prijs, ref levelUpgrade4, ref upgrade4Gekocht, lblPrijs4, upgrade4, lblUpgradeCount4, ref Upgrade4Inkomen, tbUpgrade4, pictureIcon4, pictureIcon4Level2, pictureIcon4Level3, pictureIcon4Level4, pictureIcon4Level5, ref geluid4VoorLevel5);
            CheckMaxLevelUpgradesAch();
            AchievementsActies();

        }
        private void Upgrade5_Click(object sender, RoutedEventArgs e)
        {
            Upgrade_Click(ref upgrade5Prijs, ref levelUpgrade5, ref upgrade5Gekocht, lblPrijs5, upgrade5, lblUpgradeCount5, ref Upgrade5Inkomen, tbUpgrade5, pictureIcon5, pictureIcon5Level2, pictureIcon5Level3, pictureIcon5Level4, pictureIcon5Level5, ref geluid5VoorLevel5);
            CheckMaxLevelUpgradesAch();
        }
        private void Upgrade6_Click(object sender, RoutedEventArgs e)
        {
            Upgrade_Click(ref upgrade6Prijs, ref levelUpgrade6, ref upgrade6Gekocht, lblPrijs6, upgrade6, lblUpgradeCount6, ref Upgrade6Inkomen, tbUpgrade6, pictureIcon6, pictureIcon6Level2, pictureIcon6Level3, pictureIcon6Level4, pictureIcon6Level5, ref geluid6VoorLevel5);
        }
        private void Upgrade7_Click(object sender, RoutedEventArgs e)
        {
            Upgrade_Click(ref upgrade7Prijs, ref levelUpgrade7, ref upgrade7Gekocht, lblPrijs7, upgrade7, lblUpgradeCount7, ref Upgrade7Inkomen, tbUpgrade7, pictureIcon7, pictureIcon7Level2, pictureIcon7Level3, pictureIcon7Level4, pictureIcon7Level5, ref geluid7VoorLevel5);
        }

        /// <summary>
        /// Berekent verminigvuldiger op basis van levelUpgrade.
        /// </summary>
        /// <param name="levelUpgrade">Niveau van de upgrade.</param>
        /// <returns>Bepaalt welke vermenigvuldiger je terug krijgt.</returns>
        private double UpgradeVermenigvuldiger(int levelUpgrade)
        {
            double vermenigvuldiger = 1;
            switch (levelUpgrade)
            {
                case 1:
                    vermenigvuldiger = 1;
                    break;
                case 2:
                    vermenigvuldiger = 2;
                    break;
                case 3:
                    vermenigvuldiger = 5;
                    break;
                case 4:
                    vermenigvuldiger = 10;
                    break;
                case 5:
                    vermenigvuldiger = 30;
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

        /// <summary>
        /// Methode die bij elke tick het passieve inkomen verhoogt op basis van gekochte upgrades.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            lblPassiefInkomen.Content = "Passive income:" + VeranderGroteNummer(passiefinkomen) + "/s";

            if (aantalSeconden >= 900)
            {
                ach15MinPlay = true;
            }
            if (aantalSeconden >= 1800)
            {
                ach30minPlay = true;
            }
            if (aantalSeconden >= 3600)
            {
                ach1hPlay = true;
            }
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

        /// <summary>
        /// Vernadert getallen naar een makkelijk leesbare manier. (miljoen, miljard..)
        /// Miljard in het engels is Billion en ik heb de game in het engels gemaakt.
        /// </summary>
        /// <param name="VeranderdeNummer">Dit is het getal dat moet worden omgezet.</param>
        /// <returns>1 Million, 2 Milliard..</returns>
        public string VeranderGroteNummer(double VeranderdeNummer)
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

        private void ChangeUpgradeText(Image pictureUnlocked, Image pictureUpgrade, Label lblUpgrade, Label lblPrijs, Label lblUpgradeCount, Image pictureSCRLVW, Image pictureIcon)
        {

            //hier heb ik een functie gemaakt voor visuele veranderingen zodat het mooi oogt.
            pictureUnlocked.Visibility = Visibility.Visible;
            pictureSCRLVW.Visibility = Visibility.Visible;
            pictureUpgrade.Opacity = 0.8;
            lblUpgrade.Foreground = Brushes.Black;
            lblUpgrade.FontWeight = FontWeights.Bold;
            lblPrijs.Foreground = Brushes.Yellow;
            lblPrijs.FontWeight = FontWeights.Bold;
            lblUpgradeCount.Foreground = Brushes.White;
            lblUpgradeCount.FontWeight = FontWeights.Bold;
            lblPrijs.BorderBrush = Brushes.Blue;
            lblPrijs.BorderThickness = new Thickness(2);
            pictureIcon.Opacity = 1;
        }

        private void UnlockedVisibility()
        {
            //ik heb een gesloten en een open slot, als upgrade1Gekocht is gaat de picturelocked verdwijnen en komt er een nieuwe image, picture van upgrade1 gaat naar scrollview ETC.
            if (upgrade1Gekocht)
            {
                pictureLocked1.Visibility = Visibility.Collapsed;
                ChangeUpgradeText(pictureUnlocked1, pictureUpgrade1, lblUpgrade1, lblPrijs1, lblUpgradeCount1, pictureSCRLVW1, icon1Upgrade);

            }
            if (upgrade2Gekocht)
            {
                pictureLocked2.Visibility = Visibility.Collapsed;
                ChangeUpgradeText(pictureUnlocked2, pictureUpgrade2, lblUpgrade2, lblPrijs2, lblUpgradeCount2, pictureSCRLVW2, icon2Upgrade);

            }
            if (upgrade3Gekocht)
            {
                pictureLocked3.Visibility = Visibility.Collapsed;
                ChangeUpgradeText(pictureUnlocked3, pictureUpgrade3, lblUpgrade3, lblPrijs3, lblUpgradeCount3, pictureSCRLVW3, icon3Upgrade);

            }
            if (upgrade4Gekocht)
            {
                pictureLocked4.Visibility = Visibility.Collapsed;
                ChangeUpgradeText(pictureUnlocked4, pictureUpgrade4, lblUpgrade4, lblPrijs4, lblUpgradeCount4, pictureSCRLVW4, icon4Upgrade);
            }
            if (upgrade5Gekocht)
            {
                pictureLocked5.Visibility = Visibility.Collapsed;
                ChangeUpgradeText(pictureUnlocked5, pictureUpgrade5, lblUpgrade5, lblPrijs5, lblUpgradeCount5, pictureSCRLVW5, icon5Upgrade);

            }
            if (upgrade6Gekocht)
            {
                pictureLocked6.Visibility = Visibility.Collapsed;
                ChangeUpgradeText(pictureUnlocked6, pictureUpgrade6, lblUpgrade6, lblPrijs6, lblUpgradeCount6, pictureSCRLVW6, icon6Upgrade);


            }
            if (upgrade7Gekocht)
            {
                pictureLocked7.Visibility = Visibility.Collapsed;
                ChangeUpgradeText(pictureUnlocked7, pictureUpgrade7, lblUpgrade7, lblPrijs7, lblUpgradeCount7, pictureSCRLVW7, icon7Upgrade);
            }
        }

        //zichtbaarheid van de investeringen gebeurd als de upgradeprijs  gelijk of groter dan de TOTAAL aantal clicks is dus clicks + passief inkomst zonder geld die je besteed aan de upgrades.
        private void TotaalClicksUnlockedUpgrade(Button upgrade, double totaalClicksAlles, double upgradePrijs)
        {
            if (upgradePrijs <= totaalClicksAlles)
            {
                upgrade.Visibility = Visibility.Visible;
            }
        }

        private void UpdateInvestmentButtonVisibility()
        {
            TotaalClicksUnlockedUpgrade(upgrade1, totaalClicksAlles, upgrade1Prijs);
            TotaalClicksUnlockedUpgrade(upgrade2, totaalClicksAlles, upgrade2Prijs);
            TotaalClicksUnlockedUpgrade(upgrade3, totaalClicksAlles, upgrade3Prijs);
            TotaalClicksUnlockedUpgrade(upgrade4, totaalClicksAlles, upgrade4Prijs);
            TotaalClicksUnlockedUpgrade(upgrade5, totaalClicksAlles, upgrade5Prijs);
            TotaalClicksUnlockedUpgrade(upgrade6, totaalClicksAlles, upgrade6Prijs);
            TotaalClicksUnlockedUpgrade(upgrade7, totaalClicksAlles, upgrade7Prijs);
        }

        //veranderen van naam bovenaan volgens keydown.
        private void TxtGarageNaam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string newName = txtGarageNaam.Text.Trim();

                if (!string.IsNullOrWhiteSpace(newName)) // controleert dat de string newName NIET null is
                {
                    txtGarageNaam.Text = newName;
                    upgrade1.Focus(); //omdat er een cursor was in de txtbox die heletijd aan en uit flikkerde heb ik de focus veranderd naar een random btn
                    MessageBox.Show("Are you sure?", "Congrats with ur new name!", MessageBoxButton.YesNo);
                }
                else
                {
                    MessageBox.Show("Please choose ur name!");
                }
            }
        }

        //met hulp van internet heb ik sounds in mijn programma kunnen zetten
        private void PlayUpgradeSound()
        {
            try //probeert geluid af te spelen, in dit geval carRev.wav
            {
                var soundPath = System.IO.Path.Combine("sounds", "carRev.wav");
                var soundPlayer = new System.Media.SoundPlayer(soundPath); //pad vh geluidsbestand wordt gebruikt om soundplayer in te stellen
                soundPlayer.Play(); // laat het geluid afspelen
            }
            catch (Exception ex) //foutmelding
            {
                MessageBox.Show($"Error playing sound: {ex.Message}");
            }
        }
        private void PlayHappySound()
        {
            try
            {
                var soundPath = System.IO.Path.Combine("sounds", "congratsSound.wav");
                var soundPlayer = new System.Media.SoundPlayer(soundPath);
                soundPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing sound: {ex.Message}");
            }
        }
        private void PlaySadSound()
        {
            try
            {
                var soundPath = System.IO.Path.Combine("sounds", "sadSound.wav");
                var soundPlayer = new System.Media.SoundPlayer(soundPath);
                soundPlayer.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing sound: {ex.Message}");
            }
        }

        private void btnSecret_Click(object sender, RoutedEventArgs e)
        {
            Window1 windowSecret = new Window1();
            windowSecret.Show();
        }

        private void arrowButton_Click(object sender, RoutedEventArgs e)
        {
            if (achievementsPanel.Visibility == Visibility.Collapsed)
            {
                achievementsPanel.Visibility = Visibility.Visible;
                AutoClicker.Visibility = Visibility.Collapsed;
            }
            else
            {
                achievementsPanel.Visibility = Visibility.Collapsed;
                AutoClicker.Visibility = Visibility.Visible;

            }

        }

        private void CheckMaxLevelUpgradesAch()
        {
            if (levelUpgrade1 == 5)
            {
                achMaxLvlSpeed = true;
            }
            if (levelUpgrade4 == 5)
            {
                achMaxLvlHyper = true;
            }
            if (levelUpgrade5 == 5)
            {
                achMaxLvlInfinity = true;
            }
        }

        private void UnlockAllUpgradesAch()
        {
            if (upgrade1Gekocht && upgrade2Gekocht && upgrade3Gekocht && upgrade4Gekocht && upgrade5Gekocht && upgrade6Gekocht && upgrade7Gekocht)
            {
                achUnlockAllUpgr = true;
                MessageBox.Show("Congratulations! Achievement unlocked: Unlock all upgrades.");
                txtAch15.Visibility = Visibility.Visible;
                imgCheck15.Visibility = Visibility.Visible;
                imgAch15.Visibility = Visibility.Visible;

            }
        }

        private void AchievementsActies()
        {
           
            if (achMaxLvlHyper && !IsAchMaxLvlHyperDone)
            {
                IsAchMaxLvlHyperDone = true;
                MessageBox.Show("Congratulations! Achievement unlocked: Maximum level Hyper Drive!");
                txtAch12.Visibility = Visibility.Visible;
                imgCheck12.Visibility = Visibility.Visible;
                imgAch12.Visibility = Visibility.Visible;
            }
            if (achMaxLvlSpeed && !IsAchMaxLvlSpeedDone)
            {
                IsAchMaxLvlSpeedDone = true;
                MessageBox.Show("Congratulations! Achievement unlocked: Maximum level Speed Racer!");
                txtAch13.Visibility = Visibility.Visible;
                imgCheck13.Visibility = Visibility.Visible;
                imgAch13.Visibility = Visibility.Visible;
            }
            if (achMaxLvlInfinity && !IsAchMaxLvlInfinityDone)
            {
                IsAchMaxLvlInfinityDone = true;
                MessageBox.Show("Congratulations! Achievement unlocked: Maximum level Infinity Injector!");
                txtAch14.Visibility = Visibility.Visible;
                imgCheck14.Visibility = Visibility.Visible;
                imgAch14.Visibility = Visibility.Visible;
            }
            if (ach15MinPlay && !IsAch15MinPlayDone)
            {
                IsAch15MinPlayDone = true;
                MessageBox.Show("Congratulations! Achievement unlocked: 15 min playtime!");
                txtAch16.Visibility = Visibility.Visible;
                imgCheck16.Visibility = Visibility.Visible;
                imgAch16.Visibility = Visibility.Visible;
            }
            if (ach30minPlay && !IsAch30MinPlayDone)
            {
                IsAch30MinPlayDone = true;
                MessageBox.Show("Congratulations! Achievement unlocked: 30 min playtime!");
                txtAch17.Visibility = Visibility.Visible;
                imgCheck17.Visibility = Visibility.Visible;
                imgAch17.Visibility = Visibility.Visible;
            }
            if (ach1hPlay && !IsAch1hPlayDone)
            {
                IsAch1hPlayDone = true;
                MessageBox.Show("Congratulations! Achievement unlocked: 1 hour playtime!");
                txtAch18.Visibility = Visibility.Visible;
                imgCheck18.Visibility = Visibility.Visible;
                imgAch18.Visibility = Visibility.Visible;
            }
        }




    }
}


