using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using log4net.Config;
using EasySavev3G5.ViewModel;
using System.Windows.Forms;

namespace EasySavev3G5.View
{
    /// <summary>
    /// Interaction logic for EncryptionView.xaml
    /// </summary>
    /// 

    public partial class EncryptionView : System.Windows.Controls.UserControl
    {


        EncryptionViewModel enc = new EncryptionViewModel();


        public EncryptionView()
        {
            InitializeComponent();
            XmlConfigurator.Configure();
        }

        private void btnBrows(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fdb = new FolderBrowserDialog();
            if (fdb.ShowDialog().Equals(DialogResult.OK))
            {
                txtDirectoryName.Text = fdb.SelectedPath.ToString();
            }

            listBox.Items.Clear();
            try
            {

                string[] fnames = Directory.GetFiles(txtDirectoryName.Text);

                for (int i = 0; i < fnames.Length; i++)
                {
                    listBox.Items.Add(fnames[i]);
                }
            }
            catch { }

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCryt_Click(object sender, RoutedEventArgs e)
        {

            enc.ds = txtDirectoryName.Text.ToString();
            enc.fname = listBox.SelectedItem.ToString();
            enc.key = txtKey.TabIndex;

            if (json.IsChecked == true)
            {
                enc.EncryptEventJson();

            }
            else if (xml.IsChecked == true)
            {
                enc.EncryptEventXml();
            }

        }
    }
}