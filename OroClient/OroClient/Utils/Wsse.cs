using System.Diagnostics;
using System.IO;

namespace OroClient.Utils
{
    public static class Wsse
    {
        public static string GenerateHeader()
        {
            string call = @"""C:\Program Files\php-8.1.4\php.exe""";

            //To execute the PHP file.
            string param1 = @"-f";

            //the PHP wrapper class file location. NOTE: remember to enclose in " (quotes) if there is a space in the directory structure.
            string param2 = @"""C:\projects\OroCRMIntegration\OroClient\OroClient\Utils\wsse.php""";

            Process myProcess = new Process();

            // Start a new instance of this program but specify the 'spawned' version. using the PHP.exe file location as the first argument.
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(call, "spawn");
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;

            //Provide the other arguments.
            myProcessStartInfo.Arguments = $"{param1} {param2}";
            myProcess.StartInfo = myProcessStartInfo;

            //Execute the process
            myProcess.Start();
            StreamReader myStreamReader = myProcess.StandardOutput;

            // Read the standard output of the spawned process.
            string myString = myStreamReader.ReadLine();

            return myString;
        }

        
    }
}
