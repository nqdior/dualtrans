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
            this.panel_top = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.titlePicture = new System.Windows.Forms.PictureBox();
            this.label_orig = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textbox_re_second = new System.Windows.Forms.RichTextBox();
            this.textbox_second = new System.Windows.Forms.RichTextBox();
            this.label_second_arrow = new System.Windows.Forms.Label();
            this.combo_first = new System.Windows.Forms.ComboBox();
            this.label_first = new System.Windows.Forms.Label();
            this.label_second = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textbox_re_first = new System.Windows.Forms.RichTextBox();
            this.textbox_first = new System.Windows.Forms.RichTextBox();
            this.label_first_arrow = new System.Windows.Forms.Label();
            this.combo_second = new System.Windows.Forms.ComboBox();
            this.textbox_orig = new System.Windows.Forms.RichTextBox();
            this.combo_orig = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_second_top = new System.Windows.Forms.Panel();
            this.panel_first_top = new System.Windows.Forms.Panel();
            this.panel_orig_top = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_top.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titlePicture)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_second_top.SuspendLayout();
            this.panel_first_top.SuspendLayout();
            this.panel_orig_top.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.panel2);
            this.panel_top.Controls.Add(this.titlePicture);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_top.Name = "panel_top";
            this.panel_top.Padding = new System.Windows.Forms.Padding(6, 6, 6, 0);
            this.panel_top.Size = new System.Drawing.Size(1061, 41);
            this.panel_top.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(651, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(404, 35);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(119, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "透明度";
            // 
            // trackBar1
            // 
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.trackBar1.Location = new System.Drawing.Point(164, 0);
            this.trackBar1.Minimum = 3;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(128, 35);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.TabStop = false;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(292, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(16, 35);
            this.panel3.TabIndex = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkBox1.Location = new System.Drawing.Point(308, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 35);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "最前面に固定";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // titlePicture
            // 
            this.titlePicture.Dock = System.Windows.Forms.DockStyle.Left;
            this.titlePicture.Image = ((System.Drawing.Image)(resources.GetObject("titlePicture.Image")));
            this.titlePicture.Location = new System.Drawing.Point(6, 6);
            this.titlePicture.Name = "titlePicture";
            this.titlePicture.Size = new System.Drawing.Size(162, 35);
            this.titlePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.titlePicture.TabIndex = 0;
            this.titlePicture.TabStop = false;
            // 
            // label_orig
            // 
            this.label_orig.AutoSize = true;
            this.label_orig.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_orig.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_orig.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label_orig.Location = new System.Drawing.Point(0, 5);
            this.label_orig.Name = "label_orig";
            this.label_orig.Padding = new System.Windows.Forms.Padding(5);
            this.label_orig.Size = new System.Drawing.Size(49, 26);
            this.label_orig.TabIndex = 8;
            this.label_orig.Text = "原文";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.textbox_re_second, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.textbox_second, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_second_arrow, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(712, 43);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(346, 569);
            this.tableLayoutPanel3.TabIndex = 18;
            // 
            // textbox_re_second
            // 
            this.textbox_re_second.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(58)))));
            this.textbox_re_second.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_re_second.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textbox_re_second.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textbox_re_second.Location = new System.Drawing.Point(8, 299);
            this.textbox_re_second.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_re_second.Name = "textbox_re_second";
            this.textbox_re_second.ReadOnly = true;
            this.textbox_re_second.Size = new System.Drawing.Size(330, 263);
            this.textbox_re_second.TabIndex = 4;
            this.textbox_re_second.Text = "";
            // 
            // textbox_second
            // 
            this.textbox_second.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(58)))));
            this.textbox_second.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_second.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textbox_second.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textbox_second.Location = new System.Drawing.Point(8, 7);
            this.textbox_second.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_second.Name = "textbox_second";
            this.textbox_second.Size = new System.Drawing.Size(330, 262);
            this.textbox_second.TabIndex = 2;
            this.textbox_second.Text = "";
            this.textbox_second.TextChanged += new System.EventHandler(this.second_textbox_TextChanged);
            // 
            // label_second_arrow
            // 
            this.label_second_arrow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_second_arrow.AutoSize = true;
            this.label_second_arrow.Font = new System.Drawing.Font("BIZ UDゴシック", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_second_arrow.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label_second_arrow.Location = new System.Drawing.Point(8, 271);
            this.label_second_arrow.Name = "label_second_arrow";
            this.label_second_arrow.Size = new System.Drawing.Size(330, 26);
            this.label_second_arrow.TabIndex = 6;
            this.label_second_arrow.Text = "　　対訳";
            this.label_second_arrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_first
            // 
            this.combo_first.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(50)))));
            this.combo_first.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combo_first.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_first.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_first.Font = new System.Drawing.Font("BIZ UDゴシック", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.combo_first.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.combo_first.FormattingEnabled = true;
            this.combo_first.Location = new System.Drawing.Point(65, 5);
            this.combo_first.Name = "combo_first";
            this.combo_first.Size = new System.Drawing.Size(270, 22);
            this.combo_first.TabIndex = 11;
            this.combo_first.TabStop = false;
            // 
            // label_first
            // 
            this.label_first.AutoSize = true;
            this.label_first.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_first.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_first.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label_first.Location = new System.Drawing.Point(0, 5);
            this.label_first.Name = "label_first";
            this.label_first.Padding = new System.Windows.Forms.Padding(5);
            this.label_first.Size = new System.Drawing.Size(65, 26);
            this.label_first.TabIndex = 10;
            this.label_first.Text = "訳文１";
            // 
            // label_second
            // 
            this.label_second.AutoSize = true;
            this.label_second.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_second.Font = new System.Drawing.Font("BIZ UDゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_second.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label_second.Location = new System.Drawing.Point(0, 5);
            this.label_second.Name = "label_second";
            this.label_second.Padding = new System.Windows.Forms.Padding(5);
            this.label_second.Size = new System.Drawing.Size(65, 26);
            this.label_second.TabIndex = 10;
            this.label_second.Text = "訳文２";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.textbox_re_first, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.textbox_first, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_first_arrow, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(361, 43);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(345, 569);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // textbox_re_first
            // 
            this.textbox_re_first.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(58)))));
            this.textbox_re_first.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_re_first.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textbox_re_first.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textbox_re_first.Location = new System.Drawing.Point(8, 299);
            this.textbox_re_first.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_re_first.Name = "textbox_re_first";
            this.textbox_re_first.ReadOnly = true;
            this.textbox_re_first.Size = new System.Drawing.Size(329, 263);
            this.textbox_re_first.TabIndex = 3;
            this.textbox_re_first.Text = "";
            // 
            // textbox_first
            // 
            this.textbox_first.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(58)))));
            this.textbox_first.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_first.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textbox_first.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textbox_first.Location = new System.Drawing.Point(8, 7);
            this.textbox_first.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_first.Name = "textbox_first";
            this.textbox_first.Size = new System.Drawing.Size(329, 262);
            this.textbox_first.TabIndex = 1;
            this.textbox_first.Text = "";
            this.textbox_first.TextChanged += new System.EventHandler(this.first_textbox_TextChanged);
            // 
            // label_first_arrow
            // 
            this.label_first_arrow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_first_arrow.AutoSize = true;
            this.label_first_arrow.Font = new System.Drawing.Font("BIZ UDゴシック", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_first_arrow.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label_first_arrow.Location = new System.Drawing.Point(8, 271);
            this.label_first_arrow.Name = "label_first_arrow";
            this.label_first_arrow.Size = new System.Drawing.Size(329, 26);
            this.label_first_arrow.TabIndex = 6;
            this.label_first_arrow.Text = "　　対訳";
            this.label_first_arrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_second
            // 
            this.combo_second.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(50)))));
            this.combo_second.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combo_second.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_second.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_second.Font = new System.Drawing.Font("BIZ UDゴシック", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.combo_second.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.combo_second.FormattingEnabled = true;
            this.combo_second.Location = new System.Drawing.Point(65, 5);
            this.combo_second.Name = "combo_second";
            this.combo_second.Size = new System.Drawing.Size(271, 22);
            this.combo_second.TabIndex = 11;
            this.combo_second.TabStop = false;
            // 
            // textbox_orig
            // 
            this.textbox_orig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(58)))));
            this.textbox_orig.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_orig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textbox_orig.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textbox_orig.Location = new System.Drawing.Point(5, 5);
            this.textbox_orig.Margin = new System.Windows.Forms.Padding(0);
            this.textbox_orig.Name = "textbox_orig";
            this.textbox_orig.Size = new System.Drawing.Size(342, 559);
            this.textbox_orig.TabIndex = 11;
            this.textbox_orig.Text = "";
            this.textbox_orig.Leave += new System.EventHandler(this.orig_textbox_Leave);
            // 
            // combo_orig
            // 
            this.combo_orig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(50)))));
            this.combo_orig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combo_orig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_orig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combo_orig.Font = new System.Drawing.Font("BIZ UDゴシック", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.combo_orig.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.combo_orig.FormattingEnabled = true;
            this.combo_orig.Location = new System.Drawing.Point(49, 5);
            this.combo_orig.Name = "combo_orig";
            this.combo_orig.Size = new System.Drawing.Size(293, 22);
            this.combo_orig.TabIndex = 9;
            this.combo_orig.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textbox_orig);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 43);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(352, 569);
            this.panel1.TabIndex = 16;
            // 
            // panel_second_top
            // 
            this.panel_second_top.Controls.Add(this.combo_second);
            this.panel_second_top.Controls.Add(this.label_second);
            this.panel_second_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_second_top.Location = new System.Drawing.Point(712, 3);
            this.panel_second_top.Name = "panel_second_top";
            this.panel_second_top.Padding = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.panel_second_top.Size = new System.Drawing.Size(346, 34);
            this.panel_second_top.TabIndex = 14;
            // 
            // panel_first_top
            // 
            this.panel_first_top.Controls.Add(this.combo_first);
            this.panel_first_top.Controls.Add(this.label_first);
            this.panel_first_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_first_top.Location = new System.Drawing.Point(361, 3);
            this.panel_first_top.Name = "panel_first_top";
            this.panel_first_top.Padding = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.panel_first_top.Size = new System.Drawing.Size(345, 34);
            this.panel_first_top.TabIndex = 12;
            // 
            // panel_orig_top
            // 
            this.panel_orig_top.Controls.Add(this.combo_orig);
            this.panel_orig_top.Controls.Add(this.label_orig);
            this.panel_orig_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_orig_top.Location = new System.Drawing.Point(3, 3);
            this.panel_orig_top.Name = "panel_orig_top";
            this.panel_orig_top.Padding = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.panel_orig_top.Size = new System.Drawing.Size(352, 34);
            this.panel_orig_top.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.79721F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.10139F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.10139F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel_second_top, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_first_top, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_orig_top, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1061, 615);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1061, 656);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel_top);
            this.Font = new System.Drawing.Font("BIZ UDゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Dual DeepL Translater";
            this.panel_top.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titlePicture)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel_second_top.ResumeLayout(false);
            this.panel_second_top.PerformLayout();
            this.panel_first_top.ResumeLayout(false);
            this.panel_first_top.PerformLayout();
            this.panel_orig_top.ResumeLayout(false);
            this.panel_orig_top.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private Panel panel2;
        private TrackBar trackBar1;
        private Panel panel3;
        private CheckBox checkBox1;
        private Label label1;
    }
}