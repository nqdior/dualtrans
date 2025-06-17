using DualDeepL.Utils;

namespace DualDeepL
{
    partial class MainForm
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
                if (components != null) components.Dispose();
                UnhookWindowsHookEx(hookId);
                trayIcon.Dispose();
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel_top = new Panel();
            checkBox1 = new CheckBox();
            titlePicture = new PictureBox();
            label_orig = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            textbox_re_second = new RichTextBox();
            textbox_second = new RichTextBox();
            label_second_arrow = new Label();
            combo_first = new ComboBox();
            label_first = new Label();
            label_second = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            textbox_re_first = new RichTextBox();
            textbox_first = new RichTextBox();
            label_first_arrow = new Label();
            combo_second = new ComboBox();
            textbox_orig = new RichTextBox();
            combo_orig = new ComboBox();
            panel1 = new Panel();
            panel_second_top = new Panel();
            button2 = new Button();
            panel_first_top = new Panel();
            button1 = new Button();
            panel_orig_top = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            trayIcon = new NotifyIcon(components);
            panel_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)titlePicture).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            panel_second_top.SuspendLayout();
            panel_first_top.SuspendLayout();
            panel_orig_top.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel_top
            // 
            panel_top.BackColor = ModernTheme.Colors.DarkBackground;
            panel_top.Controls.Add(checkBox1);
            panel_top.Controls.Add(titlePicture);
            panel_top.Dock = DockStyle.Top;
            panel_top.Location = new Point(0, 0);
            panel_top.Margin = new Padding(3, 2, 3, 2);
            panel_top.Name = "panel_top";
            panel_top.Padding = new Padding(ModernTheme.Spacing.Large, ModernTheme.Spacing.Medium, ModernTheme.Spacing.Large, ModernTheme.Spacing.Small);
            panel_top.Size = new Size(1061, 48);
            panel_top.TabIndex = 9;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Font = ModernTheme.Fonts.PrimaryFont;
            checkBox1.ForeColor = ModernTheme.Colors.PrimaryText;
            checkBox1.Location = new Point(878, 16);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(174, 23);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "最前面に表示";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            // 
            // titlePicture
            // 
            titlePicture.Dock = DockStyle.Left;
            titlePicture.Image = (Image)resources.GetObject("titlePicture.Image");
            titlePicture.Location = new Point(ModernTheme.Spacing.Large, ModernTheme.Spacing.Medium);
            titlePicture.Name = "titlePicture";
            titlePicture.Size = new Size(162, 35);
            titlePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            titlePicture.TabIndex = 0;
            titlePicture.TabStop = false;
            // 
            // label_orig
            // 
            label_orig.AutoSize = true;
            label_orig.Dock = DockStyle.Left;
            label_orig.Font = ModernTheme.Fonts.HeaderFont;
            label_orig.ForeColor = ModernTheme.Colors.PrimaryText;
            label_orig.Location = new Point(0, ModernTheme.Spacing.Medium);
            label_orig.Name = "label_orig";
            label_orig.Padding = new Padding(ModernTheme.Spacing.Medium);
            label_orig.Size = new Size(75, 33);
            label_orig.TabIndex = 8;
            label_orig.Text = "原文";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = ModernTheme.Colors.CardBackground;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(textbox_re_second, 0, 2);
            tableLayoutPanel3.Controls.Add(textbox_second, 0, 0);
            tableLayoutPanel3.Controls.Add(label_second_arrow, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(712, 78);
            tableLayoutPanel3.Margin = new Padding(ModernTheme.Spacing.Small);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.Padding = new Padding(ModernTheme.Spacing.Medium);
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(346, 534);
            tableLayoutPanel3.TabIndex = 18;
            // 
            // textbox_re_second
            // 
            textbox_re_second.BackColor = ModernTheme.Colors.InputBackground;
            textbox_re_second.BorderStyle = BorderStyle.None;
            textbox_re_second.Dock = DockStyle.Fill;
            textbox_re_second.Font = ModernTheme.Fonts.PrimaryFont;
            textbox_re_second.ForeColor = ModernTheme.Colors.PrimaryText;
            textbox_re_second.Location = new Point(ModernTheme.Spacing.Medium + 3, 279);
            textbox_re_second.Margin = new Padding(3, 2, 3, 2);
            textbox_re_second.Name = "textbox_re_second";
            textbox_re_second.ReadOnly = true;
            textbox_re_second.Size = new Size(322, 241);
            textbox_re_second.TabIndex = 4;
            textbox_re_second.Text = "";
            // 
            // textbox_second
            // 
            textbox_second.BackColor = ModernTheme.Colors.InputBackground;
            textbox_second.BorderStyle = BorderStyle.None;
            textbox_second.Dock = DockStyle.Fill;
            textbox_second.Font = ModernTheme.Fonts.PrimaryFont;
            textbox_second.ForeColor = ModernTheme.Colors.PrimaryText;
            textbox_second.Location = new Point(ModernTheme.Spacing.Medium + 3, ModernTheme.Spacing.Medium + 3);
            textbox_second.Margin = new Padding(3, 2, 3, 2);
            textbox_second.Name = "textbox_second";
            textbox_second.Size = new Size(322, 241);
            textbox_second.TabIndex = 2;
            textbox_second.Text = "";
            textbox_second.TextChanged += Second_textbox_TextChanged;
            // 
            // label_second_arrow
            // 
            label_second_arrow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label_second_arrow.AutoSize = true;
            label_second_arrow.BackColor = ModernTheme.Colors.EmeraldAccent;
            label_second_arrow.Font = ModernTheme.Fonts.ButtonFont;
            label_second_arrow.ForeColor = ModernTheme.Colors.PrimaryText;
            label_second_arrow.Location = new Point(ModernTheme.Spacing.Medium + 3, 251);
            label_second_arrow.Margin = new Padding(3, ModernTheme.Spacing.Small, 3, ModernTheme.Spacing.Small);
            label_second_arrow.Name = "label_second_arrow";
            label_second_arrow.Padding = new Padding(ModernTheme.Spacing.Small);
            label_second_arrow.Size = new Size(322, 16);
            label_second_arrow.TabIndex = 6;
            label_second_arrow.Text = "　　↓　対訳　↓";
            label_second_arrow.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // combo_first
            // 
            combo_first.BackColor = ModernTheme.Colors.InputBackground;
            combo_first.Dock = DockStyle.Fill;
            combo_first.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_first.FlatStyle = FlatStyle.Flat;
            combo_first.Font = ModernTheme.Fonts.PrimaryFont;
            combo_first.ForeColor = ModernTheme.Colors.PrimaryText;
            combo_first.FormattingEnabled = true;
            combo_first.Location = new Point(99, ModernTheme.Spacing.Medium);
            combo_first.Name = "combo_first";
            combo_first.Size = new Size(236, 25);
            combo_first.TabIndex = 11;
            combo_first.TabStop = false;
            // 
            // label_first
            // 
            label_first.AutoSize = true;
            label_first.Dock = DockStyle.Left;
            label_first.Font = ModernTheme.Fonts.HeaderFont;
            label_first.ForeColor = ModernTheme.Colors.PrimaryText;
            label_first.Location = new Point(0, ModernTheme.Spacing.Medium);
            label_first.Name = "label_first";
            label_first.Padding = new Padding(ModernTheme.Spacing.Medium);
            label_first.Size = new Size(99, 33);
            label_first.TabIndex = 10;
            label_first.Text = "訳文１";
            // 
            // label_second
            // 
            label_second.AutoSize = true;
            label_second.Dock = DockStyle.Left;
            label_second.Font = ModernTheme.Fonts.HeaderFont;
            label_second.ForeColor = ModernTheme.Colors.PrimaryText;
            label_second.Location = new Point(0, ModernTheme.Spacing.Medium);
            label_second.Name = "label_second";
            label_second.Padding = new Padding(ModernTheme.Spacing.Medium);
            label_second.Size = new Size(99, 33);
            label_second.TabIndex = 10;
            label_second.Text = "訳文２";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = ModernTheme.Colors.CardBackground;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(textbox_re_first, 0, 2);
            tableLayoutPanel2.Controls.Add(textbox_first, 0, 0);
            tableLayoutPanel2.Controls.Add(label_first_arrow, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(361, 78);
            tableLayoutPanel2.Margin = new Padding(ModernTheme.Spacing.Small);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(ModernTheme.Spacing.Medium);
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(345, 534);
            tableLayoutPanel2.TabIndex = 17;
            // 
            // textbox_re_first
            // 
            textbox_re_first.BackColor = ModernTheme.Colors.InputBackground;
            textbox_re_first.BorderStyle = BorderStyle.None;
            textbox_re_first.Dock = DockStyle.Fill;
            textbox_re_first.Font = ModernTheme.Fonts.PrimaryFont;
            textbox_re_first.ForeColor = ModernTheme.Colors.PrimaryText;
            textbox_re_first.Location = new Point(ModernTheme.Spacing.Medium + 3, 279);
            textbox_re_first.Margin = new Padding(3, 2, 3, 2);
            textbox_re_first.Name = "textbox_re_first";
            textbox_re_first.ReadOnly = true;
            textbox_re_first.Size = new Size(321, 241);
            textbox_re_first.TabIndex = 3;
            textbox_re_first.Text = "";
            // 
            // textbox_first
            // 
            textbox_first.BackColor = ModernTheme.Colors.InputBackground;
            textbox_first.BorderStyle = BorderStyle.None;
            textbox_first.Dock = DockStyle.Fill;
            textbox_first.Font = ModernTheme.Fonts.PrimaryFont;
            textbox_first.ForeColor = ModernTheme.Colors.PrimaryText;
            textbox_first.Location = new Point(ModernTheme.Spacing.Medium + 3, ModernTheme.Spacing.Medium + 3);
            textbox_first.Margin = new Padding(3, 2, 3, 2);
            textbox_first.Name = "textbox_first";
            textbox_first.Size = new Size(321, 241);
            textbox_first.TabIndex = 1;
            textbox_first.Text = "";
            textbox_first.TextChanged += First_textbox_TextChanged;
            // 
            // label_first_arrow
            // 
            label_first_arrow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label_first_arrow.AutoSize = true;
            label_first_arrow.BackColor = ModernTheme.Colors.EmeraldAccent;
            label_first_arrow.Font = ModernTheme.Fonts.ButtonFont;
            label_first_arrow.ForeColor = ModernTheme.Colors.PrimaryText;
            label_first_arrow.Location = new Point(ModernTheme.Spacing.Medium + 3, 251);
            label_first_arrow.Margin = new Padding(3, ModernTheme.Spacing.Small, 3, ModernTheme.Spacing.Small);
            label_first_arrow.Name = "label_first_arrow";
            label_first_arrow.Padding = new Padding(ModernTheme.Spacing.Small);
            label_first_arrow.Size = new Size(321, 16);
            label_first_arrow.TabIndex = 6;
            label_first_arrow.Text = "　　↓　対訳　↓";
            label_first_arrow.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // combo_second
            // 
            combo_second.BackColor = ModernTheme.Colors.InputBackground;
            combo_second.Dock = DockStyle.Fill;
            combo_second.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_second.FlatStyle = FlatStyle.Flat;
            combo_second.Font = ModernTheme.Fonts.PrimaryFont;
            combo_second.ForeColor = ModernTheme.Colors.PrimaryText;
            combo_second.FormattingEnabled = true;
            combo_second.Location = new Point(99, ModernTheme.Spacing.Medium);
            combo_second.Name = "combo_second";
            combo_second.Size = new Size(237, 25);
            combo_second.TabIndex = 11;
            combo_second.TabStop = false;
            // 
            // textbox_orig
            // 
            textbox_orig.BackColor = ModernTheme.Colors.InputBackground;
            textbox_orig.BorderStyle = BorderStyle.None;
            textbox_orig.Dock = DockStyle.Fill;
            textbox_orig.Font = ModernTheme.Fonts.PrimaryFont;
            textbox_orig.ForeColor = ModernTheme.Colors.PrimaryText;
            textbox_orig.Location = new Point(ModernTheme.Spacing.Medium, ModernTheme.Spacing.Medium);
            textbox_orig.Margin = new Padding(0);
            textbox_orig.Name = "textbox_orig";
            textbox_orig.Size = new Size(334, 522);
            textbox_orig.TabIndex = 0;
            textbox_orig.Text = "";
            textbox_orig.TextChanged += textbox_orig_TextChanged;
            textbox_orig.Leave += Orig_textbox_Leave;
            // 
            // combo_orig
            // 
            combo_orig.BackColor = ModernTheme.Colors.InputBackground;
            combo_orig.Dock = DockStyle.Fill;
            combo_orig.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_orig.FlatStyle = FlatStyle.Flat;
            combo_orig.Font = ModernTheme.Fonts.PrimaryFont;
            combo_orig.ForeColor = ModernTheme.Colors.PrimaryText;
            combo_orig.FormattingEnabled = true;
            combo_orig.Location = new Point(75, ModernTheme.Spacing.Medium);
            combo_orig.Name = "combo_orig";
            combo_orig.Size = new Size(267, 25);
            combo_orig.TabIndex = 9;
            combo_orig.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = ModernTheme.Colors.CardBackground;
            panel1.Controls.Add(textbox_orig);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 78);
            panel1.Margin = new Padding(ModernTheme.Spacing.Small);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(ModernTheme.Spacing.Medium);
            panel1.Size = new Size(352, 534);
            panel1.TabIndex = 16;
            // 
            // panel_second_top
            // 
            panel_second_top.BackColor = ModernTheme.Colors.CardBackground;
            panel_second_top.Controls.Add(button2);
            panel_second_top.Controls.Add(combo_second);
            panel_second_top.Controls.Add(label_second);
            panel_second_top.Dock = DockStyle.Fill;
            panel_second_top.Location = new Point(712, 3);
            panel_second_top.Margin = new Padding(ModernTheme.Spacing.Small);
            panel_second_top.Name = "panel_second_top";
            panel_second_top.Padding = new Padding(0, ModernTheme.Spacing.Medium, ModernTheme.Spacing.Medium, ModernTheme.Spacing.Medium);
            panel_second_top.Size = new Size(346, 64);
            panel_second_top.TabIndex = 14;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = ModernTheme.Colors.IndigoMain;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = ModernTheme.Fonts.ButtonFont;
            button2.ForeColor = ModernTheme.Colors.PrimaryText;
            button2.Location = new Point(245, 36);
            button2.Name = "button2";
            button2.Size = new Size(91, ModernTheme.Styling.ButtonHeight);
            button2.TabIndex = 12;
            button2.Text = "翻訳指示";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel_first_top
            // 
            panel_first_top.BackColor = ModernTheme.Colors.CardBackground;
            panel_first_top.Controls.Add(button1);
            panel_first_top.Controls.Add(combo_first);
            panel_first_top.Controls.Add(label_first);
            panel_first_top.Dock = DockStyle.Fill;
            panel_first_top.Location = new Point(361, 3);
            panel_first_top.Margin = new Padding(ModernTheme.Spacing.Small);
            panel_first_top.Name = "panel_first_top";
            panel_first_top.Padding = new Padding(0, ModernTheme.Spacing.Medium, ModernTheme.Spacing.Medium, ModernTheme.Spacing.Medium);
            panel_first_top.Size = new Size(345, 64);
            panel_first_top.TabIndex = 12;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = ModernTheme.Colors.IndigoMain;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = ModernTheme.Fonts.ButtonFont;
            button1.ForeColor = ModernTheme.Colors.PrimaryText;
            button1.Location = new Point(244, 36);
            button1.Name = "button1";
            button1.Size = new Size(91, ModernTheme.Styling.ButtonHeight);
            button1.TabIndex = 10;
            button1.Text = "翻訳指示";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel_orig_top
            // 
            panel_orig_top.BackColor = ModernTheme.Colors.CardBackground;
            panel_orig_top.Controls.Add(combo_orig);
            panel_orig_top.Controls.Add(label_orig);
            panel_orig_top.Dock = DockStyle.Fill;
            panel_orig_top.Location = new Point(3, 3);
            panel_orig_top.Margin = new Padding(ModernTheme.Spacing.Small);
            panel_orig_top.Name = "panel_orig_top";
            panel_orig_top.Padding = new Padding(0, ModernTheme.Spacing.Medium, ModernTheme.Spacing.Medium, ModernTheme.Spacing.Medium);
            panel_orig_top.Size = new Size(352, 64);
            panel_orig_top.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = ModernTheme.Colors.DarkBackground;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.79721F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.10139F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.10139F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 2, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel_second_top, 2, 0);
            tableLayoutPanel1.Controls.Add(panel_first_top, 1, 0);
            tableLayoutPanel1.Controls.Add(panel_orig_top, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 48);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(ModernTheme.Spacing.Medium, ModernTheme.Spacing.Small, ModernTheme.Spacing.Medium, ModernTheme.Spacing.Medium);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1061, 608);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // trayIcon
            // 
            trayIcon.Icon = (Icon)resources.GetObject("trayIcon.Icon");
            trayIcon.Text = "DualDeepL";
            trayIcon.Visible = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ModernTheme.Colors.DarkBackground;
            ClientSize = new Size(1061, 656);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel_top);
            Font = ModernTheme.Fonts.PrimaryFont;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Dual DeepL Translater";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            panel_top.ResumeLayout(false);
            panel_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)titlePicture).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel_second_top.ResumeLayout(false);
            panel_second_top.PerformLayout();
            panel_first_top.ResumeLayout(false);
            panel_first_top.PerformLayout();
            panel_orig_top.ResumeLayout(false);
            panel_orig_top.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel_top;
        private PictureBox titlePicture;
        private Label label_orig;
        private TableLayoutPanel tableLayoutPanel3;
        private RichTextBox textbox_re_second;
        private RichTextBox textbox_second;
        private Label label_second_arrow;
        private ComboBox combo_first;
        private Label label_first;
        private Label label_second;
        private TableLayoutPanel tableLayoutPanel2;
        private RichTextBox textbox_re_first;
        private RichTextBox textbox_first;
        private Label label_first_arrow;
        private ComboBox combo_second;
        private RichTextBox textbox_orig;
        private ComboBox combo_orig;
        private Panel panel1;
        private Panel panel_second_top;
        private Panel panel_first_top;
        private Panel panel_orig_top;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox checkBox1;
        private Button button1;
        private Button button2;
        private NotifyIcon trayIcon;
    }
}