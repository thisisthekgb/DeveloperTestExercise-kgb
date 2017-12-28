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
using ThirdPartyTools;

namespace FileData
{
    public static class Program 
    {
        #region Private Fields

        private static readonly IEnumerable<string> ValidArgs = new List<string> { "-v" };

        #endregion

        #region Private Methods

        private static void DisplayUsage()
        {
            Console.WriteLine("Please enter the path and filename required to show the version.");
            Console.WriteLine("Usage: -v <file>");
        }

        #endregion

        #region Protected Methods
        #endregion

        #region Public Methods

        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            var fileDetails = new FileDetails();
            IArgumentValidator argumentValidator = new ArgumentValidator(args);

            // Check that the program has been passed with valid arguments
            if (argumentValidator.IsValidUsage())
            {
                // If the file version is required then display it to console.
                if (argumentValidator.IsVersionRequired(ValidArgs))
                {
                    var file = args[1];
                    var result = fileDetails.Version(file);
                    Console.WriteLine("File: {0} Version: {1}", file, result);
                }
            }
            else
            {
                Console.WriteLine("Invalid usage !");
                DisplayUsage();
            }

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();

        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Environment.Exit(1);
        }

    #endregion

}
}
