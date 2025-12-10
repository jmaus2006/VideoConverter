namespace VideoConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov;*.wmv;*.mkv|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    label1.Text = openFileDialog.FileName;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxFrameRate.SelectedItem = "29.97";
            comboBoxBitrate.SelectedItem = "25M";
            comboBoxCodec.SelectedItem = "libx264";
            comboBoxInterpolation.SelectedItem = "minterpolate";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    label7.Text = folderDialog.SelectedPath;
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Get input file and output directory
            string inputFile = label1.Text;
            string outputDir = label7.Text;
            string newFileName = txtFileName.Text.Trim() ?? "outputVideo.mp4";
            if (!newFileName.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase))
            {
                newFileName += ".mp4";
            }
            if (string.IsNullOrWhiteSpace(inputFile) && string.IsNullOrWhiteSpace(outputDir))
            {
                MessageBox.Show("Please select both an input file and output directory.");
                return;
            }

            // Validation: require input file and output directory
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

            // Get options from ComboBoxes
            string frameRate = comboBoxFrameRate.SelectedItem?.ToString() ?? "29.97";
            string bitrate = comboBoxBitrate.SelectedItem?.ToString()?.Replace(" Mbps", "M") ?? "25M";
            string codec = comboBoxCodec.SelectedItem?.ToString() ?? "libx264";
            string interpolation = comboBoxInterpolation.SelectedItem?.ToString() ?? "minterpolate";

            // Build output file path
            string baseName = Path.GetFileNameWithoutExtension(newFileName);
            string ext = Path.GetExtension(newFileName);
            string outputFile = Path.Combine(outputDir, newFileName);
            int count = 1;
            while (File.Exists(outputFile))
            {
                outputFile = Path.Combine(outputDir, $"{baseName} ({count}){ext}");
                count++;
            }

            // Build ffmpeg arguments with conditional -vf and -r
            string vfArg = "";
            string rArg = $"-r {frameRate} ";
            if (interpolation.Equals("minterpolate", StringComparison.OrdinalIgnoreCase))
            {
                vfArg = $"-vf \"minterpolate=fps={frameRate}\" ";
                rArg = ""; // Do not add -r if minterpolate is used
            }
            else if (interpolation.Equals("tblend", StringComparison.OrdinalIgnoreCase))
            {
                vfArg = "-vf \"tblend=all_mode=average\" ";
            }
            else if (interpolation.Equals("None", StringComparison.OrdinalIgnoreCase))
            {
                vfArg = "";
            }

            // Determine input argument based on file type
            string inputArg;
            if (inputFile.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                inputArg = $"-f concat -safe 0 -i \"{inputFile}\" ";
            }
            else
            {
                inputArg = $"-i \"{inputFile}\" ";
            }

            string args = $"{inputArg}{vfArg}{rArg}-b:v {bitrate} -c:v {codec} -profile:v high -level 4.1 \"{outputFile}\"";

            progressBar1.Value = 0;
            labelProgress.Text = "0%";

            // Get duration first
            TimeSpan? duration = await GetVideoDurationAsync(inputFile);
            if (duration == null)
            {
                MessageBox.Show("Could not determine video duration.");
                return;
            }

            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "ffmpeg.exe";
            process.StartInfo.Arguments = args;
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
                TimeSpan lastTime = TimeSpan.Zero;
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

            // Check if file was created
            if (System.IO.File.Exists(outputFile))
            {
                progressBar1.Value = 100;
                labelProgress.Text = "100%";
                MessageBox.Show("Conversion completed successfully!");
            }
            else
            {
                MessageBox.Show("Conversion failed. Output file was not created.");
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            // Select multiple video files
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov;*.wmv;*.mkv|All Files|*.*";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputDir = label7.Text;
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
                }
            }
        }
    }
}
