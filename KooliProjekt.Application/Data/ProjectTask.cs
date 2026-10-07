using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KooliProjekt.Application.Data
{
    public class ProjectTask
    {
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public TimeSpan EstimatedTime { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? FixedPrice { get; set; }

        public List<WorkLog> WorkLogs { get; set; } = new();

        public List<ProjectFile> Files { get; set; } = new();
    }
}
