using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.System
{
    public class CMSSQLLocalDBInstanceLauncher
    {
        // --------------------------------------------------------------------------------------
        public static void Launch(string p_sInstanceName)
        {
            //[C#] Example on how to create a start a process through shell execution (like starting from a command line).    
            //      We are using a declarative approach for the StartInfo property, without keeping a local object ref variable
            //      for the ProcessStartInfo object.
            Process oProcess = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "sqllocaldb.exe",
                    Arguments = "create " + p_sInstanceName,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            oProcess.Start();           // Create the instance.
            oProcess.WaitForExit();     // Waits until the command finishes the execution.


            // Each process returns an exit code. Zero in almost any case means OK.
            if (oProcess.ExitCode != 0)
                Console.WriteLine($"Failed to create the MSSQL local DB instance [{p_sInstanceName}]");
            else
            {

                oProcess = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "sqllocaldb.exe",
                        Arguments = "start " + p_sInstanceName,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };
                oProcess.Start();           // Create the instance.
                oProcess.WaitForExit();     // Waits until the command finishes the execution.
                if (oProcess.ExitCode != 0)
                    Console.WriteLine($"Failed to start the MSSQL local DB instance [{p_sInstanceName}]");
            }
        }
        // --------------------------------------------------------------------------------------

    }
}
