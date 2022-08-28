using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MIMIRSOFT
{
    internal class PortAnalysisUtility
    {
        public static string getRunningProcess()
        {
            string macAddress = string.Empty;
            Process NetStatProcess = new Process();
            NetStatProcess.StartInfo.FileName = "netstat";
            NetStatProcess.StartInfo.Arguments = "-a ";
            NetStatProcess.StartInfo.UseShellExecute = false;
            NetStatProcess.StartInfo.RedirectStandardOutput = true;
            NetStatProcess.StartInfo.CreateNoWindow = true;
            NetStatProcess.Start();
            string strOutput = NetStatProcess.StandardOutput.ReadToEnd();
            
            return strOutput;
        }
    }
}
