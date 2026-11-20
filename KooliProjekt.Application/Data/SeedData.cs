using KooliProjekt.Application.Authentication;
using System;
using System.Linq;

namespace KooliProjekt.Application.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // USERS
            if (!context.Users.Any(u => u.Email == "admin@test.ee"))
            {
                context.Users.Add(new User
                {
                    Name = "Admin User",
                    Email = "admin@test.ee",
                    Password = PasswordHelper.Hash("Admin123!"),
                    IsAdmin = true
                });
            }

            if (!context.Users.Any(u => u.Email == "user@test.ee"))
            {
                context.Users.Add(new User
                {
                    Name = "Normal User",
                    Email = "user@test.ee",
                    Password = PasswordHelper.Hash("User123!"),
                    IsAdmin = false
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