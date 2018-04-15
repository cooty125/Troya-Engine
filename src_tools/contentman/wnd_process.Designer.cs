namespace Troya.Tools
{
    partial class WndProcess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( ) {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndProcess));
            this.guiProgress = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.guiOutput = new System.Windows.Forms.ListBox();
            this.guiAutoClose = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // guiProgress
            // 
            this.guiProgress.Location = new System.Drawing.Point(12, 163);
            this.guiProgress.Name = "guiProgress";
            this.guiProgress.Size = new System.Drawing.Size(526, 21);
            this.guiProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.guiProgress.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(463, 193);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // guiOutput
            // 
            this.guiOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guiOutput.FormattingEnabled = true;
            this.guiOutput.ItemHeight = 14;
            this.guiOutput.Location = new System.Drawing.Point(12, 14);
            this.guiOutput.Name = "guiOutput";
            this.guiOutput.Size = new System.Drawing.Size(526, 142);
            this.guiOutput.TabIndex = 4;
            // 
            // guiAutoClose
            // 
            this.guiAutoClose.AutoSize = true;
            this.guiAutoClose.Location = new System.Drawing.Point(12, 198);
            this.guiAutoClose.Name = "guiAutoClose";
            this.guiAutoClose.Size = new System.Drawing.Size(86, 18);
            this.guiAutoClose.TabIndex = 5;
            this.guiAutoClose.Text = "Auto close.";
            this.guiAutoClose.UseVisualStyleBackColor = true;
            // 
            // WndProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(550, 228);
            this.Controls.Add(this.guiAutoClose);
            this.Controls.Add(this.guiOutput);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.guiProgress);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WndProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Build";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar guiProgress;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox guiOutput;
        private System.Windows.Forms.CheckBox guiAutoClose;
    }
}