using System;
using System.Diagnostics;

namespace TestApp2005.pyScripts
{
    internal class pyService
    {
        public string fileProcessStart(int wordScore,int wordThreshold)
        {
            string pythonScript = @"C:\Users\eymen\source\repos\TestApp2005\TestApp2005\pyScripts\test.py";
            string arguments = wordScore+" "+wordThreshold;

            // Process sınıfını kullanarak Python betiğini çalıştırma
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "python";
            startInfo.Arguments = $"{pythonScript} {arguments}";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            process.StartInfo = startInfo;
            process.Start();
            // Python betiğinin çıktısını alıp ekrana yazdırma
            string output = process.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            return output;
        }
    }
}
