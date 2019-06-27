using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 成绩管理系统.Model
{
    class Score
    {
        public string sCode { set; get; }
        public string name { set; get; }
        public string kemu { set; get; }
        public string score { set; get; }

        public Score()
        {
        }

        public Score(string sCode)
        {
            this.sCode = sCode;
        }

        public Score(string name, string kemu, string score)
        {
            this.name = name;
            this.kemu = kemu;
            this.score = score;
        }

        public Score(string sCode, string name, string kemu, string score)
        {
            this.sCode = sCode;
            this.name = name;
            this.kemu = kemu;
            this.score = score;
        }
    }
}
