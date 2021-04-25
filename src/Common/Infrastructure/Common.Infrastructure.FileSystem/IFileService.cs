namespace $safeprojectname$
{
    public interface IFileService
    {
        bool FileExist(string filePath);

        string ReadFile(string filePath);

        void AddFile(string filePath, string content);

        void DeleteFile(string filePath);
    }
}
