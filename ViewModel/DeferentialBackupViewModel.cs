using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasySavev3G5.ViewModel
{
    internal class DeferentialBackupViewModel
    {
        public EventWaitHandle auto = new AutoResetEvent(true);

        bool pause = false;
        bool cancel = false;

        public void Cancel()
        {
            cancel = true;
        }
        public void Pause()
        {
            pause = true;
        }
        public void Resume()
        {
            pause = false;
        }
        public void ResetStatus()
        {
            cancel = false;
            pause = false;
        }

        public  void CopyDirectoryDiff(string sourceDir, string destinationDir, bool recursive, bool metier)
        {

            List<string> DestList = Directory.EnumerateFiles(destinationDir, "*.*", SearchOption.AllDirectories).ToList(); ;
            List<string> SrcList = Directory.EnumerateFiles(sourceDir, "*.*", SearchOption.AllDirectories).ToList();
            List<FileInfo> srcList = new List<FileInfo>();
            foreach (var item in SrcList)
            {
                srcList.Add(new FileInfo(item));
            }
            List<FileInfo> desList = new List<FileInfo>();
            foreach (var item in DestList)
            {
                desList.Add(new FileInfo(item));
            }
            List<FileInfo> changedNbList = new List<FileInfo>();
            List<FileInfo> NewFiles = new List<FileInfo>();

            foreach (FileInfo file in srcList)
            {
                int counter = 0;
                foreach (var item in desList)
                {
                    string pathFile = file.FullName;
                    pathFile = pathFile.Replace(sourceDir, "");
                    string pathDestFile = item.FullName;
                    pathDestFile = pathDestFile.Replace(destinationDir, "");
                    if (pathFile == pathDestFile)
                    {
                        counter++;
                        if (file.Length == item.Length)
                        {
                            break;
                        }
                        else
                        {
                            changedNbList.Add(file);
                        }
                    }

                }
                if (counter == 0)
                {
                    NewFiles.Add(file);
                }

            }
            ResetStatus();
            foreach (FileInfo file in NewFiles)
            {
                string pathFile = file.FullName;
                pathFile = pathFile.Replace(sourceDir, "");
                string targetFilePath = destinationDir + @"\" + pathFile;
                DateTime TimeBefore = DateTime.Now;
                Directory.CreateDirectory(new FileInfo(targetFilePath).DirectoryName);

                if (metier == true)
                {
                    while (pause == true)
                    {
                        Thread.Sleep(1000);
                    }
                    if (cancel == true)
                    {
                        return;
                    }
                    if (System.IO.Path.GetExtension(targetFilePath) != ".exe" )
                    {
                        file.CopyTo(targetFilePath, true);
                    }
                }
                else
                {
                    while (pause == true)
                    {
                        Thread.Sleep(1000);
                    }
                    if (cancel == true)
                    {
                        return;
                    }
                    file.CopyTo(targetFilePath, true);
                }
                


            }
            ResetStatus();
            foreach (FileInfo file in changedNbList)
            {
                string pathFile = file.FullName;
                pathFile = pathFile.Replace(sourceDir, "");
                string targetFilePath = destinationDir + @"\" + pathFile;
                DateTime TimeBefore = DateTime.Now;
                file.Directory.Create();
                if (metier == true)
                {
                    while (pause == true)
                    {
                        Thread.Sleep(1000);
                    }
                    if (cancel == true)
                    {
                        return;
                    }
                    if (System.IO.Path.GetExtension(targetFilePath) != ".exe")
                    {
                        file.CopyTo(targetFilePath, true);
                    }
                    
                }
                else
                {
                    while (pause == true)
                    {
                        Thread.Sleep(1000);
                    }
                    if (cancel == true)
                    {
                        return;
                    }
                    file.CopyTo(targetFilePath, true);
                }


            }
        }


    }

}

