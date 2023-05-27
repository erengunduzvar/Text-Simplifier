using System;
using System.IO;
using System.Windows.Forms;
using TestApp2005.pyScripts;
using static System.Net.Mime.MediaTypeNames;

namespace TestApp2005
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Dosyası |*.txt";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = openFileDialog1.FileName;
                string dosyaAdi = openFileDialog1.SafeFileName;
                string metin = File.ReadAllText(dosyaYolu);
                pathBox.Text = dosyaYolu;
                contentBox.Text = metin;
                File.WriteAllText("C:\\Users\\eymen\\Masaüstü\\aa\\input.txt", metin);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            progressBar1.Value = (int)numericUpDown1.Value;
            benzerlikLabel.Text = "%"+numericUpDown1.Value.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            progressBar2.Value = (int)numericUpDown2.Value;
            skorLabel.Text = "%" + numericUpDown2.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pyService pyService = new pyService();
            String cleanedText = pyService.fileProcessStart((int)numericUpDown2.Value, (int)numericUpDown1.Value);
        }
    }
}
