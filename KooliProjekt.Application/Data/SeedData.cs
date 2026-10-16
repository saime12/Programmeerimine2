using System;
using System.Linq;

namespace KooliProjekt.Application.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // USERS
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Name = "Test User",
                    Email = "test@test.ee",
                    Password = "Test123!"
                });
            }

            // PROJECTS
            if (!context.Projects.Any())
            {
                context.Projects.Add(new Project
                {
                    ProjectName = "Test Project",
                    StartDate = DateTime.Now,
                    DeadLine = DateTime.Now.AddMonths(1),
                    Budget = 5000,
                    HourlyRate = 25
                });
            }


            // WORK LOGS
            if (!context.WorkLogs.Any())
                {
                context.WorkLogs.Add(new WorkLog
                {
                    Date = DateTime.Now,
                    TimeSpent = 2.5,
                    Description = "Worked on test project"
                });
            }

            // PROJECT FILES
            if (!context.ProjectFiles.Any())
                {
                context.ProjectFiles.Add(new ProjectFile
                {
                    FileName = "test.txt",
                    FilePath = "files/test.txt",
                    UploadTime = DateTime.Now
                });
            }

            context.SaveChanges();
        }
    }
}