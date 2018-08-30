using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SemaUpd
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] argArr = Environment.GetCommandLineArgs();
                string destPath = argArr[1];
                string sourcePath = @"x:\utils\Semaphore_new\0_Sema.exe";

                Process[] processes = Process.GetProcessesByName("0_Sema");
                processes[0].Kill(); // CloseMainWindow();

                Thread.Sleep(1000);

                File.Copy(sourcePath, destPath, true);

                Process proc = new Process();
                // pathAsArg = destPath;
                //if (destPath.Contains(" "))
                //{
                //    pathAsArg = "\"" + pathAsArg + "\""; 
                //}
                //proc.StartInfo.Arguments = pathAsArg;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.FileName = destPath;
                proc.Start();                
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Возникла ошибка при обновлении Семы. " + Environment.NewLine + "Похоже, что нет запущеного приложения Семы." + Environment.NewLine + ex.Message, "Ошибка при обновлении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка при обновлении Семы. " + Environment.NewLine + ex.Message, "Ошибка при обновлении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
