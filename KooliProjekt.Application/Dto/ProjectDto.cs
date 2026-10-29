using System;
namespace KooliProjekt.Application.Dto
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeadLine { get; set; }
        public decimal Budget { get; set; }
        public decimal HourlyRate { get; set; }
    }
}
