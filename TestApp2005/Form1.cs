using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TestApp2005.pyScripts;

namespace TestApp2005
{
    public partial class Form1 : Form
    {
        List<comparableSentence> globalSentences = new List<comparableSentence>();
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
            Console.WriteLine("Startt");
            pyService pyService = new pyService();
            simplifiedTextBox.Text = "Loading";
            comparableSentence _comparableSentence;
            String[] data = contentBox.Text.Split('.');

            

            for (int i = 0; i < data.Length; i++)
            {
                _comparableSentence = new comparableSentence();
                String text = pyService.fileProcessStart(data[i]);

                _comparableSentence.originString = data[i];
                _comparableSentence.index = i;
                _comparableSentence.comparableString = text;
                globalSentences.Add(_comparableSentence);
                simplifiedTextBox.Text += text;
            }
            
            
            
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
           String answer = "İlk cumledeki ozel isim sayısı: "+globalSentences[0].calculateSentencePoint().ToString();
            MessageBox.Show(answer);
        }

        private void contentBox_TextChanged(object sender, EventArgs e)
        {
            if(contentBox.Text.Length > 0)
            {
                button2.Enabled = true;
            }
        }
    }
}
