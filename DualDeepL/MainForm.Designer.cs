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
            label1 = new Label();
            instruct_second = new RichTextBox();
            panel_first_top = new Panel();
            label2 = new Label();
            instruct_first = new RichTextBox();
            panel_orig_top = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
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
            panel_top.Controls.Add(checkBox1);
            panel_top.Controls.Add(titlePicture);
            panel_top.Dock = DockStyle.Top;
            panel_top.Location = new Point(0, 0);
            panel_top.Margin = new Padding(3, 2, 3, 2);
            panel_top.Name = "panel_top";
            panel_top.Padding = new Padding(6, 6, 6, 0);
            panel_top.Size = new Size(1061, 41);
            panel_top.TabIndex = 9;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("BIZ UDゴシック", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.ForeColor = SystemColors.ButtonHighlight;
            checkBox1.Location = new Point(936, 12);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(116, 19);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "最前面に表示";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // titlePicture
            // 
            titlePicture.Dock = DockStyle.Left;
            titlePicture.Image = (Image)resources.GetObject("titlePicture.Image");
            titlePicture.Location = new Point(6, 6);
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
            label_orig.Font = new Font("BIZ UDゴシック", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label_orig.ForeColor = Color.WhiteSmoke;
            label_orig.Location = new Point(0, 5);
            label_orig.Name = "label_orig";
            label_orig.Padding = new Padding(5);
            label_orig.Size = new Size(49, 26);
            label_orig.TabIndex = 8;
            label_orig.Text = "原文";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(textbox_re_second, 0, 2);
            tableLayoutPanel3.Controls.Add(textbox_second, 0, 0);
            tableLayoutPanel3.Controls.Add(label_second_arrow, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(712, 75);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.Padding = new Padding(5);
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(346, 537);
            tableLayoutPanel3.TabIndex = 18;
            // 
            // textbox_re_second
            // 
            textbox_re_second.BackColor = Color.FromArgb(48, 52, 58);
            textbox_re_second.BorderStyle = BorderStyle.None;
            textbox_re_second.Dock = DockStyle.Fill;
            textbox_re_second.Font = new Font("BIZ UDゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textbox_re_second.ForeColor = Color.WhiteSmoke;
            textbox_re_second.Location = new Point(8, 283);
            textbox_re_second.Margin = new Padding(3, 2, 3, 2);
            textbox_re_second.Name = "textbox_re_second";
            textbox_re_second.ReadOnly = true;
            textbox_re_second.Size = new Size(330, 247);
            textbox_re_second.TabIndex = 4;
            textbox_re_second.Text = "";
            // 
            // textbox_second
            // 
            textbox_second.BackColor = Color.FromArgb(48, 52, 58);
            textbox_second.BorderStyle = BorderStyle.None;
            textbox_second.Dock = DockStyle.Fill;
            textbox_second.Font = new Font("BIZ UDゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textbox_second.ForeColor = Color.WhiteSmoke;
            textbox_second.Location = new Point(8, 7);
            textbox_second.Margin = new Padding(3, 2, 3, 2);
            textbox_second.Name = "textbox_second";
            textbox_second.Size = new Size(330, 246);
            textbox_second.TabIndex = 2;
            textbox_second.Text = "";
            textbox_second.TextChanged += second_textbox_TextChanged;
            // 
            // label_second_arrow
            // 
            label_second_arrow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label_second_arrow.AutoSize = true;
            label_second_arrow.Font = new Font("BIZ UDゴシック", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label_second_arrow.ForeColor = Color.WhiteSmoke;
            label_second_arrow.Location = new Point(8, 255);
            label_second_arrow.Name = "label_second_arrow";
            label_second_arrow.Size = new Size(330, 26);
            label_second_arrow.TabIndex = 6;
            label_second_arrow.Text = "　　対訳";
            label_second_arrow.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // combo_first
            // 
            combo_first.BackColor = Color.FromArgb(40, 44, 50);
            combo_first.Dock = DockStyle.Fill;
            combo_first.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_first.FlatStyle = FlatStyle.Flat;
            combo_first.Font = new Font("BIZ UDゴシック", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            combo_first.ForeColor = Color.WhiteSmoke;
            combo_first.FormattingEnabled = true;
            combo_first.Location = new Point(65, 5);
            combo_first.Name = "combo_first";
            combo_first.Size = new Size(270, 22);
            combo_first.TabIndex = 11;
            combo_first.TabStop = false;
            // 
            // label_first
            // 
            label_first.AutoSize = true;
            label_first.Dock = DockStyle.Left;
            label_first.Font = new Font("BIZ UDゴシック", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label_first.ForeColor = Color.WhiteSmoke;
            label_first.Location = new Point(0, 5);
            label_first.Name = "label_first";
            label_first.Padding = new Padding(5);
            label_first.Size = new Size(65, 26);
            label_first.TabIndex = 10;
            label_first.Text = "訳文１";
            // 
            // label_second
            // 
            label_second.AutoSize = true;
            label_second.Dock = DockStyle.Left;
            label_second.Font = new Font("BIZ UDゴシック", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label_second.ForeColor = Color.WhiteSmoke;
            label_second.Location = new Point(0, 5);
            label_second.Name = "label_second";
            label_second.Padding = new Padding(5);
            label_second.Size = new Size(65, 26);
            label_second.TabIndex = 10;
            label_second.Text = "訳文２";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(textbox_re_first, 0, 2);
            tableLayoutPanel2.Controls.Add(textbox_first, 0, 0);
            tableLayoutPanel2.Controls.Add(label_first_arrow, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(361, 75);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(5);
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(345, 537);
            tableLayoutPanel2.TabIndex = 17;
            // 
            // textbox_re_first
            // 
            textbox_re_first.BackColor = Color.FromArgb(48, 52, 58);
            textbox_re_first.BorderStyle = BorderStyle.None;
            textbox_re_first.Dock = DockStyle.Fill;
            textbox_re_first.Font = new Font("BIZ UDゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textbox_re_first.ForeColor = Color.WhiteSmoke;
            textbox_re_first.Location = new Point(8, 283);
            textbox_re_first.Margin = new Padding(3, 2, 3, 2);
            textbox_re_first.Name = "textbox_re_first";
            textbox_re_first.ReadOnly = true;
            textbox_re_first.Size = new Size(329, 247);
            textbox_re_first.TabIndex = 3;
            textbox_re_first.Text = "";
            // 
            // textbox_first
            // 
            textbox_first.BackColor = Color.FromArgb(48, 52, 58);
            textbox_first.BorderStyle = BorderStyle.None;
            textbox_first.Dock = DockStyle.Fill;
            textbox_first.Font = new Font("BIZ UDゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textbox_first.ForeColor = Color.WhiteSmoke;
            textbox_first.Location = new Point(8, 7);
            textbox_first.Margin = new Padding(3, 2, 3, 2);
            textbox_first.Name = "textbox_first";
            textbox_first.Size = new Size(329, 246);
            textbox_first.TabIndex = 1;
            textbox_first.Text = "";
            textbox_first.TextChanged += first_textbox_TextChanged;
            // 
            // label_first_arrow
            // 
            label_first_arrow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label_first_arrow.AutoSize = true;
            label_first_arrow.Font = new Font("BIZ UDゴシック", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            label_first_arrow.ForeColor = Color.WhiteSmoke;
            label_first_arrow.Location = new Point(8, 255);
            label_first_arrow.Name = "label_first_arrow";
            label_first_arrow.Size = new Size(329, 26);
            label_first_arrow.TabIndex = 6;
            label_first_arrow.Text = "　　対訳";
            label_first_arrow.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // combo_second
            // 
            combo_second.BackColor = Color.FromArgb(40, 44, 50);
            combo_second.Dock = DockStyle.Fill;
            combo_second.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_second.FlatStyle = FlatStyle.Flat;
            combo_second.Font = new Font("BIZ UDゴシック", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            combo_second.ForeColor = Color.WhiteSmoke;
            combo_second.FormattingEnabled = true;
            combo_second.Location = new Point(65, 5);
            combo_second.Name = "combo_second";
            combo_second.Size = new Size(271, 22);
            combo_second.TabIndex = 11;
            combo_second.TabStop = false;
            // 
            // textbox_orig
            // 
            textbox_orig.BackColor = Color.FromArgb(48, 52, 58);
            textbox_orig.BorderStyle = BorderStyle.None;
            textbox_orig.Dock = DockStyle.Fill;
            textbox_orig.Font = new Font("BIZ UDゴシック", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textbox_orig.ForeColor = Color.WhiteSmoke;
            textbox_orig.Location = new Point(5, 5);
            textbox_orig.Margin = new Padding(0);
            textbox_orig.Name = "textbox_orig";
            textbox_orig.Size = new Size(342, 527);
            textbox_orig.TabIndex = 11;
            textbox_orig.Text = "";
            textbox_orig.Leave += orig_textbox_Leave;
            // 
            // combo_orig
            // 
            combo_orig.BackColor = Color.FromArgb(40, 44, 50);
            combo_orig.Dock = DockStyle.Fill;
            combo_orig.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_orig.FlatStyle = FlatStyle.Flat;
            combo_orig.Font = new Font("BIZ UDゴシック", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            combo_orig.ForeColor = Color.WhiteSmoke;
            combo_orig.FormattingEnabled = true;
            combo_orig.Location = new Point(49, 5);
            combo_orig.Name = "combo_orig";
            combo_orig.Size = new Size(293, 22);
            combo_orig.TabIndex = 9;
            combo_orig.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(textbox_orig);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 75);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(352, 537);
            panel1.TabIndex = 16;
            // 
            // panel_second_top
            // 
            panel_second_top.Controls.Add(label1);
            panel_second_top.Controls.Add(instruct_second);
            panel_second_top.Controls.Add(combo_second);
            panel_second_top.Controls.Add(label_second);
            panel_second_top.Dock = DockStyle.Fill;
            panel_second_top.Location = new Point(712, 3);
            panel_second_top.Name = "panel_second_top";
            panel_second_top.Padding = new Padding(0, 5, 10, 5);
            panel_second_top.Size = new Size(346, 66);
            panel_second_top.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("BIZ UDゴシック", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(0, 31);
            label1.Name = "label1";
            label1.Padding = new Padding(5);
            label1.Size = new Size(65, 26);
            label1.TabIndex = 14;
            label1.Text = "制約２";
            // 
            // instruct_second
            // 
            instruct_second.BackColor = Color.FromArgb(48, 52, 58);
            instruct_second.BorderStyle = BorderStyle.None;
            instruct_second.Dock = DockStyle.Bottom;
            instruct_second.ForeColor = Color.WhiteSmoke;
            instruct_second.Location = new Point(65, 33);
            instruct_second.Margin = new Padding(3, 2, 3, 2);
            instruct_second.Name = "instruct_second";
            instruct_second.Size = new Size(271, 28);
            instruct_second.TabIndex = 13;
            instruct_second.Text = "";
            // 
            // panel_first_top
            // 
            panel_first_top.Controls.Add(label2);
            panel_first_top.Controls.Add(instruct_first);
            panel_first_top.Controls.Add(combo_first);
            panel_first_top.Controls.Add(label_first);
            panel_first_top.Dock = DockStyle.Fill;
            panel_first_top.Location = new Point(361, 3);
            panel_first_top.Name = "panel_first_top";
            panel_first_top.Padding = new Padding(0, 5, 10, 5);
            panel_first_top.Size = new Size(345, 66);
            panel_first_top.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("BIZ UDゴシック", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(0, 31);
            label2.Name = "label2";
            label2.Padding = new Padding(5);
            label2.Size = new Size(65, 26);
            label2.TabIndex = 15;
            label2.Text = "制約１";
            // 
            // instruct_first
            // 
            instruct_first.BackColor = Color.FromArgb(48, 52, 58);
            instruct_first.BorderStyle = BorderStyle.None;
            instruct_first.Dock = DockStyle.Bottom;
            instruct_first.ForeColor = Color.WhiteSmoke;
            instruct_first.Location = new Point(65, 33);
            instruct_first.Margin = new Padding(3, 2, 3, 2);
            instruct_first.Name = "instruct_first";
            instruct_first.Size = new Size(270, 28);
            instruct_first.TabIndex = 12;
            instruct_first.Text = "";
            // 
            // panel_orig_top
            // 
            panel_orig_top.Controls.Add(combo_orig);
            panel_orig_top.Controls.Add(label_orig);
            panel_orig_top.Dock = DockStyle.Fill;
            panel_orig_top.Location = new Point(3, 3);
            panel_orig_top.Name = "panel_orig_top";
            panel_orig_top.Padding = new Padding(0, 5, 10, 5);
            panel_orig_top.Size = new Size(352, 66);
            panel_orig_top.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
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
            tableLayoutPanel1.Location = new Point(0, 41);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1061, 615);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(6F, 12F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 44, 50);
            ClientSize = new Size(1061, 656);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel_top);
            Font = new Font("BIZ UDゴシック", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Dual DeepL Translater";
            FormClosing += MainForm_FormClosing;
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
        private Label label1;
        private RichTextBox instruct_second;
        private Label label2;
        private RichTextBox instruct_first;
        private CheckBox checkBox1;
    }
}