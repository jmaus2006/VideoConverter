namespace VideoConverter
{
    partial class FileOrderDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            listBoxFiles = new ListBox();
            btnUp = new Button();
            btnDown = new Button();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // listBoxFiles
            // 
            listBoxFiles.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxFiles.FormattingEnabled = true;
            listBoxFiles.Location = new Point(12, 12);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.Size = new Size(471, 244);
            listBoxFiles.TabIndex = 0;
            // 
            // btnUp
            // 
            btnUp.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUp.Location = new Point(499, 12);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(139, 40);
            btnUp.TabIndex = 1;
            btnUp.Text = "Move Up";
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUp_Click;
            // 
            // btnDown
            // 
            btnDown.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDown.Location = new Point(499, 58);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(139, 40);
            btnDown.TabIndex = 2;
            btnDown.Text = "Move Down";
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOK.Location = new Point(499, 218);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(139, 40);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Arial Narrow", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(499, 172);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(139, 40);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // FileOrderDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 298);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(btnDown);
            Controls.Add(btnUp);
            Controls.Add(listBoxFiles);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FileOrderDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Order Blu-ray Files";
            ResumeLayout(false);
        }
    }
}
