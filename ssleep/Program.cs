using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ssleep
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        /* public class Options
        {
            [Option('t', "time", Required = false, HelpText = "Set time in which the computer will be set to sleep.")]
            public bool Time { get; set; }

            [Option('m', "message", Required = false, HelpText = "Set a message to display.")]
            public bool Message { get; set; }

            [Option('a', "abort", Required = false, HelpText = "Cancel scheduled sleep mode.")]
            public bool Abort { get; set; }

            [Option('r', "tray", Required = false, HelpText = "Automatically minimise to system tray.")]
            public bool Tray { get; set; }

            [Option('h', "help", Required = false)]
            public bool Help { get; set; }
        } */
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 1)
            {
                char z = args[0].Last();
                int inputAll = 0;
                int input = 0;
                bool parsedToIntAll = Int32.TryParse(args[0].Substring(0, args[0].Length), out inputAll);
                bool parsedToInt = Int32.TryParse(args[0].Substring(0, args[0].Length - 1), out input);
                int time = 0;

                // todo
                //
                // convert negative value to positive - ssleep.exe -20m = 20minutes

                //public int negative2Positive(int i) => (i + (i >> 31)) ^ (i >> 31);
                //or
                //public int negative2Positive(int i)
                //{
                //    return (i + (i >> 31)) ^ (i >> 31);
                //}


                if (parsedToIntAll && inputAll >= 0)
                {
                    if (inputAll < 0)

                    time = inputAll;
                }
                else if (parsedToInt && z == 'm' && input >= 0)
                {
                    time = input * 60;
                }
                else if (parsedToInt && z == 's' && input >= 0)
                {
                    time = input;
                }
                else
                {
                    return;
                }
                /*
                string type;
                if (args[1] == "sec" || args[1] == "min")
                    type = args[1];
                */
                Application.Run(new MainWindow(time));
            }
            else
                Application.Run(new HelpWindow());
            /* if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form());
            } */

            /* Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError); */
        }
        /*
        static void RunOptions(Options opts)
        {
            //handle options

        }
        static void HandleParseError(IEnumerable<Error> errs)
        {
            //handle errors
        } */
    }
}
