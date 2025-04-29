/*
I acknowledge the following statements:

1. That the code I provide below is my own work and NOT copied from any outside resource, which includes, but not limited to, an artificial intelligence program unless given explicit permission by the instructor.

2. That the code I provide below is my own work and NOT the work of my peers, tutors, or any other individual unless given explicit permission by the instructor.

3. That if the code below is in violation of statements 1 and 2 above, I may be reported to the Academic Integrity office and subject to penalties as described in the Academic Integrity Policy.

Your Name: Pappu Jha
Your Student ID: w10168315
*/


using Microsoft.Extensions.Logging;
using RestaurantAppFullImp.Project.Services;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using System.IO;

namespace RestaurantAppFullImp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // 📍 Step 1: Get DB Path
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "menu.db3");

            // 📍 Step 2: Create database service
            var databaseService = new DatabaseService(dbPath);

            // 📍 Step 3: Seed the database (insert menu items if empty)
            databaseService.SeedDataAsync().Wait();  // ✅ THIS IS CRITICAL

            // 📍 Step 4: Add to Dependency Injection
            builder.Services.AddSingleton(databaseService);

            return builder.Build();
        }
    }
}
