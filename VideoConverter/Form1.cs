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
            public string Codec { get; set; }
            public double? Fps { get; set; }
            public string Bitrate { get; set; }
        }
        private VideoInfo selectedVideoInfo = null;

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
            // Set only the background image for btnGenerateBluray and stretch it
            btnGenerateBluray.BackgroundImage = Properties.Resources.bluray; // Replace 'bluray' with your actual resource name
            btnGenerateBluray.BackgroundImageLayout = ImageLayout.Stretch;
            btnGenerateBluray.Text = string.Empty;
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
                    // Update UI labels for video info
                    if (selectedVideoInfo != null)
                    {
                        lblFpsValue.Text = $"Frames per second: {(selectedVideoInfo.Fps?.ToString() ?? "N/A" )}";
                        lblBitrateValue.Text = $"Bitrate: {selectedVideoInfo.Bitrate ?? "N/A"}";
                        lblCodecValue.Text = $"Codec: {selectedVideoInfo.Codec ?? "N/A"}";
                    }
                    else
                    {
                        lblFpsValue.Text = "Frames per second: N/A";
                        lblBitrateValue.Text = "Bitrate: N/A";
                        lblCodecValue.Text = "Codec: N/A";
                    }
                }
                else
                {
                    // No video selected
                    lblFpsValue.Text = string.Empty;
                    lblBitrateValue.Text = string.Empty;
                    lblCodecValue.Text = "No video selected";
                }
            }
        }

        private VideoInfo GetVideoInfo(string filePath)
        {
            try
            {
                var process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "ffmpeg.exe";
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
            string newFileName = txtFileName.Text.Trim() ?? "outputVideo.mp4";
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
            while (File.Exists(outputFile))
            {
                outputFile = Path.Combine(outputDir, $"{baseName} ({count}){ext}");
                count++;
            }
            string vfArg = "";
            string rArg = $"-r {frameRate} ";
            if (interpolation.Equals("minterpolate", StringComparison.OrdinalIgnoreCase))
            {
                vfArg = $"-vf \"minterpolate=fps={frameRate}\" ";
                rArg = "";
            }
            else if (interpolation.Equals("tblend", StringComparison.OrdinalIgnoreCase))
            {
                vfArg = "-vf \"tblend=all_mode=average\" ";
            }
            else if (interpolation.Equals("None", StringComparison.OrdinalIgnoreCase))
            {
                vfArg = "";
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
            if (isMKV)
            {
                // Blu-ray compliant mkv
                args = $"{inputArg}{vfArg}-c:v libx264 -profile:v high -level 4.1 -pix_fmt yuv420p -r 30000/1001 -b:v {bitrate} -c:a ac3 -b:a 640k -ar 48000 \"{outputFile}\"";
            }
            else
            {
                args = $"{inputArg}{vfArg}{rArg}-b:v {bitrate} -c:v {codec} -profile:v high -level 4.1 \"{outputFile}\"";
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
            var duration = pendingDuration;
            if (duration == null)
            {
                MessageBox.Show("Could not determine video duration.");
                return;
            }
            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "ffmpeg.exe";
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
                        }));
                    }
                }
                process.WaitForExit();
            });
            if (System.IO.File.Exists(pendingOutputFile))
            {
                progressBar1.Value = 100;
                labelProgress.Text = "100%";
                MessageBox.Show("Conversion completed successfully!");
                progressBar1.Value = 0;
                labelProgress.Text = "0%";
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
                    probe.StartInfo.FileName = "ffmpeg.exe";
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

                    // Write selected files to txtFile
                    using (var writer = new StreamWriter(txtFile))
                    {
                        foreach (var file in openFileDialog.FileNames)
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
        
        private void btnGenerateBluray_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "MKV Files|*.mkv";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputDir = lblOutputDir.Text;
                    if (string.IsNullOrWhiteSpace(outputDir))
                    {
                        MessageBox.Show("You must select an output folder first.", "Missing Output Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string metaFile = Path.Combine(outputDir, "bluray.meta");
                    using (var writer = new StreamWriter(metaFile, false))
                    {
                        for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                        {
                            string file = Path.GetFileName(openFileDialog.FileNames[i]);
                            writer.WriteLine("MUXOPT --blu-ray --auto-chapters=5 --no-pcr-on-video-pid --new-audio-pes --vbr --vbv-len=500");
                            writer.WriteLine($"V_MPEG4/ISO/AVC, \"{file}\", track=1");
                            writer.WriteLine($"A_AC3, \"{file}\", track=2");
                            if (i < openFileDialog.FileNames.Length - 1)
                                writer.WriteLine("--start-segment");
                        }
                    }
                    MessageBox.Show($"bluray.meta file created in {outputDir}");             
                                 
                }
            }
        }
    }
}
