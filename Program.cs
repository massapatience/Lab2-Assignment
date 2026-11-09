namespace Lab2BicycleMushroom;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Nav.Login = new LoginForm();
        Application.Run(Nav.Login);
    }
}

/// <summary>Keeps track of the forms so we can move between them (Login -> Choose -> Bicycle/Mushroom).</summary>
static class Nav
{
    public static LoginForm Login;
    public static ChooseForm Choose;
    public static bool Switching;   // true while we are moving between forms on purpose

    // Closing a form with the X button ends the whole program, unless we are just navigating.
    public static void Track(Form f) =>
        f.FormClosed += (s, e) => { if (!Switching) Application.Exit(); };

    public static void Logout(Form current)
    {
        Switching = true;
        Choose?.Close();
        Login.ResetFields();
        Login.Show();
        current.Close();
        Switching = false;
    }

    public static void BackToChoose(Form current)
    {
        Switching = true;
        Choose.Show();
        current.Close();
        Switching = false;
    }
}
