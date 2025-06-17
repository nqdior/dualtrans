using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DualDeepL.Utils
{
    public static class ModernUI
    {
        /// <summary>
        /// Applies modern styling to a button control
        /// </summary>
        public static void ApplyModernButtonStyle(Button button, bool isPrimary = false)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = ModernTheme.Fonts.ButtonFont;
            button.ForeColor = ModernTheme.Colors.PrimaryText;
            button.Size = new Size(button.Size.Width, ModernTheme.Styling.ButtonHeight);
            
            if (isPrimary)
            {
                button.BackColor = ModernTheme.Colors.IndigoMain;
                button.MouseEnter += (s, e) => button.BackColor = ModernTheme.Colors.IndigoHover;
                button.MouseLeave += (s, e) => button.BackColor = ModernTheme.Colors.IndigoMain;
            }
            else
            {
                button.BackColor = ModernTheme.Colors.Border;
                button.MouseEnter += (s, e) => button.BackColor = ModernTheme.Colors.BorderLight;
                button.MouseLeave += (s, e) => button.BackColor = ModernTheme.Colors.Border;
            }
        }

        /// <summary>
        /// Applies modern card styling to a panel
        /// </summary>
        public static void ApplyCardStyle(Panel panel)
        {
            panel.BackColor = ModernTheme.Colors.CardBackground;
            panel.Padding = new Padding(ModernTheme.Spacing.Medium);
            
            // Add rounded corners by handling paint event
            panel.Paint += (sender, e) =>
            {
                var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                using (var path = GetRoundedRectanglePath(rect, ModernTheme.Styling.BorderRadius))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (var brush = new SolidBrush(ModernTheme.Colors.CardBackground))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                    using (var pen = new Pen(ModernTheme.Colors.Border, 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };
        }

        /// <summary>
        /// Applies modern styling to text input controls
        /// </summary>
        public static void ApplyInputStyle(Control textControl)
        {
            textControl.BackColor = ModernTheme.Colors.InputBackground;
            textControl.ForeColor = ModernTheme.Colors.PrimaryText;
            textControl.Font = ModernTheme.Fonts.PrimaryFont;
            
            if (textControl is RichTextBox richTextBox)
            {
                richTextBox.BorderStyle = BorderStyle.None;
                
                // Add focus effects
                richTextBox.Enter += (s, e) =>
                {
                    richTextBox.BackColor = Color.FromArgb(
                        Math.Min(255, ModernTheme.Colors.InputBackground.R + 10),
                        Math.Min(255, ModernTheme.Colors.InputBackground.G + 10),
                        Math.Min(255, ModernTheme.Colors.InputBackground.B + 10)
                    );
                };
                richTextBox.Leave += (s, e) =>
                {
                    richTextBox.BackColor = ModernTheme.Colors.InputBackground;
                };
            }
            else if (textControl is TextBox textBox)
            {
                textBox.BorderStyle = BorderStyle.None;
                
                // Add focus effects
                textBox.Enter += (s, e) =>
                {
                    textBox.BackColor = Color.FromArgb(
                        Math.Min(255, ModernTheme.Colors.InputBackground.R + 10),
                        Math.Min(255, ModernTheme.Colors.InputBackground.G + 10),
                        Math.Min(255, ModernTheme.Colors.InputBackground.B + 10)
                    );
                };
                textBox.Leave += (s, e) =>
                {
                    textBox.BackColor = ModernTheme.Colors.InputBackground;
                };
            }
        }

        /// <summary>
        /// Creates a visual flow indicator between translation sections
        /// </summary>
        public static void CreateFlowIndicator(Label label, string text = "↓ 翻訳結果 ↓")
        {
            label.Text = text;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BackColor = ModernTheme.Colors.EmeraldAccent;
            label.ForeColor = ModernTheme.Colors.PrimaryText;
            label.Font = ModernTheme.Fonts.ButtonFont;
            label.Padding = new Padding(ModernTheme.Spacing.Small);
            label.AutoSize = false;
            label.Height = 32;
            
            // Add gradient background
            label.Paint += (sender, e) =>
            {
                var rect = new Rectangle(0, 0, label.Width, label.Height);
                using (var brush = new LinearGradientBrush(rect, 
                    ModernTheme.Colors.EmeraldAccent, 
                    ModernTheme.Colors.EmeraldHover, 
                    LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
                
                // Draw text
                using (var textBrush = new SolidBrush(ModernTheme.Colors.PrimaryText))
                {
                    var stringFormat = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    e.Graphics.DrawString(label.Text, label.Font, textBrush, rect, stringFormat);
                }
            };
        }

        /// <summary>
        /// Creates a rounded rectangle path for custom drawing
        /// </summary>
        private static GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int diameter = radius * 2;
            
            // Top-left arc
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            // Top-right arc
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            // Bottom-right arc
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            // Bottom-left arc
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// Applies modern combo box styling
        /// </summary>
        public static void ApplyComboBoxStyle(ComboBox comboBox)
        {
            comboBox.BackColor = ModernTheme.Colors.InputBackground;
            comboBox.ForeColor = ModernTheme.Colors.PrimaryText;
            comboBox.Font = ModernTheme.Fonts.PrimaryFont;
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            
            // Add hover effects
            comboBox.MouseEnter += (s, e) =>
            {
                comboBox.BackColor = Color.FromArgb(
                    Math.Min(255, ModernTheme.Colors.InputBackground.R + 15),
                    Math.Min(255, ModernTheme.Colors.InputBackground.G + 15),
                    Math.Min(255, ModernTheme.Colors.InputBackground.B + 15)
                );
            };
            comboBox.MouseLeave += (s, e) =>
            {
                comboBox.BackColor = ModernTheme.Colors.InputBackground;
            };
        }
        
        /// <summary>
        /// Applies modern check box styling
        /// </summary>
        public static void ApplyCheckBoxStyle(CheckBox checkBox)
        {
            checkBox.ForeColor = ModernTheme.Colors.PrimaryText;
            checkBox.Font = ModernTheme.Fonts.PrimaryFont;
            checkBox.UseVisualStyleBackColor = true;
        }
        
        /// <summary>
        /// Creates modern tooltips for controls
        /// </summary>
        public static ToolTip CreateModernToolTip()
        {
            var toolTip = new ToolTip();
            toolTip.BackColor = ModernTheme.Colors.CardBackground;
            toolTip.ForeColor = ModernTheme.Colors.PrimaryText;
            toolTip.OwnerDraw = true;
            toolTip.Draw += (sender, e) =>
            {
                // Draw custom tooltip background
                e.Graphics.FillRectangle(new SolidBrush(ModernTheme.Colors.CardBackground), e.Bounds);
                e.Graphics.DrawRectangle(new Pen(ModernTheme.Colors.Border), e.Bounds);
                
                // Draw text
                TextRenderer.DrawText(e.Graphics, e.ToolTipText, ModernTheme.Fonts.SmallFont,
                    e.Bounds, ModernTheme.Colors.PrimaryText, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };
            return toolTip;
        }
        
        /// <summary>
        /// Adds modern hover effects to a control
        /// </summary>
        public static void AddHoverEffect(Control control, Color normalColor, Color hoverColor)
        {
            control.MouseEnter += (s, e) => control.BackColor = hoverColor;
            control.MouseLeave += (s, e) => control.BackColor = normalColor;
        }
    }
}