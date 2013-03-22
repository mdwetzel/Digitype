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
        private string filename = "Untitled";
        private bool saved = true;

        public Form1()
        {
            InitializeComponent();

            UpdateTitleText();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NeedsToSave()) {
                PromptSaveFile();
            }
        }

        private void CreateNewFile()
        {
            rchPad.Clear();
        }

        private bool NeedsToSave()
        {
            return !saved;
        }

        private DialogResult PromptSaveFile()
        {
            using (SaveDialog saveDialog = new SaveDialog(filename)) {
                return saveDialog.ShowDialog();
            }
        }

        private void SaveFile()
        {
            File.WriteAllText(saveFileDialog.FileName, rchPad.Text);
            saved = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NeedsToSave()) {
                switch (PromptSaveFile()) {
                    case DialogResult.Yes:
                        OpenSaveDialog();
                        OpenDialog();
                        break;
                    case DialogResult.No:
                        OpenDialog();
                        return;
                    case DialogResult.Cancel:
                        break;
                }
            } else {
                OpenDialog();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!saved) {
                OpenSaveDialog();
            } else {
                SaveFile();
            }
        }

        private void OpenDialog()
        {
            using (openFileDialog = new OpenFileDialog()) {
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    CreateNewFile();
                    rchPad.Text = File.ReadAllText(openFileDialog.FileName);
                }
            }
        }

        private void OpenSaveDialog()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                SaveFile();
                filename = Path.GetFileName(saveFileDialog.FileName);
                UpdateTitleText();
            }
        }

        private void UpdateTitleText()
        {
            Text = string.Format("{0} - Digitype", filename);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSaveDialog();
        }

        private void rchPad_KeyUp(object sender, KeyEventArgs e)
        {
            saved = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (NeedsToSave()) {
                switch (PromptSaveFile()) {
                    case DialogResult.Yes:
                        OpenSaveDialog();
                        e.Cancel = false;
                        break;
                    case DialogResult.No:
                        return;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }
    }
}
