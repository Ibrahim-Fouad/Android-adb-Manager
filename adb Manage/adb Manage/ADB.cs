using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace adb_Manage
{
    class ADB
    {
       public static string Shell(string args)
        {
            Process p = new Process
            {
                StartInfo =
                {
                    CreateNoWindow = true,
                    FileName = "adb.exe",
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            p.Start();
            string result = string.Empty;
            while (!p.HasExited)
            {
                result = p.StandardOutput.ReadToEnd();
            }
            return result.Trim();
        }
    }
}
