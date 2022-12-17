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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace EasySavev3G5.View
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }


        private void OpenLog_Click(object sender, RoutedEventArgs e)
        {
            if (xml.IsChecked == true)
            {
                File.OpenRead("C:\\EasySaveLog.xml");
            }
            else if (Json.IsChecked == true)
            {
                File.OpenRead("C:\\WPF.json");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Choose the log file", "EasySave", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}