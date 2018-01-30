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
using System.Net;
using System.Text.RegularExpressions;

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

        private void matchsButton_Click(object sender, RoutedEventArgs e)
        {
            WebClient web = new WebClient();

            web.Encoding = Encoding.UTF8;
            string page = web.DownloadString("https://www.sports.ru/football/");
            string name = @"href=""https://www.sports.ru/stat/football/52/match/1193596.html"" title=""(.*?)""";

            foreach (Match match in Regex.Matches(page, name))
            {
                byte[] toEncodeAsBytes = System.Text.Encoding.UTF8.GetBytes(match.Groups[1].Value);
                string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
                listBox.Items.Add(match.Groups[1].Value);
            }
        }
    }
}
