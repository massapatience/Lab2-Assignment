namespace Lab2BicycleMushroom;

public class MushroomForm : Form
{
    private readonly RadioButton forestYes, forestNo, cupYes, cupNo, ringYes, ringNo, whiteYes, whiteNo;

    public MushroomForm()
    {
        Text = "Mushroom Identifier";
        ClientSize = new Size(440, 470);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        var title = new Label { Text = "Mushroom", Font = new Font("Segoe UI", 16, FontStyle.Bold), Left = 160, Top = 10, AutoSize = true };

        var g1 = MakeQuestion("1. Does it grow in a forest?", 50, out forestYes, out forestNo);
        var g2 = MakeQuestion("2. (Forest) Is the mushroom cup-shaped?", 115, out cupYes, out cupNo);
        var g3 = MakeQuestion("3. (Forest + cup) Does it have a ring on the stem?", 180, out ringYes, out ringNo);
        var g4 = MakeQuestion("4. (Not forest) Is the cap white?", 245, out whiteYes, out whiteNo);

        var btnId = new Button { Text = "Identify", Left = 170, Top = 320, Width = 100, Height = 32 };
        btnId.Click += BtnIdentify_Click;
        AcceptButton = btnId;

        var note = new Label
        {
            Left = 20, Top = 365, Width = 400, Height = 35,
            Text = "For classroom use only. Never eat a wild mushroom based on this program."
        };

        var btnBack = new Button { Text = "Back", Left = 20, Top = 420, Width = 90, Height = 30 };
        var btnLogout = new Button { Text = "Logout", Left = 330, Top = 420, Width = 90, Height = 30 };
        btnBack.Click += (s, e) => Nav.BackToChoose(this);
        btnLogout.Click += (s, e) => Nav.Logout(this);

        Controls.AddRange(new Control[] { title, g1, g2, g3, g4, btnId, note, btnBack, btnLogout });
    }

    // Radio buttons inside a GroupBox: only one answer can be picked per question
    private static GroupBox MakeQuestion(string text, int top, out RadioButton yes, out RadioButton no)
    {
        var g = new GroupBox { Text = text, Left = 20, Top = top, Width = 400, Height = 55 };
        yes = new RadioButton { Text = "Yes", Left = 20, Top = 22, AutoSize = true };
        no = new RadioButton { Text = "No", Left = 110, Top = 22, AutoSize = true };
        g.Controls.Add(yes);
        g.Controls.Add(no);
        return g;
    }

    private void BtnIdentify_Click(object sender, EventArgs e)
    {
        string result;

        if (!forestYes.Checked && !forestNo.Checked)
        {
            Warn("Please answer question 1.");
            return;
        }

        if (forestYes.Checked)
        {
            if (!cupYes.Checked && !cupNo.Checked) { Warn("Please answer question 2."); return; }

            if (cupYes.Checked)
            {
                if (!ringYes.Checked && !ringNo.Checked) { Warn("Please answer question 3."); return; }
                result = ringYes.Checked
                    ? "Death Cap (Amanita phalloides)\n\nDEADLY POISONOUS - do not eat!"
                    : "Volvaria (Volvopluteus gloiocephalus)\n\nEdible when young.";
            }
            else
            {
                result = "Chanterelle (Cantharellus cibarius)\n\nEdible and delicious.";
            }
        }
        else
        {
            if (!whiteYes.Checked && !whiteNo.Checked) { Warn("Please answer question 4."); return; }
            result = whiteYes.Checked
                ? "Field Mushroom (Agaricus campestris)\n\nEdible."
                : "Fairy Ring Champignon (Marasmius oreades)\n\nEdible, but check carefully.";
        }

        MessageBox.Show(result, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        ClearAnswers();
    }

    private void Warn(string msg) =>
        MessageBox.Show(msg, "Missing answer", MessageBoxButtons.OK, MessageBoxIcon.Warning);

    private void ClearAnswers()
    {
        foreach (var r in new[] { forestYes, forestNo, cupYes, cupNo, ringYes, ringNo, whiteYes, whiteNo })
            r.Checked = false;
    }
}
