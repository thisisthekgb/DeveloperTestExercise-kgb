namespace FileData
{
    /// <summary>
    /// Validates arguments passed to the FileData program
    /// </summary>
    public interface IArgumentValidator
    {
        /// <summary>
        /// Are the arguments valid (length and type)
        /// </summary>
        /// <returns></returns>
        bool IsValidUsage();

        /// <summary>
        /// Determines whether file version information is required.
        /// </summary>
        /// <returns></returns>
        bool IsVersionRequired();

        /// <summary>
        /// Determines whether file size information is required.
        /// </summary>
        /// <returns></returns>
        bool IsSizeRequired();
    }

}
