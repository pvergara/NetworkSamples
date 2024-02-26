using System.ComponentModel;

namespace NetworkingExercise2Client;

partial class Form1
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        ServerIp = new TextBox();
        ServerPort = new TextBox();
        UserName = new TextBox();
        ResultText = new TextBox();
        AddAction = new Button();
        ListAction = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(23, 28);
        label1.Name = "label1";
        label1.Size = new Size(63, 19);
        label1.TabIndex = 0;
        label1.Text = "Server IP";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(23, 60);
        label2.Name = "label2";
        label2.Size = new Size(76, 19);
        label2.TabIndex = 1;
        label2.Text = "Server Port";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(23, 89);
        label3.Name = "label3";
        label3.Size = new Size(71, 19);
        label3.TabIndex = 2;
        label3.Text = "Username";
        // 
        // ServerIp
        // 
        ServerIp.Location = new Point(111, 21);
        ServerIp.Name = "ServerIp";
        ServerIp.Size = new Size(165, 26);
        ServerIp.TabIndex = 3;
        ServerIp.Text = "127.0.0.1";
        // 
        // ServerPort
        // 
        ServerPort.Location = new Point(111, 53);
        ServerPort.Name = "ServerPort";
        ServerPort.Size = new Size(75, 26);
        ServerPort.TabIndex = 4;
        ServerPort.Text = "31416";
        // 
        // UserName
        // 
        UserName.Location = new Point(111, 86);
        UserName.Name = "UserName";
        UserName.Size = new Size(165, 26);
        UserName.TabIndex = 5;
        UserName.Text = "Terry";
        // 
        // ResultText
        // 
        ResultText.Enabled = false;
        ResultText.Location = new Point(364, 21);
        ResultText.Multiline = true;
        ResultText.Name = "ResultText";
        ResultText.Size = new Size(266, 91);
        ResultText.TabIndex = 6;
        // 
        // AddAction
        // 
        AddAction.Location = new Point(24, 137);
        AddAction.Name = "AddAction";
        AddAction.Size = new Size(75, 23);
        AddAction.TabIndex = 7;
        AddAction.Text = "Add";
        AddAction.UseVisualStyleBackColor = true;
        AddAction.Click += button1_Click;
        // 
        // ListAction
        // 
        ListAction.Location = new Point(24, 166);
        ListAction.Name = "ListAction";
        ListAction.Size = new Size(75, 23);
        ListAction.TabIndex = 8;
        ListAction.Text = "List";
        ListAction.UseVisualStyleBackColor = true;
        ListAction.Click += button2_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 19F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(ListAction);
        Controls.Add(AddAction);
        Controls.Add(ResultText);
        Controls.Add(UserName);
        Controls.Add(ServerPort);
        Controls.Add(ServerIp);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Label label2;
    private Label label3;
    private TextBox ServerIp;
    private TextBox ServerPort;
    private TextBox UserName;
    private TextBox ResultText;
    private Button AddAction;
    private Button ListAction;
}