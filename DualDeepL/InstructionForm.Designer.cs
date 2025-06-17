using DualDeepL.Utils;

namespace DualDeepL
{
    partial class InstructionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructionForm));
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            textbox_instruct = new RichTextBox();
            panel2 = new Panel();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = ModernTheme.Colors.CardBackground;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 345);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(ModernTheme.Spacing.Medium);
            panel1.Size = new Size(547, 54);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = ModernTheme.Colors.Border;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = ModernTheme.Fonts.ButtonFont;
            button2.ForeColor = ModernTheme.Colors.PrimaryText;
            button2.Location = new Point(444, 15);
            button2.Name = "button2";
            button2.Size = new Size(91, ModernTheme.Styling.ButtonHeight);
            button2.TabIndex = 12;
            button2.Text = "キャンセル";
            button2.UseVisualStyleBackColor = false;
            button2.Click += Button2_Click;
            // 
            // button1
            // 
            button1.BackColor = ModernTheme.Colors.IndigoMain;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = ModernTheme.Fonts.ButtonFont;
            button1.ForeColor = ModernTheme.Colors.PrimaryText;
            button1.Location = new Point(348, 15);
            button1.Name = "button1";
            button1.Size = new Size(91, ModernTheme.Styling.ButtonHeight);
            button1.TabIndex = 11;
            button1.Text = "保存";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // textbox_instruct
            // 
            textbox_instruct.BackColor = ModernTheme.Colors.InputBackground;
            textbox_instruct.BorderStyle = BorderStyle.None;
            textbox_instruct.Dock = DockStyle.Fill;
            textbox_instruct.Font = ModernTheme.Fonts.PrimaryFont;
            textbox_instruct.ForeColor = ModernTheme.Colors.PrimaryText;
            textbox_instruct.Location = new Point(0, 44);
            textbox_instruct.Margin = new Padding(3, 2, 3, 2);
            textbox_instruct.Name = "textbox_instruct";
            textbox_instruct.Size = new Size(547, 301);
            textbox_instruct.TabIndex = 0;
            textbox_instruct.Text = "";
            // 
            // panel2
            // 
            panel2.BackColor = ModernTheme.Colors.CardBackground;
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(ModernTheme.Spacing.Medium);
            panel2.Size = new Size(547, 44);
            panel2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = ModernTheme.Fonts.HeaderFont;
            label2.ForeColor = ModernTheme.Colors.PrimaryText;
            label2.Location = new Point(ModernTheme.Spacing.Medium, ModernTheme.Spacing.Medium);
            label2.Name = "label2";
            label2.Padding = new Padding(ModernTheme.Spacing.Medium);
            label2.Size = new Size(88, 33);
            label2.TabIndex = 16;
            label2.Text = "翻訳指示";
            // 
            // InstructionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ModernTheme.Colors.DarkBackground;
            ClientSize = new Size(547, 399);
            Controls.Add(textbox_instruct);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InstructionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Dual DeepL Translater";
            Load += InstructionForm_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private RichTextBox textbox_instruct;
        private Button button2;
        private Button button1;
        private Panel panel2;
        private Label label2;
    }
}