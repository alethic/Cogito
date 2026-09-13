using System;
using System.Diagnostics;
using System.IO;

namespace Cogito.Diagnostics
{

    /// <summary>
    /// Implements a <see cref="TraceListener"/> that writes to a file, rolling over for each day.
    /// </summary>
    public class RollingFileTraceListener :
        TraceListener
    {


        readonly string filePath;

        DateTime today;
        FileInfo output;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="fileName"></param>
        public RollingFileTraceListener(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            if (fileName.Length < 2)
                throw new ArgumentOutOfRangeException(nameof(fileName));

            // resolve template FileInfo
            filePath = ResolveFilePath(fileName);
        }

        /// <summary>
        /// Gets the base directory of the current executable.
        /// </summary>
        /// <returns></returns>
        string GetBaseDirectory()
        {
#if NET451
            return AppDomain.CurrentDomain.BaseDirectory;
#else
            return AppContext.BaseDirectory;
#endif
        }

        /// <summary>
        /// Resolve the <see cref="FileInfo"/> given a relative or absolute file name.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        string ResolveFilePath(string fileName)
        {
            if (Path.IsPathRooted(fileName))
                return fileName;

            // resolve base directory
            var baseDirectory = GetBaseDirectory();
            if (baseDirectory != null)
            {
                var baseDirectoryUri = new Uri(baseDirectory);
                if (baseDirectoryUri.IsFile)
                    baseDirectory = baseDirectoryUri.LocalPath;
            }

            // available base directory
            if (baseDirectory != null &&
                baseDirectory.Length > 0)
                return Path.GetFullPath(Path.Combine(baseDirectory, fileName));

            // fallback to full path of file
            return Path.GetFullPath(fileName);
        }

        /// <summary>
        /// Gets the current destination file name.
        /// </summary>
        /// <returns></returns>
        string GetCurrentFilePath()
        {
            today = DateTime.Today;

            return Path.Combine(
                Path.GetDirectoryName(filePath),
                Path.GetFileNameWithoutExtension(filePath) + "_" + today.ToString("yyyyMMdd") + Path.GetExtension(filePath));
        }

        void Rollover()
        {
            // ensure directory path exists
            var file = GetCurrentFilePath();
            if (Directory.Exists(Path.GetDirectoryName(file)) == false)
                Directory.CreateDirectory(Path.GetDirectoryName(file));

            // generate new writer
            output = new FileInfo(file);
        }

        /// <summary>
        /// Checks the current date and rolls the writer over if required.
        /// </summary>
        void CheckRollover()
        {
            if (output == null || today.CompareTo(DateTime.Today) != 0)
            {
                Rollover();
            }
        }

        /// <summary>
        /// Writes a string to the stream.
        /// </summary>
        /// <param name="value"></param>
        public override void Write(string value)
        {
            CheckRollover();

            using (var writer = output.AppendText())
                writer.Write(value);
        }

        /// <summary>
        /// Writes a string followed by a line terminator to the text string or stream.
        /// </summary>
        /// <param name="value"></param>
        public override void WriteLine(string value)
        {
            CheckRollover();

            using (var writer = output.AppendText())
                writer.WriteLine(value);
        }

        /// <summary>
        /// Clears all buffers to the current output.
        /// </summary>
        public override void Flush()
        {

        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
        }

    }

}