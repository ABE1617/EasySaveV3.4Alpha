using System;
using System.Collections.Generic;
using System.IO;
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
using EasySavev3G5.Properties;
using EasySavev3G5.ViewModel;

namespace EasySavev3G5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new FullBackupViewModel();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataContext = new DeferentialBackupViewModel();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataContext = new EncryptionViewModel();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DataContext = new DecryptionViewModel();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DataContext = new SettingsViewModel();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string path = @"C:\EasySave\language.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.Write("true");
                }

            }
            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.Write("true");
                }
            }
            FULL.Content = "Sauvegarde complète";
            DEF.Content = "Sauvegarde différentielle";
            ENC.Content = "Cryptage"; 
            DEC.Content = "Décryptage";
            SETT.Content = "Paramètre";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            string path = @"C:\EasySave\language.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.Write("false");
                }

            }
            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.Write("false");
                }
            }
            FULL.Content = "Full Backup";
            DEF.Content = "Differential Backup";
            ENC.Content = "Encryption";
            DEC.Content = "Decryption";
            SETT.Content = "Settings";
        }
    }
    }

