using System;
namespace KooliProjekt.Application.Dto
{
    public class ProjectTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan EstimatedTime { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public decimal? FixedPrice { get; set; }
    }
}
