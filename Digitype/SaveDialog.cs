using System;
using System.Windows.Forms;

namespace Digitype
{
    public partial class SaveDialog : Form
    {
        private readonly string filename;
        public SaveDialog(string filename)
        {
            InitializeComponent();
            this.filename = filename;
        }

        private void SaveDialog_Load(object sender, EventArgs e)
        {
            lblSaveMessage.Text = String.Format("Do you want to save changes to {0}?", filename);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void btnDontSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
