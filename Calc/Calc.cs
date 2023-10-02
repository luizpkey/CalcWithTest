using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCalc
{
    public class Calc
    {
        private const int MaxHistoryLenght = 3;
        private string DateHist = "";
        private List<String> StringHist = new List<String>();
        public Calc(string date)
        {
            DateHist = date;
        }

        public int Sum(int x, int y)
        {
            int res = x + y;
            AddHistory(x, y, res, "+" );   
            return res;
        }
        public int Subtract(int x, int y)
        {
            int res = x - y;
            AddHistory(x, y, res, "-");
            return res;
        }
        public int Divide(int x, int y)
        {
            if (y == 0) 
            {
                throw new DivideByZeroException();
            } ;
            int res = x / y;
            AddHistory(x, y, res, "/");
            return res;
        }
        public int Multiply(int x, int y)
        {
            int res = x * y;
            AddHistory(x, y, res, "*");
            return res;
        }
        public List<string> GetHistory()
        {
            return StringHist;
        }

        public void AddHistory(int x, int y, int res, string operation )
        {
            StringHist.Insert(0, $"In {DateHist} => {x} {operation} {y} = {res}");
            if ( StringHist.Count > MaxHistoryLenght ) 
            {
                StringHist.RemoveAt(StringHist.Count-1);
            }
        }
    }
}
