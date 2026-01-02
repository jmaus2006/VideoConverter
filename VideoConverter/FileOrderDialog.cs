using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace VideoConverter
{
    public partial class FileOrderDialog : Form
    {
        public List<string> OrderedFiles { get; private set; }

        // Helper class to store both file name and path
        private class FileListItem
        {
            public string FilePath { get; }
            public FileListItem(string filePath) { FilePath = filePath; }
            public override string ToString() => Path.GetFileName(FilePath);
        }

        public FileOrderDialog(List<string> files)
        {
            InitializeComponent();
            foreach (var file in files)
                listBoxFiles.Items.Add(new FileListItem(file));
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedIndex > 0)
            {
                int idx = listBoxFiles.SelectedIndex;
                var item = listBoxFiles.Items[idx];
                listBoxFiles.Items.RemoveAt(idx);
                listBoxFiles.Items.Insert(idx - 1, item);
                listBoxFiles.SelectedIndex = idx - 1;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedIndex >= 0 && listBoxFiles.SelectedIndex < listBoxFiles.Items.Count - 1)
            {
                int idx = listBoxFiles.SelectedIndex;
                var item = listBoxFiles.Items[idx];
                listBoxFiles.Items.RemoveAt(idx);
                listBoxFiles.Items.Insert(idx + 1, item);
                listBoxFiles.SelectedIndex = idx + 1;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            OrderedFiles = new List<string>();
            foreach (FileListItem item in listBoxFiles.Items)
                OrderedFiles.Add(item.FilePath);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
