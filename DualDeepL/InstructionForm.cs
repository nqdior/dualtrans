using DualDeepL.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DualDeepL
{
    public partial class InstructionForm : Form
    {
        public InstructionForm()
        {
            InitializeComponent();
        }

        private int dialogKey = 0;

        public void ShowDialog(int dialogKey)
        {
            this.dialogKey = dialogKey;
            ShowDialog();
        }

        private void InstructionForm_Load(object sender, EventArgs e)
        {
            textbox_instruct.Text = Settings.Default[$"Instruct{this.dialogKey}"].ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Settings.Default[$"Instruct{this.dialogKey}"] = textbox_instruct.Text;
            Settings.Default.Save();
            Close();
        }

        private void Button2_Click(object sender, EventArgs e) => Close();
    }
}
