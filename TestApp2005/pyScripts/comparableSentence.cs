using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public int calculateSentencePoint()
        {
            pyService _pyServ = new pyService();
            this.point = _pyServ.countProperNames(this.originString);
            return this.point;
        }
    }
}
