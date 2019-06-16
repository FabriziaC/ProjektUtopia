using System;
using System.Linq;
using System.Windows.Forms;
using static ProjektUtopia.FileManager;
using static ProjektUtopia.Codemetrik;

namespace ProjektUtopia
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void BrowseButton_Click(object sender, EventArgs e) => SelectAndSetPathForTextBox(this.FolderPath_TextBox, this.SelectedFile_FolderBrowserDialog);

    private void FileLocation_Button_Click(object sender, EventArgs e) => SelectAndSetPathForTextBox(this.fileLocation_TextBox, this.FileLocation_FolderBrowserDialog);

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
      string path = this.FolderPath_TextBox.Text;
      string[] pathList;

      if (FileExist(path))
      {
        pathList = new string[1];
        pathList[0] = path;
      }
      else if (DirectoryExist(path))
      {
        pathList = GetAllFilesOfFolder(this.FolderPath_TextBox.Text);
      }
      else
      {
        MessageBox.Show(String.Format("'{0}' ist kein gültiger Phad",
                                      FolderPath_TextBox.Text));
        return;
      }
      Run(pathList);

    }

    private void SelectAndSetPathForTextBox(TextBox textBox, FolderBrowserDialog foderBrowserDialog)
    {
      if (foderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        textBox.Text = foderBrowserDialog.SelectedPath;
      }
    }
  }
}
