using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharpOSC;
using IniParser;
using IniParser.Model;

namespace BenzaldehydeOSC
{
    internal class Program
    {

        public static UDPSender oscSender;
        private static IniData iniData;
        private static FileIniDataParser iniParser;
        private static readonly string CONFIGPATH = "config.ini";
        static void Main(string[] args)
        {
            iniParser = new();
            iniData = iniParser.ReadFile(CONFIGPATH);

            oscSender = new(iniData["Settings"]["IP"], int.Parse(iniData["Settings"]["Port"]));

            string message = "Imagine needing to be in a gang to be relevant lol\n\n\n                     \n         PC Specs: Pigeon Powered";

            while (true)
            {
                Console.Title = "Spamming VRCOSC";
                Thread.Sleep(5000);
                SendMessage(message);
            }
            
        }

        public static void SendMessage(string message)
        {
            oscSender.Send(new OscMessage("/chatbox/typing", false));
            oscSender.Send(new OscMessage("/chatbox/input", message, true));
        }
    }
}
