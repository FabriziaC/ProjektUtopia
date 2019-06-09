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
    public partial class Form1 : Form
    {
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public Form1()
        {
            InitializeComponent();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            //https://www.c-sharpcorner.com/uploadfile/mahesh/openfiledialog-in-C-Sharp/
            openFileDialog1.Title = "Choose any file:";
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dateien verarbeiten: " + textBox1.Text);
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; // get all files droppeds  
            if (files != null && files.Any())
                textBox1.Text = files.First(); //select the first one  
        }

        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
