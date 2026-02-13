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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            lblNewFileName = new Label();
            lblFpsValue = new Label();
            lblBitrateValue = new Label();
            lblCodecValue = new Label();
            groupBox1 = new GroupBox();
            lblAudioCodec = new Label();
            tabControl1 = new TabControl();
            ConverterTab = new TabPage();
            btnCancelConvert = new Button();
            pictureBox4 = new PictureBox();
            label8 = new Label();
            pictureBox1 = new PictureBox();
            btnCopyParameters = new Button();
            groupBox3 = new GroupBox();
            ratioChoice = new ComboBox();
            label11 = new Label();
            btnAudioOnly = new CheckBox();
            checkboxAspectRatio = new CheckBox();
            label4 = new Label();
            checkboxAC3 = new CheckBox();
            comboBoxAudioBitrate = new ComboBox();
            checkboxMKV = new CheckBox();
            groupBox2 = new GroupBox();
            BlurayTab = new TabPage();
            lblVersionNum = new Label();
            pictureBox2 = new PictureBox();
            lblWithImgBurn = new Label();
            ImgBurnLocationLabel = new Label();
            btnImgBurnLocation = new Button();
            checkboxImgBurn = new CheckBox();
            lblCreateBlu = new Label();
            labelProgressBluray = new Label();
            progressBarBluRayTab = new ProgressBar();
            lblOutputDirectoryBlurayTab = new Label();
            outputDirectoryButtonBlurayTab = new Button();
            lblBDMV = new Label();
            lblMKV = new Label();
            btnGenerateBlurayBlurayTab = new Button();
            stepsToConvertTab = new TabPage();
            lblVer = new Label();
            pictureBox3 = new PictureBox();
            lblHowTo = new Label();
            richTextBox1 = new RichTextBox();
            tabPage1 = new TabPage();
            btnCopyLogOutput = new Button();
            logOutput = new RichTextBox();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            ConverterTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            BlurayTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            stepsToConvertTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelectVid
            // 
            btnSelectVid.BackColor = SystemColors.Control;
            btnSelectVid.BackgroundImage = Properties.Resources.xSelectVideo;
            btnSelectVid.BackgroundImageLayout = ImageLayout.Zoom;
            btnSelectVid.FlatAppearance.BorderSize = 0;
            btnSelectVid.FlatStyle = FlatStyle.Flat;
            btnSelectVid.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelectVid.Location = new Point(67, 36);
            btnSelectVid.Name = "btnSelectVid";
            btnSelectVid.Size = new Size(373, 54);
            btnSelectVid.TabIndex = 0;
            btnSelectVid.UseVisualStyleBackColor = false;
            btnSelectVid.Click += btnSelectVid_Click;
            // 
            // lblSelectedFile
            // 
            lblSelectedFile.AutoSize = true;
            lblSelectedFile.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelectedFile.Location = new Point(67, 210);
            lblSelectedFile.Name = "lblSelectedFile";
            lblSelectedFile.Size = new Size(0, 28);
            lblSelectedFile.TabIndex = 1;
            lblSelectedFile.TextChanged += lblSelectedFile_TextChanged;
            // 
            // comboBoxFrameRate
            // 
            comboBoxFrameRate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFrameRate.FormattingEnabled = true;
            comboBoxFrameRate.Items.AddRange(new object[] { "Same as source", "23.976", "24", "25", "29.97", "30", "50", "59.94", "60" });
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
            lblFps.Location = new Point(8, 55);
            lblFps.Name = "lblFps";
            lblFps.Size = new Size(183, 29);
            lblFps.TabIndex = 6;
            lblFps.Text = "Frames per second";
            // 
            // lblBitrate
            // 
            lblBitrate.AutoSize = true;
            lblBitrate.Location = new Point(65, 104);
            lblBitrate.Name = "lblBitrate";
            lblBitrate.Size = new Size(124, 29);
            lblBitrate.TabIndex = 7;
            lblBitrate.Text = "Video Bitrate";
            // 
            // lblCodec
            // 
            lblCodec.AutoSize = true;
            lblCodec.Location = new Point(62, 152);
            lblCodec.Name = "lblCodec";
            lblCodec.Size = new Size(125, 29);
            lblCodec.TabIndex = 8;
            lblCodec.Text = "Video Codec";
            // 
            // lblInterpolate
            // 
            lblInterpolate.AutoSize = true;
            lblInterpolate.Location = new Point(69, 202);
            lblInterpolate.Name = "lblInterpolate";
            lblInterpolate.Size = new Size(119, 29);
            lblInterpolate.TabIndex = 9;
            lblInterpolate.Text = "Interpolation";
            // 
            // btnConvert
            // 
            btnConvert.BackgroundImage = Properties.Resources.xCreateFfmpegParameters;
            btnConvert.BackgroundImageLayout = ImageLayout.Zoom;
            btnConvert.FlatAppearance.BorderSize = 0;
            btnConvert.FlatStyle = FlatStyle.Flat;
            btnConvert.Font = new Font("Arial Narrow", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConvert.Location = new Point(440, 638);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(383, 80);
            btnConvert.TabIndex = 8;
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // lblOutputDir
            // 
            lblOutputDir.AutoSize = true;
            lblOutputDir.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOutputDir.Location = new Point(67, 729);
            lblOutputDir.Name = "lblOutputDir";
            lblOutputDir.Size = new Size(0, 28);
            lblOutputDir.TabIndex = 13;
            // 
            // btnOutputDir
            // 
            btnOutputDir.BackgroundImage = Properties.Resources.xSelectOutputFolder;
            btnOutputDir.BackgroundImageLayout = ImageLayout.Zoom;
            btnOutputDir.FlatAppearance.BorderSize = 0;
            btnOutputDir.FlatStyle = FlatStyle.Flat;
            btnOutputDir.Font = new Font("Arial Narrow", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOutputDir.Location = new Point(52, 638);
            btnOutputDir.Name = "btnOutputDir";
            btnOutputDir.Size = new Size(373, 80);
            btnOutputDir.TabIndex = 7;
            btnOutputDir.UseVisualStyleBackColor = true;
            btnOutputDir.Click += btnOutputDir_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(67, 945);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(943, 50);
            progressBar1.TabIndex = 14;
            // 
            // labelProgress
            // 
            labelProgress.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelProgress.Location = new Point(1016, 945);
            labelProgress.Name = "labelProgress";
            labelProgress.Size = new Size(69, 50);
            labelProgress.TabIndex = 15;
            labelProgress.Text = "0%";
            labelProgress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtFileName
            // 
            txtFileName.Font = new Font("Arial Narrow", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFileName.Location = new Point(667, 570);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(261, 40);
            txtFileName.TabIndex = 6;
            txtFileName.TextChanged += txtFileName_TextChanged;
            // 
            // btnConcat
            // 
            btnConcat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConcat.BackgroundImage = Properties.Resources.xJoinMultipleVideos;
            btnConcat.BackgroundImageLayout = ImageLayout.Zoom;
            btnConcat.FlatAppearance.BorderSize = 0;
            btnConcat.FlatStyle = FlatStyle.Flat;
            btnConcat.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConcat.Location = new Point(67, 126);
            btnConcat.Name = "btnConcat";
            btnConcat.Size = new Size(373, 55);
            btnConcat.TabIndex = 1;
            btnConcat.UseVisualStyleBackColor = true;
            btnConcat.Click += btnConcat_Click;
            // 
            // txtArgs
            // 
            txtArgs.BackColor = SystemColors.ControlLightLight;
            txtArgs.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtArgs.Location = new Point(67, 780);
            txtArgs.Multiline = true;
            txtArgs.Name = "txtArgs";
            txtArgs.ReadOnly = true;
            txtArgs.Size = new Size(943, 150);
            txtArgs.TabIndex = 9;
            // 
            // btnRun
            // 
            btnRun.BackgroundImage = Properties.Resources.xConvertVideo;
            btnRun.BackgroundImageLayout = ImageLayout.Zoom;
            btnRun.Enabled = false;
            btnRun.FlatAppearance.BorderSize = 0;
            btnRun.FlatStyle = FlatStyle.Flat;
            btnRun.Font = new Font("Arial Narrow", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRun.Location = new Point(836, 636);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(380, 80);
            btnRun.TabIndex = 10;
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // lblNewFileName
            // 
            lblNewFileName.AutoSize = true;
            lblNewFileName.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewFileName.Location = new Point(515, 577);
            lblNewFileName.Name = "lblNewFileName";
            lblNewFileName.Size = new Size(146, 29);
            lblNewFileName.TabIndex = 21;
            lblNewFileName.Text = "New File Name";
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
            groupBox1.Controls.Add(lblAudioCodec);
            groupBox1.Controls.Add(lblCodecValue);
            groupBox1.Controls.Add(lblBitrateValue);
            groupBox1.Controls.Add(lblFpsValue);
            groupBox1.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(67, 275);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(383, 274);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Video Info";
            // 
            // lblAudioCodec
            // 
            lblAudioCodec.Location = new Point(78, 201);
            lblAudioCodec.Name = "lblAudioCodec";
            lblAudioCodec.Size = new Size(250, 30);
            lblAudioCodec.TabIndex = 24;
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.Buttons;
            tabControl1.Controls.Add(ConverterTab);
            tabControl1.Controls.Add(BlurayTab);
            tabControl1.Controls.Add(stepsToConvertTab);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1278, 1089);
            tabControl1.TabIndex = 9;
            // 
            // ConverterTab
            // 
            ConverterTab.BackColor = SystemColors.Control;
            ConverterTab.BackgroundImageLayout = ImageLayout.None;
            ConverterTab.Controls.Add(btnCancelConvert);
            ConverterTab.Controls.Add(pictureBox4);
            ConverterTab.Controls.Add(label8);
            ConverterTab.Controls.Add(pictureBox1);
            ConverterTab.Controls.Add(btnCopyParameters);
            ConverterTab.Controls.Add(btnSelectVid);
            ConverterTab.Controls.Add(lblOutputDir);
            ConverterTab.Controls.Add(btnConcat);
            ConverterTab.Controls.Add(lblSelectedFile);
            ConverterTab.Controls.Add(groupBox3);
            ConverterTab.Controls.Add(btnRun);
            ConverterTab.Controls.Add(txtArgs);
            ConverterTab.Controls.Add(labelProgress);
            ConverterTab.Controls.Add(progressBar1);
            ConverterTab.Controls.Add(checkboxMKV);
            ConverterTab.Controls.Add(btnConvert);
            ConverterTab.Controls.Add(groupBox2);
            ConverterTab.Controls.Add(btnOutputDir);
            ConverterTab.Controls.Add(groupBox1);
            ConverterTab.Controls.Add(txtFileName);
            ConverterTab.Controls.Add(lblNewFileName);
            ConverterTab.Font = new Font("Arial Narrow", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ConverterTab.Location = new Point(4, 41);
            ConverterTab.Margin = new Padding(0);
            ConverterTab.Name = "ConverterTab";
            ConverterTab.Size = new Size(1270, 1044);
            ConverterTab.TabIndex = 1;
            ConverterTab.Text = "Convert";
            // 
            // btnCancelConvert
            // 
            btnCancelConvert.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelConvert.Location = new Point(1017, 778);
            btnCancelConvert.Name = "btnCancelConvert";
            btnCancelConvert.Size = new Size(197, 94);
            btnCancelConvert.TabIndex = 38;
            btnCancelConvert.Text = "Cancel Conversion";
            btnCancelConvert.UseVisualStyleBackColor = true;
            btnCancelConvert.Click += BtnCancelConvertClick;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(106, 555);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(344, 89);
            pictureBox4.TabIndex = 37;
            pictureBox4.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Arial Narrow", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.Location = new Point(1129, 174);
            label8.Name = "label8";
            label8.Size = new Size(54, 37);
            label8.TabIndex = 36;
            label8.Text = "2.4";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Video2BlurayBG;
            pictureBox1.Location = new Point(567, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(627, 202);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 35;
            pictureBox1.TabStop = false;
            // 
            // btnCopyParameters
            // 
            btnCopyParameters.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCopyParameters.Location = new Point(1017, 878);
            btnCopyParameters.Name = "btnCopyParameters";
            btnCopyParameters.Size = new Size(199, 52);
            btnCopyParameters.TabIndex = 34;
            btnCopyParameters.Text = "Copy Parameters";
            btnCopyParameters.UseVisualStyleBackColor = true;
            btnCopyParameters.Click += BtnCopyParametersClick;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(ratioChoice);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(btnAudioOnly);
            groupBox3.Controls.Add(checkboxAspectRatio);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(checkboxAC3);
            groupBox3.Controls.Add(comboBoxAudioBitrate);
            groupBox3.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(953, 275);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(241, 332);
            groupBox3.TabIndex = 33;
            groupBox3.TabStop = false;
            groupBox3.Text = "Additional Options";
            // 
            // ratioChoice
            // 
            ratioChoice.DropDownStyle = ComboBoxStyle.DropDownList;
            ratioChoice.FormattingEnabled = true;
            ratioChoice.Items.AddRange(new object[] { "1.85", "2.35", "2.39" });
            ratioChoice.Location = new Point(47, 194);
            ratioChoice.Name = "ratioChoice";
            ratioChoice.Size = new Size(183, 37);
            ratioChoice.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(19, 277);
            label11.Name = "label11";
            label11.Size = new Size(198, 29);
            label11.TabIndex = 11;
            label11.Text = "to blu-ray compliance";
            // 
            // btnAudioOnly
            // 
            btnAudioOnly.AutoSize = true;
            btnAudioOnly.Location = new Point(19, 241);
            btnAudioOnly.Name = "btnAudioOnly";
            btnAudioOnly.Size = new Size(201, 33);
            btnAudioOnly.TabIndex = 10;
            btnAudioOnly.Text = "Only change audio";
            btnAudioOnly.UseVisualStyleBackColor = true;
            btnAudioOnly.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkboxAspectRatio
            // 
            checkboxAspectRatio.AutoSize = true;
            checkboxAspectRatio.Location = new Point(19, 158);
            checkboxAspectRatio.Name = "checkboxAspectRatio";
            checkboxAspectRatio.Size = new Size(159, 33);
            checkboxAspectRatio.TabIndex = 9;
            checkboxAspectRatio.Text = "Force ratio to:";
            checkboxAspectRatio.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 105);
            label4.Name = "label4";
            label4.Size = new Size(69, 29);
            label4.TabIndex = 8;
            label4.Text = "Bitrate";
            // 
            // checkboxAC3
            // 
            checkboxAC3.AutoSize = true;
            checkboxAC3.Location = new Point(19, 61);
            checkboxAC3.Name = "checkboxAC3";
            checkboxAC3.Size = new Size(211, 33);
            checkboxAC3.TabIndex = 0;
            checkboxAC3.Text = "AC3 Audio (blu-ray)";
            checkboxAC3.UseVisualStyleBackColor = true;
            checkboxAC3.CheckedChanged += checkboxAC3_CheckedChanged;
            // 
            // comboBoxAudioBitrate
            // 
            comboBoxAudioBitrate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAudioBitrate.FormattingEnabled = true;
            comboBoxAudioBitrate.Items.AddRange(new object[] { "Original", "192k", "224k", "256k", "320k", "384k", "448k", "512k", "640k" });
            comboBoxAudioBitrate.Location = new Point(91, 99);
            comboBoxAudioBitrate.Name = "comboBoxAudioBitrate";
            comboBoxAudioBitrate.Size = new Size(139, 37);
            comboBoxAudioBitrate.TabIndex = 1;
            comboBoxAudioBitrate.SelectedIndexChanged += comboBoxAudioBitrate_SelectedIndexChanged;
            // 
            // checkboxMKV
            // 
            checkboxMKV.AutoSize = true;
            checkboxMKV.Font = new Font("Arial Narrow", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkboxMKV.Location = new Point(78, 585);
            checkboxMKV.Name = "checkboxMKV";
            checkboxMKV.Size = new Size(22, 21);
            checkboxMKV.TabIndex = 27;
            checkboxMKV.UseVisualStyleBackColor = true;
            checkboxMKV.CheckedChanged += checkboxMKV_CheckedChanged;
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
            groupBox2.Location = new Point(475, 275);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(453, 274);
            groupBox2.TabIndex = 26;
            groupBox2.TabStop = false;
            groupBox2.Text = "Output Video";
            // 
            // BlurayTab
            // 
            BlurayTab.BackColor = SystemColors.Control;
            BlurayTab.Controls.Add(lblVersionNum);
            BlurayTab.Controls.Add(pictureBox2);
            BlurayTab.Controls.Add(lblWithImgBurn);
            BlurayTab.Controls.Add(ImgBurnLocationLabel);
            BlurayTab.Controls.Add(btnImgBurnLocation);
            BlurayTab.Controls.Add(checkboxImgBurn);
            BlurayTab.Controls.Add(lblCreateBlu);
            BlurayTab.Controls.Add(labelProgressBluray);
            BlurayTab.Controls.Add(progressBarBluRayTab);
            BlurayTab.Controls.Add(lblOutputDirectoryBlurayTab);
            BlurayTab.Controls.Add(outputDirectoryButtonBlurayTab);
            BlurayTab.Controls.Add(lblBDMV);
            BlurayTab.Controls.Add(lblMKV);
            BlurayTab.Controls.Add(btnGenerateBlurayBlurayTab);
            BlurayTab.Location = new Point(4, 41);
            BlurayTab.Name = "BlurayTab";
            BlurayTab.Padding = new Padding(3);
            BlurayTab.Size = new Size(1270, 1044);
            BlurayTab.TabIndex = 0;
            BlurayTab.Text = "Create Blu-ray";
            BlurayTab.Click += BlurayTab_Click;
            // 
            // lblVersionNum
            // 
            lblVersionNum.AutoSize = true;
            lblVersionNum.BackColor = Color.Transparent;
            lblVersionNum.Font = new Font("Arial Narrow", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblVersionNum.Location = new Point(1129, 174);
            lblVersionNum.Name = "lblVersionNum";
            lblVersionNum.Size = new Size(54, 37);
            lblVersionNum.TabIndex = 46;
            lblVersionNum.Text = "2.4";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Video2BlurayBG;
            pictureBox2.Location = new Point(567, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(627, 202);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 45;
            pictureBox2.TabStop = false;
            // 
            // lblWithImgBurn
            // 
            lblWithImgBurn.AutoSize = true;
            lblWithImgBurn.Font = new Font("Arial Narrow", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWithImgBurn.Location = new Point(904, 863);
            lblWithImgBurn.Name = "lblWithImgBurn";
            lblWithImgBurn.Size = new Size(148, 33);
            lblWithImgBurn.TabIndex = 44;
            lblWithImgBurn.Text = "with ImgBurn";
            // 
            // ImgBurnLocationLabel
            // 
            ImgBurnLocationLabel.AutoSize = true;
            ImgBurnLocationLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ImgBurnLocationLabel.Location = new Point(31, 122);
            ImgBurnLocationLabel.Name = "ImgBurnLocationLabel";
            ImgBurnLocationLabel.Size = new Size(0, 28);
            ImgBurnLocationLabel.TabIndex = 43;
            // 
            // btnImgBurnLocation
            // 
            btnImgBurnLocation.BackgroundImage = Properties.Resources.xSetImgBurnLocation;
            btnImgBurnLocation.BackgroundImageLayout = ImageLayout.Zoom;
            btnImgBurnLocation.FlatAppearance.BorderSize = 0;
            btnImgBurnLocation.FlatStyle = FlatStyle.Flat;
            btnImgBurnLocation.Font = new Font("Arial Narrow", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImgBurnLocation.Location = new Point(87, 24);
            btnImgBurnLocation.Name = "btnImgBurnLocation";
            btnImgBurnLocation.Size = new Size(373, 90);
            btnImgBurnLocation.TabIndex = 42;
            btnImgBurnLocation.UseVisualStyleBackColor = true;
            btnImgBurnLocation.Click += btnImgBurnLocation_Click;
            // 
            // checkboxImgBurn
            // 
            checkboxImgBurn.AutoSize = true;
            checkboxImgBurn.Font = new Font("Arial Narrow", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkboxImgBurn.Location = new Point(821, 823);
            checkboxImgBurn.Name = "checkboxImgBurn";
            checkboxImgBurn.Size = new Size(295, 37);
            checkboxImgBurn.TabIndex = 41;
            checkboxImgBurn.Text = "Burn Disc / Create Image";
            checkboxImgBurn.UseVisualStyleBackColor = true;
            // 
            // lblCreateBlu
            // 
            lblCreateBlu.AutoSize = true;
            lblCreateBlu.Font = new Font("Arial Narrow", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreateBlu.Location = new Point(222, 874);
            lblCreateBlu.Name = "lblCreateBlu";
            lblCreateBlu.Size = new Size(502, 42);
            lblCreateBlu.TabIndex = 40;
            lblCreateBlu.Text = "Drag all files at once to create blu-ray";
            // 
            // labelProgressBluray
            // 
            labelProgressBluray.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelProgressBluray.Location = new Point(1120, 945);
            labelProgressBluray.Name = "labelProgressBluray";
            labelProgressBluray.Size = new Size(69, 50);
            labelProgressBluray.TabIndex = 39;
            labelProgressBluray.Text = "0%";
            labelProgressBluray.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // progressBarBluRayTab
            // 
            progressBarBluRayTab.Location = new Point(171, 945);
            progressBarBluRayTab.Name = "progressBarBluRayTab";
            progressBarBluRayTab.Size = new Size(943, 50);
            progressBarBluRayTab.TabIndex = 38;
            // 
            // lblOutputDirectoryBlurayTab
            // 
            lblOutputDirectoryBlurayTab.AutoSize = true;
            lblOutputDirectoryBlurayTab.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOutputDirectoryBlurayTab.Location = new Point(87, 273);
            lblOutputDirectoryBlurayTab.Name = "lblOutputDirectoryBlurayTab";
            lblOutputDirectoryBlurayTab.Size = new Size(0, 28);
            lblOutputDirectoryBlurayTab.TabIndex = 37;
            // 
            // outputDirectoryButtonBlurayTab
            // 
            outputDirectoryButtonBlurayTab.BackgroundImage = Properties.Resources.xSelectOutputFolder;
            outputDirectoryButtonBlurayTab.BackgroundImageLayout = ImageLayout.Zoom;
            outputDirectoryButtonBlurayTab.FlatAppearance.BorderSize = 0;
            outputDirectoryButtonBlurayTab.FlatStyle = FlatStyle.Flat;
            outputDirectoryButtonBlurayTab.Font = new Font("Arial Narrow", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            outputDirectoryButtonBlurayTab.Location = new Point(87, 181);
            outputDirectoryButtonBlurayTab.Name = "outputDirectoryButtonBlurayTab";
            outputDirectoryButtonBlurayTab.Size = new Size(373, 80);
            outputDirectoryButtonBlurayTab.TabIndex = 36;
            outputDirectoryButtonBlurayTab.UseVisualStyleBackColor = true;
            outputDirectoryButtonBlurayTab.Click += btnOutputDir_Click;
            // 
            // lblBDMV
            // 
            lblBDMV.AllowDrop = true;
            lblBDMV.AutoSize = true;
            lblBDMV.Font = new Font("Arial Narrow", 24F);
            lblBDMV.Location = new Point(261, 413);
            lblBDMV.Name = "lblBDMV";
            lblBDMV.Size = new Size(413, 57);
            lblBDMV.TabIndex = 35;
            lblBDMV.Text = "to create BDMV folder";
            // 
            // lblMKV
            // 
            lblMKV.AllowDrop = true;
            lblMKV.AutoSize = true;
            lblMKV.Font = new Font("Arial Narrow", 24F);
            lblMKV.Location = new Point(208, 356);
            lblMKV.Name = "lblMKV";
            lblMKV.Size = new Size(539, 57);
            lblMKV.TabIndex = 34;
            lblMKV.Text = "Click or drag MKV files below";
            // 
            // btnGenerateBlurayBlurayTab
            // 
            btnGenerateBlurayBlurayTab.BackgroundImage = Properties.Resources.bluray;
            btnGenerateBlurayBlurayTab.BackgroundImageLayout = ImageLayout.Stretch;
            btnGenerateBlurayBlurayTab.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerateBlurayBlurayTab.ImageAlign = ContentAlignment.TopRight;
            btnGenerateBlurayBlurayTab.Location = new Point(171, 504);
            btnGenerateBlurayBlurayTab.Name = "btnGenerateBlurayBlurayTab";
            btnGenerateBlurayBlurayTab.Size = new Size(591, 356);
            btnGenerateBlurayBlurayTab.TabIndex = 33;
            btnGenerateBlurayBlurayTab.UseVisualStyleBackColor = true;
            btnGenerateBlurayBlurayTab.Click += btnGenerateBluray_Click;
            // 
            // stepsToConvertTab
            // 
            stepsToConvertTab.Controls.Add(lblVer);
            stepsToConvertTab.Controls.Add(pictureBox3);
            stepsToConvertTab.Controls.Add(lblHowTo);
            stepsToConvertTab.Controls.Add(richTextBox1);
            stepsToConvertTab.Location = new Point(4, 41);
            stepsToConvertTab.Name = "stepsToConvertTab";
            stepsToConvertTab.Padding = new Padding(3);
            stepsToConvertTab.Size = new Size(1270, 1044);
            stepsToConvertTab.TabIndex = 2;
            stepsToConvertTab.Text = "Steps to converting";
            stepsToConvertTab.UseVisualStyleBackColor = true;
            // 
            // lblVer
            // 
            lblVer.AutoSize = true;
            lblVer.BackColor = Color.Transparent;
            lblVer.Font = new Font("Arial Narrow", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblVer.Location = new Point(1129, 174);
            lblVer.Name = "lblVer";
            lblVer.Size = new Size(54, 37);
            lblVer.TabIndex = 47;
            lblVer.Text = "2.4";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.Video2BlurayBG;
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(567, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(627, 202);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 46;
            pictureBox3.TabStop = false;
            // 
            // lblHowTo
            // 
            lblHowTo.AutoSize = true;
            lblHowTo.Font = new Font("Arial Narrow", 28F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHowTo.Location = new Point(173, 300);
            lblHowTo.Name = "lblHowTo";
            lblHowTo.Size = new Size(872, 66);
            lblHowTo.TabIndex = 1;
            lblHowTo.Text = "How to make a blu-ray folder from videos";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.Control;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Arial Narrow", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(173, 403);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(894, 403);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnCopyLogOutput);
            tabPage1.Controls.Add(logOutput);
            tabPage1.Location = new Point(4, 41);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1270, 1044);
            tabPage1.TabIndex = 3;
            tabPage1.Text = "Logs";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnCopyLogOutput
            // 
            btnCopyLogOutput.Location = new Point(21, 941);
            btnCopyLogOutput.Name = "btnCopyLogOutput";
            btnCopyLogOutput.Size = new Size(321, 53);
            btnCopyLogOutput.TabIndex = 2;
            btnCopyLogOutput.Text = "Copy Log Output";
            btnCopyLogOutput.UseVisualStyleBackColor = true;
            btnCopyLogOutput.Click += BtnCopyLogOutputClick;
            // 
            // logOutput
            // 
            logOutput.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logOutput.Location = new Point(21, 22);
            logOutput.Name = "logOutput";
            logOutput.Size = new Size(1224, 888);
            logOutput.TabIndex = 1;
            logOutput.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1277, 1088);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Video2BluRay v2.4";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            ConverterTab.ResumeLayout(false);
            ConverterTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            BlurayTab.ResumeLayout(false);
            BlurayTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            stepsToConvertTab.ResumeLayout(false);
            stepsToConvertTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
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
        private Label lblNewFileName;
        private Label lblFpsValue;
        private Label lblBitrateValue;
        private Label lblCodecValue;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox checkboxMKV;
        private GroupBox groupBox3;
        private CheckBox checkboxAC3;
        private Label lblAudioCodec;
        private ComboBox comboBoxAudioBitrate;
        private Label label4;
        private TabControl tabControl1;
        private TabPage BlurayTab;
        private TabPage ConverterTab;
        private Label lblBDMV;
        private Label lblMKV;
        private Button btnGenerateBlurayBlurayTab;
        private Label lblOutputDirectoryBlurayTab;
        private Button outputDirectoryButtonBlurayTab;
        private Label labelProgressBluray;
        private ProgressBar progressBarBluRayTab;
        private TabPage stepsToConvertTab;
        private RichTextBox richTextBox1;
        private Label lblHowTo;
        private CheckBox checkboxAspectRatio;
        private TabPage tabPage1;
        private RichTextBox logOutput;
        private Button btnCopyLogOutput;
        private Button btnCopyParameters;
        private Label lblCreateBlu;
        private CheckBox checkboxImgBurn;
        private Button btnImgBurnLocation;
        private Label ImgBurnLocationLabel;
        private Label lblWithImgBurn;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label8;
        private Label lblVersionNum;
        private Label lblVer;
        private CheckBox btnAudioOnly;
        private Label label11;
        private PictureBox pictureBox4;
        private Button btnCancelConvert;
        private ComboBox ratioChoice;
    }
}
