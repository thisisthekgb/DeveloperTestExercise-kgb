using System.Collections.Generic;

namespace FileData
{
    /// <summary>
    /// Validates arguments passed to the FileData program
    /// </summary>
    public interface IArgumentValidator
    {
        /// <summary>
        /// Provides validation for argument usage
        /// </summary>
        /// <returns></returns>
        bool IsValidUsage();

        /// <summary>
        /// Determines whether the given arguments specifiy that version information is required.
        /// </summary>
        /// <param name="validArgs"></param>
        /// <returns></returns>
        bool IsVersionRequired(IEnumerable<string> validArgs);
    }

}
