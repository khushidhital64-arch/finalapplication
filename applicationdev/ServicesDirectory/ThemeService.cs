namespace applicationdev.ServicesDirectory;

public class ThemeService
{
    public string CurrentTheme { get; private set; } = "light";

    public void ToggleTheme()
    {
        CurrentTheme = CurrentTheme == "light" ? "dark" : "light";
    }

    public void SetTheme(string theme)
    {
        if (theme == "light" || theme == "dark")
        {
            CurrentTheme = theme;
        }
    }
}