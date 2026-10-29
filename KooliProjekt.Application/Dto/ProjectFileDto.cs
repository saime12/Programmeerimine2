using System;
namespace KooliProjekt.Application.Dto
{
    public class ProjectFileDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadTime { get; set; }
    }
}
