using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Menus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            if (txtBox1.SelectedText != "")
            {
                txtBox1.Cut();
            }
        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {
            if (txtBox1.CanUndo == true)
            {
                txtBox1.Undo();
                txtBox1.ClearUndo();
            }
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            if (txtBox1.SelectionLength > 0)
            {
                txtBox1.Copy();
            }
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject() .GetDataPresent(DataFormats.Text) == true)
            {
                txtBox2.Paste();
                Clipboard.Clear();
            }
        }

        private void mnuViewTextBoxes_Click(object sender, EventArgs e)
        {
            mnuViewTextBoxes.Checked = !mnuViewTextBoxes.Checked;

            if (mnuViewTextBoxes.Checked)
            {
                txtBox1.Visible = true;
                txtBox2.Visible = true;
            }
            else
            {
                txtBox1.Visible = false;
                txtBox2.Visible = false;
            }
        }

        private void mnuViewImages_Click(object sender, EventArgs e)
        {
            string Chosen_File = "";

            openFD.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFD.Title = "Insert an Image";
            openFD.FileName = "";
            openFD.Filter = "JPEG Images|*.jpg|GIF Images|*.gif|BITMAPS|*.bmp|PNG Images|*.png";
            openFD.ShowDialog();

            if (openFD.ShowDialog() != DialogResult.Cancel)
            {
                Chosen_File = openFD.FileName;
                pictureBox1.Image = Image.FromFile(Chosen_File);
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            string Chosen_File = "";

            openFD.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFD.Title = "Open a Text File";
            openFD.FileName = "";
            openFD.Filter = "Text Files|*.txt|Word Documents|*.doc";

            if (openFD.ShowDialog() != DialogResult.Cancel)
            {
                Chosen_File = openFD.FileName;
                richTextBox1.LoadFile(Chosen_File, RichTextBoxStreamType.PlainText);
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            string Saved_File = "";

            saveFD.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFD.Title = "Save a Text File";
            saveFD.FileName = "";

            saveFD.Filter = "Text Files|*.txt|All Files|*.*";

            if (saveFD.ShowDialog() != DialogResult.Cancel)
            {
                Saved_File = saveFD.FileName;
                richTextBox1.SaveFile(Saved_File, RichTextBoxStreamType.PlainText);
            }
        }
    }
}
