using System.IO;

namespace $safeprojectname$
{
    public class FileService : IFileService
    {
        private readonly IPathAccessor pathAccessor;

        public FileService(IPathAccessor pathAccessor)
        {
            this.pathAccessor = pathAccessor;
        }

        public bool FileExist(string filePath)
        {
            string fullPath = GetFullPath(filePath);

            return File.Exists(fullPath);
        }

        public string ReadFile(string filePath)
        {
            string fullPath = GetFullPath(filePath);

            return File.ReadAllText(fullPath);
        }

        public void AddFile(string filePath, string fileContent)
        {
            string fullPath = GetFullPath(filePath);

            string directoryPath = new FileInfo(fullPath).Directory.FullName;

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            using (StreamWriter sw = File.CreateText(fullPath))
            {
                sw.Write(fileContent);
            }
        }

        public void DeleteFile(string filePath)
        {
            string fullPath = GetFullPath(filePath);

            File.Delete(fullPath);
        }

        private string GetFullPath(string filePath)
        {
            var path = pathAccessor.GetFilePath();
            return Path.Combine(path, filePath);
        }
    }
}
