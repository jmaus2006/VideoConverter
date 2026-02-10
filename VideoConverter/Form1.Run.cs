using System.Diagnostics;
using System.Globalization;

namespace VideoConverter;

public partial class Form1 : Form
{
    private async void btnRun_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(pendingArgs) || string.IsNullOrWhiteSpace(pendingOutputFile) ||
            string.IsNullOrWhiteSpace(pendingInputFile) || string.IsNullOrWhiteSpace(pendingOutputDir))
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

        ffmpegProcess = new Process();
        ffmpegProcess.StartInfo.FileName = GetBundledExePath("ffmpeg.exe");
        ffmpegProcess.StartInfo.Arguments = pendingArgs;
        ffmpegProcess.StartInfo.UseShellExecute = false;
        ffmpegProcess.StartInfo.RedirectStandardOutput = true;
        ffmpegProcess.StartInfo.RedirectStandardError = true;
        ffmpegProcess.StartInfo.CreateNoWindow = true;
        ffmpegProcess.EnableRaisingEvents = true;
        ffmpegProcess.Start();
        await Task.Run(() =>
        {
            string line;
            var stderr = ffmpegProcess.StandardError;
            var ffmpegStart = DateTime.Now;
            while ((line = stderr.ReadLine()) != null)
            {
                var time = ParseFfmpegTime(line);
                var percent = 0;
                if (time != null && duration.Value.TotalSeconds > 0)
                {
                    percent = (int)(time.Value.TotalSeconds / duration.Value.TotalSeconds * 100);
                    if (percent > 100) percent = 100;
                    Invoke(() =>
                    {
                        progressBar1.Value = percent;
                        labelProgress.Text = percent + "%";
                        progressBarBluRayTab.Value = percent;
                        labelProgressBluray.Text = percent + "%";
                    });
                }

                // Only check speed after 8 seconds from ffmpeg start
                if ((DateTime.Now - ffmpegStart).TotalSeconds > 8)
                {
                    var speedIdx = line.IndexOf("speed=");
                    if (speedIdx != -1)
                    {
                        var xIdx = line.IndexOf('x', speedIdx);
                        if (xIdx > speedIdx)
                        {
                            var speedStr = line.Substring(speedIdx + 6, xIdx - (speedIdx + 6));
                            if (double.TryParse(speedStr, NumberStyles.Float, CultureInfo.InvariantCulture,
                                    out var speedVal))
                                if (speedVal < 1.5)
                                {
                                    try
                                    {
                                        ffmpegProcess.Kill();
                                    }
                                    catch
                                    {
                                    }

                                    Invoke(() =>
                                    {
                                        logOutput.Clear();
                                        progressBar1.Value = 0;
                                        labelProgress.Text = "0%";
                                        progressBarBluRayTab.Value = 0;
                                        labelProgressBluray.Text = "0%";
                                        MessageBox.Show(
                                            "Conversion failed: This is likely due to a file parameter mismatch or performance issue.",
                                            "Conversion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    });
                                    return;
                                }
                        }
                    }
                }

                // Append ffmpeg output to logOutput RichTextBox in real time
                Invoke(() => { logOutput.AppendText(line + Environment.NewLine); });
            }

            ffmpegProcess.WaitForExit();
        });

        if (File.Exists(pendingOutputFile))
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

        // Clear/reset video info labels after conversion
        lblFpsValue.Text = string.Empty;
        lblBitrateValue.Text = string.Empty;
        lblCodecValue.Text = "No video selected";
        lblCodecValue.ForeColor = Color.Black;
        lblAudioCodec.Text = string.Empty;
        selectedVideoInfo = null;

        btnRun.Enabled = false;
        txtArgs.Text = string.Empty;
        pendingArgs = string.Empty;
        pendingOutputFile = string.Empty;
        pendingInputFile = string.Empty;
        pendingOutputDir = string.Empty;
        pendingDuration = null;
    }
}