using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestApp2005.Services;

namespace TestApp2005.pyScripts
{
    internal class comparableSentence
    {
        public String originString { get; set; }
        public String comparableString { get; set; }
        public int index { get; set; }
        public int point { get; set; }
        

        public comparableSentence(string originString, string comparableString, int index, int point)
        {
            this.originString = originString ?? throw new ArgumentNullException(nameof(originString));
            this.comparableString = comparableString ?? throw new ArgumentNullException(nameof(comparableString));
            this.index = index;
            this.point = point;
        }

        public comparableSentence()
        {

        }


        public void calculateSentencePoint(List<comparableSentence> globalSentences)
        {
            
            this.point += (int)this.findThemeRatio();
            this.point += (int)this.findCommonsInHeader(globalSentences[0].comparableString);
            this.point += (int)this.findProperNames();
            this.point += (int)this.numericCharAmount();
        }

         double findProperNames()
        {
            pyService _pyServ = new pyService();
            int _point = _pyServ.countProperNames(this.originString);

            double stLeng = (double)this.comparableString.Split('\n').Length;
            double scale = (double)_point / stLeng;
            scale = Math.Round(scale, 2);
            scale = scale * 100.0;
            return scale;
        }

         double findCommonsInHeader(String header)
        {
            String[] headerWords = header.Split('\n');
            String[] localWords = this.comparableString.Split('\n');
            var commons = headerWords.Intersect(localWords);
            int commonWord = commons.Count();
            double scale = (double)commonWord / (double)localWords.Length;
            scale = Math.Round(scale, 2);
            scale = scale * 100.0;
            return scale;
        }

         double numericCharAmount()
        {
            int count = 0;
            String[] words = this.comparableString.Split('\n');
            foreach (String word in words)
            {
                if(int.TryParse(word, out int tempint))
                {
                    count++;
                }
                else if(double.TryParse(word, out double tempdouble))
                {
                    count++;
                }
            }
            double scale = (double)count / (double)this.comparableString.Split('\n').Length;
            scale = Math.Round(scale, 2);
            scale = scale * 100.0;
            return scale;
        }

         double findThemeRatio() {
            int _count = 0;
            int value = Form1.totalString.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
            textService _textServ = new textService();
            List<String> themeWords = _textServ.findThemeWordsRatio(Form1.totalString,value);

            string[] localWords = this.originString.Split(new char[] { ' ', '.', ',', '!', '?' ,'\n'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (String oneTheme in themeWords)
            {
                foreach (string localWord in localWords)
                {
                    if(oneTheme == localWord)
                    {
                        _count++;
                    }
                }
            }
            double scale = (double)_count / (double)localWords.Length;
            scale = Math.Round(scale, 2);
            scale = scale * 100.0;
            return scale;
        }

        

        


    }
}
