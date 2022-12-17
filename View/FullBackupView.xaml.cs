using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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
using Microsoft.WindowsAPICodePack.Dialogs;

using System.Windows.Media.TextFormatting;
using EasySavev3G5.ViewModel;
using System.Threading;
using System.ComponentModel;

namespace EasySavev3G5.View
{
    /// <summary>
    /// Interaction logic for FullBackupView.xaml
    /// </summary>
    /// 

    public delegate void Deleg();

    

    public partial class FullBackupView : UserControl
    {
        string Dpath;
        string Spath;
        bool SubDirectory = true;
        public string path = System.IO.File.ReadAllText(@"C:\EasySave\language.txt");

        FullBackupViewModel CHPP = new FullBackupViewModel();


        Task CP1;
        //Thread FullCPTask;

        BackgroundWorker worker = new BackgroundWorker();


        public FullBackupView()
        {
            InitializeComponent();


            if (path == "true")
            {
                Title.Text = "Sauvegarde complète";
                status.Text = "prêt";
                StxtB.Text = "Dossier source";
                DtxtB.Text = "Dossier destination";
                Sbtn.Content = "Source ...";
                Dbtn.Content = "Destination ...";
                Copy.Content = "Copier !";
                pasue.Content = "Pause";
                CContinue.Content = "Continuer";
                cancel.Content = "Annuler";
                Sub.Content = "Désactiver la sauvegarde des sous-dossiers";
            }
            else if (path == "false")
            {
                Title.Text = "Full BackUp";
                status.Text = "Ready";
                StxtB.Text = "Source Folder";
                DtxtB.Text = "Destination Folder";
                Sbtn.Content = "Source ...";
                Dbtn.Content = "Destination ...";
                Copy.Content = "Copy !";
                pasue.Content = "Pause";
                CContinue.Content = "Continue";
                cancel.Content = "Cancel";
                Sub.Content = "Disable Sub Folders Backup";
            }


            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
           // worker.ProgressChanged += Worker_ProgressChanged;

             //= new Thread(() => { FullBackupViewModel.CopyConvert(Spath, Dpath, SubDirectory); });
        }

        public void Worker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        /// ////////////////////////(sender as BackgroundWorker).ReportProgress(i);

       /* public void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //initialisation de la barre de progression avec le pourcentage de progression
            PB.Value = e.ProgressPercentage;

            //Affichage de la progression sur un label
            PBstatus.Content = PBstatus.Value.ToString() + "%";
        }*/
        public void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialogSource = new CommonOpenFileDialog();
            dialogSource.IsFolderPicker = true;
            // dialog.Filter = "All files (*.*)|*.*";
            if (dialogSource.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Spath = dialogSource.FileName;

                status.Text = Spath;


            }
        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Dpath = dialog.FileName;

                status.Text = Dpath;
            }
        }
        public void RemoteCall()
        {
            CHPP.CopyConvert(Spath, Dpath, SubDirectory);
        }

        public void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Task.Run(RemoteCall);
            
            /*Thread FullCPTask = new Thread(new ThreadStart(() => { */
             /*}));*/
           //  FullCPTask.Start();
           //CP1 = Task.Factory.StartNew(() => RemoteCall());
            // Task.Run(RemoteCall);
            status.Text = "Operation Completed";

        }

        public void pasue_Click(object sender, RoutedEventArgs e)
        {
            CHPP.Pause();
          //  Task.WaitAll();
          // Task.W (new[] { CP1 });
          // FullCPTask.Suspend();
            status.Text = "Task Suspended";
        }




        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {


        }
        
        private void continue_Click(object sender, RoutedEventArgs e)
        {
            CHPP.Resume();
            status.Text = "Resuming Task";
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            CHPP.Cancel();
            status.Text = "Task Canceld";
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
