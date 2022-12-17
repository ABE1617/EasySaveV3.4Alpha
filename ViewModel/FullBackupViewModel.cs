using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace EasySavev3G5.ViewModel
{

    public class FullBackupViewModel
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
        public void CopyConvert(string sourceDirectory, string targetDirectory, bool DsubDirectory)
            {
                DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
                DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

                CopyAll(diSource, diTarget, DsubDirectory);

            }

            public void CopyAll(DirectoryInfo source, DirectoryInfo target, bool DsubDirectory)
            {
                Directory.CreateDirectory(target.FullName);

                // Copy each file into the new directory.
                foreach (FileInfo file in source.GetFiles())
                {
                   while (pause == true)
                {
                    Thread.Sleep(1000);
                }
                if (cancel == true)
                {
                    return;
                }
                 file.CopyTo(System.IO.Path.Combine(target.FullName, file.Name), true);
                }
                if (DsubDirectory == true)
                {
                    // Copy each subdirectory using recursion.
                    foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                    {
                        DirectoryInfo nextTargetSubDir =
                            target.CreateSubdirectory(diSourceSubDir.Name);
                        CopyAll(diSourceSubDir, nextTargetSubDir, DsubDirectory);
                    }
                }
            }
        }
    }

