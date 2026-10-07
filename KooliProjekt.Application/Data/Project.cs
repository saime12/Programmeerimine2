using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KooliProjekt.Application.Data
{
    public class Project
    {
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProjectName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime DeadLine { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Budget { get; set; }

        [Range(0, double.MaxValue)]
        public decimal HourlyRate { get; set; }

        public List<ProjectTask> Tasks { get; set; } = new();
    }
}
