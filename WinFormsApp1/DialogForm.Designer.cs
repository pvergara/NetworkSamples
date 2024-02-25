namespace WinFormsApp1
{
    partial class DialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            IP_Textbox = new TextBox();
            port_Textbox = new TextBox();
            confirm_Button = new Button();
            SuspendLayout();
            // 
            // IP_Textbox
            // 
            IP_Textbox.Location = new Point(55, 65);
            IP_Textbox.Name = "IP_Textbox";
            IP_Textbox.PlaceholderText = "IP";
            IP_Textbox.Size = new Size(100, 26);
            IP_Textbox.TabIndex = 0;
            // 
            // port_Textbox
            // 
            port_Textbox.Location = new Point(199, 65);
            port_Textbox.Name = "port_Textbox";
            port_Textbox.PlaceholderText = "Port";
            port_Textbox.Size = new Size(100, 26);
            port_Textbox.TabIndex = 1;
            // 
            // confirm_Button
            // 
            confirm_Button.Location = new Point(137, 131);
            confirm_Button.Name = "confirm_Button";
            confirm_Button.Size = new Size(75, 23);
            confirm_Button.TabIndex = 2;
            confirm_Button.Text = "Confirm";
            confirm_Button.UseVisualStyleBackColor = true;
            confirm_Button.Click += confirm_Button_Click;
            // 
            // DialogForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 263);
            Controls.Add(confirm_Button);
            Controls.Add(port_Textbox);
            Controls.Add(IP_Textbox);
            Name = "DialogForm";
            Text = "DialogForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox IP_Textbox;
        private TextBox port_Textbox;
        private Button confirm_Button;
    }
}