using System;
using System.Collections.Generic;
using System.Linq;

namespace FileData
{
    /// <summary>
    /// Implements the IArgumentValidator to allow program arguments to be checked and validated for FileData project
    /// </summary>
    public class ArgumentValidator : IArgumentValidator
    {
        #region Constants

        private const int NumberOfRequiredArgs = 2; // default to 2 program arguments required for now

        private static readonly IEnumerable<string> ValidVersionArgs = new List<string> { "-v", "--v", "/v", "-version" };
        private static readonly IEnumerable<string> ValidSizeArgs = new List<string> { "-s", "--s", "/s", "-size" };

        #endregion

        #region Private Fields

        private readonly IEnumerable<string> _args;
        private bool _valid;
        private readonly int _numberOfRequiredArgs;

        #endregion

        #region Public Properties
        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="numberOfRequiredArgs"></param>
        public ArgumentValidator(IEnumerable<string> args, int numberOfRequiredArgs = NumberOfRequiredArgs)
        {
            _numberOfRequiredArgs = numberOfRequiredArgs;
            _args = args ?? throw new ArgumentNullException(nameof(args));

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Determines whether there is a matching argument to a list of valid argument options.
        /// </summary>
        /// <param name="validArgs">the valid options for displaying version</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>true - _args contains at least one of the valid arg options, else false</returns>
        private bool IsMatch(IEnumerable<string> validArgs)
        {
            if (validArgs == null)
            {
                throw new ArgumentNullException(nameof(validArgs));
            }
            return validArgs.Any(s => _args.Any(s1 => s1 == s));
        }

        #endregion

        #region Protected Methods
        #endregion

        #region Public Methods

        /// <summary>
        /// Initially checks that the program has been passed with valid arguments
        /// </summary>
        /// <returns>true - arguments are correct number and valid values</returns>
        public bool IsValidUsage()
        {
            _valid = false;
            try
            {
                // Validate the required number of arguments 
                _valid = (_args.Count() == _numberOfRequiredArgs);
                // Add any other validation here....
            }
            catch (Exception)
            {
                throw;
            }

            return _valid;
        }

        /// <summary>
        /// Checks whether the arguments passed to the class contain a valid option 
        /// to display version information..
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>true - arguments contain a valid option to display version information, else false</returns>
        public bool IsVersionRequired()
        {
            try
            {
                return IsMatch(ValidVersionArgs);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }

        /// <summary>
        /// Checks whether the arguments passed to the class contain a valid option 
        /// to display size information..
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>true - arguments contain a valid option to display size informatiuon, else false</returns>
        public bool IsSizeRequired()
        {
            try
            {
                return IsMatch(ValidSizeArgs);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }

        #endregion
    }
}
