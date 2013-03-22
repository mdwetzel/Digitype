using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Digitype
{
    public partial class SaveDialog : Form
    {
        private string filename;
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

        }

        private void btnDontSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
