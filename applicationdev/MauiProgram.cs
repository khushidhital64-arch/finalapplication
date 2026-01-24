using applicationdev.DbContextDirectory;
using applicationdev.RepositoryDirectory;
using applicationdev.ServicesDirectory;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;
namespace applicationdev;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "MyJournalApp.db");
        builder.Services.AddDbContext<JournalAppDbContext>(options =>
            options.UseSqlite($"Data Source={dbPath}")
        );

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
        // Repositories
        builder.Services.AddScoped<IMoodRepository, MoodRepository>();
        builder.Services.AddScoped<IJournalRepository, JournalRepository>();
        builder.Services.AddScoped<ITagRepository, TagRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

// Services
        builder.Services.AddScoped<IMoodService, MoodService>();
        builder.Services.AddScoped<IJournalService, JournalService>();
        builder.Services.AddScoped<ITagService, TagService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddSingleton<IStoreUserService, StoreUserService>();
        builder.Services.AddScoped<ThemeService>(); 

#endif

        var app = builder.Build();
 
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<JournalAppDbContext>();
            //db.Database.EnsureDeleted();  
            db.Database.EnsureCreated(); 
      
        }

        return app;

    }
}