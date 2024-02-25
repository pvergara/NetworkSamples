namespace WinFormsApp1;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        TimeButton = new Button();
        DateButton = new Button();
        AllButton = new Button();
        CloseButton = new Button();
        PasswordTextBox = new TextBox();
        ResultLabel = new Label();
        colorDialog1 = new ColorDialog();
        ConfigurationButton = new Button();
        SuspendLayout();
        // 
        // TimeButton
        // 
        TimeButton.Location = new Point(12, 12);
        TimeButton.Name = "TimeButton";
        TimeButton.Size = new Size(75, 23);
        TimeButton.TabIndex = 0;
        TimeButton.Text = "Time";
        TimeButton.UseVisualStyleBackColor = true;
        TimeButton.Click += TimeButton_Click;
        // 
        // DateButton
        // 
        DateButton.Location = new Point(12, 41);
        DateButton.Name = "DateButton";
        DateButton.Size = new Size(75, 23);
        DateButton.TabIndex = 1;
        DateButton.Text = "Date";
        DateButton.UseVisualStyleBackColor = true;
        DateButton.Click += DateButton_Click;
        // 
        // AllButton
        // 
        AllButton.Location = new Point(12, 70);
        AllButton.Name = "AllButton";
        AllButton.Size = new Size(75, 23);
        AllButton.TabIndex = 3;
        AllButton.Text = "All";
        AllButton.UseVisualStyleBackColor = true;
        AllButton.Click += AllButton_Click;
        // 
        // CloseButton
        // 
        CloseButton.Location = new Point(12, 99);
        CloseButton.Name = "CloseButton";
        CloseButton.Size = new Size(75, 23);
        CloseButton.TabIndex = 2;
        CloseButton.Text = "Close";
        CloseButton.UseVisualStyleBackColor = true;
        CloseButton.Click += CloseButton_Click;
        // 
        // PasswordTextBox
        // 
        PasswordTextBox.Location = new Point(93, 96);
        PasswordTextBox.Name = "PasswordTextBox";
        PasswordTextBox.PlaceholderText = "Password";
        PasswordTextBox.Size = new Size(142, 26);
        PasswordTextBox.TabIndex = 4;
        // 
        // ResultLabel
        // 
        ResultLabel.AutoSize = true;
        ResultLabel.Location = new Point(318, 96);
        ResultLabel.Name = "ResultLabel";
        ResultLabel.Size = new Size(77, 19);
        ResultLabel.TabIndex = 5;
        ResultLabel.Text = "Result data";
        // 
        // ConfigurationButton
        // 
        ConfigurationButton.BackColor = SystemColors.ActiveCaptionText;
        ConfigurationButton.ForeColor = SystemColors.ButtonHighlight;
        ConfigurationButton.Location = new Point(12, 366);
        ConfigurationButton.Name = "ConfigurationButton";
        ConfigurationButton.Size = new Size(123, 72);
        ConfigurationButton.TabIndex = 6;
        ConfigurationButton.Text = "Configuration";
        ConfigurationButton.UseVisualStyleBackColor = false;
        ConfigurationButton.Click += configuration_Button_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(ConfigurationButton);
        Controls.Add(ResultLabel);
        Controls.Add(PasswordTextBox);
        Controls.Add(AllButton);
        Controls.Add(CloseButton);
        Controls.Add(DateButton);
        Controls.Add(TimeButton);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button time_Button;
    private Button date_Button;
    private Button all_Button;
    private Button close_Button;
    private TextBox password_TextBox;
    private Label passwordCheck_Label;
    private ColorDialog colorDialog1;
    private Button configuration_Button;
    private Button TimeButton;
    private Button DateButton;
    private Button AllButton;
    private Button CloseButton;
    private TextBox PasswordTextBox;
    private Label ResultLabel;
    private Button ConfigurationButton;
}