using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasySavev3G5.View;
using log4net;
using log4net.Config;


namespace EasySavev3G5.ViewModel
{
    internal class EncryptionViewModel
    {


        private static ILog logger = LogManager.GetLogger(typeof(MainMenu));
        public string fname;
        public int key;
        public string ds;
        public void EncryptEventJson()
        {

            string cr_content = System.IO.File.ReadAllText(fname);
            string cr_filename = System.IO.Path.GetFileNameWithoutExtension(fname);
            string cr_extention = System.IO.Path.GetExtension(fname);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            string crypted = EncryptDecrypt(cr_content, key);
            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;

            if (cr_filename.Contains("_crypted") == true)
            {
                var charsToRemovej = new string[] { "_crypted" };
                foreach (var k in charsToRemovej)
                {
                    cr_filename = cr_filename.Replace(k, string.Empty);
                }
                System.IO.File.WriteAllText(ds + @"\" + cr_filename + "_decrypted" + cr_extention, crypted);


                logger.Info(" Decryption  : " + fname + " | Path : " + ds + " | Key : " + key + " | Elapsed Time : " + elapsedMs + " Ms");
                MessageBox.Show("Decryption complete!", "EasySave", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cr_filename.Contains("_decrypted") == true)
            {
                var charsToRemovej = new string[] { "_decrypted" };
                foreach (var k in charsToRemovej)
                {
                    cr_filename = cr_filename.Replace(k, string.Empty);
                }

                System.IO.File.WriteAllText(ds + @"\" + cr_filename + "_crypted" + cr_extention, crypted);
                logger.Info(" Encryption  : " + fname + " | Path : " + ds + " | Key : " + key + " | Elapsed Time : " + elapsedMs + " Ms");

                MessageBox.Show("Encryption complete!", "EasySave", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            else
            {

                System.IO.File.WriteAllText(ds + @"\" + cr_filename + "_crypted" + cr_extention, crypted);
                logger.Info(" Encryption  : " + fname + " | Path : " + ds + " | Key : " + key + " | Elapsed Time : " + elapsedMs + " Ms");
                MessageBox.Show("Encryption complete!", "EasySave", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }


        public void EncryptEventXml()
        {

            string cr_content = System.IO.File.ReadAllText(fname);
            string cr_filename = System.IO.Path.GetFileNameWithoutExtension(fname);
            string cr_extention = System.IO.Path.GetExtension(fname);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            string crypted = EncryptDecrypt(cr_content, key);
            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;

            if (cr_filename.Contains("_crypted") == true)
            {
                var charsToRemovej = new string[] { "_crypted" };
                foreach (var k in charsToRemovej)
                {
                    cr_filename = cr_filename.Replace(k, string.Empty);
                }
                System.IO.File.WriteAllText(ds + @"\" + cr_filename + "_decrypted" + cr_extention, crypted);


                // CreateXMLfile();
                // AddRecordsXML();
                DateTime today = DateTime.Now;
                string XMLdoc = @"<DateTime>" + today + "</DateTime>" +
                        "<mode>Full BackUP</mode>" +
                        "<Inputpath>" + fname + "</Inputpath>" +
                        "<output>" + ds + "</output>" +
                        "<elapsed>" + elapsedMs + "</elapsed>";

                File.AppendAllText(@"C:\EasySave\EasySaveLog.xml", XMLdoc);


                MessageBox.Show("Decryption complete!", "EasySave", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (cr_filename.Contains("_decrypted") == true)
            {
                var charsToRemovej = new string[] { "_decrypted" };
                foreach (var k in charsToRemovej)
                {
                    cr_filename = cr_filename.Replace(k, string.Empty);
                }

                System.IO.File.WriteAllText(ds + @"\" + cr_filename + "_crypted" + cr_extention, crypted);


                // CreateXMLfile();
                // AddRecordsXML();
                DateTime today = DateTime.Now;
                string XMLdoc = @"<DateTime>" + today + "</DateTime>" +
                        "<mode>Full BackUP</mode>" +
                        "<Inputpath>" + fname + "</Inputpath>" +
                        "<output>" + ds + "</output>" +
                        "<elapsed>" + elapsedMs + "</elapsed>";

                File.AppendAllText(@"C:\EasySave\EasySaveLog.xml", XMLdoc);
                MessageBox.Show("Encryption complete!", "EasySave", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {

                System.IO.File.WriteAllText(ds + @"\" + cr_filename + "_crypted" + cr_extention, crypted);
                // CreateXMLfile();
                // AddRecordsXML();
                DateTime today = DateTime.Now;
                string XMLdoc = @"<DateTime>" + today + "</DateTime>" +
                        "<mode>Full BackUP</mode>" +
                        "<Inputpath>" + fname + "</Inputpath>" +
                        "<output>" + ds + "</output>" +
                        "<elapsed>" + elapsedMs + "</elapsed>";

                File.AppendAllText(@"C:\EasySave\EasySaveLog.xml", XMLdoc);
                MessageBox.Show("Encryption complete!", "EasySave", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }
        public string EncryptDecrypt(string szPlainText, int szEncryptionKey)
        {
            StringBuilder szInputStringBuild = new StringBuilder(szPlainText);
            StringBuilder szOutStringBuild = new StringBuilder(szPlainText.Length);
            char Textch;
            for (int iCount = 0; iCount < szPlainText.Length; iCount++)
            {
                Textch = szInputStringBuild[iCount];
                Textch = (char)((int)Textch ^ szEncryptionKey);
                szOutStringBuild.Append(Textch);
            }
            return szOutStringBuild.ToString();
        }


    }
}