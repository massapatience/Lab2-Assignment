namespace Lab2BicycleMushroom;

public class LoginForm : Form
{
    // Admin credentials
    private const string AdminUser = "Massa";
    private const string AdminPass = "123@";

    private readonly TextBox txtUser = new() { Left = 130, Top = 60, Width = 180 };
    private readonly TextBox txtPass = new() { Left = 130, Top = 100, Width = 180, UseSystemPasswordChar = true };

    public LoginForm()
    {
        Text = "Login";
        ClientSize = new Size(360, 220);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        var title = new Label { Text = "Login", Font = new Font("Segoe UI", 16, FontStyle.Bold), Left = 130, Top = 15, AutoSize = true };
        var lblUser = new Label { Text = "Username:", Left = 40, Top = 63, AutoSize = true };
        var lblPass = new Label { Text = "Password:", Left = 40, Top = 103, AutoSize = true };
        var btn = new Button { Text = "Login", Left = 130, Top = 150, Width = 100, Height = 32 };
        btn.Click += BtnLogin_Click;
        AcceptButton = btn;

        Controls.AddRange(new Control[] { title, lblUser, txtUser, lblPass, txtPass, btn });
    }

    private void BtnLogin_Click(object sender, EventArgs e)
    {
        // Validation: neither field may be empty
        if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
        {
            MessageBox.Show("Please enter both username and password.", "Login error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtUser.Focus();
            return;
        }

        // Validation: credentials must match the admin account
        if (txtUser.Text.Trim() != AdminUser || txtPass.Text != AdminPass)
        {
            MessageBox.Show("Incorrect username or password.", "Login failed",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtPass.Clear();
            txtUser.Focus();
            return;
        }

        Nav.Choose = new ChooseForm();
        Nav.Track(Nav.Choose);
        Hide();
        Nav.Choose.Show();
    }

    public void ResetFields()
    {
        txtUser.Clear();
        txtPass.Clear();
        txtUser.Focus();
    }
}
