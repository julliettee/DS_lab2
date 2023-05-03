namespace Lab2._1
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btnPanel = new System.Windows.Forms.Panel();
            this.doActionButton = new MetroFramework.Controls.MetroButton();
            this.chooseFileBtn = new MetroFramework.Controls.MetroButton();
            this.zipChB = new MetroFramework.Controls.MetroCheckBox();
            this.hashChb = new MetroFramework.Controls.MetroCheckBox();
            this.fileLbl = new MetroFramework.Controls.MetroLabel();
            this.filePathLabel = new MetroFramework.Controls.MetroLabel();
            this.progressSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.pngConverterButton = new MetroFramework.Controls.MetroCheckBox();
            this.btnPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPanel
            // 
            this.btnPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPanel.Controls.Add(this.doActionButton);
            this.btnPanel.Controls.Add(this.chooseFileBtn);
            this.btnPanel.Location = new System.Drawing.Point(23, 100);
            this.btnPanel.Name = "btnPanel";
            this.btnPanel.Size = new System.Drawing.Size(674, 55);
            this.btnPanel.TabIndex = 0;
            this.btnPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.btnPanel_Paint);
            // 
            // doActionButton
            // 
            this.doActionButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.doActionButton.Location = new System.Drawing.Point(367, 9);
            this.doActionButton.Name = "doActionButton";
            this.doActionButton.Size = new System.Drawing.Size(108, 34);
            this.doActionButton.TabIndex = 1;
            this.doActionButton.TabStop = false;
            this.doActionButton.Text = "DO!";
            this.doActionButton.UseSelectable = true;
            this.doActionButton.Click += new System.EventHandler(this.doButton_Click);
            // 
            // chooseFileBtn
            // 
            this.chooseFileBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.chooseFileBtn.Location = new System.Drawing.Point(232, 9);
            this.chooseFileBtn.Name = "chooseFileBtn";
            this.chooseFileBtn.Size = new System.Drawing.Size(109, 34);
            this.chooseFileBtn.TabIndex = 0;
            this.chooseFileBtn.Text = "Choose file";
            this.chooseFileBtn.UseSelectable = true;
            this.chooseFileBtn.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // zipChB
            // 
            this.zipChB.AutoSize = true;
            this.zipChB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.zipChB.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.zipChB.Location = new System.Drawing.Point(159, 161);
            this.zipChB.Name = "zipChB";
            this.zipChB.Size = new System.Drawing.Size(123, 19);
            this.zipChB.Style = MetroFramework.MetroColorStyle.Purple;
            this.zipChB.TabIndex = 1;
            this.zipChB.Text = "Save zip Archive";
            this.zipChB.UseSelectable = true;
            this.zipChB.CheckedChanged += new System.EventHandler(this.zipChB_CheckedChanged);
            // 
            // hashChb
            // 
            this.hashChb.AutoSize = true;
            this.hashChb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.hashChb.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.hashChb.Location = new System.Drawing.Point(330, 161);
            this.hashChb.Name = "hashChb";
            this.hashChb.Size = new System.Drawing.Size(86, 19);
            this.hashChb.Style = MetroFramework.MetroColorStyle.Purple;
            this.hashChb.TabIndex = 2;
            this.hashChb.Text = "Save hash";
            this.hashChb.UseSelectable = true;
            this.hashChb.CheckedChanged += new System.EventHandler(this.hashChb_CheckedChanged);
            // 
            // fileLbl
            // 
            this.fileLbl.AutoSize = true;
            this.fileLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.fileLbl.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.fileLbl.Location = new System.Drawing.Point(200, 72);
            this.fileLbl.Name = "fileLbl";
            this.fileLbl.Size = new System.Drawing.Size(46, 25);
            this.fileLbl.TabIndex = 3;
            this.fileLbl.Text = "File:";
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.filePathLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.filePathLabel.Location = new System.Drawing.Point(246, 72);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(36, 25);
            this.filePathLabel.TabIndex = 4;
            this.filePathLabel.Text = "???";
            // 
            // progressSpinner
            // 
            this.progressSpinner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.progressSpinner.Location = new System.Drawing.Point(367, 25);
            this.progressSpinner.Maximum = 100;
            this.progressSpinner.Name = "progressSpinner";
            this.progressSpinner.Size = new System.Drawing.Size(20, 20);
            this.progressSpinner.Speed = 2F;
            this.progressSpinner.Style = MetroFramework.MetroColorStyle.Teal;
            this.progressSpinner.TabIndex = 6;
            this.progressSpinner.TabStop = false;
            this.progressSpinner.UseSelectable = true;
            this.progressSpinner.Value = 70;
            // 
            // pngConverterButton
            // 
            this.pngConverterButton.AutoSize = true;
            this.pngConverterButton.BackColor = System.Drawing.Color.White;
            this.pngConverterButton.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.pngConverterButton.ForeColor = System.Drawing.Color.Coral;
            this.pngConverterButton.Location = new System.Drawing.Point(461, 161);
            this.pngConverterButton.Name = "pngConverterButton";
            this.pngConverterButton.Size = new System.Drawing.Size(123, 19);
            this.pngConverterButton.Style = MetroFramework.MetroColorStyle.Purple;
            this.pngConverterButton.TabIndex = 7;
            this.pngConverterButton.Text = "Convert to PNG";
            this.pngConverterButton.UseCustomBackColor = true;
            this.pngConverterButton.UseSelectable = true;
            this.pngConverterButton.CheckedChanged += new System.EventHandler(this.pngChb_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 323);
            this.Controls.Add(this.pngConverterButton);
            this.Controls.Add(this.progressSpinner);
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.fileLbl);
            this.Controls.Add(this.hashChb);
            this.Controls.Add(this.zipChB);
            this.Controls.Add(this.btnPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(299, 197);
            this.Name = "MainWindow";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "File actions";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.btnPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel btnPanel;
        private MetroFramework.Controls.MetroButton doActionButton;
        private MetroFramework.Controls.MetroButton chooseFileBtn;
        private MetroFramework.Controls.MetroCheckBox zipChB;
        private MetroFramework.Controls.MetroCheckBox hashChb;
        private MetroFramework.Controls.MetroLabel fileLbl;
        private MetroFramework.Controls.MetroLabel filePathLabel;
        private MetroFramework.Controls.MetroProgressSpinner progressSpinner;
        private MetroFramework.Controls.MetroCheckBox pngConverterButton;
    }
}

