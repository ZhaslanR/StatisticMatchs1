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
using StatusMatchs;

namespace LoginAndRegister
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            UTF8Encoding utf8 = new UTF8Encoding();
            System.Net.WebClient web = new System.Net.WebClient();
            String Response = web.DownloadString("http://www.readfootball.com/matches-now.html");
            String Rate = System.Text.RegularExpressions.Regex.Match(Response, @"< span class=""match_team1"">{}</span>").Groups[1].Value;

        }


        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow window = new SecondWindow();
            window.Show();
            this.Close();
        }

        private void discusionButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new DiscusionPage();
        }
    }
}
