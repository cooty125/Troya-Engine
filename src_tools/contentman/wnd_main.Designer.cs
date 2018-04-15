namespace Troya.Tools
{
    partial class WndMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WndMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.guiContentDir = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowseSHA = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseXNB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.guiToolsSHA = new System.Windows.Forms.TextBox();
            this.guiToolsXNB = new System.Windows.Forms.TextBox();
            this.btnItemAdd = new System.Windows.Forms.Button();
            this.btnItemRemove = new System.Windows.Forms.Button();
            this.guiGrid = new System.Windows.Forms.DataGridView();
            this.guiMainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.guiMenuFile = new System.Windows.Forms.MenuItem();
            this.guiMenuOpen = new System.Windows.Forms.MenuItem();
            this.guiMenuSave = new System.Windows.Forms.MenuItem();
            this.guiMenuSaveAs = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.guiMenuExit = new System.Windows.Forms.MenuItem();
            this.guiMenuOptions = new System.Windows.Forms.MenuItem();
            this.guiMenuBuild = new System.Windows.Forms.MenuItem();
            this.guiColumnBuild = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.guiColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guiColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guiColumnProfile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guiGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.guiContentDir);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Content Directory";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(305, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(37, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // guiContentDir
            // 
            this.guiContentDir.Location = new System.Drawing.Point(8, 21);
            this.guiContentDir.Name = "guiContentDir";
            this.guiContentDir.ReadOnly = true;
            this.guiContentDir.Size = new System.Drawing.Size(291, 22);
            this.guiContentDir.TabIndex = 1;
            this.guiContentDir.Text = ".\\content";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowseSHA);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnBrowseXNB);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.guiToolsSHA);
            this.groupBox2.Controls.Add(this.guiToolsXNB);
            this.groupBox2.Location = new System.Drawing.Point(12, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 107);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tools";
            // 
            // btnBrowseSHA
            // 
            this.btnBrowseSHA.Location = new System.Drawing.Point(305, 73);
            this.btnBrowseSHA.Name = "btnBrowseSHA";
            this.btnBrowseSHA.Size = new System.Drawing.Size(37, 23);
            this.btnBrowseSHA.TabIndex = 6;
            this.btnBrowseSHA.Text = "...";
            this.btnBrowseSHA.UseVisualStyleBackColor = true;
            this.btnBrowseSHA.Click += new System.EventHandler(this.btnBrowseSHA_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "SHA:";
            // 
            // btnBrowseXNB
            // 
            this.btnBrowseXNB.Location = new System.Drawing.Point(305, 31);
            this.btnBrowseXNB.Name = "btnBrowseXNB";
            this.btnBrowseXNB.Size = new System.Drawing.Size(37, 23);
            this.btnBrowseXNB.TabIndex = 3;
            this.btnBrowseXNB.Text = "...";
            this.btnBrowseXNB.UseVisualStyleBackColor = true;
            this.btnBrowseXNB.Click += new System.EventHandler(this.btnBrowseXNB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "XNB:";
            // 
            // guiToolsSHA
            // 
            this.guiToolsSHA.Location = new System.Drawing.Point(9, 74);
            this.guiToolsSHA.Name = "guiToolsSHA";
            this.guiToolsSHA.ReadOnly = true;
            this.guiToolsSHA.Size = new System.Drawing.Size(291, 22);
            this.guiToolsSHA.TabIndex = 3;
            // 
            // guiToolsXNB
            // 
            this.guiToolsXNB.Location = new System.Drawing.Point(9, 32);
            this.guiToolsXNB.Name = "guiToolsXNB";
            this.guiToolsXNB.ReadOnly = true;
            this.guiToolsXNB.Size = new System.Drawing.Size(291, 22);
            this.guiToolsXNB.TabIndex = 2;
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Location = new System.Drawing.Point(12, 507);
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.Size = new System.Drawing.Size(64, 23);
            this.btnItemAdd.TabIndex = 3;
            this.btnItemAdd.Text = "Add";
            this.btnItemAdd.UseVisualStyleBackColor = true;
            this.btnItemAdd.Click += new System.EventHandler(this.btnItemAdd_Click);
            // 
            // btnItemRemove
            // 
            this.btnItemRemove.Location = new System.Drawing.Point(82, 507);
            this.btnItemRemove.Name = "btnItemRemove";
            this.btnItemRemove.Size = new System.Drawing.Size(64, 23);
            this.btnItemRemove.TabIndex = 4;
            this.btnItemRemove.Text = "Remove";
            this.btnItemRemove.UseVisualStyleBackColor = true;
            this.btnItemRemove.Click += new System.EventHandler(this.btnItemRemove_Click);
            // 
            // guiGrid
            // 
            this.guiGrid.AllowUserToAddRows = false;
            this.guiGrid.AllowUserToDeleteRows = false;
            this.guiGrid.AllowUserToResizeColumns = false;
            this.guiGrid.AllowUserToResizeRows = false;
            this.guiGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.guiGrid.ColumnHeadersHeight = 25;
            this.guiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.guiGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.guiColumnBuild,
            this.guiColumnType,
            this.guiColumnName,
            this.guiColumnProfile});
            this.guiGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.guiGrid.Location = new System.Drawing.Point(12, 185);
            this.guiGrid.MultiSelect = false;
            this.guiGrid.Name = "guiGrid";
            this.guiGrid.RowHeadersVisible = false;
            this.guiGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.guiGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.guiGrid.ShowCellErrors = false;
            this.guiGrid.ShowCellToolTips = false;
            this.guiGrid.ShowEditingIcon = false;
            this.guiGrid.ShowRowErrors = false;
            this.guiGrid.Size = new System.Drawing.Size(350, 316);
            this.guiGrid.TabIndex = 6;
            this.guiGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.guiGrid_CellMouseDoubleClick);
            // 
            // guiMainMenu
            // 
            this.guiMainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.guiMenuFile,
            this.guiMenuOptions});
            // 
            // guiMenuFile
            // 
            this.guiMenuFile.Index = 0;
            this.guiMenuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.guiMenuOpen,
            this.guiMenuSave,
            this.guiMenuSaveAs,
            this.menuItem3,
            this.guiMenuExit});
            this.guiMenuFile.Text = "&File";
            // 
            // guiMenuOpen
            // 
            this.guiMenuOpen.Index = 0;
            this.guiMenuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.guiMenuOpen.Text = "Open...";
            this.guiMenuOpen.Click += new System.EventHandler(this.guiMenuOpen_Click);
            // 
            // guiMenuSave
            // 
            this.guiMenuSave.Enabled = false;
            this.guiMenuSave.Index = 1;
            this.guiMenuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.guiMenuSave.Text = "Save";
            this.guiMenuSave.Click += new System.EventHandler(this.guiMenuSave_Click);
            // 
            // guiMenuSaveAs
            // 
            this.guiMenuSaveAs.Index = 2;
            this.guiMenuSaveAs.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
            this.guiMenuSaveAs.Text = "Save As...";
            this.guiMenuSaveAs.Click += new System.EventHandler(this.guiMenuSaveAs_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.Text = "-";
            // 
            // guiMenuExit
            // 
            this.guiMenuExit.Index = 4;
            this.guiMenuExit.Text = "Exit";
            this.guiMenuExit.Click += new System.EventHandler(this.guiMenuExit_Click);
            // 
            // guiMenuOptions
            // 
            this.guiMenuOptions.Index = 1;
            this.guiMenuOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.guiMenuBuild});
            this.guiMenuOptions.Text = "&Options";
            // 
            // guiMenuBuild
            // 
            this.guiMenuBuild.Enabled = false;
            this.guiMenuBuild.Index = 0;
            this.guiMenuBuild.Shortcut = System.Windows.Forms.Shortcut.CtrlB;
            this.guiMenuBuild.Text = "Build...";
            this.guiMenuBuild.Click += new System.EventHandler(this.guiMenuBuild_Click);
            // 
            // guiColumnBuild
            // 
            this.guiColumnBuild.FillWeight = 50F;
            this.guiColumnBuild.HeaderText = "Build";
            this.guiColumnBuild.Name = "guiColumnBuild";
            this.guiColumnBuild.ReadOnly = true;
            this.guiColumnBuild.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.guiColumnBuild.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.guiColumnBuild.Width = 50;
            // 
            // guiColumnType
            // 
            this.guiColumnType.HeaderText = "Type";
            this.guiColumnType.Name = "guiColumnType";
            this.guiColumnType.ReadOnly = true;
            this.guiColumnType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // guiColumnName
            // 
            this.guiColumnName.FillWeight = 135F;
            this.guiColumnName.HeaderText = "Name";
            this.guiColumnName.Name = "guiColumnName";
            this.guiColumnName.ReadOnly = true;
            this.guiColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.guiColumnName.Width = 135;
            // 
            // guiColumnProfile
            // 
            this.guiColumnProfile.FillWeight = 60F;
            this.guiColumnProfile.HeaderText = "Profile";
            this.guiColumnProfile.Name = "guiColumnProfile";
            this.guiColumnProfile.ReadOnly = true;
            this.guiColumnProfile.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.guiColumnProfile.Width = 60;
            // 
            // WndMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 542);
            this.Controls.Add(this.guiGrid);
            this.Controls.Add(this.btnItemRemove);
            this.Controls.Add(this.btnItemAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.guiMainMenu;
            this.Name = "WndMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Troya Engine - Content Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WndMain_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guiGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox guiContentDir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox guiToolsSHA;
        private System.Windows.Forms.TextBox guiToolsXNB;
        private System.Windows.Forms.Button btnBrowseSHA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseXNB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnItemAdd;
        private System.Windows.Forms.Button btnItemRemove;
        private System.Windows.Forms.DataGridView guiGrid;
        private System.Windows.Forms.MainMenu guiMainMenu;
        private System.Windows.Forms.MenuItem guiMenuFile;
        private System.Windows.Forms.MenuItem guiMenuOpen;
        private System.Windows.Forms.MenuItem guiMenuSaveAs;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem guiMenuExit;
        private System.Windows.Forms.MenuItem guiMenuOptions;
        private System.Windows.Forms.MenuItem guiMenuBuild;
        private System.Windows.Forms.MenuItem guiMenuSave;
        private System.Windows.Forms.DataGridViewCheckBoxColumn guiColumnBuild;
        private System.Windows.Forms.DataGridViewTextBoxColumn guiColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn guiColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn guiColumnProfile;
    }
}

