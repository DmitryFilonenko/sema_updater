using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
                string sourcePath = @"x:\utils\Semaphore_new\0 Sema.exe";

                Process[] processes = Process.GetProcessesByName("Sema");
                processes[0].CloseMainWindow();

                Thread.Sleep(1000);

                File.Copy(sourcePath, destPath, true);

                Process proc = new Process();
                string pathAsArg = destPath;
                if (destPath.Contains(" "))
                {
                    pathAsArg = "\"" + pathAsArg + "\""; 
                }
                proc.StartInfo.Arguments = pathAsArg;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.FileName = pathAsArg;
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
