namespace Troya.Tools
{
    partial class WndBuild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndBuild));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.guiFonts = new System.Windows.Forms.CheckBox();
            this.guiModels = new System.Windows.Forms.CheckBox();
            this.guiTextures = new System.Windows.Forms.CheckBox();
            this.guiShaders = new System.Windows.Forms.CheckBox();
            this.guiSounds = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(94, 164);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 164);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Build";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // guiFonts
            // 
            this.guiFonts.AutoSize = true;
            this.guiFonts.Checked = true;
            this.guiFonts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.guiFonts.Location = new System.Drawing.Point(12, 12);
            this.guiFonts.Name = "guiFonts";
            this.guiFonts.Size = new System.Drawing.Size(56, 18);
            this.guiFonts.TabIndex = 2;
            this.guiFonts.Text = "Fonts";
            this.guiFonts.UseVisualStyleBackColor = true;
            // 
            // guiModels
            // 
            this.guiModels.AutoSize = true;
            this.guiModels.Checked = true;
            this.guiModels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.guiModels.Location = new System.Drawing.Point(12, 36);
            this.guiModels.Name = "guiModels";
            this.guiModels.Size = new System.Drawing.Size(67, 18);
            this.guiModels.TabIndex = 3;
            this.guiModels.Text = "Models";
            this.guiModels.UseVisualStyleBackColor = true;
            // 
            // guiTextures
            // 
            this.guiTextures.AutoSize = true;
            this.guiTextures.Checked = true;
            this.guiTextures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.guiTextures.Location = new System.Drawing.Point(12, 60);
            this.guiTextures.Name = "guiTextures";
            this.guiTextures.Size = new System.Drawing.Size(71, 18);
            this.guiTextures.TabIndex = 4;
            this.guiTextures.Text = "Textures";
            this.guiTextures.UseVisualStyleBackColor = true;
            // 
            // guiShaders
            // 
            this.guiShaders.AutoSize = true;
            this.guiShaders.Checked = true;
            this.guiShaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.guiShaders.Location = new System.Drawing.Point(12, 84);
            this.guiShaders.Name = "guiShaders";
            this.guiShaders.Size = new System.Drawing.Size(70, 18);
            this.guiShaders.TabIndex = 5;
            this.guiShaders.Text = "Shaders";
            this.guiShaders.UseVisualStyleBackColor = true;
            // 
            // guiSounds
            // 
            this.guiSounds.AutoSize = true;
            this.guiSounds.Checked = true;
            this.guiSounds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.guiSounds.Location = new System.Drawing.Point(12, 108);
            this.guiSounds.Name = "guiSounds";
            this.guiSounds.Size = new System.Drawing.Size(66, 18);
            this.guiSounds.TabIndex = 6;
            this.guiSounds.Text = "Sounds";
            this.guiSounds.UseVisualStyleBackColor = true;
            // 
            // WndBuild
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(181, 199);
            this.Controls.Add(this.guiSounds);
            this.Controls.Add(this.guiShaders);
            this.Controls.Add(this.guiTextures);
            this.Controls.Add(this.guiModels);
            this.Controls.Add(this.guiFonts);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WndBuild";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Build Content Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WndBuild_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox guiFonts;
        private System.Windows.Forms.CheckBox guiModels;
        private System.Windows.Forms.CheckBox guiTextures;
        private System.Windows.Forms.CheckBox guiShaders;
        private System.Windows.Forms.CheckBox guiSounds;
    }
}