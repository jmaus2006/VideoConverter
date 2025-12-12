namespace VideoConverter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSelectVid = new Button();
            lblSelectedFile = new Label();
            comboBoxFrameRate = new ComboBox();
            comboBoxBitrate = new ComboBox();
            comboBoxCodec = new ComboBox();
            comboBoxInterpolation = new ComboBox();
            lblFps = new Label();
            lblBitrate = new Label();
            lblCodec = new Label();
            lblInterpolate = new Label();
            btnConvert = new Button();
            lblOutputDir = new Label();
            btnOutputDir = new Button();
            progressBar1 = new ProgressBar();
            labelProgress = new Label();
            txtFileName = new TextBox();
            btnConcat = new Button();
            txtArgs = new TextBox();
            btnRun = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnSelectVid
            // 
            btnSelectVid.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelectVid.Location = new Point(27, 24);
            btnSelectVid.Name = "btnSelectVid";
            btnSelectVid.Size = new Size(337, 53);
            btnSelectVid.TabIndex = 0;
            btnSelectVid.Text = "Select Video";
            btnSelectVid.UseVisualStyleBackColor = true;
            btnSelectVid.Click += btnSelectVid_Click;
            // 
            // lblSelectedFile
            // 
            lblSelectedFile.AutoSize = true;
            lblSelectedFile.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelectedFile.Location = new Point(24, 80);
            lblSelectedFile.Name = "lblSelectedFile";
            lblSelectedFile.Size = new Size(0, 32);
            lblSelectedFile.TabIndex = 1;
            // 
            // comboBoxFrameRate
            // 
            comboBoxFrameRate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFrameRate.FormattingEnabled = true;
            comboBoxFrameRate.Items.AddRange(new object[] { "23.976", "24", "25", "29.97", "50", "59.94" });
            comboBoxFrameRate.Location = new Point(195, 115);
            comboBoxFrameRate.Name = "comboBoxFrameRate";
            comboBoxFrameRate.Size = new Size(223, 33);
            comboBoxFrameRate.TabIndex = 2;
            // 
            // comboBoxBitrate
            // 
            comboBoxBitrate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBitrate.FormattingEnabled = true;
            comboBoxBitrate.Items.AddRange(new object[] { "12M", "13M", "14M", "15M", "18M", "20M", "21M", "22M", "23M", "24M", "25M", "26M", "27M", "28M", "29M", "30M", "35M" });
            comboBoxBitrate.Location = new Point(195, 165);
            comboBoxBitrate.Name = "comboBoxBitrate";
            comboBoxBitrate.Size = new Size(223, 33);
            comboBoxBitrate.TabIndex = 3;
            // 
            // comboBoxCodec
            // 
            comboBoxCodec.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCodec.Items.AddRange(new object[] { "libx264", "mpeg2video", "vc1" });
            comboBoxCodec.Location = new Point(195, 215);
            comboBoxCodec.Name = "comboBoxCodec";
            comboBoxCodec.Size = new Size(223, 33);
            comboBoxCodec.TabIndex = 4;
            // 
            // comboBoxInterpolation
            // 
            comboBoxInterpolation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxInterpolation.FormattingEnabled = true;
            comboBoxInterpolation.Items.AddRange(new object[] { "minterpolate", "tblend", "None" });
            comboBoxInterpolation.Location = new Point(195, 265);
            comboBoxInterpolation.Name = "comboBoxInterpolation";
            comboBoxInterpolation.Size = new Size(223, 33);
            comboBoxInterpolation.TabIndex = 5;
            // 
            // lblFps
            // 
            lblFps.AutoSize = true;
            lblFps.Location = new Point(27, 115);
            lblFps.Name = "lblFps";
            lblFps.Size = new Size(162, 25);
            lblFps.TabIndex = 6;
            lblFps.Text = "Frames per second";
            // 
            // lblBitrate
            // 
            lblBitrate.AutoSize = true;
            lblBitrate.Location = new Point(27, 165);
            lblBitrate.Name = "lblBitrate";
            lblBitrate.Size = new Size(62, 25);
            lblBitrate.TabIndex = 7;
            lblBitrate.Text = "Bitrate";
            // 
            // lblCodec
            // 
            lblCodec.AutoSize = true;
            lblCodec.Location = new Point(27, 215);
            lblCodec.Name = "lblCodec";
            lblCodec.Size = new Size(62, 25);
            lblCodec.TabIndex = 8;
            lblCodec.Text = "Codec";
            // 
            // lblInterpolate
            // 
            lblInterpolate.AutoSize = true;
            lblInterpolate.Location = new Point(27, 265);
            lblInterpolate.Name = "lblInterpolate";
            lblInterpolate.Size = new Size(114, 25);
            lblInterpolate.TabIndex = 9;
            lblInterpolate.Text = "Interpolation";
            // 
            // btnConvert
            // 
            btnConvert.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConvert.Location = new Point(422, 397);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(355, 80);
            btnConvert.TabIndex = 8;
            btnConvert.Text = "Create ffmpeg parameters";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // lblOutputDir
            // 
            lblOutputDir.AutoSize = true;
            lblOutputDir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOutputDir.Location = new Point(27, 480);
            lblOutputDir.Name = "lblOutputDir";
            lblOutputDir.Size = new Size(0, 32);
            lblOutputDir.TabIndex = 13;
            // 
            // btnOutputDir
            // 
            btnOutputDir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOutputDir.Location = new Point(27, 397);
            btnOutputDir.Name = "btnOutputDir";
            btnOutputDir.Size = new Size(373, 80);
            btnOutputDir.TabIndex = 7;
            btnOutputDir.Text = "Select Output Directory";
            btnOutputDir.UseVisualStyleBackColor = true;
            btnOutputDir.Click += btnOutputDir_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(24, 531);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(557, 23);
            progressBar1.TabIndex = 14;
            // 
            // labelProgress
            // 
            labelProgress.Location = new Point(588, 531);
            labelProgress.Name = "labelProgress";
            labelProgress.Size = new Size(50, 23);
            labelProgress.TabIndex = 15;
            labelProgress.Text = "0%";
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(27, 333);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(391, 31);
            txtFileName.TabIndex = 6;
            // 
            // btnConcat
            // 
            btnConcat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConcat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConcat.Location = new Point(440, 24);
            btnConcat.Name = "btnConcat";
            btnConcat.Size = new Size(337, 53);
            btnConcat.TabIndex = 1;
            btnConcat.Text = "Concatenate Videos";
            btnConcat.UseVisualStyleBackColor = true;
            btnConcat.Click += btnConcat_Click;
            // 
            // txtArgs
            // 
            txtArgs.BackColor = SystemColors.ControlLightLight;
            txtArgs.Location = new Point(24, 570);
            txtArgs.Multiline = true;
            txtArgs.Name = "txtArgs";
            txtArgs.ReadOnly = true;
            txtArgs.Size = new Size(558, 100);
            txtArgs.TabIndex = 9;
            // 
            // btnRun
            // 
            btnRun.Enabled = false;
            btnRun.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRun.Location = new Point(588, 570);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(189, 100);
            btnRun.TabIndex = 10;
            btnRun.Text = "Convert";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(422, 339);
            label1.Name = "label1";
            label1.Size = new Size(167, 25);
            label1.TabIndex = 21;
            label1.Text = "File Name to Create";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 714);
            Controls.Add(label1);
            Controls.Add(btnConcat);
            Controls.Add(txtFileName);
            Controls.Add(lblOutputDir);
            Controls.Add(btnOutputDir);
            Controls.Add(btnConvert);
            Controls.Add(lblInterpolate);
            Controls.Add(lblCodec);
            Controls.Add(lblBitrate);
            Controls.Add(lblFps);
            Controls.Add(comboBoxInterpolation);
            Controls.Add(comboBoxCodec);
            Controls.Add(comboBoxBitrate);
            Controls.Add(comboBoxFrameRate);
            Controls.Add(lblSelectedFile);
            Controls.Add(btnSelectVid);
            Controls.Add(progressBar1);
            Controls.Add(labelProgress);
            Controls.Add(txtArgs);
            Controls.Add(btnRun);
            Name = "Form1";
            Text = "Video Converter 1.0";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSelectVid;
        private Label lblSelectedFile;
        private ComboBox comboBoxFrameRate;
        private ComboBox comboBoxBitrate;
        private ComboBox comboBoxCodec;
        private ComboBox comboBoxInterpolation;
        private Label lblFps;
        private Label lblBitrate;
        private Label lblCodec;
        private Label lblInterpolate;
        private Button btnConvert;
        private Label lblOutputDir;
        private Button btnOutputDir;
        private ProgressBar progressBar1;
        private Label labelProgress;
        private TextBox txtFileName;
        private Button btnConcat;
        private TextBox txtArgs;
        private Button btnRun;
        private Label label1;
    }
}
