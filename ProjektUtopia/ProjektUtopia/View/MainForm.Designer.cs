namespace ProjektUtopia
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.FolderPath_TextBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.RunButton = new System.Windows.Forms.Button();
      this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.BrowseButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.DragNDropPanel = new System.Windows.Forms.Panel();
      this.DragNDropPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // FolderPath_TextBox
      // 
      this.FolderPath_TextBox.Location = new System.Drawing.Point(15, 162);
      this.FolderPath_TextBox.Name = "FolderPath_TextBox";
      this.FolderPath_TextBox.ReadOnly = true;
      this.FolderPath_TextBox.Size = new System.Drawing.Size(504, 20);
      this.FolderPath_TextBox.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 146);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(68, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Selected file:";
      // 
      // RunButton
      // 
      this.RunButton.Location = new System.Drawing.Point(522, 160);
      this.RunButton.Name = "RunButton";
      this.RunButton.Size = new System.Drawing.Size(75, 23);
      this.RunButton.TabIndex = 5;
      this.RunButton.Text = "Run";
      this.RunButton.UseVisualStyleBackColor = true;
      this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
      // 
      // BrowseButton
      // 
      this.BrowseButton.Location = new System.Drawing.Point(248, 64);
      this.BrowseButton.Name = "BrowseButton";
      this.BrowseButton.Size = new System.Drawing.Size(75, 23);
      this.BrowseButton.TabIndex = 1;
      this.BrowseButton.Text = "browse.";
      this.BrowseButton.UseVisualStyleBackColor = true;
      this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(220, 34);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(134, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Drag and drop your files or ";
      // 
      // DragNDropPanel
      // 
      this.DragNDropPanel.AllowDrop = true;
      this.DragNDropPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.DragNDropPanel.AutoSize = true;
      this.DragNDropPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.DragNDropPanel.Controls.Add(this.label1);
      this.DragNDropPanel.Controls.Add(this.BrowseButton);
      this.DragNDropPanel.Location = new System.Drawing.Point(15, 12);
      this.DragNDropPanel.Name = "DragNDropPanel";
      this.DragNDropPanel.Size = new System.Drawing.Size(582, 115);
      this.DragNDropPanel.TabIndex = 4;
      this.DragNDropPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDrop_Event);
      this.DragNDropPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.DragOver_Event);
      // 
      // MainForm
      // 
      this.AllowDrop = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(609, 194);
      this.Controls.Add(this.DragNDropPanel);
      this.Controls.Add(this.RunButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.FolderPath_TextBox);
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(625, 233);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(625, 233);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Projekt Utopia";
      this.DragNDropPanel.ResumeLayout(false);
      this.DragNDropPanel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TextBox FolderPath_TextBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button RunButton;
    private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
    private System.Windows.Forms.Button BrowseButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel DragNDropPanel;
  }
}

