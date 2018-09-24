 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.IO;

namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi, my name is StartUP!");
            string settingsFile = System.AppDomain.CurrentDomain.BaseDirectory + "arcade.txt";
            if (args == null || args.Length == 0)
            {
                //No argument
                Console.WriteLine("I need a game name on the commandline!");
            } else {
                //We got a command line arg, hopefully a game!
                //Open the settings file
                bool foundGame = false;
                using (StreamReader reader = new StreamReader(settingsFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        if (parts[0].Trim().ToLower() == args[0].Trim().ToLower())
                        {
                            //Found our game, run it!
                            foundGame = true;
                            try
                            {
                                Console.WriteLine("Running " + args[0].Trim().ToLower());
                                Process ExternalProcess = new Process();
                                ExternalProcess.StartInfo.FileName = parts[1];
                                ExternalProcess.StartInfo.Arguments = parts[2];
                                ExternalProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                                ExternalProcess.Start();
                                ExternalProcess.WaitForExit();
                            } catch
                            {
                                Console.WriteLine("Could not run " + args[0].Trim().ToLower() + ", sorry..");
                            }
                            break;
                        }
                    }
                }
                if(foundGame == false)
                {
                    Console.WriteLine("I did not find the game " + args[0].Trim().ToLower() + " in my file, sorry...");
                }
            } 
            Console.WriteLine("Bye from StartUP!");
        }
    }
}
