namespace WinFormsApp1;

public partial class Form1 : Form
{
    public Form1()
    {

        InitializeComponent();
    }

    private void configuration_Button_Click(object sender, EventArgs e)
    {
        DialogForm DialogForm = new DialogForm();
        if (DialogForm.ShowDialog(this) == DialogResult.OK)
        {
            DialogForm.Text = "hey";
        }
        else
        {
            DialogForm.Text = "Cancelled";
        }

    }

    private void TimeButton_Click(object sender, EventArgs e)
    {

    }

    private void DateButton_Click(object sender, EventArgs e)
    {

    }

    private void AllButton_Click(object sender, EventArgs e)
    {

    }

    private void CloseButton_Click(object sender, EventArgs e)
    {

    }
}