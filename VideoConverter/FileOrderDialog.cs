// Copyright (c) 2025 Joel Maus
// This file is part of Video2BluRay.
// Video2BluRay is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Video2BluRay is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Video2BluRay.  If not, see <https://www.gnu.org/licenses/>.

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
