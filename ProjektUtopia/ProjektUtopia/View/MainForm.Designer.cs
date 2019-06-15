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
      this.SelectedPath_Label = new System.Windows.Forms.Label();
      this.Run_Button = new System.Windows.Forms.Button();
      this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.Browse_Button = new System.Windows.Forms.Button();
      this.DragNDrop_Label = new System.Windows.Forms.Label();
      this.DragNDrop_Panel = new System.Windows.Forms.Panel();
      this.DragNDrop_Panel.SuspendLayout();
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
      // SelectedPath_Label
      // 
      this.SelectedPath_Label.AutoSize = true;
      this.SelectedPath_Label.Location = new System.Drawing.Point(12, 146);
      this.SelectedPath_Label.Name = "SelectedPath_Label";
      this.SelectedPath_Label.Size = new System.Drawing.Size(68, 13);
      this.SelectedPath_Label.TabIndex = 4;
      this.SelectedPath_Label.Text = "Selected file:";
      // 
      // Run_Button
      // 
      this.Run_Button.Location = new System.Drawing.Point(522, 160);
      this.Run_Button.Name = "Run_Button";
      this.Run_Button.Size = new System.Drawing.Size(75, 23);
      this.Run_Button.TabIndex = 5;
      this.Run_Button.Text = "Run";
      this.Run_Button.UseVisualStyleBackColor = true;
      this.Run_Button.Click += new System.EventHandler(this.RunButton_Click);
      // 
      // Browse_Button
      // 
      this.Browse_Button.Location = new System.Drawing.Point(248, 64);
      this.Browse_Button.Name = "Browse_Button";
      this.Browse_Button.Size = new System.Drawing.Size(75, 23);
      this.Browse_Button.TabIndex = 1;
      this.Browse_Button.Text = "browse";
      this.Browse_Button.UseVisualStyleBackColor = true;
      this.Browse_Button.Click += new System.EventHandler(this.BrowseButton_Click);
      // 
      // DragNDrop_Label
      // 
      this.DragNDrop_Label.AutoSize = true;
      this.DragNDrop_Label.Location = new System.Drawing.Point(220, 34);
      this.DragNDrop_Label.Name = "DragNDrop_Label";
      this.DragNDrop_Label.Size = new System.Drawing.Size(134, 13);
      this.DragNDrop_Label.TabIndex = 3;
      this.DragNDrop_Label.Text = "Drag and drop your files or ";
      // 
      // DragNDrop_Panel
      // 
      this.DragNDrop_Panel.AllowDrop = true;
      this.DragNDrop_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.DragNDrop_Panel.AutoSize = true;
      this.DragNDrop_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.DragNDrop_Panel.Controls.Add(this.DragNDrop_Label);
      this.DragNDrop_Panel.Controls.Add(this.Browse_Button);
      this.DragNDrop_Panel.Location = new System.Drawing.Point(15, 12);
      this.DragNDrop_Panel.Name = "DragNDrop_Panel";
      this.DragNDrop_Panel.Size = new System.Drawing.Size(582, 115);
      this.DragNDrop_Panel.TabIndex = 4;
      this.DragNDrop_Panel.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDrop_Event);
      this.DragNDrop_Panel.DragOver += new System.Windows.Forms.DragEventHandler(this.DragOver_Event);
      // 
      // MainForm
      // 
      this.AllowDrop = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(609, 194);
      this.Controls.Add(this.DragNDrop_Panel);
      this.Controls.Add(this.Run_Button);
      this.Controls.Add(this.SelectedPath_Label);
      this.Controls.Add(this.FolderPath_TextBox);
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(625, 233);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(625, 233);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Projekt Utopia";
      this.DragNDrop_Panel.ResumeLayout(false);
      this.DragNDrop_Panel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TextBox FolderPath_TextBox;
    private System.Windows.Forms.Label SelectedPath_Label;
    private System.Windows.Forms.Button Run_Button;
    private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
    private System.Windows.Forms.Button Browse_Button;
    private System.Windows.Forms.Label DragNDrop_Label;
    private System.Windows.Forms.Panel DragNDrop_Panel;
  }
}

