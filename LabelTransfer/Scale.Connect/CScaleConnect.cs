using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scale.Connect
{
    public class CScaleConnect
    {
        
        protected string[] sPort { get; set; }
        public Dictionary<string, int> ips { get; set; }

        
        
        protected ProcessStartInfo startInfo { get; set; }

        private string path = $@"{GetProjectDirectory()}\Scale.Connect\Connection";


        public CScaleConnect(List<string> o_sIp)
        {
            ips = new Dictionary<string, int>();
            foreach(string ip in o_sIp)
            {
                ips.Add(ip, 0);
                
            }

            startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = path;
            startInfo.FileName = "cmd.exe";
            
        }


        public void ReadPLU()
        {
            int iLast = 0;
            string zero = new string('0',0);
            string valueToChanage = "";

            foreach (KeyValuePair<string,int> kvp in this.ips){

                
                sPort = kvp.Key.Split(".");
                Debug.WriteLine(sPort[3].Length);
                if (sPort.Length > 0)
                {
                    iLast = 3 - sPort[3].Length;
                    zero = new string('0', iLast);
                }
                else
                    iLast = 0;

                string command = $@".\TWS.exe rdf 25 {kvp.Key} 2{zero}{sPort[3]}";
                Debug.WriteLine($@"The path is : {path}");
                startInfo.Arguments = "/c" + command;
                Debug.WriteLine(command);
                Process.Start(startInfo);
                Thread.Sleep(1000);

                try
                {
                    using (StreamReader stream = new StreamReader($@"{path}\result"))
                    {
                        string status = stream.ReadLine().Split(':')[2];
                        if (status.Equals("0"))
                        {
                            valueToChanage = kvp.Key;
                            MessageBox.Show("Peshorja eshte konektuar me sukses!");
                        }
                        else
                        {
                            MessageBox.Show("Nodhi nje problem me konektimin e peshores!\n" +
                                "Shiko se mos ke futur ip-n gabim!");
                        }

                    }
                }
                catch (FileNotFoundException)
                {
                    
                    MessageBox.Show($"Peshorja me IP {kvp.Key.ToString()} nuk eshte konektuar sakte!\n" +
                        $"Provo ta Pingosh qe te shohesh a eshte konektuar me kompjuterin");
                    valueToChanage = kvp.Key.ToString();
                    
                }
                

            }
            ips[valueToChanage] = 1;

            
            

        }

        

        private static string GetProjectDirectory()
        {
            string currentDirectory = AppContext.BaseDirectory;
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
            while (directoryInfo != null && !directoryInfo.EnumerateFiles("*.sln").Any()) {
                directoryInfo = directoryInfo.Parent;
            }
            return directoryInfo?.FullName;
        }



    }
}
