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
            label1 = new Label();
            lblFpsValue = new Label();
            lblBitrateValue = new Label();
            lblCodecValue = new Label();
            groupBox1 = new GroupBox();
            lblAudioCodec = new Label();
            tabControl1 = new TabControl();
            ConverterTab = new TabPage();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            groupBox3 = new GroupBox();
            checkboxUpscale = new CheckBox();
            label4 = new Label();
            checkboxAC3 = new CheckBox();
            comboBoxAudioBitrate = new ComboBox();
            checkboxMKV = new CheckBox();
            groupBox2 = new GroupBox();
            BlurayTab = new TabPage();
            pictureBox2 = new PictureBox();
            label7 = new Label();
            ImgBurnLocationLabel = new Label();
            btnImgBurnLocation = new Button();
            checkboxImgBurn = new CheckBox();
            label6 = new Label();
            labelProgressBluray = new Label();
            progressBarBluRayTab = new ProgressBar();
            lblOutputDirectoryBlurayTab = new Label();
            outputDirectoryButtonBlurayTab = new Button();
            label3 = new Label();
            label2 = new Label();
            btnGenerateBlurayBlurayTab = new Button();
            stepsToConvertTab = new TabPage();
            pictureBox3 = new PictureBox();
            label5 = new Label();
            richTextBox1 = new RichTextBox();
            tabPage1 = new TabPage();
            button1 = new Button();
            logOutput = new RichTextBox();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            ConverterTab.SuspendLayout();
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
            btnSelectVid.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelectVid.Location = new Point(67, 37);
            btnSelectVid.Name = "btnSelectVid";
            btnSelectVid.Size = new Size(373, 53);
            btnSelectVid.TabIndex = 0;
            btnSelectVid.Text = "Select Video";
            btnSelectVid.UseVisualStyleBackColor = true;
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
            comboBoxFrameRate.Items.AddRange(new object[] { "Same as source", "23.976", "24", "25", "29.97", "50", "59.94" });
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
            btnConvert.Location = new Point(462, 638);
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
            lblOutputDir.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOutputDir.Location = new Point(67, 729);
            lblOutputDir.Name = "lblOutputDir";
            lblOutputDir.Size = new Size(0, 28);
            lblOutputDir.TabIndex = 13;
            // 
            // btnOutputDir
            // 
            btnOutputDir.Font = new Font("Arial Narrow", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOutputDir.Location = new Point(67, 638);
            btnOutputDir.Name = "btnOutputDir";
            btnOutputDir.Size = new Size(373, 80);
            btnOutputDir.TabIndex = 7;
            btnOutputDir.Text = "Select Output Directory";
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
            txtFileName.Location = new Point(667, 575);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(226, 35);
            txtFileName.TabIndex = 6;
            txtFileName.TextChanged += txtFileName_TextChanged;
            // 
            // btnConcat
            // 
            btnConcat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConcat.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConcat.Location = new Point(67, 128);
            btnConcat.Name = "btnConcat";
            btnConcat.Size = new Size(373, 53);
            btnConcat.TabIndex = 1;
            btnConcat.Text = "Join Multiple Videos";
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
            btnRun.Enabled = false;
            btnRun.Font = new Font("Arial Narrow", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRun.Location = new Point(823, 638);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(371, 80);
            btnRun.TabIndex = 10;
            btnRun.Text = "Convert Video (ffmpeg)";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(515, 578);
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
            ConverterTab.Controls.Add(pictureBox1);
            ConverterTab.Controls.Add(button2);
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
            ConverterTab.Controls.Add(label1);
            ConverterTab.Location = new Point(4, 41);
            ConverterTab.Margin = new Padding(0);
            ConverterTab.Name = "ConverterTab";
            ConverterTab.Size = new Size(1270, 1044);
            ConverterTab.TabIndex = 1;
            ConverterTab.Text = "Convert";
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
            // button2
            // 
            button2.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(1017, 850);
            button2.Name = "button2";
            button2.Size = new Size(177, 80);
            button2.TabIndex = 34;
            button2.Text = "Copy Parameters";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkboxUpscale);
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
            // checkboxUpscale
            // 
            checkboxUpscale.AutoSize = true;
            checkboxUpscale.Location = new Point(19, 156);
            checkboxUpscale.Name = "checkboxUpscale";
            checkboxUpscale.Size = new Size(191, 33);
            checkboxUpscale.TabIndex = 9;
            checkboxUpscale.Text = "Upscale to 1080p";
            checkboxUpscale.UseVisualStyleBackColor = true;
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
            checkboxMKV.Location = new Point(78, 569);
            checkboxMKV.Name = "checkboxMKV";
            checkboxMKV.Size = new Size(362, 41);
            checkboxMKV.TabIndex = 27;
            checkboxMKV.Text = "Blu-Ray Compliant (MKV)";
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
            BlurayTab.Controls.Add(pictureBox2);
            BlurayTab.Controls.Add(label7);
            BlurayTab.Controls.Add(ImgBurnLocationLabel);
            BlurayTab.Controls.Add(btnImgBurnLocation);
            BlurayTab.Controls.Add(checkboxImgBurn);
            BlurayTab.Controls.Add(label6);
            BlurayTab.Controls.Add(labelProgressBluray);
            BlurayTab.Controls.Add(progressBarBluRayTab);
            BlurayTab.Controls.Add(lblOutputDirectoryBlurayTab);
            BlurayTab.Controls.Add(outputDirectoryButtonBlurayTab);
            BlurayTab.Controls.Add(label3);
            BlurayTab.Controls.Add(label2);
            BlurayTab.Controls.Add(btnGenerateBlurayBlurayTab);
            BlurayTab.Location = new Point(4, 41);
            BlurayTab.Name = "BlurayTab";
            BlurayTab.Padding = new Padding(3);
            BlurayTab.Size = new Size(1270, 1044);
            BlurayTab.TabIndex = 0;
            BlurayTab.Text = "Create Blu-ray";
            BlurayTab.Click += BlurayTab_Click;
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
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Narrow", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(904, 863);
            label7.Name = "label7";
            label7.Size = new Size(148, 33);
            label7.TabIndex = 44;
            label7.Text = "with ImgBurn";
            // 
            // ImgBurnLocationLabel
            // 
            ImgBurnLocationLabel.AutoSize = true;
            ImgBurnLocationLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ImgBurnLocationLabel.Location = new Point(30, 95);
            ImgBurnLocationLabel.Name = "ImgBurnLocationLabel";
            ImgBurnLocationLabel.Size = new Size(0, 28);
            ImgBurnLocationLabel.TabIndex = 43;
            // 
            // btnImgBurnLocation
            // 
            btnImgBurnLocation.Font = new Font("Arial Narrow", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImgBurnLocation.Location = new Point(87, 15);
            btnImgBurnLocation.Name = "btnImgBurnLocation";
            btnImgBurnLocation.Size = new Size(354, 80);
            btnImgBurnLocation.TabIndex = 42;
            btnImgBurnLocation.Text = "Set ImgBurn Location";
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Narrow", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(222, 874);
            label6.Name = "label6";
            label6.Size = new Size(502, 42);
            label6.TabIndex = 40;
            label6.Text = "Drag all files at once to create blu-ray";
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
            lblOutputDirectoryBlurayTab.Location = new Point(84, 261);
            lblOutputDirectoryBlurayTab.Name = "lblOutputDirectoryBlurayTab";
            lblOutputDirectoryBlurayTab.Size = new Size(0, 28);
            lblOutputDirectoryBlurayTab.TabIndex = 37;
            // 
            // outputDirectoryButtonBlurayTab
            // 
            outputDirectoryButtonBlurayTab.Font = new Font("Arial Narrow", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            outputDirectoryButtonBlurayTab.Location = new Point(87, 181);
            outputDirectoryButtonBlurayTab.Name = "outputDirectoryButtonBlurayTab";
            outputDirectoryButtonBlurayTab.Size = new Size(373, 80);
            outputDirectoryButtonBlurayTab.TabIndex = 36;
            outputDirectoryButtonBlurayTab.Text = "Choose Output Directory";
            outputDirectoryButtonBlurayTab.UseVisualStyleBackColor = true;
            outputDirectoryButtonBlurayTab.Click += btnOutputDir_Click;
            // 
            // label3
            // 
            label3.AllowDrop = true;
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 24F);
            label3.Location = new Point(261, 413);
            label3.Name = "label3";
            label3.Size = new Size(413, 57);
            label3.TabIndex = 35;
            label3.Text = "to create BDMV folder";
            // 
            // label2
            // 
            label2.AllowDrop = true;
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 24F);
            label2.Location = new Point(208, 356);
            label2.Name = "label2";
            label2.Size = new Size(539, 57);
            label2.TabIndex = 34;
            label2.Text = "Click or drag MKV files below";
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
            stepsToConvertTab.Controls.Add(pictureBox3);
            stepsToConvertTab.Controls.Add(label5);
            stepsToConvertTab.Controls.Add(richTextBox1);
            stepsToConvertTab.Location = new Point(4, 41);
            stepsToConvertTab.Name = "stepsToConvertTab";
            stepsToConvertTab.Padding = new Padding(3);
            stepsToConvertTab.Size = new Size(1270, 1044);
            stepsToConvertTab.TabIndex = 2;
            stepsToConvertTab.Text = "Steps to converting";
            stepsToConvertTab.UseVisualStyleBackColor = true;
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Narrow", 28F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(173, 300);
            label5.Name = "label5";
            label5.Size = new Size(872, 66);
            label5.TabIndex = 1;
            label5.Text = "How to make a blu-ray folder from videos";
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
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(logOutput);
            tabPage1.Location = new Point(4, 41);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1270, 1044);
            tabPage1.TabIndex = 3;
            tabPage1.Text = "Logs";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(21, 941);
            button1.Name = "button1";
            button1.Size = new Size(321, 53);
            button1.TabIndex = 2;
            button1.Text = "Copy Log Output";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            Text = "Video2BluRay v1.9";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            ConverterTab.ResumeLayout(false);
            ConverterTab.PerformLayout();
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
        private Label label1;
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
        private Label label3;
        private Label label2;
        private Button btnGenerateBlurayBlurayTab;
        private Label lblOutputDirectoryBlurayTab;
        private Button outputDirectoryButtonBlurayTab;
        private Label labelProgressBluray;
        private ProgressBar progressBarBluRayTab;
        private TabPage stepsToConvertTab;
        private RichTextBox richTextBox1;
        private Label label5;
        private CheckBox checkboxUpscale;
        private TabPage tabPage1;
        private RichTextBox logOutput;
        private Button button1;
        private Button button2;
        private Label label6;
        private CheckBox checkboxImgBurn;
        private Button btnImgBurnLocation;
        private Label ImgBurnLocationLabel;
        private Label label7;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}
