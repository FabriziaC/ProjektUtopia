using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektUtopia
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void DragDrop_Event(object sender, DragEventArgs e)
    {
      string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
      if (files != null && files.Any())
        FolderPath_TextBox.Text = files.First(); //select the first one  
    }

    private void DragOver_Event(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
        e.Effect = DragDropEffects.Link;
      else
        e.Effect = DragDropEffects.None;
    }

    private void RunButton_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Dateien verarbeiten: " + FolderPath_TextBox.Text);
    }

    private void BrowseButton_Click(object sender, EventArgs e)
    {
      if (this.FolderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        FolderPath_TextBox.Text = this.FolderBrowserDialog.SelectedPath;
      }
    }
  }
}
