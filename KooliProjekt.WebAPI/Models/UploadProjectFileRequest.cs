
using Microsoft.AspNetCore.Http;

namespace KooliProjekt.WebAPI.Models
{
    public class UploadProjectFileRequest
    {
        public int ProjectTaskId { get; set; }
        public IFormFile File { get; set; }
    }
}
