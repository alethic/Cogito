using System;
using System.Diagnostics;
using System.IO;

namespace Cogito.Core.Diagnostics
{

    /// <summary>
    /// Implements a <see cref="TraceListener"/> that writes to a file, rolling over for each day.
    /// </summary>
    public class RollingFileTraceListener :
        TraceListener
    {


        readonly string fileName;

        DateTime today;
        StreamWriter writer;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="fileName"></param>
        public RollingFileTraceListener(string fileName)
        {
            this.fileName = fileName;
            this.writer = new StreamWriter(GetCurrentFileName(), true);
        }

        /// <summary>
        /// Writes a string to the stream.
        /// </summary>
        /// <param name="value"></param>
        public override void Write(string value)
        {
            CheckRollover();
            writer.Write(value);
        }

        /// <summary>
        /// Writes a string followed by a line terminator to the text string or stream.
        /// </summary>
        /// <param name="value"></param>
        public override void WriteLine(string value)
        {
            CheckRollover();
            writer.WriteLine(value);
        }

        /// <summary>
        /// Gets the current destination file name.
        /// </summary>
        /// <returns></returns>
        string GetCurrentFileName()
        {
            today = DateTime.Today;

            return Path.Combine(
                Path.GetDirectoryName(fileName),
                Path.GetFileNameWithoutExtension(fileName) + "_" + today.ToString("yyyymmdd") + Path.GetExtension(fileName));
        }

        /// <summary>
        /// Checks the current date and rolls the writer over if required.
        /// </summary>
        void CheckRollover()
        {
            if (today.CompareTo(DateTime.Today) != 0)
            {
                writer.Close();
                writer = new StreamWriter(GetCurrentFileName(), true);
            }
        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                writer.Close();
        }

    }

}