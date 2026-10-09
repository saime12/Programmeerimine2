using System;
using System.Linq;

namespace KooliProjekt.Application.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Projects.Any())
            {
                return;
            }

            for (int i = 1; i <= 35; i++)
            {
                // USER
                var user = new User
                {
                    Name = $"Kasutaja {i}",
                    Email = $"kasutaja{i}@gmail.com",
                    Password = $"Parool{i}"
                };

                context.Users.Add(user);


                // WORKLOG
                var workLog = new WorkLog
                {
                    Date = DateTime.Now.AddDays(-i),
                    TimeSpent = 1 + (i % 8),
                    Description = $"Projekti arendustöö number {i}"
                };


                // FILE
                var projectFile = new ProjectFile
                {
                    FileName = $"dokument{i}.pdf",
                    FilePath = $"/files/dokument{i}.pdf",
                    UploadTime = DateTime.Now.AddDays(-i)
                };


                // TASK
                var task = new ProjectTask
                {
                    Title = $"Ülesanne {i}",
                    StartDate = DateTime.Now.AddDays(-i),
                    EstimatedTime = TimeSpan.FromHours(5 + i % 10),
                    Description = $"Projekti ülesanne number {i}",
                    IsCompleted = i % 2 == 0,
                    FixedPrice = i % 5 == 0 ? 200 + i * 10 : null
                };

                task.WorkLogs.Add(workLog);
                task.Files.Add(projectFile);


                // PROJECT
                var project = new Project
                {
                    ProjectName = $"Projekt {i}",
                    StartDate = DateTime.Now.AddDays(-i * 2),
                    DeadLine = DateTime.Now.AddDays(30 + i),
                    Budget = 2000 + i * 500,
                    HourlyRate = 20 + i
                };

                project.Tasks.Add(task);

                context.Projects.Add(project);
            }

            context.SaveChanges();
        }
    }
}