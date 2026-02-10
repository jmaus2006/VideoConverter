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

using System.Configuration;

namespace VideoConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private class VideoInfo
        {
            public string? Codec { get; set; }
            public double? Fps { get; set; }
            public string? Bitrate { get; set; }
            public string? AudioCodec { get; set; } // Added audio codec
            public double? OriginalFPS { get; set; }
            public int? Height { get; set; } // Video height for 1080p check
        }
        private VideoInfo? selectedVideoInfo;

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxFrameRate.SelectedItem = "29.97";
            comboBoxBitrate.SelectedItem = "25M";
            comboBoxCodec.SelectedItem = "libx264";
            comboBoxInterpolation.SelectedItem = "None";
            lblFpsValue.Text = string.Empty;
            lblBitrateValue.Text = string.Empty;
            lblCodecValue.Text = "No video selected";
            comboBoxAudioBitrate.SelectedItem = "Original";
            btnGenerateBlurayBlurayTab.BackgroundImage = Properties.Resources.bluray; 
            btnGenerateBlurayBlurayTab.BackgroundImageLayout = ImageLayout.Stretch;
            btnGenerateBlurayBlurayTab.Text = string.Empty;
            // Load last output directory if available
            string lastDir = Properties.Settings.Default.LastOutputDir;
            btnConvert.Enabled = false; //must select video first
            if (!string.IsNullOrWhiteSpace(lastDir) && Directory.Exists(lastDir))
            {
                lblOutputDir.Text = lastDir;
                lblOutputDirectoryBlurayTab.Text = lastDir;
            }
            // Load last ImgBurn directory location if available
            string lastDirImgBurn = Properties.Settings.Default.ImgBurnFileLocation;
            if (!string.IsNullOrWhiteSpace(lastDirImgBurn))
                 ImgBurnLocationLabel.Text = lastDirImgBurn;            
            else            
                ImgBurnLocationLabel.Text = "C:\\Program Files(x86)\\ImgBurn\\ImgBurn.exe";
            
            btnGenerateBlurayBlurayTab.AllowDrop = true;
            btnGenerateBlurayBlurayTab.DragEnter += btnGenerateBlurayBlurayTab_DragEnter;
            btnGenerateBlurayBlurayTab.DragDrop += btnGenerateBlurayBlurayTab_DragDrop;
        }

        private void btnSelectVid_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov;*.wmv;*.mkv|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    lblSelectedFile.Text = openFileDialog.FileName;
                    selectedVideoInfo = GetVideoInfo(openFileDialog.FileName);
                    // Set output directory to input file's folder only if output dir is empty
                    if (string.IsNullOrWhiteSpace(lblOutputDir.Text) || !Directory.Exists(lblOutputDir.Text))
                    {
                        string? inputDir = Path.GetDirectoryName(openFileDialog.FileName);
                        if (!string.IsNullOrWhiteSpace(inputDir))
                        {
                            lblOutputDir.Text = inputDir;
                            lblOutputDirectoryBlurayTab.Text = inputDir;
                            Properties.Settings.Default.LastOutputDir = inputDir;
                            Properties.Settings.Default.Save();
                        }
                    }
                    // Update UI labels for video info
                    if (selectedVideoInfo != null)
                    {
                        lblFpsValue.Text = $"Frames per second: {(selectedVideoInfo.Fps?.ToString() ?? "N/A")}";
                        lblBitrateValue.Text = $"Bitrate: {selectedVideoInfo.Bitrate ?? "N/A"}";
                        lblCodecValue.Text = $"Codec: {selectedVideoInfo.Codec ?? "N/A"}";
                        lblAudioCodec.Text = $"Audio: {selectedVideoInfo.AudioCodec ?? "N/A"}";
                        selectedVideoInfo.OriginalFPS = selectedVideoInfo.Fps ?? 29.97;
                        lblFpsValue.ForeColor = (lblFpsValue.Text.Contains("29.97") || lblFpsValue.Text.Contains("23.976") || lblFpsValue.Text.Contains("23.98") || lblFpsValue.Text.Contains("24")) ? Color.Green : Color.Black;
                        lblCodecValue.ForeColor = (lblCodecValue.Text.Contains("h264") || lblCodecValue.Text.Contains("vc1")) ? Color.Green : Color.Black;
                        lblAudioCodec.ForeColor = lblAudioCodec.Text.Contains("ac3") ? Color.Green : Color.Black;
                    }
                    else
                    {
                        lblFpsValue.Text = "Frames per second: N/A";
                        lblBitrateValue.Text = "Bitrate: N/A";
                        lblCodecValue.Text = "Codec: N/A";
                        selectedVideoInfo = new VideoInfo();
                    }
                }
                else
                {
                    // No video selected
                    lblFpsValue.Text = string.Empty;
                    lblBitrateValue.Text = string.Empty;
                    lblCodecValue.Text = "No video selected";
                    selectedVideoInfo = new VideoInfo();
                }
            }
        }

        private string GetBundledExePath(string exeName)
        {
            return Path.Combine(Application.StartupPath, exeName);
        }

        private VideoInfo? GetVideoInfo(string filePath)
        {
            try
            {
                var process = new System.Diagnostics.Process();
                process.StartInfo.FileName = GetBundledExePath("ffmpeg.exe");
                process.StartInfo.Arguments = $"-i \"{filePath}\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                string output = process.StandardError.ReadToEnd();
                process.WaitForExit();
                var info = new VideoInfo();
                // Codec
                var codecMatch = System.Text.RegularExpressions.Regex.Match(output, @"Video: ([^,]+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                if (codecMatch.Success)
                    info.Codec = codecMatch.Groups[1].Value.Trim();
                // FPS
                var fpsMatch = System.Text.RegularExpressions.Regex.Match(output, @"(\d+(?:\.\d+)?) fps", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                if (fpsMatch.Success && double.TryParse(fpsMatch.Groups[1].Value, out double fps))
                    info.Fps = fps;
                // Bitrate
                var bitrateMatch = System.Text.RegularExpressions.Regex.Match(output, @"bitrate: (\d+ kb/s)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                if (bitrateMatch.Success)
                    info.Bitrate = bitrateMatch.Groups[1].Value.Trim();
                // Audio Codec
                var audioMatch = System.Text.RegularExpressions.Regex.Match(output, @"Audio: ([^,]+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                if (audioMatch.Success)
                    info.AudioCodec = audioMatch.Groups[1].Value.Trim();
                // Height (resolution)
                var resMatch = System.Text.RegularExpressions.Regex.Match(output, @"(\d{2,5})x(\d{2,5})");
                if (resMatch.Success && int.TryParse(resMatch.Groups[2].Value, out int height))
                    info.Height = height;
                return info;
            }
            catch { return null; }
        }

        private void btnOutputDir_Click(object sender, EventArgs e)
        {
            using var folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                lblOutputDir.Text = folderDialog.SelectedPath;
                lblOutputDirectoryBlurayTab.Text = folderDialog.SelectedPath;
                // Save to settings
                Properties.Settings.Default.LastOutputDir = folderDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private string pendingArgs = string.Empty;
        private string pendingOutputFile = string.Empty;
        private TimeSpan? pendingDuration = null;
        private string pendingInputFile = string.Empty;
        private string pendingOutputDir = string.Empty;

        // Class-level ffmpeg process for control from any method
        private System.Diagnostics.Process? ffmpegProcess = null; 


        private async Task<TimeSpan?> GetVideoDurationAsync(string inputFile)
        {
            // If input is a .txt concat list, sum durations of all files in the list
            if (inputFile.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    var total = TimeSpan.Zero;
                    var dir = Path.GetDirectoryName(inputFile);
                    foreach (var line in File.ReadAllLines(inputFile))
                    {
                        var match = System.Text.RegularExpressions.Regex.Match(line, "file '(.+)'", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        if (match.Success)
                        {
                            string videoPath = match.Groups[1].Value;
                            // If not absolute, combine with .txt file's directory
                            if (!Path.IsPathRooted(videoPath))
                                videoPath = Path.Combine(dir, videoPath);
                            var dur = await GetSingleVideoDurationAsync(videoPath);
                            if (dur != null)
                                total += dur.Value;
                        }
                    }
                    return total;
                }
                catch { return null; }
            }
            // Otherwise, single file as before
            return await GetSingleVideoDurationAsync(inputFile);
        }

        private async Task<TimeSpan?> GetSingleVideoDurationAsync(string inputFile)
        {
            return await Task.Run<TimeSpan?>(() =>
            {
                try
                {
                    var probe = new System.Diagnostics.Process();
                    probe.StartInfo.FileName = GetBundledExePath("ffmpeg.exe");
                    probe.StartInfo.Arguments = $"-i \"{inputFile}\"";
                    probe.StartInfo.UseShellExecute = false;
                    probe.StartInfo.RedirectStandardError = true;
                    probe.StartInfo.RedirectStandardOutput = true;
                    probe.StartInfo.CreateNoWindow = true;
                    probe.Start();
                    string output = probe.StandardError.ReadToEnd();
                    probe.WaitForExit();
                    var match = System.Text.RegularExpressions.Regex.Match(output, @"Duration: (\d+):(\d+):(\d+).(\d+)");
                    if (match.Success)
                    {
                        int h = int.Parse(match.Groups[1].Value);
                        int m = int.Parse(match.Groups[2].Value);
                        int s = int.Parse(match.Groups[3].Value);
                        int ms = int.Parse(match.Groups[4].Value) * 10;
                        return new TimeSpan(0, h, m, s, ms);
                    }
                }
                catch { }
                return null;
            });
        }

        private TimeSpan? ParseFfmpegTime(string line)
        {
            // ffmpeg outputs: ... time=00:01:23.45 ...
            var match = System.Text.RegularExpressions.Regex.Match(line, @"time=(\d+):(\d+):(\d+)\.(\d+)");
            if (match.Success)
            {
                int h = int.Parse(match.Groups[1].Value);
                int m = int.Parse(match.Groups[2].Value);
                int s = int.Parse(match.Groups[3].Value);
                int ms = int.Parse(match.Groups[4].Value) * 10;
                return new TimeSpan(0, h, m, s, ms);
            }
            return null;
        }

        private void btnConcat_Click(object sender, EventArgs e)
        {          
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov;*.wmv;*.mkv|All Files|*.*";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Show file order dialog before proceeding
                    var fileOrderDialog = new FileOrderDialog(openFileDialog.FileNames.ToList());
                    if (fileOrderDialog.ShowDialog() != DialogResult.OK) return;
                    
                    var orderedFiles = fileOrderDialog.OrderedFiles;

                    string outputDir = lblOutputDir.Text;
                    if (string.IsNullOrWhiteSpace(outputDir))
                    {
                        MessageBox.Show("You must select an output folder first.", "Missing Output Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Find next available vidClip_{number}.txt
                    int fileNum = 1;
                    string txtFile;
                    do
                    {
                        txtFile = Path.Combine(outputDir, $"vidClip_{fileNum}.txt");
                        fileNum++;
                    } while (File.Exists(txtFile));

                    // Write ordered files to txtFile
                    using (var writer = new StreamWriter(txtFile))
                    {
                        foreach (var file in orderedFiles)
                        {
                            string fileName = Path.GetFileName(file);
                            writer.WriteLine($"file '{file}'");
                        }
                    }
                    MessageBox.Show($"File created: {Path.GetFileName(txtFile)}. Use this file as video input.");
                    lblSelectedFile.Text = txtFile;
                }
            }
        }

        private void checkboxMKV_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxMKV.Checked)
            {
                comboBoxCodec.SelectedItem = "libx264";
                comboBoxCodec.Enabled = false;
                comboBoxFrameRate.Items.Clear();
                comboBoxFrameRate.Items.Add("23.976");
                comboBoxFrameRate.Items.Add("24");
                comboBoxFrameRate.Items.Add("29.97");
                comboBoxFrameRate.SelectedItem = "29.97";
                checkboxAC3.Checked = true;
                checkboxAC3.Enabled = false;
                comboBoxAudioBitrate.SelectedItem = "640k";
                comboBoxAudioBitrate.Enabled = false;
            }
            else
            {
                comboBoxCodec.Enabled = true;
                comboBoxFrameRate.Enabled = true;
                checkboxAC3.Enabled = true;
                comboBoxAudioBitrate.Enabled = true;
                // Restore original frame rate options
                comboBoxFrameRate.Items.Clear();
                comboBoxFrameRate.Items.AddRange(new object[] { "Same as source", "23.976", "24", "25", "29.97", "30", "50", "59.94", "60" });
                comboBoxFrameRate.SelectedItem = "29.97";
            }
        }

        private void checkboxAC3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxAC3.Checked)
            {
                comboBoxAudioBitrate.SelectedItem = "640k";
                comboBoxAudioBitrate.Enabled = false;
            }
            else            
                comboBoxAudioBitrate.Enabled = true;            
        }

        private void lblSelectedFile_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblSelectedFile.Text) && !string.IsNullOrEmpty(txtFileName.Text))
                btnConvert.Enabled = true;            
            else            
                btnConvert.Enabled = false;            
        }

        private void comboBoxAudioBitrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAudioBitrate.SelectedItem != null && comboBoxAudioBitrate.SelectedItem.ToString() != "640k")
                checkboxAC3.Checked = false;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(logOutput.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtArgs.Text);
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            btnConvert.Enabled = !string.IsNullOrEmpty(txtFileName.Text) && !string.IsNullOrEmpty(lblSelectedFile.Text);
        }

        private void btnGenerateBlurayBlurayTab_DragEnter(object sender, DragEventArgs e)
        {
           e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }
              
        private void btnImgBurnLocation_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executable Files|*.exe";
                openFileDialog.Title = "Select ImgBurn Executable";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.ImgBurnFileLocation = openFileDialog.FileName;
                    Properties.Settings.Default.Save();
                    MessageBox.Show($"ImgBurn location saved: {openFileDialog.FileName}");
                    ImgBurnLocationLabel.Text = Properties.Settings.Default.ImgBurnFileLocation;
                }
            }
        }

        private void BlurayTab_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAudioOnly.Checked)
            {
                comboBoxFrameRate.Enabled = false;
                comboBoxInterpolation.Enabled = false;
                comboBoxCodec.Enabled = false;
                comboBoxBitrate.Enabled = false;
                checkboxMKV.Checked = false;
                checkboxMKV.Enabled = false;
                checkboxAC3.Checked = true;
                checkboxAC3.Enabled = false;
                checkboxAspectRatio.Checked = false;
                checkboxAspectRatio.Enabled = false;
            }
            else
            {
                comboBoxFrameRate.Enabled = true;
                comboBoxInterpolation.Enabled = true;
                comboBoxCodec.Enabled = true;
                comboBoxBitrate.Enabled = true;
                checkboxMKV.Enabled = true;
                checkboxAC3.Enabled = true;
                checkboxAspectRatio.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ffmpegProcess != null && !ffmpegProcess.HasExited)
            {
                {
                    var result = MessageBox.Show("Are you sure you want to stop the conversion?", "Confirm Stop", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            ffmpegProcess.Kill();
                            logOutput.Clear();
                            progressBar1.Value = 0;
                            labelProgress.Text = "0%";
                            progressBarBluRayTab.Value = 0;
                            labelProgressBluray.Text = "0%";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to stop the conversion: {ex.Message}");
                        }
                    }
                }
            }
            else
                MessageBox.Show("No conversion is currently running.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
    }
}
