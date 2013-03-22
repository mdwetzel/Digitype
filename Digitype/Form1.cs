using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Digitype
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text)) {

            } else {

                using (SaveDialog saveDialog = new SaveDialog("fewf")) {
                    var result = saveDialog.ShowDialog();
                    switch (result) {
                        case DialogResult.Yes:
                            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                                File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                            }
                            break;
                        case DialogResult.No:
                            MessageBox.Show("Don't save");
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
