namespace VideoConverter
{
    public partial class Form1 : Form
    {
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
                    if (fileOrderDialog.ShowDialog() != DialogResult.OK) return;
                    
                    var orderedFiles = fileOrderDialog.OrderedFiles;

                    // Validate all files: must be 1080p and AC3 audio
                    foreach (var file in orderedFiles)
                    {
                        var info = GetVideoInfo(file);
                        if (info == null || info.AudioCodec == null || info.Height == null || info.Height != 1080 || !info.AudioCodec.ToLower().Contains("ac3"))
                        {
                            MessageBox.Show($"File '{Path.GetFileName(file)}' is not Blu-ray compliant. Only 1080p video with AC3 audio is allowed.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    CreateBluRayFiles(bdmvDirs, mergedSTREAM, mergedPLAYLIST, mergedCLIPINF);

                    RemoveTempFiles(bdmvDirs, outputDir);

                    // Reset progress bar
                    MessageBox.Show("Blu-ray folder created successfully!");
                    await Task.Delay(1000);
                    progressBar1.Value = 0;
                    labelProgress.Text = "0%";
                    progressBarBluRayTab.Value = 0;
                    labelProgressBluray.Text = "0%";

                    // Launch ImgBurn if checkbox is checked
                    OpenImgBurn(mergedBDMV);
                }
            }
        }

        private void OpenImgBurn(string mergedBDMV)
        {
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

        private static void RemoveTempFiles(string[] bdmvDirs, string outputDir)
        {
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
            try
            {
                var metaFilesToDelete = Directory.GetFiles(outputDir, "bluray*.meta");
                foreach (var meta in metaFilesToDelete)
                {
                    try { File.Delete(meta); } catch { }
                }
            }
            catch { }
            try
            {
                var concatFilesToDelete = Directory.GetFiles(outputDir, "vidClip_*.txt");
                foreach (var concatFile in concatFilesToDelete)
                {
                    try { File.Delete(concatFile); } catch { }
                }
            }
            catch { }
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
            CreateBluRayFiles(bdmvDirs, mergedSTREAM, mergedPLAYLIST, mergedCLIPINF);
            RemoveTempFiles(bdmvDirs, outputDir);

            // Reset progress bar
            MessageBox.Show("Blu-ray folder created successfully!");
            await Task.Delay(1000);
            progressBar1.Value = 0;
            labelProgress.Text = "0%";
            progressBarBluRayTab.Value = 0;
            labelProgressBluray.Text = "0%";

            // Launch ImgBurn if checkbox is checked
            OpenImgBurn(mergedBDMV);
        }

        private static void CreateBluRayFiles(string[] bdmvDirs, string mergedSTREAM, string mergedPLAYLIST,
            string mergedCLIPINF)
        {
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
        }
    }
}
