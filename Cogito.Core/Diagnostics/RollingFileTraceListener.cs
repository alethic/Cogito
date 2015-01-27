using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
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
        StreamWriter writer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="fileName"></param>
        public RollingFileTraceListener(string fileName)
        {
            Contract.Requires<ArgumentNullException>(fileName != null);
            Contract.Requires<ArgumentOutOfRangeException>(fileName.Length >= 2);

            // resolve template FileInfo
            filePath = ResolveFilePath(fileName);
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
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
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
            // dispose of current writer
            if (writer != null)
            {
                writer.Close();
                writer = null;
            }

            // ensure directory path exists
            var file = GetCurrentFilePath();
            if (Directory.Exists(Path.GetDirectoryName(file)) == false)
                Directory.CreateDirectory(Path.GetDirectoryName(file));

            // generate new writer
            writer = new StreamWriter(file, true);
        }

        /// <summary>
        /// Checks the current date and rolls the writer over if required.
        /// </summary>
        void CheckWriter()
        {
            if (writer == null || today.CompareTo(DateTime.Today) != 0)
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
            CheckWriter();

            writer.Write(value);
        }

        /// <summary>
        /// Writes a string followed by a line terminator to the text string or stream.
        /// </summary>
        /// <param name="value"></param>
        public override void WriteLine(string value)
        {
            CheckWriter();

            writer.WriteLine(value);
        }

        /// <summary>
        /// Clears all buffers to the current output.
        /// </summary>
        public override void Flush()
        {
            if (writer != null)
            {
                writer.Flush();
            }
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (writer != null)
                {
                    writer.Close();
                    writer = null;
                }
            }
        }

    }

}