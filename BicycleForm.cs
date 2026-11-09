namespace Lab2BicycleMushroom;

public class BicycleForm : Form
{
    // ---- Rates (RWF per hour). Change these numbers to match your lab sheet. ----
    private const int RateNight   = 500;   // 00:00 - 06:00
    private const int RateDay     = 1000;  // 06:00 - 18:00
    private const int RateEvening = 1500;  // 18:00 - 24:00

    private readonly TextBox txtStart = new() { Left = 150, Top = 60, Width = 100 };
    private readonly TextBox txtEnd   = new() { Left = 150, Top = 100, Width = 100 };
    private readonly TextBox txtTotal = new() { Left = 150, Top = 195, Width = 150, ReadOnly = true };

    public BicycleForm()
    {
        Text = "Bicycle Rental";
        ClientSize = new Size(400, 320);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        var title = new Label { Text = "Bicycle", Font = new Font("Segoe UI", 16, FontStyle.Bold), Left = 150, Top = 12, AutoSize = true };
        var l1 = new Label { Text = "Start hour (0-23):", Left = 20, Top = 63, AutoSize = true };
        var l2 = new Label { Text = "End hour (1-24):", Left = 20, Top = 103, AutoSize = true };
        var lTotal = new Label { Text = "Total (RWF):", Left = 20, Top = 198, AutoSize = true };
        var rates = new Label
        {
            Left = 20, Top = 135, AutoSize = true,
            Text = $"Rates: 00-06h = {RateNight}, 06-18h = {RateDay}, 18-24h = {RateEvening} per hour"
        };

        var btnCalc = new Button { Text = "Calculate", Left = 150, Top = 150, Width = 100, Height = 30 };
        btnCalc.Top = 160;
        rates.Top = 130;
        btnCalc.Click += BtnCalc_Click;
        AcceptButton = btnCalc;

        var btnBack = new Button { Text = "Back", Left = 20, Top = 260, Width = 90, Height = 30 };
        var btnLogout = new Button { Text = "Logout", Left = 290, Top = 260, Width = 90, Height = 30 };
        btnBack.Click += (s, e) => Nav.BackToChoose(this);
        btnLogout.Click += (s, e) => Nav.Logout(this);

        Controls.AddRange(new Control[] { title, l1, txtStart, l2, txtEnd, rates, btnCalc, lTotal, txtTotal, btnBack, btnLogout });
    }

    private void BtnCalc_Click(object sender, EventArgs e)
    {
        // Validation 1: must be whole numbers (TryParse avoids a crash on letters)
        if (!int.TryParse(txtStart.Text, out int start) || !int.TryParse(txtEnd.Text, out int end))
        {
            MessageBox.Show("Please enter whole numbers only.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtStart.Focus();
            return;
        }
        // Validation 2: ranges
        if (start < 0 || start > 23 || end < 1 || end > 24)
        {
            MessageBox.Show("Start must be 0-23 and End must be 1-24.", "Invalid range", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (end <= start)
        {
            MessageBox.Show("End hour must be later than the start hour.", "Invalid range", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Add up the rate of every hour that is rented
        int total = 0;
        int hour = start;
        while (hour < end)
        {
            total += RateForHour(hour);
            hour++;
        }

        txtTotal.Text = total.ToString("N0");
        MessageBox.Show($"Rented {end - start} hour(s) ({start}:00 to {end}:00).\nTotal to pay: {total:N0} RWF",
            "Rental total", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private static int RateForHour(int hour)
    {
        if (hour < 6) return RateNight;
        if (hour < 18) return RateDay;
        return RateEvening;
    }
}
