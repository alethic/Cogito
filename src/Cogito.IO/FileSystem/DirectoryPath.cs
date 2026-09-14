namespace Cogito.IO.FileSystem
{

    public abstract class DirectoryPath : BasePath
    {

        protected DirectoryPath()
        {
        }

        protected DirectoryPath(string path, bool isAbsolute)
            : base(path, isAbsolute)
        {

        }

        public override bool IsDirectoryPath
        {
            get { return true; }
        }

        public override bool IsFilePath
        {
            get { return false; }
        }

        public string DirectoryName
        {
            get { return InternalStringHelper.GetLastName(this.Path); }
        }

        public bool HasParentDir
        {
            get { return InternalStringHelper.HasParentDir(this.Path); }
        }

    }

}
