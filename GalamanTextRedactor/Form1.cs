using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GalamanTextRedactor
{
    public partial class Form1 : Form
    {
        string FileText { get; set; }
        string FilePart { get; set; }

        public Form1()
        {
            InitializeComponent();
            FilePart = "";
        }

        private void open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            FilePart = openFileDialog1.FileName;
            this.Text = FilePart;
            this.FileText = File.ReadAllText(FilePart, Encoding.Default);
            this.richTextBox1.Text = FileText;
        }

        private void copy_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
                Clipboard.SetDataObject(richTextBox1.SelectedText);
            else
                Clipboard.SetDataObject("");
        }

       
        private void save_Click(object sender, EventArgs e)
        {
            FileText = richTextBox1.Text;
            if(FilePart=="")
            {
                if(saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                FilePart = saveFileDialog1.FileName.ToString()+".txt";
            }
            MessageBox.Show("Сохранено как\n"+FilePart);
            File.WriteAllText(FilePart, FileText);
        }

        private void paste_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();             
            if (iData.GetDataPresent(DataFormats.Text))
            {
               richTextBox1.SelectedText=(String)iData.GetData(DataFormats.Text);
            }
           
        }

        private void cut_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                Clipboard.SetDataObject(richTextBox1.SelectedText);
                richTextBox1.SelectedText = "";
            }
            else            
                Clipboard.SetDataObject("");
             
        }

        private void new_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != FileText)
            {
                DialogResult result = MessageBox.Show("Сохранить изменения в файле?", " ", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) save_Click(sender,e);
            }
            richTextBox1.Text = "";
            FileText = "";
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = FileText;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open_Click(sender, e);
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_Click(sender, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_Click(sender, e);
        }

        private void savaAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilePart = "";
           save_Click(sender, e);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_Click(sender, e);
            this.Close();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copy_Click(sender, e);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paste_Click(sender, e);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cut_Click(sender, e);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        } 

        private void copyToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            copy_Click(sender, e);
        }

        private void cutToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            cut_Click(sender, e);
        }

        private void pasteToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            paste_Click(sender, e);
        }

        private void selectAllToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cancel_Click(sender, e);
        }
    }
}
