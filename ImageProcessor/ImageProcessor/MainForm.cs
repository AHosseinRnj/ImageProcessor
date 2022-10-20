using System;
using System.Windows.Forms;
using System.Drawing;
using ImageProcessor.Classes;

namespace ImageProcessor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        Bitmap inputImage;
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Open Image";
                fileDialog.Filter = "Image Files(*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                    inputImage = new Bitmap(fileDialog.FileName);
            }

            basePictureBox.Image = inputImage;
        }

        Bitmap outputImage;
        private void toGrayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputImage == null)
            {
                MessageBox.Show("Input image was Null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            outputImage = Operations.ToGrayScale(inputImage);
            finalPictureBox.Image = outputImage;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (outputImage == null)
            {
                MessageBox.Show("Output image was Null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var fileDialog = new SaveFileDialog())
            {
                fileDialog.Title = "Save Image";
                fileDialog.FileName = "Result";
                fileDialog.Filter = "Bitmap (*.bmp)|*.bmp";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                    outputImage.Save(fileDialog.FileName);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputImage = null;
            outputImage = null;
            basePictureBox.Image = null;
            finalPictureBox.Image = null;
        }
    }
}