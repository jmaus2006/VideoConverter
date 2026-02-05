namespace VideoConverter
{
    public partial class Form1 : Form
    {
              private async void btnConvert_Click(object sender, EventArgs e)
        {
            // Get input file and output directory
            string inputFile = lblSelectedFile.Text;
            string outputDir = lblOutputDir.Text;
            string newFileName = txtFileName.Text.Trim();
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
            // Validate inputs
            if (validateInputs(inputFile, outputDir)) return;

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

            //1920x816 (2.35:1) with black bars (letterboxing) to 1920x1080
            string aspectRatioParam = "crop=1920:816:0:132,pad=1920:1080:0:132,unsharp=5:5:0.8:3:3:0.0";
            bool isRatioModified = checkboxAspectRatio != null && checkboxAspectRatio.Checked;
            if (interpolation.Equals("minterpolate", StringComparison.OrdinalIgnoreCase))
            {
                vfArg = isRatioModified
                    ? $"-vf \"minterpolate=fps={frameRate},{aspectRatioParam}\" "
                    : $"-vf \"minterpolate=fps={frameRate}\" ";
                rArg = "";
            }
            else if (interpolation.Equals("tblend", StringComparison.OrdinalIgnoreCase))
            {
                vfArg = isRatioModified
                    ? $"-vf \"tblend=all_mode=average,{aspectRatioParam}\" "
                    : "-vf \"tblend=all_mode=average\" ";
            }
            else if (interpolation.Equals("None", StringComparison.OrdinalIgnoreCase))
            {
                if (rArg != "")
                {
                    vfArg = isRatioModified
                        ? $"-vf \"{aspectRatioParam}\" "
                        : $"-vf \"framerate={frameRate}\" ";
                    rArg = "";
                }
                else
                {
                    vfArg = isRatioModified
                        ? $"-vf \"{aspectRatioParam}\" "
                        : "";
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
                if (frameRate == "24000/1001")
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

        private static bool validateInputs(string inputFile, string outputDir)
        {
            if (string.IsNullOrWhiteSpace(inputFile) && string.IsNullOrWhiteSpace(outputDir))
            {
                MessageBox.Show("Please select both an input file and output directory.");
                return true;
            }
            if (string.IsNullOrWhiteSpace(inputFile))
            {
                MessageBox.Show("You must select an input video file before converting.", "Missing Input File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            if (string.IsNullOrWhiteSpace(outputDir))
            {
                MessageBox.Show("You must select an output folder before converting.", "Missing Output Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }
    }
}
