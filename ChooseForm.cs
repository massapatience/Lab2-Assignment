namespace Lab2BicycleMushroom;

public class ChooseForm : Form
{
    public ChooseForm()
    {
        Text = "Choose";
        ClientSize = new Size(360, 200);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        var title = new Label { Text = "Choose", Font = new Font("Segoe UI", 16, FontStyle.Bold), Left = 135, Top = 15, AutoSize = true };
        var btnBike = new Button { Text = "Bicycle", Left = 50, Top = 70, Width = 110, Height = 40 };
        var btnMush = new Button { Text = "Mushroom", Left = 200, Top = 70, Width = 110, Height = 40 };
        var btnLogout = new Button { Text = "Logout", Left = 125, Top = 135, Width = 110, Height = 30 };

        btnBike.Click += (s, e) => OpenChild(new BicycleForm());
        btnMush.Click += (s, e) => OpenChild(new MushroomForm());
        btnLogout.Click += (s, e) => Nav.Logout(this);

        Controls.AddRange(new Control[] { title, btnBike, btnMush, btnLogout });
    }

    private void OpenChild(Form child)
    {
        Nav.Track(child);
        Hide();
        child.Show();
    }
}
