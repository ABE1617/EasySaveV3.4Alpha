using EasySavev3G5.ViewModel;
using Microsoft.WindowsAPICodePack.Dialogs;
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

namespace EasySavev3G5.View
{
    /// <summary>
    /// Interaction logic for DeferentialBackupView.xaml
    /// </summary>
    public partial class DeferentialBackupView : UserControl
    {

        string Dpath;
        string Spath;
        bool SubDirectory = true;
        bool EXE;
        public string path = System.IO.File.ReadAllText(@"C:\EasySave\language.txt");

        DeferentialBackupViewModel CHP = new DeferentialBackupViewModel();

        public DeferentialBackupView()
        {
            InitializeComponent();



            if (path == "true")
            {
                Title2.Text = "Sauvegarde différentielle";
                status2.Text = "prêt";
                StxtB2.Text = "Dossier source";
                DtxtB2.Text = "Dossier destination";
                Sbtn2.Content = "Source ...";
                Dbtn2.Content = "Destination ...";
                Copy2.Content = "Copier !";
                pasue2.Content = "Pause";
                CContinue2.Content = "Continuer";
                cancel2.Content = "Annuler";
                Sub2.Content = "Désactiver la sauvegarde des sous-dossiers";
            }
            else if (path == "false")
            {
                Title2.Text = "Differential Backup";
                status2.Text = "Ready";
                StxtB2.Text = "Source Folder";
                DtxtB2.Text = "Destination Folder";
                Sbtn2.Content = "Source ...";
                Dbtn2.Content = "Destination ...";
                Copy2.Content = "Copy !";
                pasue2.Content = "Pause";
                CContinue2.Content = "Continue";
                cancel2.Content = "Cancel";
                Sub2.Content = "Disable Sub Folders Backup";
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CHP.Pause();
        }
        public void RemoteCall()
        {
            CHP.CopyDirectoryDiff(Spath, Dpath, SubDirectory, EXE);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Dpath = dialog.FileName;

                status2.Text = Dpath;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialogSource = new CommonOpenFileDialog();
            dialogSource.IsFolderPicker = true;
            // dialog.Filter = "All files (*.*)|*.*";
            if (dialogSource.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Spath = dialogSource.FileName;

                status2.Text = Spath;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Task.Run(RemoteCall);
            if (EXECH.IsChecked == true)
            {
                EXE = true;
            }
            else { EXE = false; }

            /*Thread FullCPTask = new Thread(new ThreadStart(() => { */
            /*}));*/
            //  FullCPTask.Start();
            //CP1 = Task.Factory.StartNew(() => RemoteCall());
            // Task.Run(RemoteCall);
            status2.Text = "Operation Completed";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CHP.Resume();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            CHP.Cancel();
        }


    }
}
