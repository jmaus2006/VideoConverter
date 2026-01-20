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
        private VideoInfo selectedVideoInfo = null;

        private bool IsExeInPath(string exeName)
        {
            var paths = Environment.GetEnvironmentVariable("PATH");
            if (string.IsNullOrEmpty(paths)) return false;
            foreach (var path in paths.Split(';'))
            {
                try
                {
                    var exePath = System.IO.Path.Combine(path.Trim(), exeName);
                    if (System.IO.File.Exists(exePath))
                        return true;
                }
                catch { }
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxFrameRate.SelectedItem = "29.97";
            comboBoxBitrate.SelectedItem = "25M";
            comboBoxCodec.SelectedItem = "libx264";
            comboBoxInterpolation.SelectedItem = "minterpolate";
            // Set video info labels to initial state
            lblFpsValue.Text = string.Empty;
            lblBitrateValue.Text = string.Empty;
            lblCodecValue.Text = "No video selected";
            comboBoxAudioBitrate.SelectedItem = "Original";
            // Set only the background image for btnGenerateBluray and stretch it
            btnGenerateBlurayBlurayTab.BackgroundImage = Properties.Resources.bluray; // Replace 'bluray' with your actual resource name
            btnGenerateBlurayBlurayTab.BackgroundImageLayout = ImageLayout.Stretch;
            btnGenerateBlurayBlurayTab.Text = string.Empty;
            // Load last output directory if available
            string lastDir = Properties.Settings.Default.LastOutputDir;
            btnConvert.Enabled = false; //must select video first
            if (!string.IsNullOrWhiteSpace(lastDir) && System.IO.Directory.Exists(lastDir))
            {
                lblOutputDir.Text = lastDir;
                lblOutputDirectoryBlurayTab.Text = lastDir;
            }
            // Load last ImgBurn directory location if available
            string lastDirImgBurn = Properties.Settings.Default.ImgBurnFileLocation;
            if (!string.IsNullOrWhiteSpace(lastDirImgBurn))
            {
                ImgBurnLocationLabel.Text = lastDirImgBurn;
            }
            else
            {
                ImgBurnLocationLabel.Text = "C:\\Program Files(x86)\\ImgBurn\\ImgBurn.exe";
            }
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
                    if (string.IsNullOrWhiteSpace(lblOutputDir.Text) || !System.IO.Directory.Exists(lblOutputDir.Text))
                    {
                        string inputDir = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
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
                    }
                    else
                    {
                        lblFpsValue.Text = "Frames per second: N/A";
                        lblBitrateValue.Text = "Bitrate: N/A";
                        lblCodecValue.Text = "Codec: N/A";
                        selectedVideoInfo = new VideoInfo { OriginalFPS = 29.97 };
                    }
                }
                else
                {
                    // No video selected
                    lblFpsValue.Text = string.Empty;
                    lblBitrateValue.Text = string.Empty;
                    lblCodecValue.Text = "No video selected";
                    selectedVideoInfo = new VideoInfo { OriginalFPS = 29.97 };
                }
            }
        }

        // Helper to get bundled exe path
        private string GetBundledExePath(string exeName)
        {
            return System.IO.Path.Combine(Application.StartupPath, exeName);
        }

        private VideoInfo GetVideoInfo(string filePath)
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
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    lblOutputDir.Text = folderDialog.SelectedPath;
                    lblOutputDirectoryBlurayTab.Text = folderDialog.SelectedPath;
                    // Save to settings
                    Properties.Settings.Default.LastOutputDir = folderDialog.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private string pendingArgs = null;
        private string pendingOutputFile = null;
        private TimeSpan? pendingDuration = null;
        private string pendingInputFile = null;
        private string pendingOutputDir = null;
        private async void btnConvert_Click(object sender, EventArgs e)
        {
            // Get input file and output directory
            string inputFile = lblSelectedFile.Text;
            string outputDir = lblOutputDir.Text;
            string newFileName = txtFileName.Text.Trim();
            string filterArg = "";
            if (string.IsNullOrWhiteSpace(newFileName))
            {
                MessageBox.Show("You must enter a new file name before creating ffmpeg parameters.", "Missing File Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
            bool isMKV = checkboxMKV != null && checkboxMKV.Checked;
            if (isMKV)
            {
                if (!newFileName.EndsWith(".mkv", StringComparison.OrdinalIgnoreCase))
                    newFileName = Path.ChangeExtension(newFileName, ".mkv");
            }
            else
            {
                if (!newFileName.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase))
                    newFileName += ".mp4";
            }
            if (string.IsNullOrWhiteSpace(inputFile) && string.IsNullOrWhiteSpace(outputDir))
            {
                MessageBox.Show("Please select both an input file and output directory.");
                return;
            }
            if (string.IsNullOrWhiteSpace(inputFile))
            {
                MessageBox.Show("You must select an input video file before converting.", "Missing Input File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(outputDir))
            {
                MessageBox.Show("You must select an output folder before converting.", "Missing Output Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string frameRate = comboBoxFrameRate.SelectedItem?.ToString() ?? "29.97";
            string bitrate = comboBoxBitrate.SelectedItem?.ToString()?.Replace(" Mbps", "M") ?? "25M";
            string codec = comboBoxCodec.SelectedItem?.ToString() ?? "libx264";
            string interpolation = comboBoxInterpolation.SelectedItem?.ToString() ?? "minterpolate";
            string baseName = Path.GetFileNameWithoutExtension(newFileName);
            string ext = Path.GetExtension(newFileName);
            string outputFile = Path.Combine(outputDir, newFileName);
            int count = 1;
            string vfArg = "";
            if (frameRate == "29.97")
                frameRate = "30000/1001";
            else if (frameRate == "23.976")
                frameRate = "24000/1001";

            string rArg = $"-r {frameRate} ";
            if (frameRate.Equals("Same as source", StringComparison.OrdinalIgnoreCase) && selectedVideoInfo != null && selectedVideoInfo.OriginalFPS != null)
            {
                frameRate = selectedVideoInfo.OriginalFPS.Value.ToString("0.00");
                rArg = ""; // No need to set -r if using original fps
            }

            while (File.Exists(outputFile))
            {
                outputFile = Path.Combine(outputDir, $"{baseName} ({count}){ext}");
                count++;
            }


            string upscaleFilter = "scale=1920:-1:flags=lanczos,pad=1920:1080:(ow-iw)/2:(oh-ih)/2,unsharp=5:5:0.8:3:3:0.0";
            bool isBeingUpscaled = checkboxUpscale != null && checkboxUpscale.Checked;
            if (interpolation.Equals("minterpolate", StringComparison.OrdinalIgnoreCase))
            {
                vfArg = isBeingUpscaled
                    ? $"-vf \"minterpolate=fps={frameRate},{upscaleFilter}\" "
                    : $"-vf \"minterpolate=fps={frameRate}\" ";
                rArg = "";
            }
            else if (interpolation.Equals("tblend", StringComparison.OrdinalIgnoreCase))
            {
                vfArg = isBeingUpscaled
                    ? $"-vf \"tblend=all_mode=average,{upscaleFilter}\" "
                    : "-vf \"tblend=all_mode=average\" ";
            }
            else if (interpolation.Equals("None", StringComparison.OrdinalIgnoreCase))
            { 
                if (rArg != "")
                {
                    vfArg = isBeingUpscaled
                        ? $"-vf \"{upscaleFilter}\" "
                        : $"-vf \"framerate={frameRate}\" ";
                    rArg = "";
                }
                else
                {
                    vfArg = "";
                }
               
            }
            string inputArg;
            if (inputFile.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                inputArg = $"-f concat -safe 0 -i \"{inputFile}\" ";
            }
            else
            {
                inputArg = $"-i \"{inputFile}\" ";
            }
            string args;
            string audioArg = "";
            if (checkboxAC3 != null && checkboxAC3.Checked)
            {
                audioArg = "-c:a ac3 -b:a 640k ";
            }
            if (btnAudioOnly.Checked)
            {
                args = $"-i \"{inputFile}\" -c:v copy -c:a ac3 -b:a 640k -ar 48000 \"{outputFile}\"";
                txtArgs.Text = "ffmpeg " + args;
                btnRun.Enabled = true;
                pendingArgs = args;
                pendingOutputFile = outputFile;
                pendingInputFile = inputFile;
                pendingOutputDir = outputDir;
                pendingDuration = await GetVideoDurationAsync(inputFile);
                return;
            }
            if (isMKV)
            {   
                if (frameRate=="24000/1001")
                {
                    rArg = "-r 24000/1001";
                }
                else if (frameRate == "30000/1001")
                {
                    rArg = "-r 30000/1001";
                }
                    // Blu-ray compliant mkv
                    args = $"{inputArg}{vfArg}-c:v libx264 -profile:v high -level 4.1 -pix_fmt yuv420p {rArg} -b:v {bitrate} -c:a ac3 -b:a 640k -ar 48000 \"{outputFile}\"";
            }
            else
            {
                args = $"{inputArg}{vfArg}{rArg}-b:v {bitrate} -c:v {codec} -profile:v high -level 4.1 -pix_fmt yuv420p {audioArg}\"{outputFile}\"";
            }
            txtArgs.Text = "ffmpeg " + args;
            btnRun.Enabled = true;
            pendingArgs = args;
            pendingOutputFile = outputFile;
            pendingInputFile = inputFile;
            pendingOutputDir = outputDir;
            pendingDuration = await GetVideoDurationAsync(inputFile);
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pendingArgs) || string.IsNullOrWhiteSpace(pendingOutputFile) || string.IsNullOrWhiteSpace(pendingInputFile) || string.IsNullOrWhiteSpace(pendingOutputDir))
            {
                MessageBox.Show("No command to run.");
                return;
            }
            progressBar1.Value = 0;
            labelProgress.Text = "0%";
            progressBarBluRayTab.Value = 0;
            labelProgressBluray.Text = "0%";
            logOutput.Clear(); // Clear log before starting
            var duration = pendingDuration;
            if (duration == null)
            {
                MessageBox.Show("Could not determine video duration.");
                return;
            }
            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = GetBundledExePath("ffmpeg.exe");
            process.StartInfo.Arguments = pendingArgs;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.EnableRaisingEvents = true;
            process.Start();
            await Task.Run(() =>
            {
                string line;
                var stderr = process.StandardError;
                while ((line = stderr.ReadLine()) != null)
                {
                    var time = ParseFfmpegTime(line);
                    if (time != null && duration.Value.TotalSeconds > 0)
                    {
                        int percent = (int)(time.Value.TotalSeconds / duration.Value.TotalSeconds * 100);
                        if (percent > 100) percent = 100;
                        this.Invoke(new Action(() =>
                        {
                            progressBar1.Value = percent;
                            labelProgress.Text = percent + "%";
                            progressBarBluRayTab.Value = percent;
                            labelProgressBluray.Text = percent + "%";
                        }));
                    }
                    // Append ffmpeg output to logOutput RichTextBox in real time
                    this.Invoke(new Action(() =>
                    {
                        logOutput.AppendText(line + Environment.NewLine);
                    }));
                }
                process.WaitForExit();
            });
            if (System.IO.File.Exists(pendingOutputFile))
            {
                progressBar1.Value = 100;
                labelProgress.Text = "100%";
                progressBarBluRayTab.Value = 100;
                labelProgressBluray.Text = "100%";
                MessageBox.Show("Conversion completed successfully!");
                await Task.Delay(1000);
                progressBar1.Value = 0;
                labelProgress.Text = "0%";
                progressBarBluRayTab.Value = 0;
                labelProgressBluray.Text = "0%";
                lblSelectedFile.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Conversion failed. Output file was not created.");
            }
            btnRun.Enabled = false;
            txtArgs.Text = string.Empty;
            pendingArgs = null;
            pendingOutputFile = null;
            pendingInputFile = null;
            pendingOutputDir = null;
            pendingDuration = null;
        }

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
            // Select multiple video files
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov;*.wmv;*.mkv|All Files|*.*";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Show file order dialog before proceeding
                    var fileOrderDialog = new FileOrderDialog(openFileDialog.FileNames.ToList());
                    if (fileOrderDialog.ShowDialog() != DialogResult.OK)
                    {
                        // User cancelled, abort
                        return;
                    }
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
                            writer.WriteLine($"file '{fileName}'");
                        }
                    }
                    MessageBox.Show($"Text file created: {Path.GetFileName(txtFile)}. Use this txt file as video input.");
                    lblSelectedFile.Text = txtFile;
                }
            }
        }

        private async void btnGenerateBluray_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video Files|*.mkv;*.mp4";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Show file order dialog before proceeding
                    var fileOrderDialog = new FileOrderDialog(openFileDialog.FileNames.ToList());
                    if (fileOrderDialog.ShowDialog() != DialogResult.OK)
                    {
                        // User cancelled, abort
                        return;
                    }
                    var orderedFiles = fileOrderDialog.OrderedFiles;

                    // Validate all files: must be 1080p and AC3 audio
                    foreach (var file in orderedFiles)
                    {
                        var info = GetVideoInfo(file);
                        if (info == null || info.AudioCodec == null || info.Height == null || info.Height != 1080 || !info.AudioCodec.ToLower().Contains("ac3"))
                        {
                            MessageBox.Show($"File '{System.IO.Path.GetFileName(file)}' is not Blu-ray compliant. Only 1080p video with AC3 audio is allowed.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string outputDir = lblOutputDir.Text;
                    if (string.IsNullOrWhiteSpace(outputDir))
                    {
                        MessageBox.Show("You must select an output folder first.", "Missing Output Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int fileCount = orderedFiles.Count;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = fileCount;
                    progressBar1.Value = 0;
                    progressBarBluRayTab.Minimum = 0;
                    progressBarBluRayTab.Maximum = fileCount;
                    progressBarBluRayTab.Value = 0;
                    labelProgress.Text = $"0/{fileCount}";
                    labelProgressBluray.Text = $"0/{fileCount}";
                    string[] bdmvDirs = new string[fileCount];
                    string[] metaFiles = new string[fileCount];
                    for (int i = 0; i < fileCount; i++)
                    {
                        string filePath = orderedFiles[i];
                        string metaFile = Path.Combine(outputDir, fileCount == 1 ? "bluray.meta" : $"bluray{i + 1}.meta");
                        metaFiles[i] = metaFile;
                        using (var writer = new StreamWriter(metaFile, false))
                        {
                            writer.WriteLine("MUXOPT --blu-ray --auto-chapters=5 --no-pcr-on-video-pid --new-audio-pes --vbr --vbv-len=500");
                            writer.WriteLine($"V_MPEG4/ISO/AVC, \"{filePath}\", track=1");
                            writer.WriteLine($"A_AC3, \"{filePath}\", track=2");
                        }
                        // Run tsmuxer for this meta file
                        string bdmvDir = Path.Combine(outputDir, $"BDMV{i + 1}");
                        bdmvDirs[i] = bdmvDir;
                        try
                        {
                            if (!Directory.Exists(bdmvDir))
                                Directory.CreateDirectory(bdmvDir);
                            var process = new System.Diagnostics.Process();
                            process.StartInfo.FileName = GetBundledExePath("tsmuxer.exe");
                            process.StartInfo.Arguments = $"\"{metaFile}\" \"{bdmvDir}\"";
                            process.StartInfo.UseShellExecute = false;
                            process.StartInfo.RedirectStandardOutput = true;
                            process.StartInfo.RedirectStandardError = true;
                            process.StartInfo.CreateNoWindow = true;
                            process.Start();
                            await process.WaitForExitAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to run tsmuxer for {metaFile}: {ex.Message}");
                        }
                        // Update progress bar after each file
                        progressBar1.Value = i + 1;
                        labelProgress.Text = $"{i + 1}/{fileCount}";
                        progressBarBluRayTab.Value = i + 1;
                        labelProgressBluray.Text = $"{i + 1}/{fileCount}";
                        await Task.Delay(100); // Small delay for UI update
                    }
                    // --- Merging Step ---
                    string mergedBDMV = Path.Combine(outputDir, "BDMV");
                    string mergedSTREAM = Path.Combine(mergedBDMV, "STREAM");
                    string mergedPLAYLIST = Path.Combine(mergedBDMV, "PLAYLIST");
                    string mergedCLIPINF = Path.Combine(mergedBDMV, "CLIPINF");
                    Directory.CreateDirectory(mergedBDMV);
                    Directory.CreateDirectory(mergedSTREAM);
                    Directory.CreateDirectory(mergedPLAYLIST);
                    Directory.CreateDirectory(mergedCLIPINF);
                    // Copy index.bdmv and MovieObject.bdmv from BDMV1/BDMV
                    string bdmv1BDMV = Path.Combine(bdmvDirs[0], "BDMV");
                    string[] bdmvFiles = { "index.bdmv", "MovieObject.bdmv" };
                    foreach (var file in bdmvFiles)
                    {
                        string src = Path.Combine(bdmv1BDMV, file);
                        string dst = Path.Combine(mergedBDMV, file);
                        if (File.Exists(src))
                            File.Copy(src, dst, true);
                    }
                    int streamIdx = 0, playlistIdx = 0, clipinfIdx = 0;
                    for (int i = 0; i < bdmvDirs.Length; i++)
                    {
                        string bdmvSub = Path.Combine(bdmvDirs[i], "BDMV");
                        // STREAM
                        string streamDir = Path.Combine(bdmvSub, "STREAM");
                        if (Directory.Exists(streamDir))
                        {
                            foreach (var file in Directory.GetFiles(streamDir, "*.m2ts"))
                            {
                                string newName = streamIdx.ToString("D5") + ".m2ts";
                                File.Copy(file, Path.Combine(mergedSTREAM, newName), true);
                                streamIdx++;
                            }
                        }
                        // PLAYLIST
                        string playlistDir = Path.Combine(bdmvSub, "PLAYLIST");
                        if (Directory.Exists(playlistDir))
                        {
                            foreach (var file in Directory.GetFiles(playlistDir, "*.mpls"))
                            {
                                string newName = playlistIdx.ToString("D5") + ".mpls";
                                File.Copy(file, Path.Combine(mergedPLAYLIST, newName), true);
                                playlistIdx++;
                            }
                        }
                        // CLIPINF
                        string clipinfDir = Path.Combine(bdmvSub, "CLIPINF");
                        if (Directory.Exists(clipinfDir))
                        {
                            foreach (var file in Directory.GetFiles(clipinfDir, "*.clpi"))
                            {
                                string newName = clipinfIdx.ToString("D5") + ".clpi";
                                File.Copy(file, Path.Combine(mergedCLIPINF, newName), true);
                                clipinfIdx++;
                            }
                        }
                    }
                    // --- Remove BDMV1, BDMV2, ... directories ---
                    foreach (var dir in bdmvDirs)
                    {
                        try
                        {
                            if (Directory.Exists(dir))
                                Directory.Delete(dir, true);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to delete {dir}: {ex.Message}");
                        }
                    }
                    // --- Remove .meta files in outputDir ---
                    try
                    {
                        var metaFilesToDelete = Directory.GetFiles(outputDir, "bluray*.meta");
                        foreach (var meta in metaFilesToDelete)
                        {
                            try { File.Delete(meta); } catch { }
                        }
                    }
                    catch { }
                    // Reset progress bar
                    MessageBox.Show("Blu-ray folder created successfully!");
                    await Task.Delay(1000);
                    progressBar1.Value = 0;
                    labelProgress.Text = "0%";
                    progressBarBluRayTab.Value = 0;
                    labelProgressBluray.Text = "0%";

                    // Launch ImgBurn if checkbox is checked
                    if (checkboxImgBurn != null && checkboxImgBurn.Checked)
                    {
                        try
                        {
                            string imgburnExe = Properties.Settings.Default.ImgBurnFileLocation;
                            if (string.IsNullOrWhiteSpace(imgburnExe))
                            {
                                imgburnExe = @"C:\Program Files (x86)\ImgBurn\ImgBurn.exe";
                                Properties.Settings.Default.ImgBurnFileLocation = imgburnExe;
                                Properties.Settings.Default.Save();
                            }
                            var process = new System.Diagnostics.Process();
                            process.StartInfo.FileName = imgburnExe;
                            process.StartInfo.Arguments = $"\"{mergedBDMV}\"";
                            process.StartInfo.UseShellExecute = true;
                            process.Start();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to launch ImgBurn: {ex.Message}");
                        }
                    }
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
                comboBoxFrameRate.Items.Add("Same as source");
                comboBoxFrameRate.Items.Add("23.976");
                comboBoxFrameRate.Items.Add("24");
                comboBoxFrameRate.Items.Add("25");
                comboBoxFrameRate.Items.Add("29.97");
                comboBoxFrameRate.Items.Add("30");
                comboBoxFrameRate.Items.Add("50");
                comboBoxFrameRate.Items.Add("59.94");
                comboBoxFrameRate.Items.Add("60");
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
            {
                comboBoxAudioBitrate.Enabled = true;
            }
        }

        private void lblSelectedFile_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblSelectedFile.Text) && !string.IsNullOrEmpty(txtFileName.Text))
            {
                btnConvert.Enabled = true;
            }
            else
            {
                btnConvert.Enabled = false;
            }
        }

        private void comboBoxAudioBitrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAudioBitrate.SelectedItem != null && comboBoxAudioBitrate.SelectedItem.ToString() != "640k")
            {
                checkboxAC3.Checked = false;
            }
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
            if (!string.IsNullOrEmpty(txtFileName.Text) && !string.IsNullOrEmpty(lblSelectedFile.Text))
            {
                btnConvert.Enabled = true;
            }
            else
            {
                btnConvert.Enabled = false;
            }
        }

        private void btnGenerateBlurayBlurayTab_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private async void btnGenerateBlurayBlurayTab_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files == null || files.Length == 0) return;
            // Only accept MKV files
            var mkvFiles = files.Where(f => f.EndsWith(".mkv", StringComparison.OrdinalIgnoreCase)).ToList();
            if (mkvFiles.Count == 0)
            {
                MessageBox.Show("Please drop MKV files only.");
                return;
            }
            // Show file order dialog before proceeding
            var fileOrderDialog = new FileOrderDialog(mkvFiles);
            if (fileOrderDialog.ShowDialog() != DialogResult.OK)
                return;
            var orderedFiles = fileOrderDialog.OrderedFiles;
            string outputDir = lblOutputDir.Text;
            if (string.IsNullOrWhiteSpace(outputDir))
            {
                MessageBox.Show("You must select an output folder first.", "Missing Output Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int fileCount = orderedFiles.Count;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = fileCount;
            progressBar1.Value = 0;
            progressBarBluRayTab.Minimum = 0;
            progressBarBluRayTab.Maximum = fileCount;
            progressBarBluRayTab.Value = 0;
            labelProgress.Text = $"0/{fileCount}";
            labelProgressBluray.Text = $"0/{fileCount}";
            string[] bdmvDirs = new string[fileCount];
            string[] metaFiles = new string[fileCount];
            for (int i = 0; i < fileCount; i++)
            {
                string filePath = orderedFiles[i];
                string metaFile = Path.Combine(outputDir, fileCount == 1 ? "bluray.meta" : $"bluray{i + 1}.meta");
                metaFiles[i] = metaFile;
                using (var writer = new StreamWriter(metaFile, false))
                {
                    writer.WriteLine("MUXOPT --blu-ray --auto-chapters=5 --no-pcr-on-video-pid --new-audio-pes --vbr --vbv-len=500");
                    writer.WriteLine($"V_MPEG4/ISO/AVC, \"{filePath}\", track=1");
                    writer.WriteLine($"A_AC3, \"{filePath}\", track=2");
                }
                // Run tsmuxer for this meta file
                string bdmvDir = Path.Combine(outputDir, $"BDMV{i + 1}");
                bdmvDirs[i] = bdmvDir;
                try
                {
                    if (!Directory.Exists(bdmvDir))
                        Directory.CreateDirectory(bdmvDir);
                    var process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = GetBundledExePath("tsmuxer.exe");
                    process.StartInfo.Arguments = $"\"{metaFile}\" \"{bdmvDir}\"";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    await process.WaitForExitAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to run tsmuxer for {metaFile}: {ex.Message}");
                }
                // Update progress bar after each file
                progressBar1.Value = i + 1;
                labelProgress.Text = $"{i + 1}/{fileCount}";
                progressBarBluRayTab.Value = i + 1;
                labelProgressBluray.Text = $"{i + 1}/{fileCount}";
                await Task.Delay(100); // Small delay for UI update
            }
            // --- Merging Step ---
            string mergedBDMV = Path.Combine(outputDir, "BDMV");
            string mergedSTREAM = Path.Combine(mergedBDMV, "STREAM");
            string mergedPLAYLIST = Path.Combine(mergedBDMV, "PLAYLIST");
            string mergedCLIPINF = Path.Combine(mergedBDMV, "CLIPINF");
            Directory.CreateDirectory(mergedBDMV);
            Directory.CreateDirectory(mergedSTREAM);
            Directory.CreateDirectory(mergedPLAYLIST);
            Directory.CreateDirectory(mergedCLIPINF);
            // Copy index.bdmv and MovieObject.bdmv from BDMV1/BDMV
            string bdmv1BDMV = Path.Combine(bdmvDirs[0], "BDMV");
            string[] bdmvFiles = { "index.bdmv", "MovieObject.bdmv" };
            foreach (var file in bdmvFiles)
            {
                string src = Path.Combine(bdmv1BDMV, file);
                string dst = Path.Combine(mergedBDMV, file);
                if (File.Exists(src))
                    File.Copy(src, dst, true);
            }
            int streamIdx = 0, playlistIdx = 0, clipinfIdx = 0;
            for (int i = 0; i < bdmvDirs.Length; i++)
            {
                string bdmvSub = Path.Combine(bdmvDirs[i], "BDMV");
                // STREAM
                string streamDir = Path.Combine(bdmvSub, "STREAM");
                if (Directory.Exists(streamDir))
                {
                    foreach (var file in Directory.GetFiles(streamDir, "*.m2ts"))
                    {
                        string newName = streamIdx.ToString("D5") + ".m2ts";
                        File.Copy(file, Path.Combine(mergedSTREAM, newName), true);
                        streamIdx++;
                    }
                }
                // PLAYLIST
                string playlistDir = Path.Combine(bdmvSub, "PLAYLIST");
                if (Directory.Exists(playlistDir))
                {
                    foreach (var file in Directory.GetFiles(playlistDir, "*.mpls"))
                    {
                        string newName = playlistIdx.ToString("D5") + ".mpls";
                        File.Copy(file, Path.Combine(mergedPLAYLIST, newName), true);
                        playlistIdx++;
                    }
                }
                // CLIPINF
                string clipinfDir = Path.Combine(bdmvSub, "CLIPINF");
                if (Directory.Exists(clipinfDir))
                {
                    foreach (var file in Directory.GetFiles(clipinfDir, "*.clpi"))
                    {
                        string newName = clipinfIdx.ToString("D5") + ".clpi";
                        File.Copy(file, Path.Combine(mergedCLIPINF, newName), true);
                        clipinfIdx++;
                    }
                }
            }
            // --- Remove BDMV1, BDMV2, ... directories ---
            foreach (var dir in bdmvDirs)
            {
                try
                {
                    if (Directory.Exists(dir))
                        Directory.Delete(dir, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete {dir}: {ex.Message}");
                }
            }
            // --- Remove .meta files in outputDir ---
            try
            {
                var metaFilesToDelete = Directory.GetFiles(outputDir, "bluray*.meta");
                foreach (var meta in metaFilesToDelete)
                {
                    try { File.Delete(meta); } catch { }
                }
            }
            catch { }
            // Reset progress bar
            MessageBox.Show("Blu-ray folder created successfully!");
            await Task.Delay(1000);
            progressBar1.Value = 0;
            labelProgress.Text = "0%";
            progressBarBluRayTab.Value = 0;
            labelProgressBluray.Text = "0%";

            // Launch ImgBurn if checkbox is checked
            if (checkboxImgBurn != null && checkboxImgBurn.Checked)
            {
                try
                {
                    string imgburnExe = Properties.Settings.Default.ImgBurnFileLocation;
                    if (string.IsNullOrWhiteSpace(imgburnExe))
                    {
                        imgburnExe = @"C:\Program Files (x86)\ImgBurn\ImgBurn.exe";
                        Properties.Settings.Default.ImgBurnFileLocation = imgburnExe;
                        Properties.Settings.Default.Save();
                    }
                    var process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = imgburnExe;
                    process.StartInfo.Arguments = $"\"{mergedBDMV}\"";
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to launch ImgBurn: {ex.Message}");
                }
            }
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
            if (btnAudioOnly.Checked) {    
                comboBoxFrameRate.Enabled = false;
                comboBoxInterpolation.Enabled = false;
                comboBoxCodec.Enabled = false;
                comboBoxBitrate.Enabled = false;
                checkboxMKV.Checked = false;
                checkboxMKV.Enabled = false;
                checkboxAC3.Checked = true;
                checkboxAC3.Enabled = false;
            }
            else
            {
                comboBoxFrameRate.Enabled = true;
                comboBoxInterpolation.Enabled = true;
                comboBoxCodec.Enabled = true;
                comboBoxBitrate.Enabled = true;
                checkboxMKV.Enabled = true;
                checkboxAC3.Enabled = true;
            }
        }
    }
}
