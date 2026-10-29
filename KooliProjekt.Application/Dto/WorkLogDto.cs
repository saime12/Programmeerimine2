using System;
namespace KooliProjekt.Application.Dto
{
    public class WorkLogDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double TimeSpent { get; set; }
        public string Description { get; set; }
    }
}
