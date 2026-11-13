
using System.IO;
using System.Threading.Tasks;

namespace KooliProjekt.Application.Infrastructure.Files
{
    public class LocalFileClient : IFileClient
    {
        private readonly string _filesRoot;

        public LocalFileClient(string filesRoot)
        {
            _filesRoot = filesRoot;
        }

        public async Task Save(
            string fileName,
            string fileStore,
            Stream inputStream)
        {
            var folder = Path.Combine(_filesRoot, fileStore);

            Directory.CreateDirectory(folder);

            var filePath = Path.Combine(folder, fileName);

            using (var outputStream = new FileStream(
                filePath,
                FileMode.Create))
            {
                await inputStream.CopyToAsync(outputStream);
            }
        }

        public Task Delete(string filePath)
        {
            var fullPath = Path.Combine(_filesRoot, filePath);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            return Task.CompletedTask;
        }
    }
}
