using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KooliProjekt.Application.Data
{
    public class WorkLog
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Range(0, double.MaxValue)]
        public double TimeSpent { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
