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
            lblFpsValue = new Label();
            lblBitrateValue = new Label();
            lblCodecValue = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            checkboxMKV = new CheckBox();
            btnGenerateBluray = new Button();
            label2 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelectVid
            // 
            btnSelectVid.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            comboBoxFrameRate.Location = new Point(195, 52);
            comboBoxFrameRate.Name = "comboBoxFrameRate";
            comboBoxFrameRate.Size = new Size(223, 37);
            comboBoxFrameRate.TabIndex = 2;
            // 
            // comboBoxBitrate
            // 
            comboBoxBitrate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBitrate.FormattingEnabled = true;
            comboBoxBitrate.Items.AddRange(new object[] { "12M", "13M", "14M", "15M", "18M", "20M", "21M", "22M", "23M", "24M", "25M", "26M", "27M", "28M", "29M", "30M", "35M" });
            comboBoxBitrate.Location = new Point(195, 102);
            comboBoxBitrate.Name = "comboBoxBitrate";
            comboBoxBitrate.Size = new Size(223, 37);
            comboBoxBitrate.TabIndex = 3;
            // 
            // comboBoxCodec
            // 
            comboBoxCodec.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCodec.Items.AddRange(new object[] { "libx264", "mpeg2video", "vc1" });
            comboBoxCodec.Location = new Point(195, 152);
            comboBoxCodec.Name = "comboBoxCodec";
            comboBoxCodec.Size = new Size(223, 37);
            comboBoxCodec.TabIndex = 4;
            // 
            // comboBoxInterpolation
            // 
            comboBoxInterpolation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxInterpolation.FormattingEnabled = true;
            comboBoxInterpolation.Items.AddRange(new object[] { "minterpolate", "tblend", "None" });
            comboBoxInterpolation.Location = new Point(195, 202);
            comboBoxInterpolation.Name = "comboBoxInterpolation";
            comboBoxInterpolation.Size = new Size(223, 37);
            comboBoxInterpolation.TabIndex = 5;
            // 
            // lblFps
            // 
            lblFps.AutoSize = true;
            lblFps.Location = new Point(14, 55);
            lblFps.Name = "lblFps";
            lblFps.Size = new Size(183, 29);
            lblFps.TabIndex = 6;
            lblFps.Text = "Frames per second";
            // 
            // lblBitrate
            // 
            lblBitrate.AutoSize = true;
            lblBitrate.Location = new Point(120, 105);
            lblBitrate.Name = "lblBitrate";
            lblBitrate.Size = new Size(69, 29);
            lblBitrate.TabIndex = 7;
            lblBitrate.Text = "Bitrate";
            // 
            // lblCodec
            // 
            lblCodec.AutoSize = true;
            lblCodec.Location = new Point(122, 152);
            lblCodec.Name = "lblCodec";
            lblCodec.Size = new Size(70, 29);
            lblCodec.TabIndex = 8;
            lblCodec.Text = "Codec";
            // 
            // lblInterpolate
            // 
            lblInterpolate.AutoSize = true;
            lblInterpolate.Location = new Point(63, 202);
            lblInterpolate.Name = "lblInterpolate";
            lblInterpolate.Size = new Size(119, 29);
            lblInterpolate.TabIndex = 9;
            lblInterpolate.Text = "Interpolation";
            // 
            // btnConvert
            // 
            btnConvert.Font = new Font("Arial Narrow", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConvert.Location = new Point(431, 487);
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
            lblOutputDir.Location = new Point(33, 573);
            lblOutputDir.Name = "lblOutputDir";
            lblOutputDir.Size = new Size(0, 32);
            lblOutputDir.TabIndex = 13;
            // 
            // btnOutputDir
            // 
            btnOutputDir.Font = new Font("Arial Narrow", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOutputDir.Location = new Point(36, 487);
            btnOutputDir.Name = "btnOutputDir";
            btnOutputDir.Size = new Size(373, 80);
            btnOutputDir.TabIndex = 7;
            btnOutputDir.Text = "Select Output Directory";
            btnOutputDir.UseVisualStyleBackColor = true;
            btnOutputDir.Click += btnOutputDir_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(33, 621);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(630, 33);
            progressBar1.TabIndex = 14;
            // 
            // labelProgress
            // 
            labelProgress.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelProgress.Location = new Point(670, 611);
            labelProgress.Name = "labelProgress";
            labelProgress.Size = new Size(69, 50);
            labelProgress.TabIndex = 15;
            labelProgress.Text = "0%";
            labelProgress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(574, 423);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(324, 31);
            txtFileName.TabIndex = 6;
            // 
            // btnConcat
            // 
            btnConcat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConcat.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConcat.Location = new Point(635, 24);
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
            txtArgs.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtArgs.Location = new Point(33, 674);
            txtArgs.Multiline = true;
            txtArgs.Name = "txtArgs";
            txtArgs.ReadOnly = true;
            txtArgs.Size = new Size(342, 240);
            txtArgs.TabIndex = 9;
            // 
            // btnRun
            // 
            btnRun.Enabled = false;
            btnRun.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRun.Location = new Point(381, 674);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(282, 100);
            btnRun.TabIndex = 10;
            btnRun.Text = "Run ffmpeg parameters";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(431, 423);
            label1.Name = "label1";
            label1.Size = new Size(146, 29);
            label1.TabIndex = 21;
            label1.Text = "New File Name";
            // 
            // lblFpsValue
            // 
            lblFpsValue.Location = new Point(78, 52);
            lblFpsValue.Name = "lblFpsValue";
            lblFpsValue.Size = new Size(250, 30);
            lblFpsValue.TabIndex = 21;
            // 
            // lblBitrateValue
            // 
            lblBitrateValue.Location = new Point(78, 102);
            lblBitrateValue.Name = "lblBitrateValue";
            lblBitrateValue.Size = new Size(250, 30);
            lblBitrateValue.TabIndex = 22;
            // 
            // lblCodecValue
            // 
            lblCodecValue.Location = new Point(78, 152);
            lblCodecValue.Name = "lblCodecValue";
            lblCodecValue.Size = new Size(250, 30);
            lblCodecValue.TabIndex = 23;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblCodecValue);
            groupBox1.Controls.Add(lblBitrateValue);
            groupBox1.Controls.Add(lblFpsValue);
            groupBox1.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(36, 124);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(383, 274);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Video Info";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBoxFrameRate);
            groupBox2.Controls.Add(comboBoxBitrate);
            groupBox2.Controls.Add(comboBoxCodec);
            groupBox2.Controls.Add(comboBoxInterpolation);
            groupBox2.Controls.Add(lblFps);
            groupBox2.Controls.Add(lblBitrate);
            groupBox2.Controls.Add(lblCodec);
            groupBox2.Controls.Add(lblInterpolate);
            groupBox2.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(444, 124);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(453, 274);
            groupBox2.TabIndex = 26;
            groupBox2.TabStop = false;
            groupBox2.Text = "New Parameters";
            // 
            // checkboxMKV
            // 
            checkboxMKV.AutoSize = true;
            checkboxMKV.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkboxMKV.Location = new Point(745, 619);
            checkboxMKV.Name = "checkboxMKV";
            checkboxMKV.Size = new Size(182, 33);
            checkboxMKV.TabIndex = 27;
            checkboxMKV.Text = "Create MKV File";
            checkboxMKV.UseVisualStyleBackColor = true;
            // 
            // btnGenerateBluray
            // 
            btnGenerateBluray.BackgroundImage = Properties.Resources.bluray;
            btnGenerateBluray.BackgroundImageLayout = ImageLayout.Stretch;
            btnGenerateBluray.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerateBluray.ImageAlign = ContentAlignment.TopRight;
            btnGenerateBluray.Location = new Point(670, 674);
            btnGenerateBluray.Name = "btnGenerateBluray";
            btnGenerateBluray.Size = new Size(321, 240);
            btnGenerateBluray.TabIndex = 30;
            btnGenerateBluray.UseVisualStyleBackColor = true;
            btnGenerateBluray.Click += btnGenerateBluray_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(381, 852);
            label2.Name = "label2";
            label2.Size = new Size(283, 46);
            label2.TabIndex = 31;
            label2.Text = "Click to Create -->";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1003, 944);
            Controls.Add(label2);
            Controls.Add(btnGenerateBluray);
            Controls.Add(checkboxMKV);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(btnConcat);
            Controls.Add(txtFileName);
            Controls.Add(lblOutputDir);
            Controls.Add(btnOutputDir);
            Controls.Add(btnConvert);
            Controls.Add(lblSelectedFile);
            Controls.Add(btnSelectVid);
            Controls.Add(progressBar1);
            Controls.Add(labelProgress);
            Controls.Add(txtArgs);
            Controls.Add(btnRun);
            Name = "Form1";
            Text = "Video Converter 1.1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
        private Label lblFpsValue;
        private Label lblBitrateValue;
        private Label lblCodecValue;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox checkboxMKV;
        private Button btnGenerateBluray;
        private Label label2;
    }
}
