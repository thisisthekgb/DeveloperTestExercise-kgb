/*
 * Program:     DisplayUsage
 * Description:
 * 
 * Display file version of given filename to the console.
 * 
 * Usage : -v <pathname>
 *
 *  */

using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
    public static class Program 
    {
        #region Private Methods

        private static void DisplayUsage()
        {
            Console.WriteLine("Please enter the path and filename required to show the version or size.");
            Console.WriteLine("Usage: <[-v | --v | /v | -version | -s | --s | /s | -size]> <file>");
        }

        private static void DisplayInvalidUsage(IEnumerable<string> args)
        {
            Console.WriteLine("Invalid usage [{0}]", args != null && args.Any() ? args.Aggregate((x,y) => x + string.Empty + y):string.Empty);
            DisplayUsage();
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Environment.Exit(1);
        }

        #endregion

        #region Protected Methods
        #endregion

        #region Public Methods

        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            var fileDetails = new FileDetails();
            IArgumentValidator validator = new ArgumentValidator(args);

            // Check that the arguments passed to the program are valid and the right length
            if (validator.IsValidUsage())
            {
                var file = args[1];

                // If the file version is required then display it to console.
                if (validator.IsVersionRequired())
                {
                    Console.WriteLine("File: {0} Version: {1}", file, fileDetails.Version(file));
                }
                // If the file size is required then display it to console.
                else if (validator.IsSizeRequired())
                {
                    Console.WriteLine("File: {0} Size: {1}", file, fileDetails.Size(file));
                }
                else
                {
                    DisplayInvalidUsage(args);
                }
            }
            else
            {
                DisplayInvalidUsage(args);
            }

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();

        }

        #endregion

    }
}
