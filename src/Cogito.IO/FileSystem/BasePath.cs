using System;
using System.Diagnostics;

namespace Cogito.IO.FileSystem
{

    [DebuggerDisplay(@"{this.GetType().Name}  {m_Path}")]
    public abstract class BasePath
    {

        public static explicit operator string(BasePath path)
        {
            return path.Path;
        }

        string m_Path;

        public BasePath(string path, bool isAbsolute)
        {
            if (path == null)
                throw new ArgumentNullException("Input path string is null");

            // No check fro empty paths
            if (path.Length == 0)
                throw new ArgumentException(path, "Input path string is empty");

            path = InternalStringHelper.NormalizePath(path);

            string errorReason;
            if (isAbsolute)
                PathHelper.IsValidAbsolutePath(path, out errorReason);
            else
                PathHelper.IsValidRelativePath(path, out errorReason);
            if (errorReason.Length > 0)
                throw new ArgumentException(path, errorReason);

            // Try remove eventual InnerSpecialDir
            if (InternalStringHelper.ContainsInnerSpecialDir(path))
                InternalStringHelper.TryResolveInnerSpecialDir(path, out path, out errorReason);

            Debug.Assert(errorReason.Length == 0);
            Debug.Assert(path != null && path.Length > 0);

            m_Path = path;
        }

        public string Path
        {
            get { return m_Path; }
        }

        public abstract bool IsAbsolutePath { get; }

        public abstract bool IsRelativePath { get; }

        public abstract bool IsDirectoryPath { get; }

        public abstract bool IsFilePath { get; }

        protected BasePath()
        {
            m_Path = string.Empty;
        }

        public bool IsEmpty
        {
            get { return m_Path.Length == 0; }
        }

        public DirectoryPath ParentDirectoryPath
        {
            get
            {
                string parentPath = InternalStringHelper.GetParentDirectory(this.Path);
                if (this.IsRelativePath)
                    return new DirectoryPathRelative(parentPath);
                return new DirectoryPathAbsolute(parentPath);
            }
        }

        protected string DriveProtected
        {
            get
            {
                Debug.Assert(this.IsAbsolutePath);
                if (this.IsEmpty)
                    throw new InvalidOperationException("Cannot infer a drive from an empty path");

                return this.m_Path.Substring(0, 1);
            }
        }

        bool Equals(BasePath path)
        {
            Debug.Assert(path != null);

            if (path.IsEmpty)
                return this.IsEmpty;

            if (this.IsAbsolutePath != path.IsAbsolutePath)
                return false;

            // A FilePath could be equal to a DirectoryPath
            if (this.IsDirectoryPath != path.IsDirectoryPath)
                return false;

            return string.Compare(this.m_Path, path.m_Path, true) == 0;
        }

        public override bool Equals(object obj)
        {
            BasePath basePath = obj as BasePath;
            if (!BasePath.ReferenceEquals(basePath, null))
                return this.Equals(basePath);

            return false;
        }

        public static bool operator ==(BasePath path1, object path2)
        {
            if (BasePath.ReferenceEquals(path1, null))
                return BasePath.ReferenceEquals(path2, null);

            return path1.Equals(path2);
        }

        public static bool operator !=(BasePath path1, object path2)
        {
            return !(path1 == path2);
        }


        public override int GetHashCode()
        {
            return m_Path.ToLower().GetHashCode() +
               (this.IsAbsolutePath ? 1231 : 5677) +
               (this.IsFilePath ? 1457 : 3461);
        }

        protected static string GetPathRelative(DirectoryPathAbsolute pathFrom, BasePath pathTo)
        {
            Debug.Assert(pathTo.IsAbsolutePath);

            if (string.Compare(pathFrom.DriveProtected, pathTo.DriveProtected, true) != 0)
            {
                throw new ArgumentException(@"Cannot compute relative path from 2 paths that are not on the same drive 
PathFrom = """ + pathFrom.Path + @"""
PathTo   = """ + pathTo.Path + @"""");
            }

            if (pathTo.IsFilePath)
                pathTo = pathTo.ParentDirectoryPath;

            return InternalStringHelper.GetPathRelativeTo(pathFrom.Path, pathTo.Path);
        }

        protected static string GetAbsolutePathFrom(DirectoryPathAbsolute pathFrom, BasePath pathTo)
        {
            Debug.Assert(pathTo.IsRelativePath);

            if (pathTo.IsFilePath)
                pathTo = pathTo.ParentDirectoryPath;

            return InternalStringHelper.GetAbsolutePath(pathFrom.Path, pathTo.Path);
        }

    }

}
